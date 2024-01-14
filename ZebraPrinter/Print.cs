using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ZebraPrinter.BLL;
using ZebraPrinter.Entity;
using ZebraPrinter.Utils;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ZebraPrinter
{
  public partial class Print : Form
  {
    private PatientEntity patient;
    private PatientPrintBLL printBLL;

    private List<PatientPrintEntity> prints;

    public Print(PatientEntity entity, PatientPrintBLL printBLL)
    {
      InitializeComponent();

      patient = entity;
      this.printBLL = printBLL;

      BindBasicData();
      BindPrintData();
      BindLastPrint();
    }

    private void doPrint()
    {
      PrintDocument pd = new PrintDocument { PrinterSettings = { PrinterName = ConfigHelper.ZebraPrinter } };


      StandardPrintController pc = new StandardPrintController();
      pd.PrintController = pc;

      pd.DefaultPageSettings.Margins = new Margins(5, 0, 0, 0);
      pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(5, 0, 0, 0);

      if (pd.PrinterSettings.IsValid == false)
      {
        throw new Exception(pd.PrinterSettings.PrinterName);
      }

      // set the document name to a guid
      pd.DocumentName = Guid.NewGuid().ToString();

      // call the print page event to put the xml document information on the pass
      pd.PrintPage += (sndr, args) =>
      {

        Font lineFont = new Font("Arial", 8);
        float lineHeight = lineFont.GetHeight(args.Graphics);

        Font lineFontBold = new Font("Arial", 9, FontStyle.Bold);
        float lineBoldHeight = lineFontBold.GetHeight(args.Graphics);

        Font headerFont = new Font("Arial", 11, FontStyle.Bold);
        float headerHeight = headerFont.GetHeight(args.Graphics);

        Font footerFont = new Font("Arial", 8);
        float footerHeight = footerFont.GetHeight(args.Graphics);


        float leftMargin = args.MarginBounds.Left + 10;
        float topMargin = args.MarginBounds.Top;

        int height = args.PageSettings.PaperSize.Height;
        int width = args.PageSettings.PaperSize.Width;
        float yPos = 15;

        StringFormat sfRight = new StringFormat();
        sfRight.Alignment = StringAlignment.Far;
        sfRight.LineAlignment = StringAlignment.Far;

        StringFormat sfLeft = new StringFormat();
        sfLeft.Alignment = StringAlignment.Near;
        sfLeft.LineAlignment = StringAlignment.Near;


        args.Graphics.DrawString(string.Format("{0}  病案号:{1}", this.txtName.Text, this.txtCaseId.Text),
                  headerFont, Brushes.Black,
                    leftMargin, yPos, sfLeft);

        yPos += topMargin + headerHeight + 5;


        args.Graphics.DrawString(string.Format("{0} {1}床", this.txtDepartment.Text, this.txtNumber.Text.Replace("床", "")),
                headerFont, Brushes.Black,
                  leftMargin, yPos, sfLeft);

        yPos += topMargin + headerHeight + 5;

        args.Graphics.DrawString(string.Format("{0}{1}{2}    X {3}{4}", 
            !String.IsNullOrWhiteSpace(this.txtKCal.Text) ? this.txtKCal.Text + "Kcal" : "",
            !String.IsNullOrWhiteSpace(this.txtKCal.Text) && !String.IsNullOrWhiteSpace(this.txtML.Text) ? " / " : "",
            !String.IsNullOrWhiteSpace(this.txtML.Text) ? this.txtML.Text + "ml" : "", 
            this.quantity.Value, 
            this.cbUnit.Text),
                      headerFont, Brushes.Black,
                    leftMargin, yPos, sfLeft);

        yPos = yPos + lineBoldHeight + 10;

        args.Graphics.DrawString("                 配制时间：" + this.dt.Value.ToString("yyyy-MM-dd HH:mm"), lineFont, Brushes.Black,
                     leftMargin, yPos, sfLeft);

        yPos = yPos + lineHeight + 2;

        args.Graphics.DrawString("                                     冷藏保存 24小时", footerFont, Brushes.Black,
                     leftMargin, yPos, sfLeft);
        yPos = yPos + lineHeight + 2;

        args.Graphics.DrawString("         仅供肠内营养治疗 严禁静脉输注", footerFont, Brushes.Black,
                     leftMargin, yPos, sfLeft);

        yPos = yPos + lineHeight + 2;

        args.Graphics.DrawString("        交大二附院营养科 029-87679504", footerFont, Brushes.Black,
                    leftMargin , yPos, sfLeft);



        args.HasMorePages = false;
      };

      // set the portrait
      pd.DefaultPageSettings.Landscape = false;

      // print
      pd.Print();

      pd.Dispose();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      int count = 0;
      while (count < this.quantity.Value + 1)
      {
        doPrint();
        count++;
      }

      try
      {
        printBLL.Create(getCurrentPrint());
      }
      catch (Exception ex)
      {
        MessageBox.Show("错误：" + ex.Message);
      }
     

      BindPrintData();
      BindLastPrint();
    }

    private PatientPrintEntity getCurrentPrint()
    {
      return new PatientPrintEntity
      {
        Calorie = txtKCal.Text,
        ML = txtML.Text,
        PatientId = patient.Id,
        Quantity = ConvertHelper.ConvertToInt(quantity.Value, 0),
        Unit = cbUnit.Text,
        PrintDate = dt.Value
      };
    }

    private void BindBasicData()
    {
      txtName.Text = patient.Name;
      txtDepartment.Text = patient.Department;
      txtNumber.Text = patient.BedNumber;
      txtCaseId.Text = patient.CaseId;
    }

    private void BindPrintData()
    {
      prints = printBLL.SearchByPatientId(new List<int>() { patient.Id });
    }

    private void BindLastPrint()
    {
      if (prints != null && prints.Count > 0)
      {
        var myPrints = prints.OrderByDescending(p => p.UpdatedOn);

        var sb = new StringBuilder();
        foreach (var print in myPrints)
        {
          sb.AppendLine(string.Format(string.Format(" {0}Kcal / {1}ml    X {2}{3}  配置时间: {4}   更新时间: {5}",
          print.Calorie, print.ML, print.Quantity, print.Unit, print.PrintDate.ToString("yyyy-MM-dd HH:mm"), print.UpdatedOn.ToString("yyyy-MM-dd HH:mm"))));
        }

        labLastPrintInfo.Text = sb.ToString();
      }
      else
      {
        labLastPrintInfo.Text = "";
      }
    }

    private void btnPrintPreview_Click(object sender, EventArgs e)
    {
      var preview = new PrintPreview(patient, getCurrentPrint());
      preview.ShowDialog();
    }

  }
}
