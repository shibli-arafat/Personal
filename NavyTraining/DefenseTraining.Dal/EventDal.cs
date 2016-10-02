using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class EventDal : DalBase
    {
        public List<Event> GetEvents(EventFilter filter, out int totalCount)
        {
            totalCount = 0;
            List<Event> events = new List<Event>();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@TotalCount", 0)
                                               ,new SqlParameter("@Id", filter.Id)
                                               ,new SqlParameter("@Name", filter.Name)
                                               ,new SqlParameter("@EventTypeId", filter.EventTypeId)
                                               ,new SqlParameter("@CountryId", filter.CountryId)
                                               ,new SqlParameter("@RankId", filter.RankId)
                                               ,new SqlParameter("@PersonalNo", filter.PersonalNo)
                                               ,new SqlParameter("@DateFrom", DateTime.ParseExact(filter.DateFrom, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@DateTo", DateTime.ParseExact(filter.DateTo, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@StartIndex", filter.StartIndex)
                                               ,new SqlParameter("@DisplayCount", filter.DisplayCount)
                                            };
                parameters[0].Direction = ParameterDirection.Output;
                using (DataSet ds = GetDataSet("EventGetAll", parameters))
                {
                    DataTable eventTable = ds.Tables[0];
                    foreach (DataRow row in eventTable.Rows)
                    {
                        Event evnt = new Event();
                        evnt.Id = Convert.ToInt32(row["Id"]);
                        evnt.Name = row["Name"].ToString();
                        evnt.Type.Name = row["TypeName"].ToString();
                        evnt.Country.Name = row["CountryName"].ToString();
                        evnt.City = row["City"].ToString();
                        evnt.Institute = row["Institute"].ToString();
                        evnt.StartsOn = Convert.ToDateTime(row["StartsOn"]).ToString("dd MMM yyyy");
                        evnt.EndsOn = Convert.ToDateTime(row["EndsOn"]).ToString("dd MMM yyyy");
                        evnt.IsActive = Convert.ToBoolean(row["IsActive"]);
                        events.Add(evnt);
                    }
                }
                totalCount = Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
            return events;
        }

        public void DeleteEvent(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("EventDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveEvent(Event evnt)
        {
            OpenConnection();
            try
            {

                DataTable responsibilities = new DataTable("IntType");
                responsibilities.Clear();
                responsibilities.Columns.Add("Id", typeof(int));
                DataTable requiredDocs = new DataTable("IntType");
                requiredDocs.Clear();
                requiredDocs.Columns.Add("Id", typeof(int));
                DataTable reminders = new DataTable("ReminderType");
                reminders.Clear();
                reminders.Columns.Add("RemindFor", typeof(string));
                reminders.Columns.Add("RemindOn", typeof(DateTime));
                reminders.Columns.Add("ActionsNeeded", typeof(string));
                foreach (Reminder reminder in evnt.Reminders)
                {
                    DataRow row = reminders.NewRow();
                    row["RemindFor"] = reminder.RemindFor;
                    row["RemindOn"] = DateTime.ParseExact(reminder.RemindOn, "dd MMM yyyy", CultureInfo.InvariantCulture);
                    row["ActionsNeeded"] = reminder.ActionsNeeded;
                    reminders.Rows.Add(row);
                }
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", evnt.Id) 
                                               ,new SqlParameter("@EventTypeId", evnt.Type.Id)
                                               ,new SqlParameter("@Name", evnt.Name)
                                               ,new SqlParameter("@CountryId", evnt.Country.Id)
                                               ,new SqlParameter("@City", evnt.City)
                                               ,new SqlParameter("@Institute", evnt.Institute)
                                               ,new SqlParameter("@StartsOn", DateTime.ParseExact(evnt.StartsOn, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@EndsOn",  DateTime.ParseExact(evnt.EndsOn, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@Responsibilities", responsibilities)
                                               ,new SqlParameter("@RequiredDocs", requiredDocs)
                                               ,new SqlParameter("@Reminders", reminders)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("EventSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Event GetEvent(int id)
        {
            Event evnt = new Event();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", id)
                                            };
                using (DataSet ds = GetDataSet("EventGet", parameters))
                {
                    DataTable eventData = ds.Tables[0];
                    DataTable respData = ds.Tables[1];
                    DataTable initAlotData = ds.Tables[2];
                    DataTable reAlotData = ds.Tables[3];
                    DataTable nomineeData = ds.Tables[4];
                    DataTable requiredDocData = ds.Tables[5];
                    DataTable reminderData = ds.Tables[6];
                    evnt = MapEvent(eventData.Rows[0]);
                }
            }
            finally
            {
                CloseConnection();
            }
            return evnt;
        }

        public List<EventReminder> GetReminders()
        {
            List<EventReminder> reminders = new List<EventReminder>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("EventReminderGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        EventReminder reminder = new EventReminder();
                        reminder.EventId = reader.GetInt32(reader.GetOrdinal("EventId"));
                        reminder.EventName = reader.GetString(reader.GetOrdinal("EventName"));
                        reminder.RemindFor = reader.GetString(reader.GetOrdinal("RemindFor"));
                        reminder.RemindOn = reader.GetDateTime(reader.GetOrdinal("RemindOn")).ToString("dd MMM yyyy");
                        reminders.Add(reminder);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return reminders;
        }

        public void DismissReminder(int eventId, string remindFor)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("EventReminderDismiss", new SqlParameter[] { 
                    new SqlParameter("@EventId", eventId)
                   ,new SqlParameter("@RemindFor", remindFor) 
                });
            }
            finally
            {
                CloseConnection();
            }
        }

        private List<RequiredDoc> MapRequiredDocs(DataTable table)
        {
            List<RequiredDoc> requiredDocs = new List<RequiredDoc>();
            foreach (DataRow row in table.Rows)
            {
                RequiredDoc requiredDoc = new RequiredDoc();
                requiredDoc.Id = Convert.ToInt32(row["Id"]);
                requiredDoc.Name = row["Name"].ToString();
                requiredDocs.Add(requiredDoc);
            }
            return requiredDocs;
        }

        private List<Reminder> MapReminders(DataTable reminderData)
        {
            List<Reminder> reminders = new List<Reminder>();
            foreach (DataRow row in reminderData.Rows)
            {
                Reminder reminder = new Reminder();
                reminder.RemindFor = row["RemindFor"].ToString();
                reminder.RemindOn = Convert.ToDateTime(row["RemindOn"]).ToString("dd MMM yyyy");
                reminder.ActionsNeeded = Convert.ToString(row["ActionsNeeded"]);
                reminders.Add(reminder);
            }
            return reminders;
        }

        private Event MapEvent(DataRow row)
        {
            Event evt = new Event();
            evt.Id = Convert.ToInt32(row["Id"]);
            evt.Name = row["Name"].ToString();
            evt.Institute = row["Institute"].ToString();
            evt.IsActive = Convert.ToBoolean(row["IsActive"]);
            evt.StartsOn = Convert.ToDateTime(row["StartsOn"].ToString()).ToString("dd MMM yyyy");
            evt.Type.Id = Convert.ToInt32(row["TypeId"]);
            evt.Type.Name = row["TypeName"].ToString();
            evt.City = row["City"].ToString();
            evt.Country.Id = Convert.ToInt32(row["CountryId"]);
            evt.Country.Name = row["CountryName"].ToString();
            evt.EndsOn = Convert.ToDateTime(row["EndsOn"].ToString()).ToString("dd MMM yyyy");
            return evt;
        }

        private List<ExpenseHead> MapResponsibilities(DataTable table)
        {
            List<ExpenseHead> responsibilities = new List<ExpenseHead>();
            foreach (DataRow row in table.Rows)
            {
                ExpenseHead responsibility = new ExpenseHead();
                responsibility.Id = Convert.ToInt32(row["Id"]);
                responsibility.Name = row["Name"].ToString();
                responsibilities.Add(responsibility);
            }
            return responsibilities;
        }
    }
}
