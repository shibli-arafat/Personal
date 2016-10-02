using System;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class MonthlyDepositEdit : Form
    {
        private MonthlyDeposit _Deposit;
        private RefreshGridDataHandler<MonthlyDeposit> _RefreshGridData;
        private ILoanService _Service;
        private SystemConfig _SystemConfig;

        public MonthlyDepositEdit(MonthlyDeposit deposit, RefreshGridDataHandler<MonthlyDeposit> refreshGridData, ILoanService service, SystemConfig systemConfig)
        {
            InitializeComponent();
            _Deposit = deposit;
            _RefreshGridData = refreshGridData;
            _Service = service;
            _SystemConfig = systemConfig;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _Deposit.Amount = double.Parse(txtAmount.Text);
                _Deposit.Comment = txtComment.Text;
                _Deposit.DepositedOn = dtpDepositedOn.Value;
                _Service.SaveMonthlyDeposit(_Deposit, _SystemConfig.GetCurrentConfigDetail().DepositCharge);
                _RefreshGridData(_Deposit);
                MessageBox.Show("Data saved successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the record.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _Service.DeleteMonthlyDeposit(_Deposit.Id);
                    _RefreshGridData(_Deposit);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MonthlyDepositEdit_Load(object sender, EventArgs e)
        {
            txtAmount.Text = _Deposit.Amount.ToString();
            txtCollectedBy.Text = _Deposit.CollectedBy.Name;
            txtComment.Text = _Deposit.Comment;
            txtDepositedById.Text = _Deposit.DepositedBy.MemberId.ToString();
            txtDepositedBy.Text = _Deposit.DepositedBy.Name;
            dtpDepositedOn.Value = _Deposit.DepositedOn;
            txtMonth.Text = _Deposit.Month.ToString();
            txtYear.Text = _Deposit.Year.ToString();
        }
    }
}
