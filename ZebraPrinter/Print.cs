using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;

namespace ZebraPrinter
{
    public partial class Print : Form
    {
        private PatientEntity patient;

        public Print(PatientEntity entity)
        {
            InitializeComponent();

            patient = entity;

            this.txtName.Text = entity.Name;
            this.txtDepartment.Text = entity.Department;
            this.txtNumber.Text = entity.BedNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            while (count < this.quantity.Value)
            {
                doPrint2();
                count++;
            }

            patient.Calorie = this.txtKCal.Text;
            patient.Count = (int)this.quantity.Value;
            patient.ML = this.txtML.Text;
            patient.PrintDate = DateTime.Now;
            patient.Unit = this.cbUnit.Text;
        }

        private void doPrint()
        {
            PrintDocument pd = new PrintDocument { PrinterSettings = { PrinterName = "ZDesigner GK888t" } };


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

                Font headerFont = new Font("Arial", 11, FontStyle.Bold);
                float headerHeight = headerFont.GetHeight(args.Graphics);

                Font footerFont = new Font("Arial", 7);
                float footerHeight = footerFont.GetHeight(args.Graphics);


                float leftMargin = args.MarginBounds.Left;
                float topMargin = args.MarginBounds.Top;

                int height = args.PageSettings.PaperSize.Height;
                int width = args.PageSettings.PaperSize.Width;
                float yPos = 0;

                StringFormat sfRight = new StringFormat();
                sfRight.Alignment = StringAlignment.Far;
                sfRight.LineAlignment = StringAlignment.Far;

                StringFormat sfLeft = new StringFormat();
                sfRight.Alignment = StringAlignment.Near;
                sfRight.LineAlignment = StringAlignment.Near;

                StringFormat sfCenter = new StringFormat();
                sfCenter.Alignment = StringAlignment.Center;
                sfCenter.LineAlignment = StringAlignment.Center;

                args.Graphics.DrawString(string.Format("{0}    {1} {2}床", this.txtName.Text, this.txtDepartment.Text, this.txtNumber.Text),
                    headerFont, Brushes.Black,
                      leftMargin, yPos, sfLeft);

                yPos = topMargin + headerHeight;

                args.Graphics.DrawString(string.Format("{0}Kcal/{1}ml", this.txtKCal.Text, this.txtML.Text), lineFont, Brushes.Black,
                      leftMargin, yPos, sfLeft);

                yPos = yPos + lineHeight;

                args.Graphics.DrawString("配制时间：" + this.dt.Value.ToString("yyyy-MM-dd HH:mm"), lineFont, Brushes.Black,
                       leftMargin, yPos, sfLeft);

                yPos = yPos + lineHeight;

                args.Graphics.DrawString("冷藏保存 24小时", footerFont, Brushes.Black,
                       leftMargin, yPos, sfRight);

                yPos = yPos + lineHeight;

                args.Graphics.DrawString("仅供肠内营养 严禁静脉输注", footerFont, Brushes.Black,
                       leftMargin, yPos, sfRight);

                yPos = yPos + lineHeight;

                args.Graphics.DrawString("交大二附院营养科 87679504", footerFont, Brushes.Black,
                      leftMargin, yPos, sfRight);



                args.HasMorePages = false;
            };

            // set the portrait
            pd.DefaultPageSettings.Landscape = false;

            // print
            pd.Print();

            pd.Dispose();
        }



        private void doPrint2()
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

                Font footerFont = new Font("Arial", 7);
                float footerHeight = footerFont.GetHeight(args.Graphics);


                float leftMargin = args.MarginBounds.Left;
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


                args.Graphics.DrawString(string.Format("{0}    {1}科 {2}床", this.txtName.Text, this.txtDepartment.Text.Replace("科", ""), this.txtNumber.Text.Replace("床", "")),
                    headerFont, Brushes.Black,
                      leftMargin, yPos, sfLeft);

                yPos += topMargin + headerHeight + 10;

                args.Graphics.DrawString(string.Format("    {0}Kcal / {1}ml    X {2}{3}", this.txtKCal.Text, this.txtML.Text, this.quantity.Value, this.cbUnit.Text),
                        lineFontBold, Brushes.Black,
                      leftMargin, yPos, sfLeft);

                yPos = yPos + lineBoldHeight + 10;

                args.Graphics.DrawString("配制时间：" + this.dt.Value.ToString("yyyy-MM-dd HH:mm"), lineFont, Brushes.Black,
                       leftMargin, yPos, sfLeft);

                yPos = yPos + lineHeight;

                args.Graphics.DrawString("冷藏保存 24小时", footerFont, Brushes.Black,
                       leftMargin, yPos, sfLeft);

                yPos = yPos + lineHeight;

                args.Graphics.DrawString("      仅供肠内营养治疗 严禁静脉输注", footerFont, Brushes.Black,
                       leftMargin, yPos, sfLeft);

                yPos = yPos + lineHeight;

                args.Graphics.DrawString("      交大二附院营养科 029-87679504", footerFont, Brushes.Black,
                      leftMargin, yPos, sfLeft);



                args.HasMorePages = false;
            };

            // set the portrait
            pd.DefaultPageSettings.Landscape = false;

            // print
            pd.Print();

            pd.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
