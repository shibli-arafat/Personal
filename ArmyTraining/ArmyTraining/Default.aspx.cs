using System;
using ArmyTraining.Internal;
using ArmyTraining.Model.Reports;
using ArmyTraining.Model.Trainings;

namespace ArmyTraining
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TrainingInternal _internal = new TrainingInternal();
                TrainingFilter filter = new TrainingFilter();
                filter.PersonalNo = string.Empty;
                filter.PageNumber = 1;
                filter.Count = 3;
                filter.CompletionType = TrainingCompletionType.Ongoing;
                TrainingInfoCollection ongoingTrainings = _internal.GetTrainingInfos(filter).Result;
                if (ongoingTrainings.Count > 0)
                {
                    emptyOngoingCell.Visible = false;
                    rptOngoingTrainings.DataSource = ongoingTrainings;
                    rptOngoingTrainings.DataBind();
                }
                filter.CompletionType = TrainingCompletionType.Upcomming;
                TrainingInfoCollection upcommingTrainings = _internal.GetTrainingInfos(filter).Result;
                if (upcommingTrainings.Count > 0)
                {
                    emptyCellUpcomming.Visible = false;
                    rptUpcommings.DataSource = upcommingTrainings;
                    rptUpcommings.DataBind();
                }
                filter.CompletionType = TrainingCompletionType.Completed;
                TrainingInfoCollection completedTrainings = _internal.GetTrainingInfos(filter).Result;
                if (completedTrainings.Count > 0)
                {
                    emptyCompleted.Visible = false;
                    rptCompleted.DataSource = completedTrainings;
                    rptCompleted.DataBind();
                }
            }
        }
    }
}
