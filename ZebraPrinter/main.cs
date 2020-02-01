using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZebraPrinter.BLL;
using ZebraPrinter.Entity;
using ZebraPrinter.Utils;

namespace ZebraPrinter
{
  public partial class main : Form
  {
    private static List<PatientFullEntity> listPatient;
    private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private static string dataPath = Path.Combine(currentDirectory, "patients.json");
    private static string oldDataPath = Path.Combine(currentDirectory, "oldpatients.json");

    private PatientPrintBLL printBLL;
    private PatientBLL patientBLL;

    private string Sort = "Id";
    private string Order = "DESC";

    public main()
    {
      InitializeComponent();

      printBLL = new PatientPrintBLL();
      patientBLL = new PatientBLL(printBLL);
    }

    private void Patients_Load(object sender, EventArgs e)
    {
      //listPatient = new List<OldPatientEntity>();
      //if (File.Exists(dataPath))
      //{
      //  string jsonFile = File.ReadAllText(dataPath);

      //  if (!string.IsNullOrEmpty(jsonFile))
      //  {
      //    listPatient = JsonConvert.DeserializeObject<List<OldPatientEntity>>(jsonFile).FindAll(p => p.InsertedOn > DateTime.Now.AddMonths(-1));
      //  }

      //}
      BackupData();
      ResetSearch();
      RefreshData();
      BindData();
    }

    #region GridView Events
    private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1 || e.ColumnIndex == -1)
      {
        return;
      }

