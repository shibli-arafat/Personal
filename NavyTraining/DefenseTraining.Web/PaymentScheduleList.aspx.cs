using System;
using System.Web.Services;
using DefenseTraining.Bol;

namespace DefenseTraining.Web
{
    public partial class PaymentScheduleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetPaymentSchedules(string dateFrom, string dateTo)
        {
            try
            {
                PaymentScheduleBol bol = new PaymentScheduleBol();
                return new AjaxData(true, bol.GetPaymentSchedules(dateFrom, dateTo), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.ToString());
            }
        }

        [WebMethod]
        public static AjaxData DeletePaymentSchedule(int id)
        {
            try
            {
                PaymentScheduleBol bol = new PaymentScheduleBol();
                bol.DeletePaymentSchedule(id);
                return new AjaxData(true, null, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}