using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class InstituteDal : DalBase
    {
        public List<Institute> GetInstitutes()
        {
            List<Institute> institutes = new List<Institute>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("InstituteGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        Institute institute = new Institute();
                        institute.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        institute.Name = reader.GetString(reader.GetOrdinal("Name"));
                        institute.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        institutes.Add(institute);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return institutes;
        }

        public void DeleteInstitute(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("InstituteDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveInstitute(Institute institute)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", institute.Id) 
                                               ,new SqlParameter("@Name", institute.Name)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("InstituteSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool InstituteExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Id", id), new SqlParameter("@Name", name) };
                return ExecuteScalar<bool>("InstituteExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
