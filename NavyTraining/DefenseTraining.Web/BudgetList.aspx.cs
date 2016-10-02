using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class BudgetList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetBudgets()
        {
            try
            {
                BudgetBol bol = new BudgetBol();
                return new AjaxData(true, bol.GetBudgets(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteBudget(int id)
        {
            try
            {
                BudgetBol bol = new BudgetBol();
                bol.DeleteBudget(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
