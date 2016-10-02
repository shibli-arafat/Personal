using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class ExpenseHeadDal : DalBase
    {
        public List<ExpenseHead> GetExpenseHeads()
        {
            List<ExpenseHead> expenseHeads = new List<ExpenseHead>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("ExpenseHeadGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        ExpenseHead expenseHead = new ExpenseHead();
                        expenseHead.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        expenseHead.Name = reader.GetString(reader.GetOrdinal("Name"));
                        expenseHead.IsAutoCalc = reader.GetBoolean(reader.GetOrdinal("IsAutoCalc"));
                        expenseHead.BasedOn = (AutoCalcBase)Enum.Parse(typeof(AutoCalcBase), reader.GetValue(reader.GetOrdinal("BasedOn")).ToString());
                        expenseHead.IsDaily = reader.GetBoolean(reader.GetOrdinal("IsDaily"));
                        expenseHead.ApplicableForSpouse = reader.GetBoolean(reader.GetOrdinal("ApplicableForSpouse"));
                        expenseHead.ApplicableForKids = reader.GetBoolean(reader.GetOrdinal("ApplicableForKids"));
                        expenseHead.BudgetCode.Id = reader.GetInt32(reader.GetOrdinal("BudgetCodeId"));
                        expenseHead.BudgetCode.Code = reader.GetString(reader.GetOrdinal("BudgetCode"));
                        expenseHead.Value = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Value")));
                        expenseHead.IsInBdt = reader.GetBoolean(reader.GetOrdinal("IsInBdt"));
                        expenseHead.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        expenseHeads.Add(expenseHead);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return expenseHeads;
        }

        public ExpenseHead GetExpenseHead(int id)
        {
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("ExpenseHeadGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    if (reader.Read())
                    {
                        ExpenseHead expenseHead = new ExpenseHead();
                        expenseHead.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        expenseHead.Name = reader.GetString(reader.GetOrdinal("Name"));
                        expenseHead.IsAutoCalc = reader.GetBoolean(reader.GetOrdinal("IsAutoCalc"));
                        expenseHead.BasedOn = (AutoCalcBase)Enum.Parse(typeof(AutoCalcBase), reader.GetValue(reader.GetOrdinal("BasedOn")).ToString());
                        expenseHead.IsDaily = reader.GetBoolean(reader.GetOrdinal("IsDaily"));
                        expenseHead.ApplicableForSpouse = reader.GetBoolean(reader.GetOrdinal("ApplicableForSpouse"));
                        expenseHead.ApplicableForKids = reader.GetBoolean(reader.GetOrdinal("ApplicableForKids"));
                        expenseHead.BudgetCode.Id = reader.GetInt32(reader.GetOrdinal("BudgetCodeId"));
                        expenseHead.BudgetCode.Code = reader.GetString(reader.GetOrdinal("BudgetCode"));
                        expenseHead.Value = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Value")));
                        expenseHead.IsInBdt = reader.GetBoolean(reader.GetOrdinal("IsInBdt"));
                        expenseHead.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        return expenseHead;
                    }
                    throw new Exception("No expense head found in the system with ID: " + id);
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteExpenseHead(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("ExpenseHeadDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveExpenseHead(ExpenseHead expenseHead)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", expenseHead.Id) 
                                               ,new SqlParameter("@Name", expenseHead.Name)
                                               ,new SqlParameter("@IsAutoCalc", expenseHead.IsAutoCalc)
                                               ,new SqlParameter("@IsDaily", expenseHead.IsDaily)
                                               ,new SqlParameter("@ApplicableForSpouse", expenseHead.ApplicableForSpouse)
                                               ,new SqlParameter("@ApplicableForKids", expenseHead.ApplicableForKids)
                                               ,new SqlParameter("@BudgetCodeId", expenseHead.BudgetCode.Id)
                                               ,new SqlParameter("@BasedOn", expenseHead.BasedOn)
                                               ,new SqlParameter("@IsInBdt", expenseHead.IsInBdt)
                                               ,new SqlParameter("@Value", expenseHead.Value)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("ExpenseHeadSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ExpenseHeadExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("Id", id)
                                               ,new SqlParameter("Name", name)
                                            };
                return ExecuteScalar<bool>("ExpenseHeadExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
