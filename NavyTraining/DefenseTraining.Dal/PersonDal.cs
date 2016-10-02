using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class PersonDal : DalBase
    {
        public List<Person> GetPersons(string personNo, string name, int rankId)
        {
            List<Person> persons = new List<Person>();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@PersonNo", personNo)
                                               ,new SqlParameter("@Name", name)
                                               ,new SqlParameter("@RankId", rankId)                                               
                                            };
                using (SqlDataReader reader = ExecuteReader("PersonGetAll", parameters))
                {
                    while (reader.Read())
                    {
                        Person person = MapToPerson(reader);
                        persons.Add(person);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return persons;
        }

        public Person GetPerson(int id)
        {
            OpenConnection();
            try
            {
                SqlDataReader reader = ExecuteReader("PersonGet", new SqlParameter[] { new SqlParameter("@Id", id) });
                if (reader.Read())
                {
                    return MapToPerson(reader);
                }
                else
                {
                    throw new Exception("No person found with ID: " + id);
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeletePerson(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("PersonDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SavePerson(Person person)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", person.Id) 
                                               ,new SqlParameter("@PersonNo", person.PersonNo)
                                               ,new SqlParameter("@Name", person.Name)
                                               ,new SqlParameter("@RankId", person.Rank.Id)
                                               ,new SqlParameter("@Email", person.Email)
                                               ,new SqlParameter("@MobileNo", person.MobileNo)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("PersonSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool PersonExists(int id, string personNo)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@Id", id)
                                               ,new SqlParameter("@PersonNo", personNo)
                                            };
                return ExecuteScalar<bool>("PersonExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }

        private static Person MapToPerson(SqlDataReader reader)
        {
            Person person = new Person();
            person.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            person.PersonNo = reader.GetString(reader.GetOrdinal("PersonNo"));
            person.Name = reader.GetString(reader.GetOrdinal("Name"));
            person.Rank.Id = reader.GetInt32(reader.GetOrdinal("RankId"));
            person.Rank.Name = reader.GetString(reader.GetOrdinal("RankName"));
            person.Rank.Group.Id = reader.GetInt32(reader.GetOrdinal("RankGroupId"));
            person.Rank.Group.Name = reader.GetString(reader.GetOrdinal("RankGroupName"));
            person.Email = reader.GetString(reader.GetOrdinal("Email"));
            person.MobileNo = reader.GetString(reader.GetOrdinal("MobileNo"));
            person.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
            return person;
        }
    }
}
