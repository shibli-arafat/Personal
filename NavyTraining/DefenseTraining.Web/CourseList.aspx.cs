using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class CourseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetCourses(int eventTypeId, string keyword)
        {
            try
            {
                CourseBol bol = new CourseBol();
                return new AjaxData(true, bol.GetCourses(eventTypeId, keyword), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData DeleteCourse(int id)
        {
            try
            {
                CourseBol bol = new CourseBol();
                bol.DeleteCourse(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
