using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class ExpenseHeadList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetExpenseHeads()
        {
            try
            {
                ExpenseHeadBol bol = new ExpenseHeadBol();
                return new AjaxData(true, bol.GetExpenseHeads(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteExpenseHead(int id)
        {
            try
            {
                ExpenseHeadBol bol = new ExpenseHeadBol();
                bol.DeleteExpenseHead(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
