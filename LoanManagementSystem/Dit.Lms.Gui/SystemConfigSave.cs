using System;
using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class SystemConfigSave : Form
    {
        private SystemConfig _SysConfig;
        private ILoanService _Service;

        public SystemConfigSave()
        {
            _Service = LoanServiceFactory.CreateLoanService();
            InitializeComponent();
        }

        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            SystemConfigDetail configDetail = new SystemConfigDetail();
            configDetail.SysConfigId = _SysConfig.Id;
            new ConfigDetailSave(configDetail, RefreshGrid).ShowDialog();
        }

        private void SystemConfigSave_Load(object sender, EventArgs e)
        {
            grdConfigDetails.AutoGenerateColumns = false;
            try
            {
                _SysConfig = _Service.GetSystemConfig(1);
                PopulateSysConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshGrid(SystemConfigDetailCollection configDetails)
        {
            grdConfigDetails.DataSource = configDetails;
        }

        private void PopulateSysConfig()
        {
            txtCompanyAddress.Text = _SysConfig.CompanyAddress;
            txtCompanyName.Text = _SysConfig.CompanyName;
            txtCompanyRegNo.Text = _SysConfig.CompanyRegNo;
            btnAddDetails.Enabled = _SysConfig.Id != 0;
            RefreshGrid(_SysConfig.ConfigDetails);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SysConfig = GetFormData();
            if (IsValidData(_SysConfig))
            {
                _Service.SaveSystemConfig(_SysConfig);
                MessageBox.Show("System configuration saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsValidData(SystemConfig _SysConfig)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
            {
                builder.Append("Please enter Company Name.\n");
            }
            if (string.IsNullOrEmpty(txtCompanyAddress.Text.Trim()))
            {
                builder.Append("Please enter Company Address.\n");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                MessageBox.Show(builder.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private SystemConfig GetFormData()
        {
            if (_SysConfig == null) _SysConfig = new SystemConfig();
            _SysConfig.CompanyAddress = txtCompanyAddress.Text.Trim();
            _SysConfig.CompanyName = txtCompanyName.Text.Trim();
            _SysConfig.CompanyRegNo = txtCompanyRegNo.Text.Trim();
            return _SysConfig;
        }

        private void grdConfigDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SystemConfigDetail configDetail = grdConfigDetails.CurrentRow.DataBoundItem as SystemConfigDetail;
            new ConfigDetailSave(configDetail, RefreshGrid).ShowDialog();
        }
    }
}
