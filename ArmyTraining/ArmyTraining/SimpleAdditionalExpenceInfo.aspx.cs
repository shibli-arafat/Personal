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
    public partial class SimpleAdditionalExpenceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdditionalExpenditureCollection budgets = Session["AdditionalBudgets"] as AdditionalExpenditureCollection;
                if (budgets == null)
                {
                    budgets = new AdditionalExpenditureCollection();
                }
                if (!string.IsNullOrEmpty(Request["index"]))
                {
                    AdditionalExpenditure budget = budgets[int.Parse(Request["index"])];
                    txtName.Text = budget.Details;
                    txtRemarks.Text = budget.Remarks;
                    rdBangladesh.Checked = budget.Mode == AdditionExpenditureMode.TraineeCountry;
                    rdSponsor.Checked = budget.Mode == AdditionExpenditureMode.SponsorCountry;
                    rdTraining.Checked = budget.Mode == AdditionExpenditureMode.TrainerCountry;
                }
                Session["AdditionalBudgets"] = budgets;

            }
        }
        protected void Ok_Cliced(object sender, EventArgs e)
        {
            AdditionalExpenditure budget = new AdditionalExpenditure();
            budget.Details = txtName.Text;
            budget.Remarks = txtRemarks.Text;
            budget.Mode =
                (rdBangladesh.Checked) ? AdditionExpenditureMode.TraineeCountry :
                (rdSponsor.Checked) ? AdditionExpenditureMode.SponsorCountry :
                AdditionExpenditureMode.TrainerCountry;
            AdditionalExpenditureCollection budgets = Session["AdditionalBudgets"] as AdditionalExpenditureCollection;
            if (budgets == null)
            {
                budgets = new AdditionalExpenditureCollection();
            }
            if (string.IsNullOrEmpty(Request["index"])) budgets.Add(budget);
            else budgets[int.Parse(Request["index"])] = budget;
            Session["AdditionalBudgets"] = budgets;
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Saved", "window.returnValue=1; window.close();", true);
        }
    }
}
