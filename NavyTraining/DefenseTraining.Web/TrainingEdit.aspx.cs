using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class TrainingEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SaveTraining(Training training)
        {
            try
            {
                TrainingBol bol = new TrainingBol();
                return new AjaxData(true, bol.SaveTraining(training), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetTraining(int id)
        {
            try
            {
                TrainingBol bol = new TrainingBol();
                return new AjaxData(true, bol.GetTraining(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetTrainee(TraineeParam traineeParam)
        {
            try
            {
                TrainingBol bol = new TrainingBol();
                return new AjaxData(true, bol.GetTrainee(traineeParam), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}