using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Dit.Lms.Api;
using Dit.Lms.Gui.Reports;

namespace Dit.Lms.Gui
{
    public partial class IncomeReportWindow : Form
    {
        private ILoanService _Service;
        private SystemConfig _SysConfig;

        public IncomeReportWindow()
        {
            InitializeComponent();
            _Service = LoanServiceFactory.CreateLoanService();
            _SysConfig = _Service.GetSystemConfig(1);
        }

        private void IncomeReportWindow_Load(object sender, EventArgs e)
        {
            IncomeHeadCollection incomeHeads = _Service.GetIncomeHeads();
            incomeHeads.Insert(0, new IncomeHead("All", false));
            cmbIncomeHeads.DataSource = incomeHeads;
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
                IncomeCollection incomes = _Service.GetIncomes(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, (cmbIncomeHeads.SelectedItem as IncomeHead).Id);
                if (incomes == null || incomes.Count == 0)
                {
                    MessageBox.Show("No income report found on the condition you selected.", "Infomraton", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ReportClass report = new IncomeReportHeadWise();
                if (rdoDateWise.Checked)
                {
                    report = new IncomeReportDateWise();
                }
                report.SetDataSource(incomes.ToReportData());
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

        private void cmbIncomeHeads_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }
    }
}
