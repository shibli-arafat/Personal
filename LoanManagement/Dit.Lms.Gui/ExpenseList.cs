using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class ExpenseList : BaseForm
    {
        private Form _MdiParent;
        private ExpenseSave _ExpenseSaveForm;
        private Expense _Expense;
        private ExpenseCollection _Expenses;

        public ExpenseList(Form mdiParent)
        {
            _MdiParent = mdiParent;
            InitializeComponent();
            grdExpenseList.AutoGenerateColumns = false;
        }

        private void RefreshGridData(Expense expense)
        {
            _Expenses.Update(expense);
            BindExpenses();
        }

        private void BindExpenses()
        {
            this.BindingSource.DataSource = _Expenses;
            this.BindingSource.ResetBindings(false);
            grdExpenseList.DataSource = this.BindingSource;
        }

        private void ExpenseList_Load(object sender, System.EventArgs e)
        {            
            ExpenseHeadCollection expenseHeads = Service.GetExpenseHeads();
            expenseHeads.Insert(0, new ExpenseHead("All", false));
            cmbExpenseHeads.DataSource = expenseHeads;
            ShowSearchResult();
        }

        private void btnAddNew_Click(object sender, System.EventArgs e)
        {
            _Expense = new Expense();
            ShowExpenseForm();
        }

        private void ShowExpenseForm()
        {
            if (_ExpenseSaveForm == null || _ExpenseSaveForm.IsDisposed) _ExpenseSaveForm = new ExpenseSave(_Expense, RefreshGridData);
            _ExpenseSaveForm.MdiParent = _MdiParent;
            if (!_ExpenseSaveForm.Visible) _ExpenseSaveForm.Show();
            else _ExpenseSaveForm.Activate();
        }

        private void grdExpenseList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Expense = grdExpenseList.CurrentRow.DataBoundItem as Expense;
            ShowExpenseForm();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            ShowSearchResult();
        }

        private void ShowSearchResult()
        {
            _Expenses = Service.GetExpenses(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, (cmbExpenseHeads.SelectedItem as ExpenseHead).Id);
            BindExpenses();
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

        private void cmbExpenseHeads_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowSearchResult();
            }
        }
    }
}
