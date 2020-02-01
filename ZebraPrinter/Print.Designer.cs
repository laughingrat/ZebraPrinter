namespace ZebraPrinter
{
    partial class Print
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
      this.btnPrint = new System.Windows.Forms.Button();
      this.txtName = new System.Windows.Forms.TextBox();
      this.lblName = new System.Windows.Forms.Label();
      this.txtDepartment = new System.Windows.Forms.TextBox();
      this.lblDepartment = new System.Windows.Forms.Label();
      this.txtNumber = new System.Windows.Forms.TextBox();
      this.lblNumber = new System.Windows.Forms.Label();
      this.lblKCal = new System.Windows.Forms.Label();
      this.txtKCal = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtML = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.dt = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.quantity = new System.Windows.Forms.NumericUpDown();
      this.cbUnit = new System.Windows.Forms.ComboBox();
      this.btnClose = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnPrintPreview = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.labLastPrintInfo = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnPrint
      // 
      this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPrint.Location = new System.Drawing.Point(919, 145);
      this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new System.Drawing.Size(149, 48);
      this.btnPrint.TabIndex = 0;
      this.btnPrint.Text = "打印";
      this.btnPrint.UseVisualStyleBackColor = true;
      this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
      // 
      // txtName
      // 
      this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtName.Location = new System.Drawing.Point(155, 34);
      this.txtName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new System.Drawing.Size(257, 32);
      this.txtName.TabIndex = 1;
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblName.Location = new System.Drawing.Point(17, 36);
      this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(104, 26);
      this.lblName.TabIndex = 2;
      this.lblName.Text = "病人名称";
      // 
      // txtDepartment
      // 
      this.txtDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtDepartment.Location = new System.Drawing.Point(535, 34);
      this.txtDepartment.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.txtDepartment.Name = "txtDepartment";
      this.txtDepartment.ReadOnly = true;
      this.txtDepartment.Size = new System.Drawing.Size(257, 32);
      this.txtDepartment.TabIndex = 2;
      // 
      // lblDepartment
      // 
      this.lblDepartment.AutoSize = true;
      this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDepartment.Location = new System.Drawing.Point(455, 36);
      this.lblDepartment.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lblDepartment.Name = "lblDepartment";
      this.lblDepartment.Size = new System.Drawing.Size(58, 26);
      this.lblDepartment.TabIndex = 2;
      this.lblDepartment.Text = "科室";
      // 
      // txtNumber
      // 
      this.txtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtNumber.Location = new System.Drawing.Point(951, 34);
      this.txtNumber.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.ReadOnly = true;
      this.txtNumber.Size = new System.Drawing.Size(257, 32);
      this.txtNumber.TabIndex = 3;
      // 
      // lblNumber
      // 
      this.lblNumber.AutoSize = true;
      this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNumber.Location = new System.Drawing.Point(833, 36);
      this.lblNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lblNumber.Name = "lblNumber";
      this.lblNumber.Size = new System.Drawing.Size(81, 26);
      this.lblNumber.TabIndex = 2;
      this.lblNumber.Text = "病床号";
      // 
      // lblKCal
      // 
      this.lblKCal.AutoSize = true;
      this.lblKCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblKCal.Location = new System.Drawing.Point(60, 101);
      this.lblKCal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lblKCal.Name = "lblKCal";
      this.lblKCal.Size = new System.Drawing.Size(58, 26);
      this.lblKCal.TabIndex = 3;
      this.lblKCal.Text = "热能";
      // 
      // txtKCal
      // 
      this.txtKCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtKCal.Location = new System.Drawing.Point(155, 94);
      this.txtKCal.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.txtKCal.Name = "txtKCal";
      this.txtKCal.Size = new System.Drawing.Size(257, 32);
      this.txtKCal.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(456, 101);
      this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(72, 25);
      this.label3.TabIndex = 3;
      this.label3.Text = "Kcal/  ";
      // 
      // txtML
      // 
      this.txtML.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtML.Location = new System.Drawing.Point(535, 94);
      this.txtML.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.txtML.Name = "txtML";
      this.txtML.Size = new System.Drawing.Size(257, 32);
      this.txtML.TabIndex = 5;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(809, 101);
      this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(34, 25);
      this.label4.TabIndex = 3;
      this.label4.Text = "ml";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(15, 161);
      this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(104, 26);
      this.label5.TabIndex = 4;
      this.label5.Text = "配制时间";
      // 
      // dt
      // 
      this.dt.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dt.Location = new System.Drawing.Point(155, 161);
      this.dt.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.dt.Name = "dt";
      this.dt.Size = new System.Drawing.Size(297, 32);
      this.dt.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(863, 101);
      this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(20, 25);
      this.label1.TabIndex = 8;
      this.label1.Text = "*";
      // 
      // quantity
      // 
      this.quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.quantity.Location = new System.Drawing.Point(897, 94);
      this.quantity.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.quantity.Name = "quantity";
      this.quantity.Size = new System.Drawing.Size(123, 32);
      this.quantity.TabIndex = 6;
      this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // cbUnit
      // 
      this.cbUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbUnit.FormattingEnabled = true;
      this.cbUnit.Items.AddRange(new object[] {
            "袋",
            "杯"});
      this.cbUnit.Location = new System.Drawing.Point(1031, 94);
      this.cbUnit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.cbUnit.Name = "cbUnit";
      this.cbUnit.Size = new System.Drawing.Size(121, 33);
      this.cbUnit.TabIndex = 7;
      // 
      // btnClose
      // 
      this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClose.Location = new System.Drawing.Point(1081, 145);
      this.btnClose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(149, 48);
      this.btnClose.TabIndex = 9;
      this.btnClose.Text = "关闭";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnPrintPreview);
      this.groupBox1.Controls.Add(this.txtName);
      this.groupBox1.Controls.Add(this.btnClose);
      this.groupBox1.Controls.Add(this.btnPrint);
      this.groupBox1.Controls.Add(this.cbUnit);
      this.groupBox1.Controls.Add(this.txtKCal);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.txtML);
      this.groupBox1.Controls.Add(this.quantity);
      this.groupBox1.Controls.Add(this.lblName);
      this.groupBox1.Controls.Add(this.dt);
      this.groupBox1.Controls.Add(this.txtDepartment);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.lblDepartment);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtNumber);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.lblNumber);
      this.groupBox1.Controls.Add(this.lblKCal);
      this.groupBox1.Location = new System.Drawing.Point(16, 15);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Size = new System.Drawing.Size(1244, 207);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "打印";
      // 
      // btnPrintPreview
      // 
      this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPrintPreview.Location = new System.Drawing.Point(748, 146);
      this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.btnPrintPreview.Name = "btnPrintPreview";
      this.btnPrintPreview.Size = new System.Drawing.Size(149, 48);
      this.btnPrintPreview.TabIndex = 10;
      this.btnPrintPreview.Text = "打印预览";
      this.btnPrintPreview.UseVisualStyleBackColor = true;
      this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.labLastPrintInfo);
      this.groupBox2.Location = new System.Drawing.Point(17, 230);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox2.Size = new System.Drawing.Size(1243, 184);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "上次打印信息";
      // 
      // labLastPrintInfo
      // 
      this.labLastPrintInfo.AutoSize = true;
      this.labLastPrintInfo.Location = new System.Drawing.Point(41, 40);
      this.labLastPrintInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labLastPrintInfo.Name = "labLastPrintInfo";
      this.labLastPrintInfo.Size = new System.Drawing.Size(134, 26);
      this.labLastPrintInfo.TabIndex = 0;
      this.labLastPrintInfo.Text = "LastPrintInfo";
      // 
      // Print
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1279, 429);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.MaximizeBox = false;
      this.Name = "Print";
      this.ShowInTaskbar = false;
      this.Text = "二附院营养科-打印";
      ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblKCal;
        private System.Windows.Forms.TextBox txtKCal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtML;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labLastPrintInfo;
        private System.Windows.Forms.Button btnPrintPreview;
    }
}

