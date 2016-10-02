using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Dit.Lms.Api;
using Dit.Lms.Gui.Reports;

namespace Dit.Lms.Gui
{
    public partial class MonthlyDepositReportWindow : Form
    {
        private ILoanService _Service;
        private SystemConfig _SysConfig;
        private MonthlyDeposit _LatestDeposit;

        public MonthlyDepositReportWindow()
        {
            _Service = LoanServiceFactory.CreateLoanService();
            InitializeComponent();
            _SysConfig = _Service.GetSystemConfig(1);
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            if (_SysConfig == null || _SysConfig.GetCurrentConfigDetail() == null)
            {
                MessageBox.Show("No configuration data is available for current year. Please go to control panel and add configuration data and then try to generate report", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(txtMemberId.Text))
                {
                    MessageBox.Show("Please enter Member ID\n", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMemberId.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtYearFrom.Text))
                {
                    MessageBox.Show("Please enter Year From\n", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtYearFrom.Focus();
                    return;
                }
                Member member = _Service.GetMemberByMemberId(int.Parse(txtMemberId.Text));
                if (member == null)
                {
                    MessageBox.Show("You have entered invalid member ID\nPlease enter a valid member ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMemberId.Focus();
                    return;
                }
                _LatestDeposit = _Service.GetLatestMonthlyDeposit(member.Id);
                MonthlyDepositCollection deposits = _Service.GetMonthlyDeposits(int.Parse(txtMemberId.Text), int.Parse(txtYearFrom.Text));
                if (deposits == null || deposits.Count == 0)
                {
                    deposits = new MonthlyDepositCollection();
                    MonthlyDeposit deposit = new MonthlyDeposit();
                    deposit.DepositedBy = member;
                    deposit.Month = Month.July;
                    deposit.Year = int.Parse(txtYearFrom.Text);
                    deposits.Add(deposit);
                }
                ReportClass report = new MonthlyDepositReport();
                report.SetDataSource(deposits.ToReportData());
                report.SetParameterValue("@Company", _SysConfig.CompanyName);
                report.SetParameterValue("@RegNo", string.Format("Reg No: {0}", _SysConfig.CompanyRegNo));
                report.SetParameterValue("@Address", string.Format("Address: {0}", _SysConfig.CompanyAddress));
                report.SetParameterValue("@AmountDue", _LatestDeposit.GetAmountDue(_SysConfig.GetCurrentConfigDetail().MonthlyDepositAmount));
                ReportViewerWindow viewer = new ReportViewerWindow(report);
                viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtYearFrom_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYearFrom.Text))
            {
                txtYearTo.Text = string.Empty;
                return;
            }
            txtYearTo.Text = (int.Parse(txtYearFrom.Text) + 1).ToString();
        }

        private void txtYearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void txtMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }
    }
}
