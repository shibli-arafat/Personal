using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class EventTypeDal : DalBase
    {
        public List<EventType> GetEventTypes()
        {
            List<EventType> evtTypes = new List<EventType>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("EventTypeGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        EventType evtType = new EventType();
                        evtType.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        evtType.Name = reader.GetString(reader.GetOrdinal("Name"));
                        evtType.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        evtTypes.Add(evtType);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return evtTypes;
        }

        public void DeleteEventType(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("EventTypeDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveEventType(EventType eventType)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", eventType.Id) 
                                               ,new SqlParameter("@Name", eventType.Name)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("EventTypeSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
