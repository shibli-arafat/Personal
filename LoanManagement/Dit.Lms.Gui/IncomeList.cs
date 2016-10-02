using System;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class IncomeList : BaseForm
    {
        private Form _MdiParent;
        private IncomeSave _IncomeForm;
        private Income _Income;
        private IncomeCollection _Incomes;

        public IncomeList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdIncomeList.AutoGenerateColumns = false;
        }

        private void RefreshGridData(Income income)
        {
            _Incomes.Update(income);
            BindIncomes();
        }

        private void BindIncomes()
        {
            this.BindingSource.DataSource = _Incomes;
            this.BindingSource.ResetBindings(false);
            grdIncomeList.DataSource = this.BindingSource;
        }

        private void IncomeList_Load(object sender, EventArgs e)
        {
            IncomeHeadCollection incomeHeads = Service.GetIncomeHeads();
            incomeHeads.Insert(0, new IncomeHead("All", false));
            cmbIncomeHeads.DataSource = incomeHeads;
            _Incomes = new IncomeCollection();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _Income = new Income();
            ShowIncomeForm();
        }

        private void ShowIncomeForm()
        {
            if (_IncomeForm == null || _IncomeForm.IsDisposed) _IncomeForm = new IncomeSave(_Income, RefreshGridData);
            _IncomeForm.MdiParent = _MdiParent;
            if (!_IncomeForm.Visible) _IncomeForm.Show();
            else _IncomeForm.Activate();
        }

        private void grdIncomeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Income = grdIncomeList.CurrentRow.DataBoundItem as Income;
            ShowIncomeForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowSearchResult();
        }

        private void ShowSearchResult()
        {
            _Incomes = Service.GetIncomes(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, (cmbIncomeHeads.SelectedItem as IncomeHead).Id);
            BindIncomes();
        }

        private void dtpDateFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowSearchResult();
            }
        }

        private void dtpDateTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowSearchResult();
            }
        }

        private void cmbIncomeHeads_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowSearchResult();
            }
        }
    }
}
