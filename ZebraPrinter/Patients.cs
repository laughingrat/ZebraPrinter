using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Printing;

namespace ZebraPrinter
{
    public partial class Patients : Form
    {
        private static List<PatientEntity> listPatient;
        private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string dataPath = Path.Combine(currentDirectory, "patients.json");
        private static string oldDataPath = Path.Combine(currentDirectory, "oldpatients.json");

        public Patients()
        {
            InitializeComponent();
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            listPatient = new List<PatientEntity>();
            if (File.Exists(dataPath)) {
                string jsonFile = File.ReadAllText(dataPath);

                if (!string.IsNullOrEmpty(jsonFile)) {
                    listPatient = JsonConvert.DeserializeObject<List<PatientEntity>>(jsonFile).FindAll(p => p.InsertedOn > DateTime.Now.AddMonths(-1));
                }

            }

            BindData();
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex > 4)
            {
                int id = ParseInt(this.dgvPatient.Rows[e.RowIndex].Cells[0].Value.ToString());
                PatientEntity entity = listPatient.Find(p => p.Id == id);
                if (entity == null)
                    return;

                switch (e.ColumnIndex)
                {
                    case 5:  // 删除
                        listPatient.Remove(entity);
                        SaveData();
                        BindData();
                        break;
                    case 6: // 打印
                        Print p = new Print(entity);
                        p.ShowDialog();
                        SaveData();
                        break;
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                MessageBox.Show("请输入名称！");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtDepartment.Text))
            {
                MessageBox.Show("请输入科室！");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtNumber.Text))
            {
                MessageBox.Show("请输入病床号！");
                return;
            }

            listPatient.Add(new PatientEntity()
            {
                Id = GetMaxId(),
                Name = this.txtName.Text,
                Department = this.txtDepartment.Text,
                BedNumber = this.txtNumber.Text,
                InsertedOn = DateTime.Now
            });

            SaveData();
            BindData();

            this.txtName.Text = "";
            this.txtDepartment.Text = "";
            this.txtNumber.Text = "";
        }

        void BindData()
        {
            this.dgvPatient.DataSource = null;
            this.dgvPatient.Columns.Clear();

            listPatient.Sort((p1, p2) => p2.Id - p1.Id);
            List<BasePatientEntity> list = listPatient.Select(x => (BasePatientEntity)x).ToList();
            this.dgvPatient.DataSource = list;

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Text = "删除";
            btnDelete.UseColumnTextForButtonValue = true;
            this.dgvPatient.Columns.Add(btnDelete);

            DataGridViewButtonColumn btnPrint = new DataGridViewButtonColumn();
            btnPrint.Text = "打印";
            btnPrint.UseColumnTextForButtonValue = true;
            this.dgvPatient.Columns.Add(btnPrint);

            this.dgvPatient.AllowUserToAddRows = true;
            this.dgvPatient.AllowUserToDeleteRows = true;
            this.dgvPatient.AllowUserToOrderColumns = true;

            this.dgvPatient.Columns[0].HeaderText = "ID";
            this.dgvPatient.Columns[0].ReadOnly = true;
            this.dgvPatient.Columns[1].HeaderText = "姓名";
            this.dgvPatient.Columns[1].ReadOnly = true;
            this.dgvPatient.Columns[2].HeaderText = "科室";
            this.dgvPatient.Columns[2].ReadOnly = true;
            this.dgvPatient.Columns[3].HeaderText = "床号";
            this.dgvPatient.Columns[3].ReadOnly = true;
            this.dgvPatient.Columns[4].HeaderText = "插入时间";
            this.dgvPatient.Columns[4].ReadOnly = true;
        }


        int ParseInt(string val)
        {
            int temp = -1;
            if (int.TryParse(val, out temp))
            {
                return temp;
            }

            return -1;
        }


        int GetMaxId()
        {
            if (listPatient.Count > 0)
                return listPatient.Max(p => p.Id) + 1;

            return 1;
        }

        void SaveData()
        {
            listPatient.Sort((p1, p2) => p1.Id - p2.Id);
            File.WriteAllText(dataPath, JsonConvert.SerializeObject(listPatient));
        }

        private void Patients_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void dgvPatient_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            SaveData();
        }

        private void button2_Click(object sender1, EventArgs e1)
        {

            List<PatientEntity> list = listPatient.FindAll(p => p.InsertedOn > DateTime.Now.Date || p.PrintDate > DateTime.Now.Date);
            list.Sort((a, b) => { return a.Department.CompareTo(b.Department) * 10 + a.Name.CompareTo(b.Name); });

            if (list.Count() == 0)
            {
                MessageBox.Show("今天没有病人！");
                return;
            }

            int pagecount = 20;

            while (list.Count > 0)
            {
                List<PatientEntity> temp = list.Take(pagecount).ToList();
                printPatientList(temp);

                list = list.Skip(pagecount).ToList();
            }
        }

        private void printPatientList(List<PatientEntity> list)
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
                foreach (PatientEntity entity in list)
                {
                    e.Graphics.DrawString(entity.Department, tableRowFont, Brushes.Black, row1X, totalHeight);
                    e.Graphics.DrawString(entity.Name, tableRowFont, Brushes.Black, row2X, totalHeight);
                    e.Graphics.DrawString(entity.BedNumber, tableRowFont, Brushes.Black, row3X, totalHeight);
                    if (!string.IsNullOrEmpty(entity.Calorie))
                    {
                        e.Graphics.DrawString(string.Format("{0}kal/{1}ml * {2}{3}", entity.Calorie, entity.ML, entity.Count, entity.Unit), tableRowFont, Brushes.Black, row4X, totalHeight);
                    }
                    e.Graphics.DrawLine(Pens.Black, new Point((int)row5X, (int)totalHeight + (int)rowHeight - 15), new Point((int)row5X + 150, (int)totalHeight + (int)rowHeight - 15));

                    totalHeight += rowHeight;
                    totalHeight += 5;
                }
            };

            document.Print();
        }

    }
}
