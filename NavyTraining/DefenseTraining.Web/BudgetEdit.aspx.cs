using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class BudgetEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SaveBudget(Budget budget)
        {
            try
            {
                BudgetBol bol = new BudgetBol();
                return new AjaxData(true, bol.SaveBudget(budget), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetBudget(int id)
        {
            try
            {
                BudgetBol bol = new BudgetBol();
                return new AjaxData(true, bol.GetBudget(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetBudgetCodes()
        {
            try
            {
                BudgetBol bol = new BudgetBol();
                return new AjaxData(true, bol.GetBudgetCodes(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
