using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class IncomeSave : BaseSaveForm
    {
        private RefreshGridDataHandler<Income> _RefreshGridData;
        private Income _Income;

        public IncomeSave(Income income, RefreshGridDataHandler<Income> refreshGridData)
        {
            _Income = income;
            _RefreshGridData = refreshGridData;
            InitializeComponent();
            InitData();
            btnSave.Click += btnSaveClick;
            btnDelete.Click += btnDeleteClick;
            btnClear.Click += btnClearClick;
        }

        private void IncomeSave_Load(object sender, System.EventArgs e)
        {
            DisplayData();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 && txtAmount.Text.Contains(".") || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        protected override void InitData()
        {
            IncomeHeadCollection incomeHeads = Service.GetIncomeHeads();
            if (_Income.Head.Id != 0 && !incomeHeads.Exists(_Income.Head.Id))
            {
                incomeHeads.Add(_Income.Head);
            }
            incomeHeads.Insert(0, new IncomeHead("<<Please Select>>", false));
            cmbIncomeHead.DataSource = incomeHeads;
        }

        protected override void DisplayData()
        {
            btnDelete.Enabled = _Income.Id != 0;
            cmbIncomeHead.SetSelectedItem(_Income.Head);
            txtComment.Text = _Income.Comment;
            txtAmount.Text = _Income.Amount.ToString();
            dtpDate.Value = _Income.IncomeOn;
            if (_Income.Head.Id == 1)
            {
                MessageBox.Show("This is a system generated income.\nYou can't edit this.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = btnDelete.Enabled = btnClear.Enabled = false;
            }
        }

        protected override void CollectData()
        {
            _Income.Head = cmbIncomeHead.SelectedItem as IncomeHead;
            _Income.Amount = double.Parse(txtAmount.Text);
            _Income.Comment = txtComment.Text;
            _Income.IncomeOn = dtpDate.GetDate();
            _Income.IsActive = true;
        }

        protected override void ClearData()
        {
            _Income = new Income();
            DisplayData();
        }

        protected override bool ValidateData()
        {
            StringBuilder builder = new StringBuilder();
            if (cmbIncomeHead.SelectedIndex == 0)
            {
                builder.AppendLine("Please select an income head.");
            }
            IncomeHead selectedHead = cmbIncomeHead.SelectedItem as IncomeHead;
            if (selectedHead != null
                && selectedHead.Id == 1)
            {
                builder.AppendLine(string.Format(@"The income head ""{0}"" can only be used by system. Please select another income head.", selectedHead.Name));
                cmbIncomeHead.SelectedIndex = 0;
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
            _RefreshGridData(_Income);
        }

        protected override void DeleteData()
        {
            Service.DeleteIncome(_Income.Id);
            _Income.IsActive = false;
        }

        protected override void SaveData()
        {
            Service.SaveIncome(_Income);
        }
    }
}
