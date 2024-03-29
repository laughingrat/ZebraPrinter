﻿namespace ZebraPrinter
{
    partial class main
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
      this.dgvPatient = new System.Windows.Forms.DataGridView();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnPrintTodayPatients = new System.Windows.Forms.Button();
      this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
      this.beginDate = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.endDate = new System.Windows.Forms.DateTimePicker();
      this.tbKeyword = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.btnSearch = new System.Windows.Forms.Button();
      this.btnReset = new System.Windows.Forms.Button();
      this.btnImport = new System.Windows.Forms.Button();
      this.btnExport = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
      this.SuspendLayout();
      // 
      // dgvPatient
      // 
      this.dgvPatient.AllowUserToOrderColumns = true;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPatient.Location = new System.Drawing.Point(3, 66);
      this.dgvPatient.Margin = new System.Windows.Forms.Padding(4);
      this.dgvPatient.Name = "dgvPatient";
      this.dgvPatient.RowHeadersWidth = 62;
      this.dgvPatient.RowTemplate.Height = 30;
      this.dgvPatient.Size = new System.Drawing.Size(2376, 1134);
      this.dgvPatient.TabIndex = 0;
      this.dgvPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellClick);
      this.dgvPatient.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPatient_ColumnHeaderMouseClick);
      // 
      // btnAdd
      // 
      this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnAdd.Location = new System.Drawing.Point(1254, 12);
      this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(96, 45);
      this.btnAdd.TabIndex = 6;
      this.btnAdd.Text = "添加";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnPrintTodayPatients
      // 
      this.btnPrintTodayPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPrintTodayPatients.Location = new System.Drawing.Point(1644, 12);
      this.btnPrintTodayPatients.Margin = new System.Windows.Forms.Padding(4);
      this.btnPrintTodayPatients.Name = "btnPrintTodayPatients";
      this.btnPrintTodayPatients.Size = new System.Drawing.Size(231, 45);
      this.btnPrintTodayPatients.TabIndex = 9;
      this.btnPrintTodayPatients.Text = "打印今日病人列表";
      this.btnPrintTodayPatients.UseVisualStyleBackColor = true;
      this.btnPrintTodayPatients.Click += new System.EventHandler(this.btnPrintTodayPatients_Click);
      // 
      // printPreviewDialog1
      // 
      this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
      this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
      this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
      this.printPreviewDialog1.Enabled = true;
      this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
      this.printPreviewDialog1.Name = "printPreviewDialog1";
      this.printPreviewDialog1.Visible = false;
      // 
      // beginDate
      // 
      this.beginDate.CustomFormat = "yyyy-MM-dd";
      this.beginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.beginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.beginDate.Location = new System.Drawing.Point(90, 10);
      this.beginDate.Margin = new System.Windows.Forms.Padding(4);
      this.beginDate.Name = "beginDate";
      this.beginDate.Size = new System.Drawing.Size(226, 43);
      this.beginDate.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(0, 20);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(83, 37);
      this.label4.TabIndex = 3;
      this.label4.Text = "起始";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(327, 20);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(83, 37);
      this.label5.TabIndex = 3;
      this.label5.Text = "结束";
      // 
      // endDate
      // 
      this.endDate.CustomFormat = "yyyy-MM-dd";
      this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.endDate.Location = new System.Drawing.Point(417, 10);
      this.endDate.Margin = new System.Windows.Forms.Padding(4);
      this.endDate.Name = "endDate";
      this.endDate.Size = new System.Drawing.Size(226, 43);
      this.endDate.TabIndex = 2;
      // 
      // tbKeyword
      // 
      this.tbKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbKeyword.Location = new System.Drawing.Point(768, 10);
      this.tbKeyword.Margin = new System.Windows.Forms.Padding(4);
      this.tbKeyword.Name = "tbKeyword";
      this.tbKeyword.Size = new System.Drawing.Size(284, 43);
      this.tbKeyword.TabIndex = 3;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(651, 20);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(116, 37);
      this.label6.TabIndex = 3;
      this.label6.Text = "关键字";
      // 
      // btnSearch
      // 
      this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSearch.Location = new System.Drawing.Point(1059, 12);
      this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(96, 45);
      this.btnSearch.TabIndex = 4;
      this.btnSearch.Text = "搜索";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // btnReset
      // 
      this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnReset.Location = new System.Drawing.Point(1156, 12);
      this.btnReset.Margin = new System.Windows.Forms.Padding(4);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(96, 45);
      this.btnReset.TabIndex = 5;
      this.btnReset.Text = "重置";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // btnImport
      // 
      this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnImport.Location = new System.Drawing.Point(1352, 12);
      this.btnImport.Margin = new System.Windows.Forms.Padding(4);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new System.Drawing.Size(96, 45);
      this.btnImport.TabIndex = 7;
      this.btnImport.Text = "导入";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
      // 
      // btnExport
      // 
      this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnExport.Location = new System.Drawing.Point(1449, 12);
      this.btnExport.Margin = new System.Windows.Forms.Padding(4);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new System.Drawing.Size(96, 45);
      this.btnExport.TabIndex = 8;
      this.btnExport.Text = "导出";
      this.btnExport.UseVisualStyleBackColor = true;
      this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
      // 
      // btnClear
      // 
      this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClear.Location = new System.Drawing.Point(1546, 12);
      this.btnClear.Margin = new System.Windows.Forms.Padding(4);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(96, 45);
      this.btnClear.TabIndex = 7;
      this.btnClear.Text = "清空";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(2392, 1206);
      this.Controls.Add(this.endDate);
      this.Controls.Add(this.beginDate);
      this.Controls.Add(this.btnPrintTodayPatients);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.tbKeyword);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.btnReset);
      this.Controls.Add(this.btnExport);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.btnImport);
      this.Controls.Add(this.btnSearch);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.dgvPatient);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximizeBox = false;
      this.Name = "main";
      this.Text = "二附院营养科-病人列表";
      this.Load += new System.EventHandler(this.Patients_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrintTodayPatients;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    private System.Windows.Forms.DateTimePicker beginDate;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DateTimePicker endDate;
    private System.Windows.Forms.TextBox tbKeyword;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.Button btnClear;
  }
}