using System;
using System.Web.Security;
using DefenseTraining.Model;
using System.Web.UI.WebControls;
using System.Web;

namespace DefenseTraining.Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Session["LoggedInUser"] as User).IsInRole("Administrator"))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem menuItem = new MenuItem();
                foreach (MenuItem item in menuItems)
                {
                    if (string.Compare(item.Text, "Admin", true) == 0)
                    {
                        menuItem = item;
                        break;
                    }
                }
                menuItems.Remove(menuItem);
            }
            lblUser.InnerText = string.Format("You are logged in as: {0}", (Session["LoggedInUser"] as User).FullName);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("Login.aspx");        
        }
    }
}
