using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ArmyTraining.Presenter.Views;
using ArmyTraining.Model.Trainings;
using ArmyTraining.Presenter;
using System.Collections.Generic;
using ArmyTraining.Model;

namespace ArmyTraining
{
    public partial class Training : System.Web.UI.Page, ITrainingDetailView
    {
        TrainingPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new TrainingPresenter(this);
            _Presenter.OnViewLoad();
        }

        protected void Ok_Clicked(object sender, EventArgs e)
        {
            _Presenter.HandleSave();
        }

        protected void CourseIndexChanged(object sender, EventArgs e)
        {
            _Presenter.HandleCourseSelection(int.Parse(drpCourse.SelectedValue));
        }

        protected void CourseTypeIndexChanged(object sender, EventArgs e)
        {
            _Presenter.HandleCourseTypeSelection(int.Parse(drpCourseType.SelectedValue));
        }


        protected void ViewChange(object sender, EventArgs e)
        {
            mvTraining.ActiveViewIndex = Convert.ToInt32(((Button)sender).CommandArgument);
            btnGeneral.CssClass = "button";
            btnTrainee.CssClass = "button";
            btnBudget.CssClass = "button";
            btnFlow.CssClass = "button";
            ((Button)sender).CssClass = "buttonSelected";
        }

        public bool IsPagePostBack
        {
            get { return IsPostBack; }
        }

        public int TrainingId
        {
            get { return int.Parse(Request[Constants.TrainingDetail_Request_Id]); }
        }

        public void PopulateGUIForGeneral(TrainingGeneral general)
        {
            int courseTypeId = _Presenter.GetCourseTypeId(general.CourseId);
            drpCourseType.SelectedIndex =
                drpCourseType.Items.IndexOf(drpCourseType.Items.FindByValue(courseTypeId.ToString()));
            if (drpCourse.Items.Count == 0)
            {
                int typeToBound;
                int.TryParse(drpCourseType.SelectedValue, out typeToBound);
                _Presenter.HandleCourseTypeSelection(typeToBound);
            }

            drpCourse.SelectedIndex =
                drpCourse.Items.IndexOf(drpCourse.Items.FindByValue(general.CourseId.ToString()));
            if (drpCountry.Items.Count == 0)
            {
                int courseToBound;
                int.TryParse(drpCourse.SelectedValue, out courseToBound);
                _Presenter.HandleCourseSelection(courseToBound);
            }
            drpCountry.SelectedIndex =
                drpCountry.Items.IndexOf(drpCountry.Items.FindByValue(general.CountryId.ToString()));
            droSponsorCountry.SelectedIndex =
                droSponsorCountry.Items.IndexOf(droSponsorCountry.Items.FindByValue(general.SponsorCountryId.ToString()));

            drpStatus.DataSource = _Presenter.GetAllowedStatusList(general.StatusId).Items;
            drpStatus.DataBind();

            txtPreRequisites.Text = general.Prerequisites;
            txtRemarks.Text = general.Remarks;
            srartDate.SelectedDate = general.StartDate;
            endDate.SelectedDate = general.EndDate;            
        }

        //OnCancelCommand="CancelBudgetEdit" OnDeleteCommand="DeleteBudget" OnEditCommand="EditBudget" OnItemCommand="BudgetItemCommand"

        public void PopulateGUIForTrainee(TraineeCollection traineess)
        {
            throw new NotImplementedException();
        }

        public void PopulateGUIForBudget(TrainingBudgetInfo budgetInfo)
        {
            int index = 1;
            if (budgetInfo.Budgets != null)
            {
                foreach (TrainingBudget budget in budgetInfo.Budgets)
                {
                    ((TextBox)viewBudget.FindControl("txtBudgetYear" + index.ToString())).Text = budget.BudgetYear;
                    ((TextBox)viewBudget.FindControl("txtExpense" + index.ToString())).Text = budget.Expenditure.ToString();
                    index++;
                }
            }
            if (budgetInfo.AdditionalExpences != null)
            {
                foreach (AdditionalExpenditure addition in budgetInfo.AdditionalExpences)
                {
                    if (addition.Details == spnPlaneFair.InnerText)
                    {
                        if (addition.Mode == AdditionExpenditureMode.SponsorCountry) choise1Sponsor.Checked = true;
                        if (addition.Mode == AdditionExpenditureMode.TraineeCountry) choice1Bangladesh.Checked = true;
                        if (addition.Mode == AdditionExpenditureMode.TrainerCountry) choice1Training.Checked = true;
                    }
                    if (addition.Details == spnAllownce.InnerText)
                    {
                        if (addition.Mode == AdditionExpenditureMode.SponsorCountry) choise2Sponsor.Checked = true;
                        if (addition.Mode == AdditionExpenditureMode.TraineeCountry) choice2Bangladesh.Checked = true;
                        if (addition.Mode == AdditionExpenditureMode.TrainerCountry) choice2Training.Checked = true;
                    }

                }
            }
        }

