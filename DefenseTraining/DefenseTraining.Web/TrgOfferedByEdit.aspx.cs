using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class TrgOfferedByEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static AjaxData SaveTrgOfferedBy(TrgOfferedBy trgOfferedBy)
        {
            try
            {
                TrgOfferedByBol bol = new TrgOfferedByBol();
                return new AjaxData(true, bol.SaveTrgOfferedBy(trgOfferedBy), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
