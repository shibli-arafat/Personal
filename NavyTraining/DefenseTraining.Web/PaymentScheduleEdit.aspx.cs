using System;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;
using System.Collections.Generic;

namespace DefenseTraining.Web
{
    public partial class PaymentScheduleEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData SavePaymentSchedule(PaymentSchedule paymentSchedule)
        {
            try
            {
                PaymentScheduleBol bol = new PaymentScheduleBol();
                return new AjaxData(true, bol.SavePaymentSchedule(paymentSchedule), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData GetPaymentSchedule(int id, int trainingId)
        {
            try
            {
                PaymentScheduleBol bol = new PaymentScheduleBol();
                if (id != 0)
                {
                    return new AjaxData(true, bol.GetPaymentSchedule(id), string.Empty);
                }
                else
                {
                    BudgetBol bBol = new BudgetBol();
                    TrainingBol tBol = new TrainingBol();
                    Training training = tBol.GetTraining(trainingId);
                    List<BudgetCode> budgetCodes = bBol.GetBudgetCodes();
                    PaymentSchedule ps = new PaymentSchedule();
                    ps.TrainingId = training.Id;
                    ps.StartDate = training.StartDate;
                    ps.EndDate = training.EndDate;
                    ps.CourseName = training.Course.Name;
                    foreach (BudgetCode code in budgetCodes)
                    {
                        Payment payment = new Payment();
                        payment.BudgetCode = code;
                        ps.Payments.Add(payment);
                    }
                    return new AjaxData(true, ps, string.Empty);
                }
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}
