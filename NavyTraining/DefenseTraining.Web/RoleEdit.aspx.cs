using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class RoleEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SaveRole(Role role)
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.SaveRole(role), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetRole(int id)
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.GetRole(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetPrivileges()
        {
            try
            {
                UserBol bol = new UserBol();
                return new AjaxData(true, bol.GetPrivileges(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
