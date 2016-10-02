using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class CountryEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetCountry(int id)
        {
            try
            {
                CountryBol bol = new CountryBol();
                return new AjaxData(true, bol.GetCountry(id), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.ToString());
            }
        }

        [WebMethod]
        public static AjaxData SaveCountry(Country country)
        {
            try
            {
                CountryBol bol = new CountryBol();
                return new AjaxData(true, bol.SaveCountry(country), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
