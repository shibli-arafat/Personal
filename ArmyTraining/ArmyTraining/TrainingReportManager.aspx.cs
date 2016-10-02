using System;
using System.Web.UI.WebControls;
using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Model.Reports;
using ArmyTraining.Model.Trainings;
using ArmyTraining.Model.Util;
using ArmyTraining.Presenter;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining
{
    public partial class TrainingReportManager : System.Web.UI.Page, ITrainingReportManagerView
    {
        private TrainingReportManagerPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _Presenter = new TrainingReportManagerPresenter(this);
                _Presenter.PopulateInitialData();

                drpCompletionType.DataSource = Enum.GetValues(typeof(TrainingCompletionType));
                drpCompletionType.DataBind();

                ddlDurationType.DataSource = Enum.GetValues(typeof(DurationType));
                ddlDurationType.DataBind();

                string completion = Request["completion"];
                if (!string.IsNullOrEmpty(completion))
                {
                    BindDataOnCompletionType(completion);
                }
            }
            drpCompletionType.SetTooltip();
            ddlDurationType.SetTooltip();
            ddlCountry.SetTooltip();
            ddlCourseType.SetTooltip();
            ddlCourseLevel.SetTooltip();
            ddlRank.SetTooltip();
            ddlCourse.SetTooltip();
            drpTrainingBkg.SetTooltip();
            drpTrainingLevel.SetTooltip();
        }

        private void BindDataOnCompletionType(string completion)
        {
            ReportFilter filter = new ReportFilter();
            switch (completion)
            {
                case "ongoing":
                    filter.CompletionType = TrainingCompletionType.Ongoing;
                    break;
                case "upcomming":
                    filter.CompletionType = TrainingCompletionType.Upcomming;
                    break;
                case "completed":
                    filter.CompletionType = TrainingCompletionType.Completed;
                    break;
            }
            drpCompletionType.SelectedValue = filter.CompletionType.ToString();
            ShowReportOnFilter(filter);
        }

        protected void ddlCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CourseFilter filter = new CourseFilter();
            filter.CourseTypeId = int.Parse(ddlCourseType.SelectedValue);

            CourseCollection courses = new CourseInternal().GetCourses(filter).Courses;
            ddlCourse.DataSource = courses;
            ddlCourse.DataValueField = "Id";
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            ddlCourse.SetTooltip();
        }

        private void ShowReportOnFilter(ReportFilter filter)
        {
            Session["ReportData"] = _Presenter.GetTrainingReports(filter).PutSerialNo();
            Server.Transfer("~/TrainingReportViewer.aspx");
        }

        public void ShowReport(object sender, EventArgs e)
        {
            try
            {
                _Presenter = new TrainingReportManagerPresenter(this);
                ReportFilter filter = this.CreateReportFilter();
                ShowReportOnFilter(filter);
            }
            catch (ArgumentException ae)
            {
                Response.Write(ae.Message);
            }
        }

        private ReportFilter CreateReportFilter()
        {
            ReportFilter filter = new ReportFilter();
            int duration = 0;
            if (!string.IsNullOrEmpty(txtDuration.Text) && !int.TryParse(txtDuration.Text, out duration))
            {
                throw new ArgumentException(string.Format("Duration {0} is not a valid numeric value.", txtDuration.Text));
            }

            filter.Duration = duration;
            filter.IsUpto = rdUpto.Checked;
            filter.DurationType = (DurationType)Enum.Parse(typeof(DurationType), ddlDurationType.SelectedValue);
            filter.CountryId = int.Parse(ddlCountry.SelectedValue);
            filter.SponsorCountryId = int.Parse(ddlSponsorCountry.SelectedValue);
            filter.RankId = int.Parse(ddlRank.SelectedValue);
            filter.PersonalNo = txtTrainee.Value;
            filter.CourseId = int.Parse(ddlCourse.SelectedValue);
            filter.CourseTypeId = int.Parse(ddlCourseType.SelectedValue);
            filter.CourseLevel = (CourseLevel)Enum.Parse(typeof(CourseLevel), ddlCourseLevel.SelectedValue);
            if (!string.IsNullOrEmpty(txtStartDate.Value))
            {
                filter.StartDate = txtStartDate.Value.ToDateValue().Value;
            }
            if (!string.IsNullOrEmpty(txtEndDate.Value))
            {
                filter.EndDate = txtEndDate.Value.ToDateValue().Value;
            }
            if (!string.IsNullOrEmpty(txtTrainingId.Value))
            {
                filter.TrainingId = int.Parse(txtTrainingId.Value);
            }
            if (!string.IsNullOrEmpty(txtYear.Value))
            {
                filter.TrainingYear = int.Parse(txtYear.Value);
            }
            filter.CompletionType = (TrainingCompletionType)Enum.Parse(typeof(TrainingCompletionType), drpCompletionType.SelectedValue);
            filter.TrainingBkgId = int.Parse(drpTrainingBkg.SelectedValue);
            filter.TrainingLevel = (TrainingLevel)Enum.Parse(typeof(TrainingLevel), drpTrainingLevel.SelectedValue);
            return filter;
        }

        void ITrainingReportManagerView.PopulateCountryList(ArmyTraining.Model.CountryCollection countries)
        {
            ddlCountry.DataSource = countries;
            ddlCountry.DataValueField = "Id";
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            ddlCountry.SetTooltip();

            ddlSponsorCountry.DataSource = countries;
            ddlSponsorCountry.DataValueField = "Id";
            ddlSponsorCountry.DataTextField = "Name";
            ddlSponsorCountry.DataBind();
            ddlSponsorCountry.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            ddlSponsorCountry.SetTooltip();
        }

        void ITrainingReportManagerView.PopulateCourseList(ArmyTraining.Model.CourseCollection courses)
        {
            ddlCourse.DataSource = courses;
            ddlCourse.DataValueField = "Id";
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            ddlCourse.SetTooltip();
        }

        void ITrainingReportManagerView.PopulateRankList(ArmyTraining.Model.RankCollection ranks)
        {
            ddlRank.DataSource = ranks;
            ddlRank.DataValueField = "Id";
            ddlRank.DataTextField = "Name";
            ddlRank.DataBind();
            ddlRank.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            ddlRank.SetTooltip();
        }

        public void PopulateCourseTypeList(CourseTypeCollection courseTypes)
        {
            ddlCourseType.DataSource = courseTypes;
            ddlCourseType.DataValueField = "Id";
            ddlCourseType.DataTextField = "Name";
            ddlCourseType.DataBind();
            ddlCourseType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            ddlCourseType.SetTooltip();
        }

        public void PopulateCourseLevel()
        {
            ddlCourseLevel.DataSource = Enum.GetValues(typeof(CourseLevel));
            ddlCourseLevel.DataBind();
            ddlCourseLevel.SetTooltip();
        }


        public void PopulateTrainingBkg()
        {
            drpTrainingBkg.DataSource = new TrainingBackgroundInternal().GetTrainingBackgrounds();
            drpTrainingBkg.DataValueField = "Id";
            drpTrainingBkg.DataTextField = "Name";
            drpTrainingBkg.DataBind();
            drpTrainingBkg.Items.Insert(0, new ListItem("All", "0"));
        }

        public void PopulateTrainingLevel()
        {
            drpTrainingLevel.DataSource = Enum.GetValues(typeof(TrainingLevel));
            drpTrainingLevel.DataBind();
        }
    }
}
