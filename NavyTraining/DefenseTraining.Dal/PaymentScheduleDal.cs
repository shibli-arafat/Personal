using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class PaymentScheduleDal : DalBase
    {
        public List<PaymentSchedule> GetPaymentSchedules(string dateFrom, string dateTo)
        {
            List<PaymentSchedule> paymentSchedules = new List<PaymentSchedule>();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@DateFrom", DateTime.ParseExact(dateFrom, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@DateTo", DateTime.ParseExact(dateTo, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                            };
                using (DataSet ds = GetDataSet("PaymentScheduleGetAll", parameters))
                {
                    DataTable scheduleTable = ds.Tables[0];
                    DataTable paymentTable = ds.Tables[1];

                    foreach (DataRow row in scheduleTable.Rows)
                    {
                        PaymentSchedule paymentSchedule = new PaymentSchedule();
                        paymentSchedule.Id = Convert.ToInt32(row["Id"]);
                        paymentSchedule.TrainingId = Convert.ToInt32(row["TrainingId"]);
                        paymentSchedule.CourseName = Convert.ToString(row["CourseName"]);
                        paymentSchedule.StartDate = Convert.ToDateTime(row["StartDate"]).ToString("dd MMM yyyy");
                        paymentSchedule.EndDate = Convert.ToDateTime(row["EndDate"]).ToString("dd MMM yyyy");
                        paymentSchedule.PaymentDate = Convert.ToDateTime(row["PaymentDate"]).ToString("dd MMM yyyy");
                        paymentSchedule.IsActive = Convert.ToBoolean(row["IsActive"]);
                        paymentSchedule.Payments = MapPayments(paymentSchedule.Id, paymentTable);
                        paymentSchedules.Add(paymentSchedule);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return paymentSchedules;
        }

        public PaymentSchedule GetPaymentSchedule(int id)
        {
            OpenConnection();
            try
            {
                using (DataSet ds = GetDataSet("PaymentScheduleGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    DataTable scheduleTable = ds.Tables[0];
                    DataTable paymentTable = ds.Tables[1];
                    if (scheduleTable.Rows.Count > 0)
                    {
                        DataRow row = scheduleTable.Rows[0];
                        PaymentSchedule paymentSchedule = new PaymentSchedule();
                        paymentSchedule.Id = Convert.ToInt32(row["Id"]);
                        paymentSchedule.TrainingId = Convert.ToInt32(row["TrainingId"]);
                        paymentSchedule.CourseName = Convert.ToString(row["CourseName"]);
                        paymentSchedule.StartDate = Convert.ToDateTime(row["StartDate"]).ToString("dd MMM yyyy");
                        paymentSchedule.EndDate = Convert.ToDateTime(row["EndDate"]).ToString("dd MMM yyyy");
                        paymentSchedule.PaymentDate = Convert.ToDateTime(row["PaymentDate"]).ToString("dd MMM yyyy");
                        paymentSchedule.IsActive = Convert.ToBoolean(row["IsActive"]);
                        paymentSchedule.Payments = MapPayments(paymentSchedule.Id, paymentTable);
                        return paymentSchedule;
                    }
                    throw new Exception("No paymentSchedule found in the system with ID: " + id);
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        private List<Payment> MapPayments(int id, DataTable paymentTable)
        {
            List<Payment> payments = new List<Payment>();
            foreach (DataRow row in paymentTable.Rows)
            {
                if (Convert.ToInt32(row["PaymentScheduleId"]) == id)
                {
                    Payment payment = new Payment();
                    payment.BudgetCode.Id = Convert.ToInt32(row["BudgetCodeId"]);
                    payment.BudgetCode.Code = Convert.ToString(row["BudgetCode"]);
                    payment.Amount = Convert.ToDouble(row["Amount"]);
                    payments.Add(payment);
                }
            }
            return payments;
        }

        public int SavePaymentSchedule(PaymentSchedule paymentSchedule)
        {
            OpenConnection();
            try
            {
                DataTable paymentTable = new DataTable("PaymentType");
                paymentTable.Clear();
                paymentTable.Columns.Add("BudgetCodeId", typeof(int));
                paymentTable.Columns.Add("Amount", typeof(double));
                foreach (Payment payment in paymentSchedule.Payments)
                {
                    DataRow row = paymentTable.NewRow();
                    row["BudgetCodeId"] = payment.BudgetCode.Id;
                    row["Amount"] = payment.Amount;
                    paymentTable.Rows.Add(row);
                }
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", paymentSchedule.Id) 
                                               ,new SqlParameter("@TrainingId", paymentSchedule.TrainingId)
                                               ,new SqlParameter("@PaymentDate", paymentSchedule.PaymentDate)
                                               ,new SqlParameter("@Payments", paymentTable)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("PaymentScheduleSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool PaymentScheduleExists(int id, int trainingId, string paymentDate)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@Id", id)
                                               ,new SqlParameter("@trainingId", trainingId)
                                               ,new SqlParameter("@paymentDate", DateTime.ParseExact(paymentDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                            };
                return ExecuteScalar<bool>("PaymentScheduleExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeletePaymentSchedule(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("PaymentScheduleDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
