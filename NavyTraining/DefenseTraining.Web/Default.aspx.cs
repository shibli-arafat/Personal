using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetReminders()
        {
            try
            {
                TrainingBol bol = new TrainingBol();
                return new AjaxData(true, bol.GetReminders(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(true, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DismissReminder(int eventId, string remindFor)
        {
            EventBol bol = new EventBol();
            try
            {
                bol.DismissReminder(eventId, remindFor);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
