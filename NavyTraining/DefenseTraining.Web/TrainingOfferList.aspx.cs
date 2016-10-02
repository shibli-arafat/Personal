using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class TrainingOfferList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetTrainingOffers()
        {
            try
            {
                TrainingOfferBol bol = new TrainingOfferBol();
                return new AjaxData(true, bol.GetTrainingOffers(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteTrainingOffer(int id)
        {
            try
            {
                TrainingOfferBol bol = new TrainingOfferBol();
                bol.DeleteTrainingOffer(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
