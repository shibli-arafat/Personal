using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Dit.Lms.Api;
using Dit.Lms.Gui.Reports;

namespace Dit.Lms.Gui
{
    public partial class MemberReportWindow : Form
    {
        private ILoanService _Service;
        private SystemConfig _SysConfig;

        public MemberReportWindow()
        {
            _Service = LoanServiceFactory.CreateLoanService();
            InitializeComponent();
            _SysConfig = _Service.GetSystemConfig(1);
        }

        private void rdoIndividual_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = txtMemberId.Visible = rdoIndividual.Checked;
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void txtMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void ShowReport()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ReportClass report;
                MemberCollection members = new MemberCollection();
                if (rdoAll.Checked)
                {
                    members = _Service.GetMembers(string.Empty);
                    report = new MemberReportAll();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtMemberId.Text))
                    {
                        MessageBox.Show("Please enter Member ID");
                        txtMemberId.Focus();
                        return;
                    }
                    Member member = _Service.GetMemberByMemberId(int.Parse(txtMemberId.Text));
                    if (member != null && member.Id > 0)
                    {
                        members.Add(member);
                    }
                    report = new MemberReportDetail();
                }
                if (members.Count == 0)
                {
                    MessageBox.Show("No member report found with the condition you selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                report.SetDataSource(members.ToReportData());
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

        private void rdoIndividual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }

        private void rdoAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowReport();
            }
        }
    }
}
