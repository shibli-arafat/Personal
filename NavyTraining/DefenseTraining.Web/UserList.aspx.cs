using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetUsers(string keyword, int roleId)
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.GetUsers(keyword, roleId), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteUser(int id)
        {
            try
            {
                UserBol bol = new UserBol();
                bol.DeleteUser(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
