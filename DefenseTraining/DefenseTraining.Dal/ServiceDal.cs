using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class ServiceDal : DalBase
    {
        public List<Service> GetServices()
        {
            List<Service> services = new List<Service>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("ServiceGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        Service service = new Service();
                        service.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        service.Name = reader.GetString(reader.GetOrdinal("Name"));
                        service.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        services.Add(service);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return services;
        }

        public void DeleteService(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("ServiceDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveService(Service service)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", service.Id) 
                                               ,new SqlParameter("@Name", service.Name)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("ServiceSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ServiceExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Id", id), new SqlParameter("@Name", name) };
                return ExecuteScalar<bool>("ServiceExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
