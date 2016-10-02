using System;
using System.Windows.Forms;

namespace Dit.Lms.Gui
{
    public partial class ReportMenu : Form
    {
        public ReportMenu()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            new MemberReportWindow().ShowDialog();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            new MonthlyDepositReportWindow().ShowDialog();
        }

        private void btnIncomeReport_Click(object sender, EventArgs e)
        {
            new IncomeReportWindow().ShowDialog();
        }

        private void btnExpenseReport_Click(object sender, EventArgs e)
        {
            new ExpenseReportWindow().ShowDialog();
        }

        private void btnLoanReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not currently available.\nIt will be available later on.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
