using System;
using System.Web.UI;
using ArmyTraining.Internal;
using ArmyTraining.Model;

namespace ArmyTraining
{
    public partial class YearlyBudgetDetail : System.Web.UI.Page
    {
        private YearlyBudgetInternal _Internal;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Internal = new YearlyBudgetInternal();
            if (!IsPostBack)
            {
                if (BudgetId > 0)
                {
                    YearlyBudget budget = _Internal.GetYearlyBudget(BudgetId);
                    this.PopulateFormData(budget);
                    header.Text = "Edit budget (" + BudgetId + ").";
                }
                else
                {
                    header.Text = "Add budget.";
                }
            }
        }

        protected void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (BudgetId == 0)
                {
                    _Internal.AddYearlyBudget(GetFormData());
                }
                else
                {
                    _Internal.UpdateYearlyBudget(GetFormData());
                }
                string js = "window.returnValue = 1;window.close();";
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "SaveSuccess", js, true);
            }
            catch (Exception ex)
            {
                hdnMessage.Value = ex.Message;
            }
        }

        public int BudgetId
        {
            get { return int.Parse(Request["ID"]); }
        }

        public void PopulateFormData(YearlyBudget budget)
        {
            txtYear.Value = budget.Year.ToString();
            txtYearTo.Value = (budget.Year + 1).ToString();
            txtBudget.Value = string.Format("{0:0.00}", budget.Budget);
        }

        public YearlyBudget GetFormData()
        {
            YearlyBudget budget = new YearlyBudget(BudgetId, int.Parse(txtYear.Value), double.Parse(txtBudget.Value));
            return budget;
        }
    }
}
