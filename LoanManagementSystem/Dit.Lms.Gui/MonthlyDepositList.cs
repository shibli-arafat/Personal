using System;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class MonthlyDepositList : BaseForm
    {
        private Form _MdiParent;
        private MonthlyDepositBulkSave _MonthlyDepositBulkForm;
        private MonthlyDepositEdit _MonthlyDepositEditForm;
        private MonthlyDeposit _MonthlyDeposit;
        private MonthlyDepositCollection _MonthlyDeposits;
        private SystemConfig _SystemConfig;

        public MonthlyDepositList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdDepositList.AutoGenerateColumns = false;
            _MonthlyDeposits = new MonthlyDepositCollection();
        }

        private void RefreshGridData(MonthlyDepositCollection gridData)
        {
            //_MonthlyDeposits.Update(gridData);
            //BindMonthlyDeposits();
        }

        private void RefreshGridData(MonthlyDeposit gridData)
        {
            _MonthlyDeposits.Update(gridData);
            BindMonthlyDeposits();
        }

        private void BindMonthlyDeposits()
        {
            this.BindingSource.DataSource = _MonthlyDeposits;
            this.BindingSource.ResetBindings(false);
            grdDepositList.DataSource = this.BindingSource;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _MonthlyDeposit = new MonthlyDeposit();
            ShowMonthlyDepositBulkForm();
        }

        private void ShowMonthlyDepositBulkForm()
        {
            if (_MonthlyDepositBulkForm == null || _MonthlyDepositBulkForm.IsDisposed) _MonthlyDepositBulkForm = new MonthlyDepositBulkSave(RefreshGridData);
            _MonthlyDepositBulkForm.MdiParent = _MdiParent;
            _MonthlyDepositBulkForm.SystemConfig = _SystemConfig;
            if (!_MonthlyDepositBulkForm.Visible) _MonthlyDepositBulkForm.Show();
            else _MonthlyDepositBulkForm.Activate();
        }

        private void ShowMonthlyDepositEditForm()
        {
            if (_MonthlyDepositEditForm == null || _MonthlyDepositEditForm.IsDisposed) _MonthlyDepositEditForm = new MonthlyDepositEdit(_MonthlyDeposit, RefreshGridData, Service, _SystemConfig);
            _MonthlyDepositEditForm.MdiParent = _MdiParent;
            if (!_MonthlyDepositEditForm.Visible) _MonthlyDepositEditForm.Show();
            else _MonthlyDepositEditForm.Activate();
        }

        private void grdDepositList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _MonthlyDeposit = grdDepositList.CurrentRow.DataBoundItem as MonthlyDeposit;
            ShowMonthlyDepositEditForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowSearchResult();
        }

        private void ShowSearchResult()
        {
            if (string.IsNullOrEmpty(txtMemberId.Text))
            {
                MessageBox.Show("Please enter Member ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMemberId.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtYearFrom.Text))
            {
                MessageBox.Show("Please enter Fiscal Year", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtYearFrom.Focus();
                return;
            }
            _MonthlyDeposits = Service.GetMonthlyDeposits(int.Parse(txtMemberId.Text), int.Parse(txtYearFrom.Text));
            BindMonthlyDeposits();
        }

        private void txtYearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowSearchResult();
            }
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
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

        private void txtMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtYearFrom.Focus();
            }
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void MonthlyDepositList_Load(object sender, EventArgs e)
        {
            _SystemConfig = Service.GetSystemConfig(1);
        }
    }
}
