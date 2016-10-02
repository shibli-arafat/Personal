using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class BudgetDal : DalBase
    {
        public List<Budget> GetBudgets()
        {
            List<Budget> budgets = new List<Budget>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("BudgetGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        Budget budget = new Budget();
                        budget.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        budget.BudgetYear = reader.GetInt32(reader.GetOrdinal("BudgetYear"));
                        budget.BudgetCode.Id = reader.GetInt32(reader.GetOrdinal("BudgetCodeId"));
                        budget.BudgetCode.Code = reader.GetString(reader.GetOrdinal("BudgetCode"));
                        budget.Amount = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Amount")));
                        budget.AmountPaid = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("AmountPaid")));
                        budget.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        budgets.Add(budget);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return budgets;
        }

        public Budget GetBudget(int id)
        {
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("BudgetGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    if (reader.Read())
                    {
                        Budget budget = new Budget();
                        budget.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        budget.BudgetYear = reader.GetInt32(reader.GetOrdinal("BudgetYear"));
                        budget.BudgetCode.Id = reader.GetInt32(reader.GetOrdinal("BudgetCodeId"));
                        budget.BudgetCode.Code = reader.GetString(reader.GetOrdinal("BudgetCode"));
                        budget.Amount = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Amount")));
                        budget.AmountPaid = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("AmountPaid")));
                        budget.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        return budget;
                    }
                    throw new Exception("No budget found in the system with ID: " + id);
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<BudgetCode> GetBudgetCodes()
        {
            List<BudgetCode> codes = new List<BudgetCode>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("BudgetCodeGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        BudgetCode code = new BudgetCode();
                        code.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        code.Code = reader.GetString(reader.GetOrdinal("Code"));
                        code.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        codes.Add(code);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return codes;
        }

        public int SaveBudget(Budget budget)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", budget.Id) 
                                               ,new SqlParameter("@BudgetYear", budget.BudgetYear)
                                               ,new SqlParameter("@BudgetCodeId", budget.BudgetCode.Id)
                                               ,new SqlParameter("@Amount", budget.Amount)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("BudgetSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool BudgetExists(int id, int budgetYear, int budgetCodeId)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@Id", id)
                                               ,new SqlParameter("@BudgetYear", budgetYear)
                                               ,new SqlParameter("@BudgetCodeId", budgetCodeId)
                                            };
                return ExecuteScalar<bool>("BudgetExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteBudget(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("BudgetDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }        
    }
}
