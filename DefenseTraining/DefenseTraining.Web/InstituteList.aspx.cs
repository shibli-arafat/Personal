using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class InstituteList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static AjaxData GetInstitutes()
        {
            try
            {
                InstituteBol bol = new InstituteBol();
                return new AjaxData(true, bol.GetInstitutes(), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteInstitute(int id)
        {
            try
            {
                InstituteBol bol = new InstituteBol();
                bol.DeleteInstitute(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
