using System;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class MonthlyDepositBulkSave : BaseSaveForm
    {
        private RefreshGridDataHandler<MonthlyDepositCollection> _RefreshGridData;
        private MonthlyDepositCollection _MonthlyDeposits;

        public SystemConfig SystemConfig { get; set; }

        public MonthlyDepositBulkSave(RefreshGridDataHandler<MonthlyDepositCollection> refreshGridData)
        {
            _RefreshGridData = refreshGridData;
            InitializeComponent();
            this.btnSave.Click += btnSaveClick;
            this.btnDelete.Click += btnDeleteClick;
            this.btnClear.Click += btnClearClick;
        }

        private void MonthlyDepositSave_Load(object sender, EventArgs e)
        {
            InitData();
            DisplayData();
            btnDelete.Enabled = false;
        }

        protected override void CollectData()
        {
            _MonthlyDeposits = new MonthlyDepositCollection();
            double amount = double.Parse(txtAmount.Text);
            SystemConfigDetail configDetail = SystemConfig.GetCurrentConfigDetail();
            if (amount <= 0
                || amount % configDetail.MonthlyDepositAmount != 0)
            {
                throw new Exception(string.Format(@"Invalid amount. The amount must be an integral multiple of ""{0}""", configDetail.MonthlyDepositAmount));
            }
            int month = 0;
            int year = 0;
            Member depositedBy = cmbDepositedBy.SelectedItem as Member;
            MonthlyDeposit latestDeposit = Service.GetLatestMonthlyDeposit(depositedBy.Id);
            int months = (int)(amount / configDetail.MonthlyDepositAmount);
            if (latestDeposit != null)
            {
                month = (int)latestDeposit.Month;
                year = latestDeposit.Year;
            }
            for (int i = 0; i < months; i++)
            {
                MonthlyDeposit deposit = CreateNextMonthlyDeposit(year, month, configDetail.MonthlyDepositAmount, depositedBy);
                month = (int)deposit.Month;
                year = deposit.Year;
                _MonthlyDeposits.Add(deposit);
            }
        }

        private MonthlyDeposit CreateNextMonthlyDeposit(int year, int month, double amount, Member depositedBy)
        {
            int nextYear;
            int nextMonth;
            if (month == 0 && year == 0)
            {
                nextYear = 2012;
                nextMonth = 7;
            }
            else
            {
                if (month == 12)
                {
                    nextMonth = 1;
                    nextYear = year + 1;
                }
                else
                {
                    nextMonth = month + 1;
                    nextYear = year;
                }
            }
            MonthlyDeposit deposit = new MonthlyDeposit();
            deposit.Year = nextYear;
            deposit.Month = (Month)Enum.Parse(typeof(Month), nextMonth.ToString());
            deposit.Amount = amount;
            deposit.CollectedBy = LoggedInUser;
            deposit.DepositedBy = depositedBy;
            deposit.DepositedOn = dtpDepositedOn.GetDate();
            return deposit;
        }

        protected override void ClearData()
        {
            cmbDepositedBy.SelectedIndex = 0;
            txtAmount.Text = string.Empty;
            txtComment.Text = string.Empty;
        }

        protected override void InitData()
        {
            MemberCollection members = Service.GetMembers(string.Empty);
            members.Insert(0, new Member("<<Please Select>>"));
            members.Sort(new MemberComparer());
            cmbDepositedBy.DataSource = members;
            txtCollectedBy.Tag = LoggedInUser;
            txtCollectedBy.Text = LoggedInUser.Name;
        }

        protected override bool ValidateData()
        {
            if (cmbDepositedBy.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a member who is depositing", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepositedBy.Focus();
                return false;
            }
            double amount = 0;
            if (!double.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Please enter amount in numeric form.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        protected override void RefreshGridData()
        {
            _RefreshGridData(_MonthlyDeposits);
        }

        protected override void SaveData()
        {
            foreach (MonthlyDeposit deposit in _MonthlyDeposits)
            {
                Service.SaveMonthlyDeposit(deposit, SystemConfig.GetCurrentConfigDetail().DepositCharge);
            }
        }
    }
}
