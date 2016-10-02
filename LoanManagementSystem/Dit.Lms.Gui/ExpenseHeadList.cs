using System;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class ExpenseHeadList : BaseForm
    {
        private Form _MdiParent;
        private ExpenseHeadSave _ExpenseHeadForm;
        private ExpenseHead _ExpenseHead;
        private ExpenseHeadCollection _ExpenseHeads;

        public ExpenseHeadList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdExpenseHeadList.AutoGenerateColumns = false;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _ExpenseHead = new ExpenseHead();
            ShowSaveForm();
        }

        private void ShowSaveForm()
        {
            if (_ExpenseHeadForm == null || _ExpenseHeadForm.IsDisposed) _ExpenseHeadForm = new ExpenseHeadSave(_ExpenseHead, RefreshGridData);
            _ExpenseHeadForm.MdiParent = _MdiParent;
            if (!_ExpenseHeadForm.Visible) _ExpenseHeadForm.Show();
            else _ExpenseHeadForm.Activate();
        }

        private void ExpenseHeadList_Load(object sender, EventArgs e)
        {
            _ExpenseHeads = Service.GetExpenseHeads();
            BindExpenseHeads();
        }

        private void RefreshGridData(ExpenseHead expenseHead)
        {
            _ExpenseHeads.Update(expenseHead);
            BindExpenseHeads();
        }

        private void BindExpenseHeads()
        {
            this.BindingSource.DataSource = _ExpenseHeads;
            this.BindingSource.ResetBindings(false);
            grdExpenseHeadList.DataSource = this.BindingSource;
        }

        private void grdExpenseHeadList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ExpenseHead = grdExpenseHeadList.CurrentRow.DataBoundItem as ExpenseHead;
            ShowSaveForm();
        }
    }
}
