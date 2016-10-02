using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class ExpenseSave : BaseSaveForm
    {
        private RefreshGridDataHandler<Expense> _RefreshGridData;
        private Expense _Expense;

        public ExpenseSave(Expense expense, RefreshGridDataHandler<Expense> refreshGridData)
        {
            _Expense = expense;
            _RefreshGridData = refreshGridData;
            InitializeComponent();
            InitData();
            btnSave.Click += btnSaveClick;
            btnDelete.Click += btnDeleteClick;
            btnClear.Click += btnClearClick;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 && txtAmount.Text.Contains(".") || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void ExpenseSave_Load(object sender, System.EventArgs e)
        {
            DisplayData();
        }

        protected override void InitData()
        {
            ExpenseHeadCollection expenseHeads = Service.GetExpenseHeads();
            if (_Expense.Head.Id != 0 && !expenseHeads.Exists(_Expense.Head.Id))
            {
                expenseHeads.Add(_Expense.Head);
            }
            expenseHeads.Insert(0, new ExpenseHead("<<Please select>>", false));
            cmbExpenseHead.DataSource = expenseHeads;
        }

        protected override void CollectData()
        {
            _Expense.Head = cmbExpenseHead.SelectedItem as ExpenseHead;
            _Expense.Amount = double.Parse(txtAmount.Text);
            _Expense.Comment = txtComment.Text;
            _Expense.ExpenseOn = dtpDate.GetDate();
            _Expense.IsActive = true;
        }

        protected override void DisplayData()
        {
            btnDelete.Enabled = _Expense.Id != 0;
            cmbExpenseHead.SetSelectedItem(_Expense.Head);
            txtComment.Text = _Expense.Comment;
            txtAmount.Text = _Expense.Amount.ToString();
            dtpDate.Value = _Expense.ExpenseOn;
        }

        protected override void ClearData()
        {
            _Expense = new Expense();
            DisplayData();
        }

        protected override bool ValidateData()
        {
            StringBuilder builder = new StringBuilder();
            if (cmbExpenseHead.SelectedIndex == 0)
            {
                builder.AppendLine("Please select an expense head.");
            }
            if (string.IsNullOrEmpty(txtAmount.Text) || double.Parse(txtAmount.Text) <= 0)
            {
                builder.AppendLine("Amount can't be blank or zero.");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                MessageBox.Show(builder.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        protected override void RefreshGridData()
        {
            _RefreshGridData(_Expense);
        }

        protected override void DeleteData()
        {
            Service.DeleteExpense(_Expense.Id);
            _Expense.IsActive = false;
        }

        protected override void SaveData()
        {
            Service.SaveExpense(_Expense);
        }
    }
}
