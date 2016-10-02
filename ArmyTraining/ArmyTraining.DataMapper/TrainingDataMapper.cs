using System;
using System.Data;
using System.Text;
using ArmyTraining.Model;
using ArmyTraining.Model.Trainings;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class TrainingDataMapper
    {
        private IDatabaseAccess _Db;

        public TrainingDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public Training GetTraining(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            DataSet ds = _Db.GetDataSet(StoredProcedureNames.TrainingGet, parameters);
            return MapToTraining(ds);
        }

        private Training MapToTraining(DataSet ds)
        {
            Training training = new Training();
            PopulateGeneral(training, ds.Tables[0]);
            PopulateBudget(training, ds.Tables[1], ds.Tables[0]);
            PopulateTrainees(training, ds.Tables[2]);
            PopulateFlow(training, ds.Tables[3]);
            return training;
        }

        private void PopulateGeneral(Training training, DataTable generalTable)
        {
            if (generalTable.Rows.Count == 0) throw new Exception("No training found");
            training.Id = (int)generalTable.Rows[0]["Id"];
            training.General.CountryId = (int)generalTable.Rows[0]["CountryId"];
            training.General.CountryName = string.Format("{0}", generalTable.Rows[0]["CountryName"]);
            training.General.CourseId = (int)generalTable.Rows[0]["COurseId"];
            training.General.CourseName = string.Format("{0}", generalTable.Rows[0]["CourseName"]);
            training.General.EndDate = (DateTime)generalTable.Rows[0]["EndDate"];
            training.General.Prerequisites = string.Format("{0}", generalTable.Rows[0]["Prerequisites"]);
            training.General.Remarks = string.Format("{0}", generalTable.Rows[0]["Remarks"]);
            training.General.SponsorCountryId = (int)generalTable.Rows[0]["SponsorCountryId"];
            training.General.SponsorCountryName = string.Format("{0}", generalTable.Rows[0]["SponsorCountryName"]);
            training.General.StartDate = (DateTime)generalTable.Rows[0]["StartDate"];
            training.General.TrainingLevel = (TrainingLevel)Enum.Parse(typeof(TrainingLevel), generalTable.Rows[0]["TrainingLevel"].ToString());
        }

        private void PopulateTrainees(Training training, DataTable traineeTable)
        {
            TraineeCollection result = new TraineeCollection();
            for (int rowIndex = 0; rowIndex < traineeTable.Rows.Count; rowIndex++)
            {
                Trainee item = new Trainee();
                item.Id = (int)traineeTable.Rows[rowIndex]["Id"];
                item.PersonId = (int)traineeTable.Rows[rowIndex]["PersonId"];
                item.RankId = (int)traineeTable.Rows[rowIndex]["RankId"];
                if (traineeTable.Rows[rowIndex]["Expenditure"] != DBNull.Value)
                {
                    item.Expenditure = (decimal)traineeTable.Rows[rowIndex]["Expenditure"];
                }
                if (traineeTable.Rows[rowIndex]["OtherExpenditure"] != DBNull.Value)
                {
                    item.OtherExpenditure = (decimal)traineeTable.Rows[rowIndex]["OtherExpenditure"];
                }
                if (traineeTable.Rows[rowIndex]["Sponsor"] != DBNull.Value)
                {
                    item.Sponsor = (string)traineeTable.Rows[rowIndex]["Sponsor"];
                }
                if (traineeTable.Rows[rowIndex]["DocName"] != DBNull.Value)
                {
                    item.DocName = (string)traineeTable.Rows[rowIndex]["DocName"];
                }
                result.Add(item);
            }
            training.Trainees = result;
        }

        private void PopulateFlow(Training training, DataTable flowTable)
        {
            TrainingFlow item = new TrainingFlow();
            if (flowTable.Rows.Count > 0)
            {
                DataRow dr = flowTable.Rows[0];
                item.Id = (int)dr["Id"];
                if (dr["AcceptanceDate"] != DBNull.Value)
                {
                    item.AcceptanceDate = (DateTime)dr["AcceptanceDate"];
                }
                if (dr["AttachmentDate"] != DBNull.Value)
                {
                    item.AttachmentDate = (DateTime)dr["AttachmentDate"];
                }
                if (dr["DocumentDate"] != DBNull.Value)
                {
                    item.DocumentDate = (DateTime)dr["DocumentDate"];
                }
                if (dr["DraftGoDate"] != DBNull.Value)
                {
                    item.DraftGoDate = (DateTime)dr["DraftGoDate"];
                }
                if (dr["EntitlementDate"] != DBNull.Value)
                {
                    item.EntitlementDate = (DateTime)dr["EntitlementDate"];
                }
                if (dr["FltItineraryDate"] != DBNull.Value)
                {
                    item.FltItineraryDate = (DateTime)dr["FltItineraryDate"];
                }
                if (dr["LetterToAllConcern"] != DBNull.Value)
                {
                    item.LetterToAllConcernDate = (DateTime)dr["LetterToAllConcern"];
                }
                if (dr["MedicalDate"] != DBNull.Value)
                {
                    item.MedicalDate = (DateTime)dr["MedicalDate"];
                }
                if (dr["NominationDate"] != DBNull.Value)
                {
                    item.NominationDate = (DateTime)dr["NominationDate"];
                }
                if (dr["OfferLetterDate"] != DBNull.Value)
                {
                    item.OfferLetterDate = (DateTime)dr["OfferLetterDate"];
                }
                if (dr["SelectionLetterDate"] != DBNull.Value)
                {
                    item.SelectionLetterDate = (DateTime)dr["SelectionLetterDate"];
                }
            }
            training.Flows = item;
        }

        private void PopulateBudget(Training training, DataTable budgetTable, DataTable commonTable)
        {
            training.Budget.AdditionalExpences = new AdditionalExpenditureCollection();
            if (commonTable.Rows.Count > 0)
            {
                string str = string.Format("{0}", commonTable.Rows[0]["AdditionalExpenditure"]);
                if (!string.IsNullOrEmpty(str))
                {
                    training.Budget.AdditionalExpences = XmlSerializeHelper<AdditionalExpenditureCollection>.Deserialize(str);
                }
            }
        }

        public void UpdateTraining(Training training)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", training.Id));
            parameters.Add(new QueryParameter("CourseId", training.General.CourseId));
            parameters.Add(new QueryParameter("CountryId", training.General.CountryId));
            parameters.Add(new QueryParameter("SponsorCountryId", training.General.SponsorCountryId));
            parameters.Add(new QueryParameter("TrainingLevel", (int)training.General.TrainingLevel));
            parameters.Add(new QueryParameter("PreRequisites", training.General.Prerequisites));
            parameters.Add(new QueryParameter("Remarks", training.General.Remarks));
            parameters.Add(new QueryParameter("StartDate", training.General.StartDate));
            parameters.Add(new QueryParameter("EndDate", training.General.EndDate));
            if (training.Budget.AdditionalExpences != null)
            {
                parameters.Add(new QueryParameter("AdditionalExpenses", XmlSerializeHelper<AdditionalExpenditureCollection>.Serialize(training.Budget.AdditionalExpences)));
            }
            parameters.Add(new QueryParameter("Trainees", XmlSerializeHelper<TraineeCollection>.Serialize(training.Trainees)));
            parameters.Add(new QueryParameter("FlowId", training.Flows.Id));
            if (training.Flows.AcceptanceDate == null)
            {
                parameters.Add(new QueryParameter("AcceptanceDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("AcceptanceDate", training.Flows.AcceptanceDate));
            }
            if (training.Flows.AttachmentDate == null)
            {
                parameters.Add(new QueryParameter("AttachmentDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("AttachmentDate", training.Flows.AttachmentDate));
            }
            if (training.Flows.DocumentDate == null)
            {
                parameters.Add(new QueryParameter("DocumentDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("DocumentDate", training.Flows.DocumentDate));
            }
            if (training.Flows.DraftGoDate == null)
            {
                parameters.Add(new QueryParameter("DraftGoDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("DraftGoDate", training.Flows.DraftGoDate));
            }
            if (training.Flows.GoDate == null)
            {
                parameters.Add(new QueryParameter("GoDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("GoDate", training.Flows.GoDate));
            }
            if (training.Flows.EntitlementDate == null)
            {
                parameters.Add(new QueryParameter("EntitlementDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("EntitlementDate", training.Flows.EntitlementDate));
            }
            if (training.Flows.FltItineraryDate == null)
            {
                parameters.Add(new QueryParameter("FltItineraryDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("FltItineraryDate", training.Flows.FltItineraryDate));
            }
            if (training.Flows.LetterToAllConcernDate == null)
            {
                parameters.Add(new QueryParameter("LetterToAllConcern", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("LetterToAllConcern", training.Flows.LetterToAllConcernDate));
            }
            if (training.Flows.MedicalDate == null)
            {
                parameters.Add(new QueryParameter("MedicalDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("MedicalDate", training.Flows.MedicalDate));
            }
            if (training.Flows.NominationDate == null)
            {
                parameters.Add(new QueryParameter("NominationDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("NominationDate", training.Flows.NominationDate));
            }
            if (training.Flows.OfferLetterDate == null)
            {
                parameters.Add(new QueryParameter("OfferLetterDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("OfferLetterDate", training.Flows.OfferLetterDate));
            }
            if (training.Flows.SelectionLetterDate == null)
            {
                parameters.Add(new QueryParameter("SelectionLetterDate", DBNull.Value));
            }
            else
            {
                parameters.Add(new QueryParameter("SelectionLetterDate", training.Flows.SelectionLetterDate));
            }

            _Db.ExecuteNonQuery(StoredProcedureNames.TrainingUpdate, parameters);
        }

        public int AddTraining(Training training)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", training.Id));
            parameters[0].IsOutput = true;
            parameters.Add(new QueryParameter("CourseId", training.General.CourseId));
            parameters.Add(new QueryParameter("CountryId", training.General.CountryId));
            parameters.Add(new QueryParameter("SponsorCountryId", training.General.SponsorCountryId));
            parameters.Add(new QueryParameter("TrainingLevel", (int)training.General.TrainingLevel));
            parameters.Add(new QueryParameter("PreRequisites", training.General.Prerequisites));
            parameters.Add(new QueryParameter("Remarks", training.General.Remarks));
            parameters.Add(new QueryParameter("StartDate", training.General.StartDate));
            parameters.Add(new QueryParameter("EndDate", training.General.EndDate));
            _Db.ExecuteNonQuery(StoredProcedureNames.TrainingAdd, parameters);
            return (int)parameters.GetParameterByName("Id").Value;
        }

        public TrainingSearchResult GetTrainings(TrainingFilter filter)
        {
            TrainingSearchResult result = new TrainingSearchResult();
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("StartDate", filter.StartDate));
            parameters.Add(new QueryParameter("EndDate", filter.EndDate));
            parameters.Add(new QueryParameter("Duration", filter.Duration));
            parameters.Add(new QueryParameter("IsUpto", filter.IsUpto));
            parameters.Add(new QueryParameter("DurationType", filter.DurationType));
            parameters.Add(new QueryParameter("CountryId", filter.CountryId));
            parameters.Add(new QueryParameter("SponsorCountryId", filter.SponsorCountryId));
            parameters.Add(new QueryParameter("CourseTypeId", filter.CourseTypeId));
            parameters.Add(new QueryParameter("CourseId", filter.CourseId));
            parameters.Add(new QueryParameter("CompletionType", (int)filter.CompletionType));
            parameters.Add(new QueryParameter("PersonalNo", filter.PersonalNo));
            parameters.Add(new QueryParameter("CourseLevel", filter.CourseLevel));
            parameters.Add(new QueryParameter("RankId", filter.RankId));
            parameters.Add(new QueryParameter("PageNumber", filter.PageNumber));
            parameters.Add(new QueryParameter("Count", filter.Count));
            parameters.Add(new QueryParameter("TrainingLevel", (int)filter.TrainingLevel));
            parameters.Add(new QueryParameter("TrainingBkgId", filter.TrainingBkgId));
            parameters.Add(new QueryParameter("TotalCount", 0, true));
            parameters.Add(new QueryParameter("TrainingId", filter.TrainingId));
            parameters.Add(new QueryParameter("TrainingYear", filter.TrainingYear));

            DataTable tbl = _Db.GetDataTable("TrainingGetAll", parameters);
            foreach (DataRow dr in tbl.Rows)
            {
                TrainingInfo item = new TrainingInfo();
                item.Id = (int)dr["Id"];
                item.CountryName = string.Format("{0}", dr["Country"]);
                item.CourseName = string.Format("{0}", dr["Course"]);
                item.Description = string.Format("{0}", dr["Remarks"]);
                item.StartDate = (DateTime)dr["StartDate"];
                item.EndDate = (DateTime)dr["EndDate"];
                item.Qualifications = string.Format("{0}", dr["PreRequisites"]);
                item.TraineeInfos = GetTraineeInfos(item.Id, filter.RankId);
                result.Result.Add(item);
            }
            result.TotalCount = (int)parameters.GetParameterByName("TotalCount").Value;
            return result;
        }

        private TraineeInfoCollection GetTraineeInfos(int trainingId, int rankId)
        {
            TraineeInfoCollection traineeInfos = new TraineeInfoCollection();
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("TrainingId", trainingId));
            parameters.Add(new QueryParameter("RankId", rankId));
            DataTable table = _Db.GetDataTable("TraineeInfoGetAll", parameters);
            foreach (DataRow row in table.Rows)
            {
                TraineeInfo teeInfo = new TraineeInfo();
                teeInfo.PersonalNo = row["PersonalNumber"].ToString();
                teeInfo.Name = row["Name"].ToString();
                traineeInfos.Add(teeInfo);
            }
            return traineeInfos;
        }

        public void DeleteTraining(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("id", id));
            _Db.ExecuteNonQuery("TrainingDelete", parameters);
        }

        public TrainingReportCollection GetTrainingReports(ReportFilter filter)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("CompletionType", (int)filter.CompletionType));
            parameters.Add(new QueryParameter("CountryId", filter.CountryId));
            parameters.Add(new QueryParameter("CourseId", filter.CourseId));
            parameters.Add(new QueryParameter("Duration", filter.Duration));
            parameters.Add(new QueryParameter("DurationType", filter.DurationType));
            parameters.Add(new QueryParameter("EndDate", filter.EndDate));
            parameters.Add(new QueryParameter("IsUpto", filter.IsUpto));
            parameters.Add(new QueryParameter("PersonalNo", filter.PersonalNo));
            parameters.Add(new QueryParameter("RankId", filter.RankId));
            parameters.Add(new QueryParameter("SponsorCountryId", filter.SponsorCountryId));
            parameters.Add(new QueryParameter("StartDate", filter.StartDate));
            parameters.Add(new QueryParameter("CourseLevel", (int)filter.CourseLevel));
            parameters.Add(new QueryParameter("TrainingLevel", (int)filter.TrainingLevel));
            parameters.Add(new QueryParameter("TrainingBkgId", filter.TrainingBkgId));
            parameters.Add(new QueryParameter("CourseTypeId", filter.CourseTypeId));
            parameters.Add(new QueryParameter("TrainingId", filter.TrainingId));
            parameters.Add(new QueryParameter("TrainingYear", filter.TrainingYear));
            DataTable dataTable = _Db.GetDataTable("TrainingReportGetAll", parameters);
            TrainingReportCollection reports = new TrainingReportCollection();
            foreach (DataRow row in dataTable.Rows)
            {
                reports.Add(MapTrainingReport(row));
            }
            return reports;
        }

        private TrainingReport MapTrainingReport(DataRow row)
        {
            TrainingReport report = new TrainingReport();
            report.TrainingId = (int)row["TrainingId"];
            report.StartDate = (DateTime)row["StartDate"];
            report.EndDate = (DateTime)row["EndDate"];
            report.Country = row["CountryName"] as string;
            report.SponsorCountry = row["SponsorCountryName"] as string;
            report.Rank = row["RankName"] as string;
            report.Course = row["CourseName"] as string;
            report.PersonNo = row["PersonalNumber"] as string;
            report.PersonId = (int)row["PersonId"];
            report.PersonName = row["Name"] as string;
            report.ServiceName = row["ServiceName"] as string;
            report.DocName = row["DocName"] as string;
            if (row["FinancialInvolvement"] != DBNull.Value)
            {
                report.FinancialInvolvement = double.Parse(row["FinancialInvolvement"].ToString());
            }
            if (row["OfferLetterDate"] != DBNull.Value)
            {
                report.OfferLetterDate = ((DateTime)row["OfferLetterDate"]).ToString("d/M/yy");
            }
            if (row["AcceptanceDate"] != DBNull.Value)
            {
                report.AcceptanceDate = ((DateTime)row["AcceptanceDate"]).ToString("d/M/yy");
            }
            if (row["NominationDate"] != DBNull.Value)
            {
                report.NominationDate = ((DateTime)row["NominationDate"]).ToString("d/M/yy");
            }
            if (row["DraftGoDate"] != DBNull.Value)
            {
                report.DraftGoDate = ((DateTime)row["DraftGoDate"]).ToString("d/M/yy");
            }
            if (row["GoDate"] != DBNull.Value)
            {
                report.GoDate = ((DateTime)row["GoDate"]).ToString("d/M/yy");
            }
            if (row["SelectionLetterDate"] != DBNull.Value)
            {
                report.SelectionLetterDate = ((DateTime)row["SelectionLetterDate"]).ToString("d/M/yy");
            }
            if (row["LetterToAllConcern"] != DBNull.Value)
            {
                report.LetterToAllConcern = ((DateTime)row["LetterToAllConcern"]).ToString("d/M/yy");
            }
            if (row["AttachmentDate"] != DBNull.Value)
            {
                report.Attachment = ((DateTime)row["AttachmentDate"]).ToString("d/M/yy");
            }
            if (row["MedicalDate"] != DBNull.Value)
            {
                report.Medical = ((DateTime)row["MedicalDate"]).ToString("d/M/yy");
            }
            if (row["DocumentDate"] != DBNull.Value)
            {
                report.DocumentDate = ((DateTime)row["DocumentDate"]).ToString("d/M/yy");
            }
            if (row["FltItineraryDate"] != DBNull.Value)
            {
                report.FltItinerary = ((DateTime)row["FltItineraryDate"]).ToString("d/M/yy");
            }
            if (row["EntitlementDate"] != DBNull.Value)
            {
                report.EntitlementDate = ((DateTime)row["EntitlementDate"]).ToString("d/M/yy");
            }
            report.TrainingLevel = Enum.Parse(typeof(TrainingLevel), row["TrainingLevel"].ToString()).ToString();
            if (row["TrainingBkg"] != DBNull.Value)
            {
                report.TrainingBkg = row["TrainingBkg"].ToString();
            }
            report.CourseType = row["CourseType"].ToString();
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("PersonId", (int)row["PersonId"]));
            DataTable table = _Db.GetDataTable("DecorationsGetByPersonId", parameters);
            StringBuilder decorations = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                decorations.Append(dr["DecorationName"].ToString() + ", ");
            }
            if (row["Remarks"] != DBNull.Value)
            {
                report.Remarks = row["Remarks"].ToString();
            }
            char[] chars = new char[] { ',', ' ' };
            report.Decoration = decorations.ToString().TrimEnd(chars);
            return report;
        }

        public decimal GetBalanceForSameYearExceptThisTraining(int trainingId, int trainingYear)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("TrainingId", trainingId));
            parameters.Add(new QueryParameter("TrainingYear", trainingYear));
            object obj = _Db.ExecuteScaler("GetBalance", parameters);
            if (obj != DBNull.Value)
            {
                return (decimal)obj;
            }
            return 0;
        }

        public void BackupDatabase(string backupPath)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("DatabaseName", "ArmyTraining"));
            parameters.Add(new QueryParameter("BackupPath", backupPath));
            parameters.Add(new QueryParameter("BackupName", "ArmyTraining"));
            _Db.ExecuteNonQuery(StoredProcedureNames.BackupDatabase, parameters);
        }

        public bool IsDuplicate(int trainingId, int courseId, DateTime startDate)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("TrainingId", trainingId));
            parameters.Add(new QueryParameter("CourseId", courseId));
            parameters.Add(new QueryParameter("StartDate", startDate));
            DataTable dataTable = _Db.GetDataTable("TrainingGetForDuplicate", parameters);
            return dataTable.Rows.Count != 0;
        }
    }
}
