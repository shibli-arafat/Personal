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
                                               ,new SqlParameter("@GenreId", filter.GenreId)
                                               ,new SqlParameter("@SpecialityId", filter.SpecialityId)
                                               ,new SqlParameter("@CountryId", filter.CountryId)
                                               ,new SqlParameter("@InstituteId", filter.InstituteId)
                                               ,new SqlParameter("@TrgOfferedById", filter.TrgOfferedById)
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
                    DataTable nomineeTable = ds.Tables[1];
                    foreach (DataRow row in eventTable.Rows)
                    {
                        Event evnt = new Event();
                        evnt.Id = Convert.ToInt32(row["Id"]);
                        evnt.Name = row["Name"].ToString();
                        evnt.Type.Name = row["TypeName"].ToString();
                        evnt.Genre.Name = row["GenreName"].ToString();
                        evnt.Speciality.Name = row["SpecialityName"].ToString();
                        evnt.Country.Name = row["CountryName"].ToString();
                        evnt.City = row["City"].ToString();
                        evnt.Institute.Id = Convert.ToInt32(row["InstituteId"]);
                        evnt.Institute.Name = row["InstituteName"].ToString();
                        evnt.TrgOfferedBy.Id = Convert.ToInt32(row["TrgOfferedById"]);
                        evnt.TrgOfferedBy.Name = row["TrgOfferedByName"].ToString();
                        evnt.StartsOn = Convert.ToDateTime(row["StartsOn"]).ToString("dd MMM yyyy");
                        evnt.EndsOn = Convert.ToDateTime(row["EndsOn"]).ToString("dd MMM yyyy");
                        evnt.AcceptanceOn = Convert.ToDateTime(row["AcceptanceOn"]).ToString("dd MMM yyyy");
                        evnt.NominationOn = Convert.ToDateTime(row["NominationOn"]).ToString("dd MMM yyyy");
                        evnt.DocForwardOn = Convert.ToDateTime(row["DocForwardedOn"]).ToString("dd MMM yyyy");
                        evnt.Vacancies = Convert.ToInt32(row["Vacancies"]);
                        evnt.IsActive = Convert.ToBoolean(row["IsActive"]);
                        if (row["CreatedBy"] != DBNull.Value)
                        {
                            evnt.CreatedBy = row["CreatedBy"].ToString();
                        }
                        if (row["CreatedOn"] != DBNull.Value)
                        {
                            evnt.CreatedOn = Convert.ToDateTime(row["CreatedOn"]).ToString("dd MMM yyyy, hh:mm tt");
                        }
                        if (row["ModifiedBy"] != DBNull.Value)
                        {
                            evnt.ModifiedBy = row["ModifiedBy"].ToString();
                        }
                        if (row["ModifiedOn"] != DBNull.Value)
                        {
                            evnt.ModifiedOn = Convert.ToDateTime(row["ModifiedOn"]).ToString("dd MMM yyyy, hh:mm tt");
                        }
                        foreach (DataRow nomineeRow in nomineeTable.Rows)
                        {
                            if (Convert.ToInt32(nomineeRow["EventId"]) == evnt.Id)
                            {
                                Nominee nominee = new Nominee();
                                nominee.Name = nomineeRow["Name"].ToString();
                                nominee.PersonalNo = nomineeRow["PersonalNo"].ToString();
                                nominee.Rank.Id = Convert.ToInt32(nomineeRow["RankId"]);
                                nominee.Rank.Name = nomineeRow["RankName"].ToString();
                                nominee.Unit.Id = Convert.ToInt32(nomineeRow["UnitId"]);
                                nominee.Unit.Name = nomineeRow["UnitName"].ToString();
                                nominee.Branch.Id = Convert.ToInt32(nomineeRow["BranchId"]);
                                nominee.Branch.Name = nomineeRow["BranchName"].ToString();
                                evnt.Nominees.Add(nominee);
                            }
                        }
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

        public void DeleteEvent(int id, string modifiedBy)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("EventDelete", new SqlParameter[] { new SqlParameter("@Id", id), new SqlParameter("@ModifiedBy", modifiedBy) });
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
                DataTable initAlotment = new DataTable("AlotmentType");
                initAlotment.Clear();
                initAlotment.Columns.Add("ServiceId", typeof(Int32));
                initAlotment.Columns.Add("Quota", typeof(string));
                initAlotment.Columns.Add("Availed", typeof(Int32));
                initAlotment.Columns.Add("ReasonofNotAvailing", typeof(string));
                foreach (Alotment alotment in evnt.Allotments)
                {
                    DataRow row = initAlotment.NewRow();
                    row["ServiceId"] = alotment.Service.Id;
                    row["Quota"] = alotment.Allotted;
                    row["Availed"] = alotment.Availed;
                    row["ReasonOfNotAvailing"] = alotment.ReasonOfNotAvailing;
                    initAlotment.Rows.Add(row);
                }
                DataTable reAlotment = new DataTable("AlotmentType");
                reAlotment.Clear();
                reAlotment.Columns.Add("ServiceId", typeof(Int32));
                reAlotment.Columns.Add("Quota", typeof(string));
                reAlotment.Columns.Add("Availed", typeof(Int32));
                reAlotment.Columns.Add("ReasonofNotAvailing", typeof(string));
                foreach (Alotment alotment in evnt.ReAllotments)
                {
                    DataRow row = reAlotment.NewRow();
                    row["ServiceId"] = alotment.Service.Id;
                    row["Quota"] = alotment.Allotted;
                    row["Availed"] = alotment.Availed;
                    row["ReasonOfNotAvailing"] = alotment.ReasonOfNotAvailing;
                    reAlotment.Rows.Add(row);
                }
                DataTable nominees = new DataTable("NomineeType");
                nominees.Clear();
                nominees.Columns.Add("PersonalNo", typeof(string));
                nominees.Columns.Add("Name", typeof(string));
                nominees.Columns.Add("RankId", typeof(int));
                nominees.Columns.Add("UnitId", typeof(int));
                nominees.Columns.Add("BranchId", typeof(int));
                foreach (Nominee nominee in evnt.Nominees)
                {
                    DataRow row = nominees.NewRow();
                    row["PersonalNo"] = nominee.PersonalNo;
                    row["Name"] = nominee.Name;
                    row["RankId"] = nominee.Rank.Id;
                    row["UnitId"] = nominee.Unit.Id;
                    row["BranchId"] = nominee.Branch.Id;
                    nominees.Rows.Add(row);
                }
                DataTable responsibilities = new DataTable("IntType");
                responsibilities.Clear();
                responsibilities.Columns.Add("Id", typeof(int));
                foreach (Responsibility responsibility in evnt.Responsibilities)
                {
                    DataRow row = responsibilities.NewRow();
                    row["Id"] = responsibility.Id;
                    responsibilities.Rows.Add(row);
                }
                DataTable ownResponsibilities = new DataTable("IntType");
                ownResponsibilities.Clear();
                ownResponsibilities.Columns.Add("Id", typeof(int));
                foreach (Responsibility responsibility in evnt.OwnResponsibilities)
                {
                    DataRow row = ownResponsibilities.NewRow();
                    row["Id"] = responsibility.Id;
                    ownResponsibilities.Rows.Add(row);
                }
                DataTable requiredDocs = new DataTable("IntType");
                requiredDocs.Clear();
                requiredDocs.Columns.Add("Id", typeof(int));
                foreach (RequiredDoc requiredDoc in evnt.RequiredDocs)
                {
                    DataRow row = requiredDocs.NewRow();
                    row["Id"] = requiredDoc.Id;
                    requiredDocs.Rows.Add(row);
                }
                DataTable reminders = new DataTable("ReminderType");
                reminders.Clear();
                reminders.Columns.Add("RemindFor", typeof(string));
                reminders.Columns.Add("RemindOn", typeof(DateTime));
                reminders.Columns.Add("RespAgency", typeof(string));
                reminders.Columns.Add("Dismissed", typeof(bool));
                foreach (Reminder reminder in evnt.Reminders)
                {
                    DataRow row = reminders.NewRow();
                    row["RemindFor"] = reminder.RemindFor;
                    row["RemindOn"] = DateTime.ParseExact(reminder.RemindOn, "dd MMM yyyy", CultureInfo.InvariantCulture);
                    row["RespAgency"] = reminder.RespAgency;
                    row["Dismissed"] = reminder.Dismissed;
                    reminders.Rows.Add(row);
                }
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", evnt.Id) 
                                               ,new SqlParameter("@EventTypeId", evnt.Type.Id)
                                               ,new SqlParameter("@GenreId", evnt.Genre.Id)
                                               ,new SqlParameter("@SpecialityId", evnt.Speciality.Id)
                                               ,new SqlParameter("@Name", evnt.Name)
                                               ,new SqlParameter("@CountryId", evnt.Country.Id)
                                               ,new SqlParameter("@City", evnt.City)
                                               ,new SqlParameter("@InstituteId", evnt.Institute.Id)
                                               ,new SqlParameter("@TrgOfferedById", evnt.TrgOfferedBy.Id)
                                               ,new SqlParameter("@StartsOn", DateTime.ParseExact(evnt.StartsOn, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@EndsOn",  DateTime.ParseExact(evnt.EndsOn, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@Ranks", evnt.Ranks)
                                               ,new SqlParameter("@Vacancies", evnt.Vacancies)
                                               ,new SqlParameter("@Responsibilities", responsibilities)
                                               ,new SqlParameter("@InitAlotment", initAlotment)
                                               ,new SqlParameter("@ReAlotment", reAlotment)
                                               ,new SqlParameter("@AcceptanceOn", DateTime.ParseExact(evnt.AcceptanceOn, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@NominationOn", DateTime.ParseExact(evnt.NominationOn, "dd MMM yyyy", CultureInfo.InvariantCulture))                                              
                                               ,new SqlParameter("@DocForwardOn", DateTime.ParseExact(evnt.DocForwardOn, "dd MMM yyyy", CultureInfo.InvariantCulture))                                              
                                               ,new SqlParameter("@CreatedBy", evnt.CreatedBy)
                                               ,new SqlParameter("@ModifiedBy", evnt.ModifiedBy)
                                               ,new SqlParameter("@Nominees", nominees)
                                               ,new SqlParameter("@RequiredDocs", requiredDocs)
                                               ,new SqlParameter("@Reminders", reminders)
                                               ,new SqlParameter("@OwnResponsibilities", ownResponsibilities)
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
                    DataTable ownRespData = ds.Tables[7];
                    evnt = MapEvent(eventData.Rows[0]);
                    evnt.Responsibilities = MapResponsibilities(respData);
                    evnt.Allotments = MapAlotment(initAlotData);
                    evnt.ReAllotments = MapAlotment(reAlotData);
                    evnt.Nominees = MapNominees(nomineeData);
                    evnt.RequiredDocs = MapRequiredDocs(requiredDocData);
                    evnt.Reminders = MapReminders(reminderData);
                    evnt.OwnResponsibilities = MapResponsibilities(ownRespData);
                }
            }
            finally
            {
                CloseConnection();
            }
            return evnt;
        }

        public List<EventReminder> GetReminders(int sortBy)
        {
            List<EventReminder> reminders = new List<EventReminder>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("EventReminderGetAll", new SqlParameter[] { new SqlParameter("@SortBy", sortBy) }))
                {
                    int i = 1;
                    while (reader.Read())
                    {
                        EventReminder reminder = new EventReminder();
                        reminder.SlNo = i;
                        reminder.EventId = reader.GetInt32(reader.GetOrdinal("EventId"));
                        reminder.EventName = reader.GetString(reader.GetOrdinal("EventName"));
                        reminder.RemindFor = reader.GetString(reader.GetOrdinal("RemindFor"));
                        reminder.RemindOn = reader.GetDateTime(reader.GetOrdinal("RemindOn")).ToString("dd MMM yyyy");
                        reminder.RespAgency = reader.GetString(reader.GetOrdinal("RespAgency"));
                        reminder.StartDate = reader.GetDateTime(reader.GetOrdinal("StartsOn")).ToString("dd MMM yyyy");
                        reminder.EndDate = reader.GetDateTime(reader.GetOrdinal("EndsOn")).ToString("dd MMM yyyy");
                        reminder.Country = reader.GetString(reader.GetOrdinal("Country"));
                        reminders.Add(reminder);
                        i++;
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
                reminder.RespAgency = row["RespAgency"].ToString();
                reminder.Dismissed = Convert.ToBoolean(row["Dismissed"]);
                reminders.Add(reminder);
            }
            return reminders;
        }

        private Event MapEvent(DataRow row)
        {
            Event evnt = new Event();
            evnt.Id = Convert.ToInt32(row["Id"]);
            evnt.Name = row["Name"].ToString();
            evnt.Institute.Id = Convert.ToInt32(row["InstituteId"]);
            evnt.Institute.Name = row["InstituteName"].ToString();
            evnt.TrgOfferedBy.Id = Convert.ToInt32(row["TrgOfferedById"]);
            evnt.TrgOfferedBy.Name = row["TrgOfferedByName"].ToString();
            evnt.IsActive = Convert.ToBoolean(row["IsActive"]);
            evnt.NominationOn = Convert.ToDateTime(row["NominationOn"].ToString()).ToString("dd MMM yyyy");
            evnt.Ranks = row["Rank"].ToString();
            evnt.Speciality.Id = Convert.ToInt32(row["SpecialityId"]);
            evnt.Speciality.Name = row["SpecialityName"].ToString();
            evnt.StartsOn = Convert.ToDateTime(row["StartsOn"].ToString()).ToString("dd MMM yyyy");
            evnt.Type.Id = Convert.ToInt32(row["TypeId"]);
            evnt.Type.Name = row["TypeName"].ToString();
            evnt.AcceptanceOn = Convert.ToDateTime(row["AcceptanceOn"].ToString()).ToString("dd MMM yyyy");
            evnt.City = row["City"].ToString();
            evnt.Country.Id = Convert.ToInt32(row["CountryId"]);
            evnt.Country.Name = row["CountryName"].ToString();
            evnt.DocForwardOn = Convert.ToDateTime(row["DocForwardedOn"].ToString()).ToString("dd MMM yyyy");
            evnt.EndsOn = Convert.ToDateTime(row["EndsOn"].ToString()).ToString("dd MMM yyyy");
            evnt.Genre.Id = Convert.ToInt32(row["GenreId"]);
            evnt.Genre.Name = row["GenreName"].ToString();
            evnt.Vacancies = Convert.ToInt32(row["Vacancies"]);
            if (row["CreatedBy"] != DBNull.Value)
            {
                evnt.CreatedBy = row["CreatedBy"].ToString();
            }
            if (row["CreatedOn"] != DBNull.Value)
            {
                evnt.CreatedOn = Convert.ToDateTime(row["CreatedOn"]).ToString("dd MMM yyyy, hh:mm tt");
            }
            if (row["ModifiedBy"] != DBNull.Value)
            {
                evnt.ModifiedBy = row["ModifiedBy"].ToString();
            }
            if (row["ModifiedOn"] != DBNull.Value)
            {
                evnt.ModifiedOn = Convert.ToDateTime(row["ModifiedOn"]).ToString("dd MMM yyyy, hh:mm tt");
            }
            return evnt;
        }

        private List<Responsibility> MapResponsibilities(DataTable table)
        {
            List<Responsibility> responsibilities = new List<Responsibility>();
            foreach (DataRow row in table.Rows)
            {
                Responsibility responsibility = new Responsibility();
                responsibility.Id = Convert.ToInt32(row["Id"]);
                responsibility.Name = row["Name"].ToString();
                responsibilities.Add(responsibility);
            }
            return responsibilities;
        }

        private List<Alotment> MapAlotment(DataTable table)
        {
            List<Alotment> alotments = new List<Alotment>();
            foreach (DataRow row in table.Rows)
            {
                Alotment alotment = new Alotment();
                alotment.Service.Id = Convert.ToInt32(row["ServiceId"]);
                alotment.Service.Name = row["ServiceName"].ToString();
                alotment.Allotted = Convert.ToInt32(row["Quota"]);
                alotment.Availed = Convert.ToInt32(row["Availed"]);
                alotment.ReasonOfNotAvailing = Convert.ToString(row["ReasonOfNotAvailing"]);
                alotments.Add(alotment);
            }
            return alotments;
        }

        private List<Nominee> MapNominees(DataTable table)
        {
            List<Nominee> nominees = new List<Nominee>();
            foreach (DataRow row in table.Rows)
            {
                Nominee nominee = new Nominee();
                nominee.PersonalNo = row["PersonalNo"].ToString();
                nominee.Rank.Id = Convert.ToInt32(row["RankId"]);
                nominee.Rank.Name = row["RankName"].ToString();
                nominee.Name = row["Name"].ToString();
                nominee.Unit.Id = Convert.ToInt32(row["UnitId"]);
                nominee.Unit.Name = row["UnitName"].ToString();
                nominee.Branch.Id = Convert.ToInt32(row["BranchId"]);
                nominee.Branch.Name = row["BranchName"].ToString();
                nominees.Add(nominee);
            }
            return nominees;
        }

        public bool EventExists(int id, string name, string startsOn)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Id", id), new SqlParameter("@Name", name), new SqlParameter("@Year", DateTime.ParseExact(startsOn, "dd MMM yyyy", CultureInfo.InvariantCulture).Year) };
                return ExecuteScalar<bool>("EventExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
