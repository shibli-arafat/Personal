using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class PaymentScheduleBol
    {
        private PaymentScheduleDal _Dal;

        public PaymentScheduleBol()
        {
            _Dal = new PaymentScheduleDal();
        }

        public List<PaymentSchedule> GetPaymentSchedules(string dateFrom, string dateTo)
        {
            if (string.IsNullOrEmpty(dateFrom))
            {
                dateFrom = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(dateTo))
            {
                dateTo = "31 Dec 3000";
            }
            return _Dal.GetPaymentSchedules(dateFrom, dateTo);
        }

        public void DeletePaymentSchedule(int id)
        {
            _Dal.DeletePaymentSchedule(id);
        }

        public PaymentSchedule SavePaymentSchedule(PaymentSchedule paymentSchedule)
        {
            if (_Dal.PaymentScheduleExists(paymentSchedule.Id, paymentSchedule.TrainingId, paymentSchedule.PaymentDate))
                throw new Exception("A payment of the same training already exists in this date.");
            paymentSchedule.Id = _Dal.SavePaymentSchedule(paymentSchedule);
            return paymentSchedule;
        }

        public PaymentSchedule GetPaymentSchedule(int id)
        {
            return _Dal.GetPaymentSchedule(id);
        }
    }
}