      if (e.ColumnIndex > 5)
      {
        int id = ConvertHelper.ConvertToInt(this.dgvPatient.Rows[e.RowIndex].Cells[0].Value.ToString(), 0);
        PatientFullEntity entity = listPatient.Find(p => p.Id == id);
        if (entity == null)
          return;

        switch (e.ColumnIndex)
        {
          case 6: // 修改
            var patientForm = new Patient(entity);
            var result = patientForm.ShowDialog();
            if (result == DialogResult.OK)
            {
              patientBLL.Update(patientForm.Entity);
              RefreshData();
              BindData();
            }
            break;
          case 7:  // 删除
            patientBLL.Delete(id);
            RefreshData();
            BindData();
            break;
          case 8: // 打印
            Print p = new Print(entity, printBLL);
            p.ShowDialog();
            break;
        }
      }
    }

    private void dgvPatient_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.ColumnIndex > -1 && e.ColumnIndex < 6)
      {
        var newSort = this.dgvPatient.Columns[e.ColumnIndex].DataPropertyName;

        if (Sort.Equals(newSort))
        {
          Order = Order == "DESC" ? "ASC" : "DESC";
        }
        else
        {
          Sort = newSort;
        }

        BindData();
      }
    }
    #endregion

    #region Button Events
    private void btnAdd_Click(object sender, EventArgs e)
    {
      var patientForm = new Patient(new PatientEntity());
      var result = patientForm.ShowDialog();
      if (result == DialogResult.OK)
      {
        patientBLL.Create(patientForm.Entity);
        RefreshData();
        BindData();
      }
    }

    private void btnPrintTodayPatients_Click(object sender, EventArgs e)
    {
      var list = patientBLL.GetTodayPatients();
      if (list.Count() == 0)
      {
        MessageBox.Show("今天没有病人！");
        return;
      }

      int pagecount = 20;

      while (list.Count > 0)
      {
        List<PatientFullEntity> temp = list.Take(pagecount).ToList();
        printPatientList(temp);

        list = list.Skip(pagecount).ToList();
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      SearchData();
      BindData();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      ResetSearch();
      RefreshData();
      BindData();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      var fileDialog = new OpenFileDialog();
      fileDialog.Filter = "(*.json)|*.json";
      fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
      if (fileDialog.ShowDialog() == DialogResult.OK)
      {
        string jsonFile = File.ReadAllText(fileDialog.FileName);
        var oldData = JsonConvert.DeserializeObject<List<OldPatientEntity>>(jsonFile);
        var results = patientBLL.Import(oldData);
        var sb = new StringBuilder();

        if (results.Count > 0)
        {
          var successData = results.Where(x => string.IsNullOrEmpty(x.Value)).ToList();
          var failedData = results.Where(x => !string.IsNullOrEmpty(x.Value)).ToList();

          if (successData.Count > 0)
            sb.AppendLine("成功导入" + successData.Count + "条数据：" + string.Join(",", successData.Select(x => x.Key.Name)));

          if (failedData.Count > 0)
            sb.AppendLine("导入错误" + failedData.Count + "条数据：" + string.Join(",", failedData.Select(x => x.Key.Name)));
        }
        else
        {
          sb.AppendLine("没有有效数据被导入!");
        }

        MessageBox.Show(sb.ToString(), "导入", MessageBoxButtons.OK, MessageBoxIcon.Information);

        RefreshData();
        BindData();
      }
    }
    private void btnExport_Click(object sender, EventArgs e)
    {
      var patients = patientBLL.GetTodayPatients();
      var data = patientBLL.Export(patients);

      string fileName = DateTime.Now.ToString("yyyy-MM-dd") + "营养液发放记录.csv";
      string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
      File.WriteAllText(filePath, data, Encoding.UTF8);

      Process.Start(filePath);
    }
    #endregion


    #region Private Functions
    private void RefreshData()
    {
      listPatient = patientBLL.GetTodayPatients();
    }

    private void SearchData()
    {
      var list = patientBLL.Search(GetSearchEntity());
      var prints = printBLL.SearchByPatientId(list.Select(x => x.Id).ToList());

      listPatient = list.Select(x => new PatientFullEntity(x) {
        Prints = prints.Where(p => x.Id == p.PatientId).ToList()
      }).ToList();
    }

    private void BindData()
    {
      this.dgvPatient.DataSource = null;
      this.dgvPatient.Columns.Clear();

      //listPatient.Sort((p1, p2) => p2.Id - p1.Id);
      List<PatientEntity> list = listPatient.Select(x => (PatientEntity)x).ToList();

      if (!string.IsNullOrEmpty(Sort))
      {
        list.Sort((p1, p2) =>
        {
          var order = Order == "DESC" ? -1 : 1;

          switch (Sort)
          {
            case "Name":
              return p1.Name.CompareTo(p2.Name) * order;
            case "Department":
              return p1.Department.CompareTo(p2.Department) * order;
            case "BedNumber":
              return p1.BedNumber.CompareTo(p2.BedNumber) * order;
            case "InsertedOn":
              return p1.InsertedOn.CompareTo(p2.InsertedOn) * order;
            case "UpdatedOn":
              return p1.UpdatedOn.CompareTo(p2.UpdatedOn) * order;
            case "Id":
            default:
              return p1.Id.CompareTo(p2.Id) * order;
          }
        });
      }

      this.dgvPatient.DataSource = list;

      this.dgvPatient.Font = new Font("Microsoft Sans Serif", 16);

      DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
      btnUpdate.Text = "修改";
      btnUpdate.UseColumnTextForButtonValue = true;
      btnUpdate.Width = 70;
      this.dgvPatient.Columns.Add(btnUpdate);

      DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
      btnDelete.Text = "删除";
      btnDelete.UseColumnTextForButtonValue = true;
      btnDelete.Width = 70;
      this.dgvPatient.Columns.Add(btnDelete);

      DataGridViewButtonColumn btnPrint = new DataGridViewButtonColumn();
      btnPrint.Text = "打印";
      btnPrint.UseColumnTextForButtonValue = true;
      btnPrint.Width = 70;
      this.dgvPatient.Columns.Add(btnPrint);

      this.dgvPatient.AllowUserToAddRows = true;
      this.dgvPatient.AllowUserToDeleteRows = true;
      this.dgvPatient.AllowUserToOrderColumns = true;

      this.dgvPatient.Columns[0].ReadOnly = true;
      this.dgvPatient.Columns[0].DataPropertyName = "Id";
      this.dgvPatient.Columns[0].Width = 60;
      this.dgvPatient.Columns[0].HeaderText = "ID" + (Sort == "Id" ? "*" : "");
      this.dgvPatient.Columns[0].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
      this.dgvPatient.Columns[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 16);

      this.dgvPatient.Columns[1].HeaderText = "姓名" + (Sort == "Name" ? "*" : "");
      this.dgvPatient.Columns[1].ReadOnly = true;
      this.dgvPatient.Columns[1].DataPropertyName = "Name";
      this.dgvPatient.Columns[1].Width = 200;
      this.dgvPatient.Columns[1].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);

      this.dgvPatient.Columns[2].HeaderText = "科室" + (Sort == "Department" ? "*" : "");
      this.dgvPatient.Columns[2].ReadOnly = true;
      this.dgvPatient.Columns[2].DataPropertyName = "Department";
      this.dgvPatient.Columns[2].Width = 200;
      this.dgvPatient.Columns[2].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);

      this.dgvPatient.Columns[3].HeaderText = "床号" + (Sort == "BedNumber" ? "*" : "");
      this.dgvPatient.Columns[3].ReadOnly = true;
      this.dgvPatient.Columns[3].DataPropertyName = "BedNumber";
      this.dgvPatient.Columns[3].Width = 200;
      this.dgvPatient.Columns[3].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);

      this.dgvPatient.Columns[4].HeaderText = "插入时间" + (Sort == "InsertedOn" ? "*" : "");
      this.dgvPatient.Columns[4].ReadOnly = true;
      this.dgvPatient.Columns[4].DataPropertyName = "InsertedOn";
      this.dgvPatient.Columns[4].Width = 250;
      this.dgvPatient.Columns[4].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);

      this.dgvPatient.Columns[5].HeaderText = "修改时间" + (Sort == "UpdatedOn" ? "*" : "");
      this.dgvPatient.Columns[5].ReadOnly = true;
      this.dgvPatient.Columns[5].DataPropertyName = "UpdatedOn";
      this.dgvPatient.Columns[5].Width = 250;
      this.dgvPatient.Columns[5].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
    }

    private void BackupData()
    {
      var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "nutrition.mdb");
      var bakPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + ".bak");
      if (!File.Exists(bakPath))
      {
        File.Copy(dbPath, bakPath);
      }
    }

    private void printPatientList(List<PatientFullEntity> list)
    {
      PrintDocument document;
      if (!string.IsNullOrEmpty(ConfigHelper.ListPrinter))
      {
        document = new PrintDocument { PrinterSettings = { PrinterName = ConfigHelper.ListPrinter } };
      }
      else
      {
        document = new PrintDocument();
      }

      document.DocumentName = string.Format("病人列表-{0}", DateTime.Now.ToString("yyyy-MM-dd"));
      document.PrintPage += (sender, e) =>
      {
        float topMargin = 80;
        float leftMargin = 70;


        float totalHeight = topMargin;
        // 页头
        string header = string.Format("{0}肠内营养液发放记录表", DateTime.Now.ToString("yyyy年MM月dd日"));
        Font headerFont = new Font("Arial", 25, FontStyle.Bold);
        e.Graphics.DrawString(header, headerFont, Brushes.Black, 70, totalHeight);

        totalHeight += headerFont.GetHeight(e.Graphics);

        totalHeight += 40;

        float row1X = leftMargin;
        float row2X = row1X + 100;
        float row3X = row2X + 120;
        float row4X = row3X + 100;
        float row5X = row4X + 220;
        float rowHeight = 40;

        // table header
        Font tableHeaderFont = new Font("Arial", 20, FontStyle.Bold);
        e.Graphics.DrawString("科室", tableHeaderFont, Brushes.Black, row1X, totalHeight);
        e.Graphics.DrawString("姓名", tableHeaderFont, Brushes.Black, row2X, totalHeight);
        e.Graphics.DrawString("病床", tableHeaderFont, Brushes.Black, row3X, totalHeight);
        e.Graphics.DrawString("热能", tableHeaderFont, Brushes.Black, row4X, totalHeight);
        e.Graphics.DrawString("签名", tableHeaderFont, Brushes.Black, row5X, totalHeight);

        totalHeight += rowHeight;
        totalHeight += 15;

        Font tableRowFont = new Font("Arial", 14, FontStyle.Regular);
        foreach (var entity in list)
        {
          e.Graphics.DrawString(entity.Department, tableRowFont, Brushes.Black, row1X, totalHeight);
          e.Graphics.DrawString(entity.Name, tableRowFont, Brushes.Black, row2X, totalHeight);
          e.Graphics.DrawString(entity.BedNumber, tableRowFont, Brushes.Black, row3X, totalHeight);
          if (entity.Prints != null && entity.Prints.Count > 0)
          {
            var lastPrint = entity.Prints.Last();
            e.Graphics.DrawString(string.Format("{0}kal/{1}ml * {2}{3}", lastPrint.Calorie, lastPrint.ML, lastPrint.Quantity, lastPrint.Unit), tableRowFont, Brushes.Black, row4X, totalHeight);
          }
          e.Graphics.DrawLine(Pens.Black, new Point((int)row5X, (int)totalHeight + (int)rowHeight - 15), new Point((int)row5X + 150, (int)totalHeight + (int)rowHeight - 15));

          totalHeight += rowHeight;
          totalHeight += 5;
        }
      };

      document.Print();
    }

    private PatientSearchEntity GetSearchEntity()
    {
      var search = new PatientSearchEntity();
      search.BeginDate = beginDate.Value.Date;
      search.EndDate = endDate.Value.Date;
      search.Keyword = tbKeyword.Text;

      return search;
    }

    private void ResetSearch()
    {
      beginDate.Value = DateTime.Now.Date;
      endDate.Value = DateTime.Now.Date.AddDays(1);
      tbKeyword.Text = "";
    }
    #endregion

  }
}
