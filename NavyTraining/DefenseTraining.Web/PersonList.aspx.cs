using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class PersonList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetPersons(string personNo, string name, int rankId)
        {
            try
            {
                PersonBol bol = new PersonBol();
                return new AjaxData(true, bol.GetPersons(personNo, name, rankId), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.ToString());
            }
        }

        [WebMethod]
        public static AjaxData DeletePerson(int id)
        {
            try
            {
                PersonBol bol = new PersonBol();
                bol.DeletePerson(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}