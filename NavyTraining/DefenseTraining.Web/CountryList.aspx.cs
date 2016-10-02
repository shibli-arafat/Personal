using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class CountryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetCountries(int group)
        {
            try
            {
                CountryBol bol = new CountryBol();
                return new AjaxData(true, bol.GetCountries((CountryGroup)group), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.ToString());
            }
        }

        [WebMethod]
        public static AjaxData DeleteCountry(int id)
        {
            try
            {
                CountryBol bol = new CountryBol();
                bol.DeleteCountry(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
