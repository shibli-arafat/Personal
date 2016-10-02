using System;
using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class ConfigDetailSave : Form
    {
        private SystemConfigDetail _ConfigDetail;
        private ILoanService _Service;
        public delegate void RefreshConfigDetailsHandler(SystemConfigDetailCollection configDetails);
        private RefreshConfigDetailsHandler _RefreshHandler;

        public ConfigDetailSave(SystemConfigDetail configDetail, RefreshConfigDetailsHandler refreshHandler)
        {
            _ConfigDetail = configDetail;
            _RefreshHandler = refreshHandler;
            _Service = LoanServiceFactory.CreateLoanService();
            InitializeComponent();
        }

        private void txtYearFrom_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYearFrom.Text))
            {
                txtYearTo.Text = string.Empty;
                return;
            }
            txtYearTo.Text = (int.Parse(txtYearFrom.Text) + 1).ToString();
        }

        private void txtYearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _ConfigDetail = GetFormData();
                if (IsValidData(_ConfigDetail))
                {
                    _Service.SaveConfigDetail(_ConfigDetail);
                    SystemConfigDetailCollection configDetails = _Service.GetConfigDetails(_ConfigDetail.SysConfigId);
                    _RefreshHandler(configDetails);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private SystemConfigDetail GetFormData()
        {
            if (_ConfigDetail == null) _ConfigDetail = new SystemConfigDetail();
            _ConfigDetail.YearFrom = int.Parse(txtYearFrom.Text.Trim());
            _ConfigDetail.MaxLoanAmountInPercent = int.Parse(txtMaxLoanInPercent.Text.Trim());
            _ConfigDetail.MonthlyDepositAmount = double.Parse(txtDepositAmount.Text.Trim());
            _ConfigDetail.DepositCharge = double.Parse(txtDepositCharge.Text.Trim());
            return _ConfigDetail;
        }

        private void ConfigDetailSave_Load(object sender, EventArgs e)
        {
            PopulateConfigDetail(_ConfigDetail);
        }

        private void PopulateConfigDetail(SystemConfigDetail _ConfigDetail)
        {
            txtYearFrom.Text = _ConfigDetail.YearFrom.ToString();
            txtDepositAmount.Text = _ConfigDetail.MonthlyDepositAmount.ToString();
            txtMaxLoanInPercent.Text = _ConfigDetail.MaxLoanAmountInPercent.ToString();
            txtDepositCharge.Text = _ConfigDetail.DepositCharge.ToString();
            btnDelete.Enabled = _ConfigDetail.Id != 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ConfigDetail = new SystemConfigDetail();
            PopulateConfigDetail(_ConfigDetail);
        }

        private bool IsValidData(SystemConfigDetail configDetail)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(txtYearFrom.Text.Trim()) || int.Parse(txtYearFrom.Text.Trim()) == 0)
            {
                builder.Append("Please enter Fiscal Year.\n");
            }
            if (string.IsNullOrEmpty(txtDepositAmount.Text.Trim()) || double.Parse(txtDepositAmount.Text.Trim()) == 0)
            {
                builder.Append("Please enter Deposit Amount.\n");
            }
            if (string.IsNullOrEmpty(txtMaxLoanInPercent.Text.Trim()) || double.Parse(txtMaxLoanInPercent.Text.Trim()) == 0)
            {
                builder.Append("Please enter Max. Loan in Percent.\n");
            }
            if (string.IsNullOrEmpty(txtDepositCharge.Text.Trim()) || double.Parse(txtDepositCharge.Text.Trim()) == 0)
            {
                builder.Append("Please enter Deposit Charge.\n");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                MessageBox.Show(builder.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sere you want to delete the record.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Service.DeleteSysConfigDetail(_ConfigDetail.Id);
                    SystemConfigDetailCollection configDetails = _Service.GetConfigDetails(_ConfigDetail.SysConfigId);
                    _RefreshHandler(configDetails);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtDepositAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void txtMaxLoanInPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void txtDepositCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }
    }
}
