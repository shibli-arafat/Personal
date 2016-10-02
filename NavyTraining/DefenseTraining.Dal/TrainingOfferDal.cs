using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class TrainingOfferDal : DalBase
    {
        public List<TrainingOffer> GetTrainingOffers()
        {
            List<TrainingOffer> expenseHeads = new List<TrainingOffer>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("TrainingOfferGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        TrainingOffer trainingOffer = new TrainingOffer();
                        trainingOffer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        trainingOffer.Name = reader.GetString(reader.GetOrdinal("Name"));
                        trainingOffer.Country.Id = reader.GetInt32(reader.GetOrdinal("CountryId"));
                        trainingOffer.Country.Name = reader.GetString(reader.GetOrdinal("CountryName"));
                        trainingOffer.RankGroup.Id = reader.GetInt32(reader.GetOrdinal("RankGroupId"));
                        trainingOffer.RankGroup.Name = reader.GetString(reader.GetOrdinal("RankGroupName"));
                        trainingOffer.EventType.Id = reader.GetInt32(reader.GetOrdinal("EventTypeId"));
                        trainingOffer.EventType.Name = reader.GetString(reader.GetOrdinal("EventTypeName"));
                        trainingOffer.NoOfVacancies = reader.GetInt32(reader.GetOrdinal("NoOfVacancies"));
                        trainingOffer.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")).ToString("dd MMM yyyy");
                        trainingOffer.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")).ToString("dd MMM yyyy");
                        trainingOffer.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        expenseHeads.Add(trainingOffer);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return expenseHeads;
        }

        public TrainingOffer GetTrainingOffer(int id)
        {
            OpenConnection();
            try
            {
                using (DataSet ds = GetDataSet("TrainingOfferGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    TrainingOffer trainingOffer = new TrainingOffer();
                    trainingOffer.Id = Convert.ToInt32(dr["Id"]);
                    trainingOffer.Name = Convert.ToString(dr["Name"]);
                    trainingOffer.Country.Id = Convert.ToInt32(dr["CountryId"]);
                    trainingOffer.Country.Name = Convert.ToString(dr["CountryName"]);
                    trainingOffer.RankGroup.Id = Convert.ToInt32(dr["RankGroupId"]);
                    trainingOffer.RankGroup.Name = Convert.ToString(dr["RankGroupName"]);
                    trainingOffer.EventType.Id = Convert.ToInt32(dr["EventTypeId"]);
                    trainingOffer.EventType.Name = Convert.ToString(dr["EventTypeName"]);
                    trainingOffer.NoOfVacancies = Convert.ToInt32(dr["NoOfVacancies"]);
                    trainingOffer.StartDate = Convert.ToDateTime(dr["StartDate"]).ToString("dd MMM yyyy");
                    trainingOffer.EndDate = Convert.ToDateTime(dr["EndDate"]).ToString("dd MMM yyyy");
                    trainingOffer.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    foreach (DataRow dr1 in ds.Tables[1].Rows)
                    {
                        ExpenseHead responsibility = new ExpenseHead();
                        responsibility.Id = Convert.ToInt32(dr1["Id"]);
                        responsibility.Name = Convert.ToString(dr1["Name"]);
                        trainingOffer.HostResponsibilities.Add(responsibility);
                    }
                    foreach (DataRow dr1 in ds.Tables[2].Rows)
                    {
                        RequiredDoc requiredDoc = new RequiredDoc();
                        requiredDoc.Id = Convert.ToInt32(dr1["Id"]);
                        requiredDoc.Name = Convert.ToString(dr1["Name"]);
                        trainingOffer.RequiredDocs.Add(requiredDoc);
                    }
                    return trainingOffer;
                    throw new Exception("No budget found in the system with ID: " + id);
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteTrainingOffer(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("TrainingOfferDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveTrainingOffer(TrainingOffer trainingOffer)
        {
            OpenConnection();
            try
            {
                DataTable responsibilities = new DataTable("IntType");
                responsibilities.Clear();
                responsibilities.Columns.Add("Id", typeof(int));
                foreach (ExpenseHead responsibility in trainingOffer.HostResponsibilities)
                {
                    DataRow row = responsibilities.NewRow();
                    row["Id"] = responsibility.Id;
                    responsibilities.Rows.Add(row);
                }
                DataTable requiredDocs = new DataTable("IntType");
                requiredDocs.Clear();
                requiredDocs.Columns.Add("Id", typeof(int));
                foreach (RequiredDoc requiredDoc in trainingOffer.RequiredDocs)
                {
                    DataRow row = requiredDocs.NewRow();
                    row["Id"] = requiredDoc.Id;
                    requiredDocs.Rows.Add(row);
                }
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", trainingOffer.Id) 
                                               ,new SqlParameter("@Name", trainingOffer.Name)
                                               ,new SqlParameter("@EventTypeId", trainingOffer.EventType.Id)
                                               ,new SqlParameter("@CountryId", trainingOffer.Country.Id)
                                               ,new SqlParameter("@RankGroupId", trainingOffer.RankGroup.Id)
                                               ,new SqlParameter("@NoOfVacancies", trainingOffer.NoOfVacancies)
                                               ,new SqlParameter("@StartDate", DateTime.ParseExact(trainingOffer.StartDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@EndDate", DateTime.ParseExact(trainingOffer.EndDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@HostResponsibilities", responsibilities)
                                               ,new SqlParameter("@RequiredDocs", requiredDocs)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("TrainingOfferSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool TrainingOfferExists(int id, string startDate, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@Id", id)
                                               ,new SqlParameter("@TrainingYear", DateTime.ParseExact(startDate, "dd MMM yyyy", CultureInfo.InvariantCulture).Year)
                                               ,new SqlParameter("@Name", name)
                                            };
                return ExecuteScalar<bool>("TrainingOfferExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
