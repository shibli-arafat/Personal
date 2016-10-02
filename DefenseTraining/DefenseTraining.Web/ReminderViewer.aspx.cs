using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class ReminderViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EventBol bol = new EventBol();
            ReportDocument doc = new ReportDocument();
            string rptType = Request.QueryString["reportType"];
            string sortBy = Request.QueryString["sortBy"];
            if (string.IsNullOrEmpty(rptType))
            {
                List<EventReminder> reminders = bol.GetReminders(Convert.ToInt32(sortBy));
                doc.Load(Server.MapPath("~/Reports/EventReminderReport.rpt"));
                doc.Refresh();
                doc.SetDataSource(reminders);
                rptViewer.ReportSource = doc;
            }
            else
            {
                string year = Request.QueryString["year"];
                List<JointStatement> alotments = new PortalBol().GetJointStatements(int.Parse(year));
                doc.Load(Server.MapPath("~/Reports/JointStatementReport.rpt"));
                doc.Refresh();
                doc.SetDataSource(alotments);
                rptViewer.ReportSource = doc;
                doc.SetParameterValue("@Year", year);
            }
            rptViewer.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            rptViewer.BestFitPage = true;
        }
    }
}