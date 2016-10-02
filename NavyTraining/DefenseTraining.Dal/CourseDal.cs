using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class CourseDal : DalBase
    {
        public List<Course> GetCourses(int eventTypeId, string keyword)
        {
            List<Course> ranks = new List<Course>();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@EventTypeId", eventTypeId) 
                                               ,new SqlParameter("@Keyword", keyword)
                                            };
                using (SqlDataReader reader = ExecuteReader("CourseGetAll", parameters))
                {
                    while (reader.Read())
                    {
                        Course rank = new Course();
                        rank.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        rank.Name = reader.GetString(reader.GetOrdinal("Name"));
                        rank.EventType.Id = reader.GetInt32(reader.GetOrdinal("EventTypeId"));
                        rank.EventType.Name = reader.GetString(reader.GetOrdinal("EventTypeName"));
                        rank.PreRequisites = reader.GetString(reader.GetOrdinal("PreRequisites"));
                        rank.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        ranks.Add(rank);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return ranks;
        }

        public Course GetCourse(int id)
        {
            Course rank = new Course();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("CourseGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    if (reader.Read())
                    {
                        rank.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        rank.Name = reader.GetString(reader.GetOrdinal("Name"));
                        rank.EventType.Id = reader.GetInt32(reader.GetOrdinal("EventTypeId"));
                        rank.EventType.Name = reader.GetString(reader.GetOrdinal("EventTypeName"));
                        rank.PreRequisites = reader.GetString(reader.GetOrdinal("PreRequisites"));
                        rank.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return rank;
        }

        public void DeleteCourse(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("CourseDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveCourse(Course rank)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", rank.Id) 
                                               ,new SqlParameter("@Name", rank.Name)
                                               ,new SqlParameter("@EventTypeId", rank.EventType.Id)
                                               ,new SqlParameter("@PreRequisites", rank.PreRequisites)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("CourseSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool CourseExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("Id", id)
                                               ,new SqlParameter("Name", name)
                                            };
                return ExecuteScalar<bool>("CourseExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
