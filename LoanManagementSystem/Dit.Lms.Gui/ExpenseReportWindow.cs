using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Dit.Lms.Api;
using Dit.Lms.Gui.Reports;

namespace Dit.Lms.Gui
{
    public partial class ExpenseReportWindow : Form
    {
        private ILoanService _Service;
        private SystemConfig _SysConfig;

        public ExpenseReportWindow()
        {
            InitializeComponent();
            _Service = LoanServiceFactory.CreateLoanService();
            _SysConfig = _Service.GetSystemConfig(1);
        }

        private void IncomeReportWindow_Load(object sender, EventArgs e)
        {
            ExpenseHeadCollection expenseHeads = _Service.GetExpenseHeads();
            expenseHeads.Insert(0, new ExpenseHead("All", false));
            cmbExpenseHeads.DataSource = expenseHeads;
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ExpenseCollection expenses = _Service.GetExpenses(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, (cmbExpenseHeads.SelectedItem as ExpenseHead).Id);
                if (expenses == null || expenses.Count == 0)
                {
                    MessageBox.Show("No expense report found with the condition you selected.", "Infomraton", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ReportClass report = new ExpenseReportHeadWise();
                if (rdoDateWise.Checked)
                {
                    report = new ExpenseReportDateWise();
                }
                report.SetDataSource(expenses.ToReportData());
                report.SetParameterValue("@Company", _SysConfig.CompanyName);
                report.SetParameterValue("@RegNo", string.Format("Reg No: {0}", _SysConfig.CompanyRegNo));
                report.SetParameterValue("@Address", string.Format("Address: {0}", _SysConfig.CompanyAddress));
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

        private void rdoDateWise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }

        private void rdoHeadWise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }

        private void dtpDateFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }

        private void dtpDateTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }

        private void cmbExpenseHeads_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }
    }
}
