using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class BudgetReportViewer : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                BudgetBol bol = new BudgetBol();
                List<Budget> budgets = bol.GetBudgets();
                rptViewer.RefreshReport();
                ReportDocument doc = new ReportDocument();
                doc.Load(Server.MapPath("~/Reports/BudgetReport.rpt"));
                doc.SetDataSource(budgets);
                rptViewer.ReportSource = doc;
                rptViewer.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                rptViewer.BestFitPage = true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}