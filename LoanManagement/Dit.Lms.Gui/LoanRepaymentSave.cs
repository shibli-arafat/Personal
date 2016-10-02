using System;
using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class LoanRepaymentSave : BaseSaveForm
    {
        private RefreshGridDataHandler<LoanRepayment> _RefreshGridData;
        private LoanRepayment _LoanRepayment;

        public LoanRepaymentSave(LoanRepayment repayment, RefreshGridDataHandler<LoanRepayment> refreshGridData)
        {
            _LoanRepayment = repayment;
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

        private void LoanRepaymentSave_Load(object sender, System.EventArgs e)
        {
            DisplayData();
        }

        protected override void InitData()
        {
            MemberCollection members = Service.GetMembers(string.Empty);
            Member member = new Member("<<Please Select>>");
            members.Insert(0, member);
            if (_LoanRepayment.RepaidBy.Id != 0 && !members.Exists(_LoanRepayment.RepaidBy.Id))
            {
                members.Add(_LoanRepayment.RepaidBy);
            }
            cmbRepaidBy.DataSource = members;
            members.Sort(new MemberComparer());
            cmbMonth.DataSource = Enum.GetValues(typeof(Month));
            cmbYear.FillYearCombo();
        }

        protected override void CollectData()
        {
            _LoanRepayment.Amount = double.Parse(txtAmount.Text);
            _LoanRepayment.Comment = txtComment.Text;
            _LoanRepayment.CollectedOn = dtpDate.GetDate();
            _LoanRepayment.RepaidBy = cmbRepaidBy.SelectedItem as Member;
            _LoanRepayment.CollectedBy = txtCollectedBy.Tag as User;
            _LoanRepayment.Month = (Month)Enum.Parse(typeof(Month), cmbMonth.SelectedItem.ToString());
            _LoanRepayment.Year = int.Parse(cmbYear.SelectedItem.ToString());
            _LoanRepayment.IsActive = true;
        }

        protected override void DisplayData()
        {
            btnDelete.Enabled = _LoanRepayment.Id != 0;
            cmbRepaidBy.SetSelectedItem(_LoanRepayment.RepaidBy);
            cmbMonth.SelectedItem = _LoanRepayment.Month;
            cmbYear.SelectedItem = _LoanRepayment.Year;
            txtAmount.Text = _LoanRepayment.Amount.ToString();
            dtpDate.Value = _LoanRepayment.CollectedOn;
            txtComment.Text = _LoanRepayment.Comment;
            if (_LoanRepayment.CollectedBy.Id != 0)
            {
                txtCollectedBy.Tag = _LoanRepayment.CollectedBy;
                txtCollectedBy.Text = _LoanRepayment.CollectedBy.Name;
            }
            else
            {
                txtCollectedBy.Tag = LoggedInUser;
                txtCollectedBy.Text = LoggedInUser.Name;
            }
        }

        protected override void ClearData()
        {
            _LoanRepayment = new LoanRepayment();
            DisplayData();
        }

        protected override bool ValidateData()
        {
            StringBuilder errorBuilder = new StringBuilder();
            if (cmbRepaidBy.SelectedIndex == 0)
            {
                errorBuilder.Append("Please select repaid by.\n");
            }
            double amount = 0;
            if (!double.TryParse(txtAmount.Text, out amount) || amount == 0)
            {
                errorBuilder.Append("Please enter a valid amount.\n");
            }
            if (!string.IsNullOrEmpty(errorBuilder.ToString()))
            {
                MessageBox.Show(errorBuilder.ToString(), "Validatin error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        protected override void RefreshGridData()
        {
            _RefreshGridData(_LoanRepayment);
        }

        protected override void DeleteData()
        {
            Service.DeleteLoanRepayment(_LoanRepayment.Id);
            _LoanRepayment.IsActive = false;
        }

        protected override void SaveData()
        {
            Service.SaveLoanRepayment(_LoanRepayment);
        }
    }
}
