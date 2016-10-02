using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class TrainingReportViewer : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                int totalCount = 0;
                string id = Request.QueryString["id"];
                if (string.IsNullOrEmpty(id))
                {
                    TrainingFilter filter = new TrainingFilter();
                    filter.CountryId = int.Parse(Request.QueryString["cid"]);
                    filter.DateFrom = Request.QueryString["df"];
                    filter.DateTo = Request.QueryString["dt"];
                    filter.EventTypeId = int.Parse(Request.QueryString["etid"]);
                    filter.CourseId = int.Parse(Request.QueryString["crsid"]);                    
                    filter.Id = int.Parse(Request.QueryString["tid"]);
                    filter.PersonNo = Request.QueryString["pn"];
                    filter.RankId = int.Parse(Request.QueryString["rid"]);
                    TrainingBol bol = new TrainingBol();
                    List<Training> trainings = bol.GetTrainings(filter, out totalCount);
                    rptViewer.RefreshReport();
                    ReportDocument doc = new ReportDocument();
                    doc.Load(Server.MapPath("~/Reports/TrainingListReport.rpt"));
                    doc.SetDataSource(trainings);
                    rptViewer.ReportSource = doc;
                    rptViewer.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                    rptViewer.BestFitPage = true;
                }                
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