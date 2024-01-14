using System;
using System.Windows.Forms;
using ZebraPrinter.BLL;
using ZebraPrinter.Entity;

namespace ZebraPrinter
{
  public partial class Patient : Form
  {
    private PatientEntity entity;

    public Patient(PatientEntity entity)
    {
      InitializeComponent();

      this.entity = entity;
    }

    protected void BindData()
    {
      this.txtName.Text = this.entity.Name;
      this.txtDepartment.Text = this.entity.Department;
      this.txtNumber.Text = this.entity.BedNumber;
      this.txtCaseId.Text = this.entity.CaseId;

      this.btnAdd.Text = this.entity.Id > 0 ? "修改" : "添加";
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
        MessageBox.Show("请输入床号！");
        return;
      }

      if (string.IsNullOrWhiteSpace(this.txtCaseId.Text))
      {
        MessageBox.Show("请输入病案号！");
        return;
      }

      entity.Name = this.txtName.Text;
      entity.Department = txtDepartment.Text;
      entity.BedNumber = txtNumber.Text;
      entity.CaseId = txtCaseId.Text;

      DialogResult = DialogResult.OK;
      this.Close();
    }

    public PatientEntity Entity
    {
      get { return this.entity; }
    }

    private void Patient_Load(object sender, EventArgs e)
    {
      BindData();
    }
  }
}
