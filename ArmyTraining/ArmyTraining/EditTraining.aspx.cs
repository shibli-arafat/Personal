using System;
using System.Drawing;
using System.Web.UI.WebControls;
using ArmyTraining.Internal;
using ArmyTraining.Model.Trainings;

namespace ArmyTraining
{
    public partial class EditTraining : System.Web.UI.Page
    {
        private bool IsEdit
        {
            get
            {
                return !string.IsNullOrEmpty(Request["ID"]);
            }
        }

        public int TrainingId
        {
            get
            {
                if (IsEdit)
                {
                    return int.Parse(Request["ID"]);
                }
                return 0;
            }
        }

        public int TrainingYear
        {
            get
            {
                return generalControl.GetInfo().StartDate.Year;
            }
        }

        public int TrainingMonth
        {
            get
            {
                return generalControl.GetInfo().StartDate.Month;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (IsEdit)
                {
                    TrainingInternal _internal = new TrainingInternal();
                    Model.Trainings.Training traing = _internal.GetTraining(TrainingId);
                    generalControl.Initialize(traing.General);
                    traineeControl.Initialize(traing.Trainees);
                    budgetControl.Initialize(traing.Budget);
                    activitiesControl.Initialize(traing.Flows);
                    ltrHeader.Text = "Edit training - " + TrainingId.ToString();
                    viewHeader.Text = "(" + btnGeneral.Text + ")";
                }
                else
                {
                    TrainingGeneral general = new TrainingGeneral();
                    general.StartDate = DateTime.Now;
                    general.EndDate = DateTime.Now;
                    generalControl.Initialize(general);
                    traineeControl.Visible = false;
                    budgetControl.Visible = false;
                    activitiesControl.Visible = false;
                    btnBudget.Visible = false;
                    btnTrainee.Visible = false;
                    btnActivities.Visible = false;
                    ltrHeader.Text = "Add training";
                }
                btnGeneral.Enabled = true;
                btnGeneral.BackColor = Color.Gray;
            }
        }

        private void SettAllViewButtonEnabled()
        {
            btnGeneral.BackColor = Color.Silver;
            btnBudget.BackColor = Color.Silver;
            btnTrainee.BackColor = Color.Silver;
            btnActivities.BackColor = Color.Silver;
        }

        protected void ChangeView(object sender, EventArgs e)
        {
            viewHeader.Text = "(" + ((LinkButton)sender).Text + ")";
            mvTraining.ActiveViewIndex = int.Parse(((LinkButton)sender).CommandArgument);
            SettAllViewButtonEnabled();
            //((LinkButton)sender).Enabled = false;
            ((LinkButton)sender).BackColor = Color.Gray;
        }

        protected void SaveClicked(object sender, EventArgs e)
        {
            try
            {
                if (IsEdit)
                {
                    TrainingInternal _internal = new TrainingInternal();
                    Model.Trainings.Training traing = _internal.GetTraining(TrainingId);
                    traing.General = generalControl.GetInfo();
                    traing.Trainees = traineeControl.GetInfo();
                    traing.Budget = budgetControl.GetInfo();
                    traing.Flows = activitiesControl.GetInfo();
                    _internal.SaveTraining(traing);
                }
                else
                {
                    TrainingInternal _internal = new TrainingInternal();
                    Model.Trainings.Training traing = new ArmyTraining.Model.Trainings.Training();
                    traing.General = generalControl.GetInfo();
                    int newId = _internal.AddTraining(traing);
                    Response.Redirect("EditTraining.aspx?ID=" + newId.ToString());
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
    }
}
