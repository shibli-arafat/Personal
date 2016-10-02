using System;
using System.Text;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class LoanDisbursementSave : BaseSaveForm
    {
        public RefreshGridDataHandler<LoanDisbursement> _RefreshGridData;
        private LoanDisbursement _Disbursement;

        public LoanDisbursementSave(LoanDisbursement disbursement, RefreshGridDataHandler<LoanDisbursement> refreshGridData)
        {
            _Disbursement = disbursement;
            _RefreshGridData = refreshGridData;
            InitializeComponent();
            btnSave.Click += btnSaveClick;
            btnDelete.Click += btnDeleteClick;
            btnClear.Click += btnClearClick;
        }

        private void LoanDisbursementSave_Load(object sender, System.EventArgs e)
        {
            InitData();
        }

        protected override void InitData()
        {
            MemberCollection members = Service.GetMembers(string.Empty);
            Member member = new Member("<<Please Select>>");
            members.Insert(0, member);
            if (_Disbursement.DisbursedTo.Id != 0 && !members.Exists(_Disbursement.DisbursedTo.Id))
            {
                members.Add(_Disbursement.DisbursedTo);
            }
            members.Sort(new MemberComparer());
            cmbDisbursedTo.DataSource = members;
            cmbMonth.DataSource = Enum.GetValues(typeof(Month));
            cmbYear.FillYearCombo();
            txtDisbursedBy.Text = LoggedInUser.Name;
            DisplayData();
        }

        protected override void DisplayData()
        {
            btnDelete.Enabled = _Disbursement.Id != 0;
            cmbDisbursedTo.SetSelectedItem(_Disbursement.DisbursedTo);
            cmbMonth.SelectedItem = _Disbursement.Month;
            cmbYear.SelectedItem = _Disbursement.Year;
            txtAmount.Text = _Disbursement.Amount.ToString();
            if (_Disbursement.DisbursedBy.Id != 0)
            {
                txtDisbursedBy.Tag = _Disbursement.DisbursedBy;
                txtDisbursedBy.Text = _Disbursement.DisbursedBy.Name;
            }
            else
            {
                txtDisbursedBy.Tag = LoggedInUser;
                txtDisbursedBy.Text = LoggedInUser.Name;
            }
            txtComment.Text = _Disbursement.Comment;
            dtpDate.Value = _Disbursement.DisbursedOn;
        }

        protected override void CollectData()
        {
            _Disbursement.Amount = double.Parse(txtAmount.Text);
            _Disbursement.Comment = txtComment.Text;
            _Disbursement.DisbursedBy = txtDisbursedBy.Tag as User;
            _Disbursement.DisbursedOn = dtpDate.GetDate();
            _Disbursement.DisbursedTo = cmbDisbursedTo.SelectedItem as Member;
            _Disbursement.Month = (Month)Enum.Parse(typeof(Month), cmbMonth.SelectedItem.ToString());
            _Disbursement.Year = int.Parse(cmbYear.SelectedItem.ToString());
            _Disbursement.IsActive = true;
        }

        protected override void ClearData()
        {
            InitData();
            _Disbursement = new LoanDisbursement();
            _Disbursement.DisbursedBy = LoggedInUser;
            DisplayData();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 && txtAmount.Text.Contains(".") || char.IsLetter(e.KeyChar);
        }

        protected override bool ValidateData()
        {
            StringBuilder builder = new StringBuilder();
            if (cmbDisbursedTo.SelectedIndex == 0)
            {
                builder.AppendLine("Please select distributed to.");
            }
            if (cmbYear.SelectedIndex == 0)
            {
                builder.AppendLine("Please select year.");
            }
            if (string.IsNullOrEmpty(txtAmount.Text) || double.Parse(txtAmount.Text) <= 0)
            {
                builder.AppendLine("Please enter a valid amount.");
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
            _RefreshGridData(_Disbursement);
        }

        protected override void DeleteData()
        {
            _Disbursement.IsActive = false;
            Service.DeleteLoanDisbursement(_Disbursement.Id);
        }

        protected override void SaveData()
        {
            Service.SaveLoanDisbursement(_Disbursement);
        }
    }
}
