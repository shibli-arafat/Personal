using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class ExpenseHeadSave : BaseSaveForm
    {
        private RefreshGridDataHandler<ExpenseHead> _RefreshGridData;
        private ExpenseHead _ExpenseHead;

        public ExpenseHeadSave(ExpenseHead expenseHead, RefreshGridDataHandler<ExpenseHead> refreshGridData)
        {
            _ExpenseHead = expenseHead;
            _RefreshGridData = refreshGridData;
            InitializeComponent();
            btnSave.Click += btnSaveClick;
            btnDelete.Click += btnDeleteClick;
            btnClear.Click += btnClearClick;
        }

        private void ExpenseHeadSave_Load(object sender, System.EventArgs e)
        {
            DisplayData();
        }

        protected override void DisplayData()
        {
            txtExpenseHead.Text = _ExpenseHead.Name;
            btnDelete.Enabled = _ExpenseHead.Id != 0;
        }

        protected override void CollectData()
        {
            _ExpenseHead.Name = txtExpenseHead.Text.Trim();
        }

        protected override void ClearData()
        {
            _ExpenseHead = new ExpenseHead();
            DisplayData();
        }

        protected override bool ValidateData()
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(txtExpenseHead.Text.Trim()))
            {
                builder.AppendLine("Expense head can't be blank.");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                MessageBox.Show(builder.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        protected override void RefreshGridData()
        {
            _RefreshGridData(_ExpenseHead);
        }

        protected override void DeleteData()
        {
            Service.DeleteExpenseHead(_ExpenseHead.Id);
            _ExpenseHead.IsActive = false;
        }

        protected override void SaveData()
        {
            Service.SaveExpenseHead(_ExpenseHead);
        }

        protected override void InitData() { }
    }
}
