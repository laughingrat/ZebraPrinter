namespace ZebraPrinter
{
  partial class PrintPreview
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnClose = new System.Windows.Forms.Button();
      this.picPreview = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
      this.SuspendLayout();
      // 
      // btnClose
      // 
      this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClose.Location = new System.Drawing.Point(168, 318);
      this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(150, 44);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "关闭";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // picPreview
      // 
      this.picPreview.Image = global::ZebraPrinter.Properties.Resources.blank;
      this.picPreview.Location = new System.Drawing.Point(70, 35);
      this.picPreview.Margin = new System.Windows.Forms.Padding(6);
      this.picPreview.Name = "picPreview";
      this.picPreview.Size = new System.Drawing.Size(404, 262);
      this.picPreview.TabIndex = 0;
      this.picPreview.TabStop = false;
      // 
      // PrintPreview
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(537, 389);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.picPreview);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.MaximizeBox = false;
      this.Name = "PrintPreview";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "打印预览";
      this.Load += new System.EventHandler(this.PrintPreview_Load);
      ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnClose;
    }
}