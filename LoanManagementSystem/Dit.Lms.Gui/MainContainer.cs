using System;
using System.Windows.Forms;

namespace Dit.Lms.Gui
{
    public partial class MainContainer : BaseForm
    {
        private MonthlyDepositList _DepositList;
        private LoanDisbursementList _DisbursmentList;
        private LoanRepaymentList _RepaymentList;
        private IncomeList _IncomeList;
        private ExpenseList _ExpenseList;
        private IncomeHeadList _IncomeHeadList;
        private ExpenseHeadList _ExpenseHeadList;
        private MemberList _MemberList;
        private UserList _UserList;

        public MainContainer()
        {
            InitializeComponent();
            if (_DepositList == null)
            {
                _DepositList = new MonthlyDepositList(this);
            }
            if (_DisbursmentList == null)
            {
                _DisbursmentList = new LoanDisbursementList(this);
            }
            if (_RepaymentList == null)
            {
                _RepaymentList = new LoanRepaymentList(this);
            }
            if (_ExpenseList == null)
            {
                _ExpenseList = new ExpenseList(this);
            }
            if (_IncomeList == null)
            {
                _IncomeList = new IncomeList(this);
            }
            if (_ExpenseHeadList == null)
            {
                _ExpenseHeadList = new ExpenseHeadList(this);
            }
            if (_IncomeHeadList == null)
            {
                _IncomeHeadList = new IncomeHeadList(this);
            }
            if (_MemberList == null)
            {
                _MemberList = new MemberList(this);
            }
            if (_UserList == null)
            {
                _UserList = new UserList(this);
            }
            this.Text += string.Format(@" ***[You are logged in as ""{0}""]***", LoggedInUser.Name);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (_DepositList.IsDisposed) _DepositList = new MonthlyDepositList(this);
            _DepositList.MdiParent = this;
            if (!_DepositList.Visible)
                _DepositList.Show();
            else
                _DepositList.Activate();
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not currently available.\nIt will be available later on.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

            //if (_DisbursmentList.IsDisposed) _DisbursmentList = new LoanDisbursementList(this);
            //_DisbursmentList.MdiParent = this;
            //if (!_DisbursmentList.Visible)
            //    _DisbursmentList.Show();
            //else
            //    _DisbursmentList.Activate();
        }

        private void btnIncomeHead_Click(object sender, EventArgs e)
        {
            if (_IncomeHeadList.IsDisposed) _IncomeHeadList = new IncomeHeadList(this);
            _IncomeHeadList.MdiParent = this;
            if (!_IncomeHeadList.Visible)
                _IncomeHeadList.Show();
            else
                _IncomeHeadList.Activate();
        }

        private void btnExpenseHead_Click(object sender, EventArgs e)
        {
            if (_ExpenseHeadList.IsDisposed) _ExpenseHeadList = new ExpenseHeadList(this);
            _ExpenseHeadList.MdiParent = this;
            if (!_ExpenseHeadList.Visible)
                _ExpenseHeadList.Show();
            else
                _ExpenseHeadList.Activate();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (_UserList.IsDisposed) _UserList = new UserList(this);
            _UserList.MdiParent = this;
            if (!_UserList.Visible)
                _UserList.Show();
            else
                _UserList.Activate();
        }

        private void btnRepayment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not currently available.\nIt will be available later on.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            //if (_RepaymentList.IsDisposed) _RepaymentList = new LoanRepaymentList(this);
            //_RepaymentList.MdiParent = this;
            //if (!_RepaymentList.Visible)
            //    _RepaymentList.Show();
            //else
            //    _RepaymentList.Activate();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            if (_IncomeList.IsDisposed) _IncomeList = new IncomeList(this);
            _IncomeList.MdiParent = this;
            if (!_IncomeList.Visible)
                _IncomeList.Show();
            else
                _IncomeList.Activate();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            if (_ExpenseList.IsDisposed) _ExpenseList = new ExpenseList(this);
            _ExpenseList.MdiParent = this;
            if (!_ExpenseList.Visible)
                _ExpenseList.Show();
            else
                _ExpenseList.Activate();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            if (_MemberList.IsDisposed) _MemberList = new MemberList(this);
            _MemberList.MdiParent = this;
            _MemberList.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            _MemberList.Left = 100;
            _MemberList.Top = 60;
            if (!_MemberList.Visible)
                _MemberList.Show();
            else
                _MemberList.Activate();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            new AboutUs().ShowDialog();
        }

        private void btnBackupDatabase_Click(object sender, EventArgs e)
        {
            new ControlPanel().ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new ReportMenu().ShowDialog();
        }
    }
}
