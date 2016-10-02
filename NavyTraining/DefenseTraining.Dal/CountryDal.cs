using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class CountryDal : DalBase
    {
        public List<Country> GetCountries(CountryGroup group)
        {
            List<Country> countries = new List<Country>();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Group", group)
                                            };
                using (SqlDataReader reader = ExecuteReader("CountryGetAll", parameters))
                {
                    while (reader.Read())
                    {
                        Country country = MapToCountry(reader);
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

        private static Country MapToCountry(SqlDataReader reader)
        {
            Country country = new Country();
            country.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            country.Name = reader.GetString(reader.GetOrdinal("Name"));
            country.Group = (CountryGroup)Enum.Parse(typeof(CountryGroup), reader.GetValue(reader.GetOrdinal("Group")).ToString());
            country.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
            return country;
        }

        public Country GetCountry(int id)
        {
            OpenConnection();
            try
            {
                SqlDataReader reader = ExecuteReader("CountryGet", new SqlParameter[] { new SqlParameter("@Id", id) });
                if (reader.Read())
                {
                    return MapToCountry(reader);
                }
                else
                {
                    throw new Exception("No country found with ID: " + id);
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteCountry(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("CountryDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveCountry(Country country)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", country.Id) 
                                               ,new SqlParameter("@Group", country.Group)
                                               ,new SqlParameter("@Name", country.Name)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("CountrySave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
