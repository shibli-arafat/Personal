using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class TrgOfferedByDal : DalBase
    {
        public List<TrgOfferedBy> GetTrgOfferedBys()
        {
            List<TrgOfferedBy> countries = new List<TrgOfferedBy>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("TrgOfferedByGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        TrgOfferedBy country = new TrgOfferedBy();
                        country.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        country.Name = reader.GetString(reader.GetOrdinal("Name"));
                        country.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        countries.Add(country);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return countries;
        }

        public void DeleteTrgOfferedBy(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("TrgOfferedByDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveTrgOfferedBy(TrgOfferedBy country)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", country.Id) 
                                               ,new SqlParameter("@Name", country.Name)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("TrgOfferedBySave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool TrgOfferedByExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Id", id), new SqlParameter("@Name", name) };
                return ExecuteScalar<bool>("TrgOfferedByExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
