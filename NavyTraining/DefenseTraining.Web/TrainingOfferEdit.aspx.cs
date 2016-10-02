using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class TrainingOfferEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SaveTrainingOffer(TrainingOffer budget)
        {
            try
            {
                TrainingOfferBol bol = new TrainingOfferBol();
                return new AjaxData(true, bol.SaveTrainingOffer(budget), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetTrainingOffer(int id)
        {
            try
            {
                TrainingOfferBol bol = new TrainingOfferBol();
                return new AjaxData(true, bol.GetTrainingOffer(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
