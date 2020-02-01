using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZebraPrinter.Entity;

namespace ZebraPrinter
{
  public partial class PrintPreview : Form
  {
    private PatientEntity patient;
    private PatientPrintEntity print;

    public PrintPreview(PatientEntity patient, PatientPrintEntity print)
    {
      InitializeComponent();

      this.patient = patient;
      this.print = print;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void PrintPreview_Load(object sender, EventArgs e)
    {
      GeneratePrintImage();
    }

    private Graphics GeneratePrintImage()
    {
      var graph = Graphics.FromImage(picPreview.Image);

      Font lineFont = new Font("Arial", 16);
      float lineHeight = lineFont.GetHeight(graph);

      Font lineFontBold = new Font("Arial", 18, FontStyle.Bold);
      float lineBoldHeight = lineFontBold.GetHeight(graph);

      Font headerFont = new Font("Arial", 22, FontStyle.Bold);
      float headerHeight = headerFont.GetHeight(graph);

      Font footerFont = new Font("Arial", 14);
      float footerHeight = footerFont.GetHeight(graph);


      float leftMargin = 10;
      float topMargin = 10;

      float yPos = 15;

      StringFormat sfRight = new StringFormat();
      sfRight.Alignment = StringAlignment.Far;
      sfRight.LineAlignment = StringAlignment.Far;

      StringFormat sfLeft = new StringFormat();
      sfLeft.Alignment = StringAlignment.Near;
      sfLeft.LineAlignment = StringAlignment.Near;


      graph.DrawString(string.Format("{0}    {1}科 {2}床", patient.Name, patient.Department.Replace("科", ""), patient.BedNumber.Replace("床", "")),
                headerFont, Brushes.Black,
                  leftMargin, yPos, sfLeft);

      yPos += topMargin + headerHeight + 10;

      graph.DrawString(string.Format("    {0}Kcal / {1}ml    X {2}{3}", print.Calorie, print.ML, print.Quantity, print.Unit),
                    lineFontBold, Brushes.Black,
                  leftMargin, yPos, sfLeft);

      yPos = yPos + lineBoldHeight + 10;

      graph.DrawString("配制时间：" + print.PrintDate.ToString("yyyy-MM-dd HH:mm"), lineFont, Brushes.Black,
                   leftMargin, yPos, sfLeft);

      yPos = yPos + lineHeight;

      graph.DrawString("冷藏保存 24小时", footerFont, Brushes.Black,
                   leftMargin, yPos, sfLeft);

      yPos = yPos + lineHeight;

      graph.DrawString("      仅供肠内营养治疗 严禁静脉输注", footerFont, Brushes.Black,
                   leftMargin, yPos, sfLeft);

      yPos = yPos + lineHeight;

      graph.DrawString("      交大二附院营养科 029-87679504", footerFont, Brushes.Black,
                  leftMargin, yPos, sfLeft);

      return graph;
    }

  }
}
