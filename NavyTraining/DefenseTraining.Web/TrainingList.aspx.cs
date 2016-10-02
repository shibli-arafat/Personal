using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class TrainingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetTrainings(TrainingFilter filter)
        {
            int totalCount = 0;
            try
            {
                TrainingBol bol = new TrainingBol();
                return new AjaxData(true, bol.GetTrainings(filter, out totalCount), string.Empty, totalCount);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteTraining(int id)
        {
            try
            {
                TrainingBol bol = new TrainingBol();
                bol.DeleteTraining(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}