using System;
using DefenseTraining.Bol;
using DefenseTraining.Model;
using System.Web.Security;

namespace DefenseTraining.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserBol bol = new UserBol();
            try
            {
                User user = bol.Login(txtUserName.Value.Trim(), txtPassword.Value.Trim());
                Session["User"] = user;
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                lblErrorMessage.InnerHtml = ex.Message;
                txtPassword.Value = string.Empty;
            }
        }
    }
}