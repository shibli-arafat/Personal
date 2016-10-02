using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserBol bol = new UserBol();
            try
            {
                User user = bol.Login(txtUserName.Value.Trim(), txtPassword.Value.Trim());
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.UserName, false, 20);
                IIdentity identity = new FormsIdentity(ticket);
                IPrincipal principal = new GenericPrincipal(identity, user.RoleNames.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, false);
                HttpContext.Current.User = principal;
                Session["LoggedInUser"] = user;
            }
            catch (Exception ex)
            {
                lblErrorMessage.InnerText = ex.Message;
            }
        }
    }
}