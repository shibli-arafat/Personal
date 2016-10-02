using System;
using CrystalDecisions.CrystalReports.Engine;

namespace ArmyTraining
{
    public partial class TrainingReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument doc = new ReportDocument();
            doc.Load(Server.MapPath(@"Reports\TrainingCrystalReport.rpt"));
            doc.SetDataSource(Session["ReportData"]);
            CrystalReportViewer1.ReportSource = doc;
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            CrystalReportViewer1.BestFitPage = true;
        }
    }
}
