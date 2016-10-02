using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class ExpenseHeadEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SaveExpenseHead(ExpenseHead expenseHead)
        {
            try
            {
                ExpenseHeadBol bol = new ExpenseHeadBol();
                return new AjaxData(true, bol.SaveExpenseHead(expenseHead), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetExpenseHead(int id)
        {
            try
            {
                ExpenseHeadBol bol = new ExpenseHeadBol();
                return new AjaxData(true, bol.GetExpenseHead(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
