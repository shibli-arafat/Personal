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
using ArmyTraining.Model.Trainings;

namespace ArmyTraining
{
    public partial class SimpleBudgetInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TrainingBudgetCollection budgets = Session["Budgets"] as TrainingBudgetCollection;
                if (budgets == null)
                {
                    budgets = new TrainingBudgetCollection();
                }
                if (!string.IsNullOrEmpty(Request["index"]))
                {
                    TrainingBudget budget = budgets[int.Parse(Request["index"])];
                    txtBudgetYear.Text = budget.BudgetYear;
                    txtExpence.Text = budget.Expenditure.ToString("0.00");
                }
                Session["Budgets"] = budgets;

            }
        }
        protected void Ok_Cliced(object sender, EventArgs e)
        {
            TrainingBudget budget = new TrainingBudget();
            budget.BudgetYear = txtBudgetYear.Text;
            budget.Expenditure = decimal.Parse(txtExpence.Text);
            TrainingBudgetCollection budgets = Session["Budgets"] as TrainingBudgetCollection;
            if (budgets == null)
            {
                budgets = new TrainingBudgetCollection();
            }
            if (string.IsNullOrEmpty(Request["index"])) budgets.Add(budget);
            else budgets[int.Parse(Request["index"])] = budget;
            Session["Budgets"] = budgets;
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Saved", "window.returnValue=1; window.close();", true);
        }
    }
}
