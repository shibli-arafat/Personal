using System;
using ArmyTraining.Internal;
using ArmyTraining.Model;
using CrystalDecisions.CrystalReports.Engine;

namespace ArmyTraining
{
    public partial class YearlyBudgetReportViewer : System.Web.UI.Page
    {
        private YearlyBudgetInternal _Internal;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Internal = new YearlyBudgetInternal();
            YearlyBudgetReportCollection data = _Internal.GetYearlyBudgetReports();
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath(@"Reports\YearlyBudgetCrystalReport.rpt"));
            doc.SetDataSource(data);
            CrystalReportViewer1.DisplayToolbar = true;
            CrystalReportViewer1.ReportSource = doc;
            CrystalReportViewer1.BestFitPage = true;
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
        }
    }
}