        public void PopulateGUIForFlow(TrainingFlowCollection flows)
        {
            throw new NotImplementedException();
        }

        public TrainingGeneral PopulateGeneralFromGUI()
        {
            TrainingGeneral general = new TrainingGeneral();
            general.CountryId = int.Parse(drpCountry.SelectedValue);
            general.CountryName = drpCountry.SelectedItem.Text;
            general.CourseId = int.Parse(drpCourse.SelectedValue);
            general.CourseName = drpCourse.SelectedItem.Text;
            general.SponsorCountryId = int.Parse(droSponsorCountry.SelectedValue);
            general.SponsorCountryName = droSponsorCountry.SelectedItem.Text;

            general.StatusId = int.Parse(drpStatus.SelectedValue);
            general.Prerequisites = txtPreRequisites.Text;
            general.Remarks = txtRemarks.Text;
            general.StartDate = srartDate.SelectedDate;
            general.EndDate = endDate.SelectedDate;

            return general;
        }

        public TraineeCollection PopulateTraineesFromGUI()
        {
            throw new NotImplementedException();
        }

        public TrainingBudgetInfo PopulateBudgetInfoFromGUI()
        {
            TrainingBudgetInfo result = new TrainingBudgetInfo();
            result.Budgets = new TrainingBudgetCollection();
            result.AdditionalExpences = new AdditionalExpenditureCollection();

            int index = 1;
            while (viewBudget.FindControl("txtBudgetYear" + index.ToString()) != null)
            {
                TextBox txtBudgetYear = viewBudget.FindControl("txtBudgetYear" + index.ToString()) as TextBox;
                TextBox txtExpence = viewBudget.FindControl("txtExpense" + index.ToString()) as TextBox;

                decimal expence;
                if (decimal.TryParse(txtExpence.Text, out expence))
                {
                    TrainingBudget budget = new TrainingBudget();
                    budget.BudgetYear = txtBudgetYear.Text;
                    budget.Expenditure = expence;
                    result.Budgets.Add(budget);
                }

                index++;
            }

            return result;
        }

        public TrainingFlowCollection PopulateFlowsFromGUI()
        {
            throw new NotImplementedException();
        }

        public void RedirectToEdit(int id)
        {
            Response.Redirect("Training.aspx?id=" + id);
        }

        public void BindCourses(CourseCollection courses)
        {
            drpCourse.DataSource = courses;
            drpCourse.DataBind();
        }

        public void BindCountries(CountryCollection countries)
        {
            drpCountry.DataSource = countries;
            drpCountry.DataBind();
        }

        public void BindSponsorCountries(CountryCollection countries)
        {
            droSponsorCountry.DataSource = countries;
            droSponsorCountry.DataBind();
        }

        public void BindCourseTypes(CourseTypeCollection courseTypes)
        {
            drpCourseType.DataSource = courseTypes;
            drpCourseType.DataBind();
        }

        public TrainingBudgetCollection BudgetsInState
        {
            get
            {
                return Session["BudgetsInState"] as TrainingBudgetCollection;
            }
            set
            {
                Session["BudgetsInState"] = value;
            }
        }

        public AdditionalExpenditureCollection AdditionalExpencesInState
        {
            get
            {
                return Session["AdditionalExpencesInState"] as AdditionalExpenditureCollection;
            }
            set
            {
                Session["AdditionalExpencesInState"] = value;
            }
        }
    }
}
