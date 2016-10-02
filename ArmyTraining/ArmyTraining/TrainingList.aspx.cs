using System;
using System.Web.UI.WebControls;
using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Model.Reports;
using ArmyTraining.Model.Trainings;
using ArmyTraining.Model.Util;

namespace ArmyTraining
{
    public partial class TrainingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInitialData();
                string completion = Request["completion"];
                if (!string.IsNullOrEmpty(completion))
                {
                    BindDataOnCompletionType(completion);
                }
            }
            ddlCountry.SetTooltip();
            ddlSponsorCountry.SetTooltip();
            ddlCourseType.SetTooltip();
            ddlCourse.SetTooltip();
            drpCompletionType.SetTooltip();
            ddlDurationType.SetTooltip();
            ddlCourseLevel.SetTooltip();
            ddlRank.SetTooltip();
            drpTrainingBkg.SetTooltip();
            drpTrainingLevel.SetTooltip();
        }

        private void BindDataOnCompletionType(string completion)
        {
            TrainingFilter filter = CreateFilter();
            filter.PageNumber = 1;
            filter.Count = 10;
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
            BindData(filter);
        }

        private void BindInitialData()
        {
            CountryCollection countries = new CountryInternal().GetCountrys();
            ddlCountry.DataSource = countries;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Id";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("All", "0"));

            ddlSponsorCountry.DataSource = countries;
            ddlSponsorCountry.DataTextField = "Name";
            ddlSponsorCountry.DataValueField = "Id";
            ddlSponsorCountry.DataBind();
            ddlSponsorCountry.Items.Insert(0, new ListItem("All", "0"));

            ddlCourseType.DataSource = new CourseTypeInternal().GetCourseTypes();
            ddlCourseType.DataTextField = "Name";
            ddlCourseType.DataValueField = "Id";
            ddlCourseType.DataBind();
            ddlCourseType.Items.Insert(0, new ListItem("All", "0"));

            ddlCourse.DataSource = new CourseCollection();
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataValueField = "Id";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("All", "0"));

            ddlDurationType.DataSource = Enum.GetValues(typeof(DurationType));
            ddlDurationType.DataBind();

            drpCompletionType.DataSource = Enum.GetValues(typeof(TrainingCompletionType));
            drpCompletionType.DataBind();

            ddlCourseLevel.DataSource = Enum.GetValues(typeof(CourseLevel));
            ddlCourseLevel.DataBind();

            ddlRank.DataSource = new RankInternal().GetRanks();
            ddlRank.DataValueField = "Id";
            ddlRank.DataTextField = "Name";
            ddlRank.DataBind();
            ddlRank.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));

            drpTrainingBkg.DataSource = new TrainingBackgroundInternal().GetTrainingBackgrounds();
            drpTrainingBkg.DataValueField = "Id";
            drpTrainingBkg.DataTextField = "Name";
            drpTrainingBkg.DataBind();
            drpTrainingBkg.Items.Insert(0, new ListItem("All", "0"));

            drpTrainingLevel.DataSource = Enum.GetValues(typeof(TrainingLevel));
            drpTrainingLevel.DataBind();
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

        protected void PrevClicked(object sender, EventArgs e)
        {
            TrainingFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) - 1;
            BindData(filter);
        }

        protected void NextClicked(object sender, EventArgs e)
        {
            TrainingFilter filter = CreateFilter();
            filter.PageNumber = int.Parse(drpPages.SelectedValue) + 1;
            BindData(filter);
        }

        protected void PageIndexChanged(object sender, EventArgs e)
        {
            TrainingFilter filter = CreateFilter();
            filter.PageNumber = int.Parse((sender as DropDownList).SelectedValue);
            BindData(filter);
        }

        protected void Search_Clicked(object sender, EventArgs e)
        {
            BindData(CreateFilter());
        }

        private void BindData(TrainingFilter filter)
        {
            spnNoSearch.Visible = false;
            TrainingSearchResult data = new TrainingInternal().GetTrainingInfos(filter);

            if (data.Result.Count == 0)
            {
                pageHeader.Visible = false;
                rptCourses.Visible = false;
                spnEmptyRow.Visible = true;
            }
            else
            {
                pageHeader.Visible = true;
                PopulatePager(data, filter);
                rptCourses.Visible = true;
                spnEmptyRow.Visible = false;
                rptCourses.DataSource = data.Result;
                rptCourses.DataBind();
            }
        }

        private void PopulatePager(TrainingSearchResult data, TrainingFilter filter)
        {
            int totalPages = (int)Math.Ceiling((float)data.TotalCount / filter.Count);
            drpPages.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                li.Selected = filter.PageNumber == i;
                drpPages.Items.Add(li);
            }
            lnkPrev.Enabled = true;
            lnkNext.Enabled = true;
            drpPages.Enabled = true;

            if (filter.PageNumber == 1)
            {
                lnkPrev.Enabled = false;
            }
            if (filter.PageNumber == totalPages)
            {
                lnkNext.Enabled = false;
            }
            if (totalPages == 1)
            {
                drpPages.Enabled = false;
            }
            int start = (filter.PageNumber - 1) * filter.Count + 1;
            int end = start + data.Result.Count - 1;
            ltStart.Text = start.ToString();
            ltEnd.Text = end.ToString();
            ltTotal.Text = data.TotalCount.ToString();
        }

        private TrainingFilter CreateFilter()
        {
            TrainingFilter filter = new TrainingFilter();
            filter.CountryId = int.Parse(ddlCountry.SelectedValue);
            filter.CourseTypeId = int.Parse(ddlCourseType.SelectedValue);
            filter.CourseId = int.Parse(ddlCourse.SelectedValue);
            filter.Duration = string.IsNullOrEmpty(txtDuration.Text) ? 0 : int.Parse(txtDuration.Text);
            filter.DurationType = (DurationType)Enum.Parse(typeof(DurationType), ddlDurationType.SelectedValue);
            if (!string.IsNullOrEmpty(txtEndDate.Value))
            {
                filter.EndDate = txtEndDate.Value.ToDateValue().Value;
            }
            filter.IsUpto = rdUpto.Checked;
            filter.SponsorCountryId = int.Parse(ddlSponsorCountry.SelectedValue);
            if (!string.IsNullOrEmpty(txtStartDate.Value))
            {
                filter.StartDate = txtStartDate.Value.ToDateValue().Value;
            }
            filter.PersonalNo = string.Format("{0}", txtTrainee.Value);
            filter.RankId = int.Parse(ddlRank.SelectedValue);
            filter.CourseLevel = (CourseLevel)Enum.Parse(typeof(CourseLevel), ddlCourseLevel.SelectedValue);
            filter.CompletionType = (TrainingCompletionType)Enum.Parse(typeof(TrainingCompletionType), drpCompletionType.SelectedValue);
            filter.TrainingBkgId = int.Parse(drpTrainingBkg.SelectedValue);
            filter.TrainingLevel = (TrainingLevel)Enum.Parse(typeof(TrainingLevel), drpTrainingLevel.SelectedValue);
            filter.PageNumber = 1;
            filter.Count = 13;
            if (!string.IsNullOrEmpty(txtTrainingId.Value))
            {
                filter.TrainingId = int.Parse(txtTrainingId.Value);
            }
            if (!string.IsNullOrEmpty(txtYear.Value))
            {
                filter.TrainingYear = int.Parse(txtYear.Value);
            }
            return filter;
        }

        protected void DeleteCommand(object sender, EventArgs e)
        {
            int id = int.Parse(((ImageButton)sender).CommandArgument);
            new TrainingInternal().DeleteTraining(id);
            BindData(CreateFilter());
        }

        protected void ItemEditClicked(object sender, EventArgs e)
        {
            int id = int.Parse(((LinkButton)sender).CommandArgument);
            Response.Redirect("EditTraining.aspx?ID=" + id.ToString());
        }

        protected void ItemData_Bound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lnkEdit = e.Item.FindControl("lnkEdit") as LinkButton;
                ImageButton deleteBtton = e.Item.FindControl("imgBtnDelete") as ImageButton;
                lnkEdit.CommandArgument = ((TrainingInfo)e.Item.DataItem).Id.ToString();
                deleteBtton.CommandArgument = ((TrainingInfo)e.Item.DataItem).Id.ToString();
            }
        }
    }
}
