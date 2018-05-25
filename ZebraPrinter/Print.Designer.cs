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
            this.button1 = new System.Windows.Forms.Button();
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
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 21);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(16, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "病人名称";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(275, 9);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(131, 21);
            this.txtDepartment.TabIndex = 2;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(235, 16);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(29, 12);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "科室";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(483, 9);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(131, 21);
            this.txtNumber.TabIndex = 3;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(424, 16);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(41, 12);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "病床号";
            // 
            // lblKCal
            // 
            this.lblKCal.AutoSize = true;
            this.lblKCal.Location = new System.Drawing.Point(37, 61);
            this.lblKCal.Name = "lblKCal";
            this.lblKCal.Size = new System.Drawing.Size(29, 12);
            this.lblKCal.TabIndex = 3;
            this.lblKCal.Text = "热能";
            // 
            // txtKCal
            // 
            this.txtKCal.Location = new System.Drawing.Point(86, 52);
            this.txtKCal.Name = "txtKCal";
            this.txtKCal.Size = new System.Drawing.Size(131, 21);
            this.txtKCal.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kcal/  ";
            // 
            // txtML
            // 
            this.txtML.Location = new System.Drawing.Point(275, 52);
            this.txtML.Name = "txtML";
            this.txtML.Size = new System.Drawing.Size(131, 21);
            this.txtML.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "ml";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "配制时间";
            // 
            // dt
            // 
            this.dt.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt.Location = new System.Drawing.Point(86, 96);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(151, 21);
            this.dt.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "*";
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(456, 49);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(61, 21);
            this.quantity.TabIndex = 6;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbUnit
            // 
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "袋",
            "杯"});
            this.cbUnit.Location = new System.Drawing.Point(523, 49);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(63, 20);
            this.cbUnit.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(548, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(632, 196);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblKCal);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtML);
            this.Controls.Add(this.txtKCal);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.button1);
            this.Name = "Print";
            this.ShowInTaskbar = false;
            this.Text = "二附院营养科打印";
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Button button2;
    }
}

