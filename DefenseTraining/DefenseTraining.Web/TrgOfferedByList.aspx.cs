using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class TrgOfferedByList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static AjaxData GetTrgOfferedBys()
        {
            try
            {
                TrgOfferedByBol bol = new TrgOfferedByBol();
                return new AjaxData(true, bol.GetTrgOfferedBys(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteTrgOfferedBy(int id)
        {
            try
            {
                TrgOfferedByBol bol = new TrgOfferedByBol();
                bol.DeleteTrgOfferedBy(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
