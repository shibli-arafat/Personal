using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class TrainingDal : DalBase
    {
        public List<Training> GetTrainings(TrainingFilter filter, out int totalCount)
        {
            List<Training> trainings = new List<Training>();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@Id", filter.Id)
                                               ,new SqlParameter("@PersonNo", filter.PersonNo)
                                               ,new SqlParameter("@RankId", filter.RankId)
                                               ,new SqlParameter("@EventTypeId", filter.EventTypeId)
                                               ,new SqlParameter("@CourseId", filter.CourseId)
                                               ,new SqlParameter("@CountryId", filter.CountryId)
                                               ,new SqlParameter("@DateFrom", DateTime.ParseExact(filter.DateFrom, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@DateTo", DateTime.ParseExact(filter.DateTo, "dd MMM yyyy", CultureInfo.InvariantCulture))                                               
                                               ,new SqlParameter("@StartIndex", filter.StartIndex)
                                               ,new SqlParameter("@DataPerPage", filter.DataPerPage)
                                               ,new SqlParameter("@TotalCount", 0)
                                            };
                parameters[10].Direction = ParameterDirection.Output;
                using (DataSet ds = GetDataSet("TrainingGetAll", parameters))
                {
                    DataTable trTable = ds.Tables[0];
                    DataTable teeTable = ds.Tables[1];
                    foreach (DataRow row in trTable.Rows)
                    {
                        Training training = new Training();
                        training.AcceptanceDate = Convert.ToDateTime(row["AcceptanceDate"]).ToString("dd MMM yyyy");
                        training.BriefingDate = Convert.ToDateTime(row["BriefingDate"]).ToString("dd MMM yyyy");
                        training.DocForwardDate = Convert.ToDateTime(row["DocForwardDate"]).ToString("dd MMM yyyy");
                        training.DocumentDate = Convert.ToDateTime(row["DocumentDate"]).ToString("dd MMM yyyy");
                        training.EndDate = Convert.ToDateTime(row["EndDate"]).ToString("dd MMM yyyy");
                        training.MedicalDate = Convert.ToDateTime(row["MedicalDate"]).ToString("dd MMM yyyy");
                        training.NominationDate = Convert.ToDateTime(row["NominationDate"]).ToString("dd MMM yyyy");
                        training.StartDate = Convert.ToDateTime(row["StartDate"]).ToString("dd MMM yyyy");
                        training.Country.Id = Convert.ToInt32(row["CountryId"]);
                        training.Country.Name = Convert.ToString(row["CountryName"]);
                        training.Course.Id = Convert.ToInt32(row["CourseId"]);
                        training.Course.Name = Convert.ToString(row["CourseName"]);
                        training.Id = Convert.ToInt32(row["Id"]);
                        training.IsActive = Convert.ToBoolean(row["IsActive"]);

                        training.Trainees = MapTrainees(training.Id, teeTable);

                        trainings.Add(training);
                    }
                }
                totalCount = Convert.ToInt32(parameters[10].Value);
            }
            finally
            {
                CloseConnection();
            }
            return trainings;
        }

        private List<Trainee> MapTrainees(int trainingId, DataTable teeTable)
        {
            List<Trainee> trainees = new List<Trainee>();
            foreach (DataRow teeRow in teeTable.Rows)
            {
                int trId = Convert.ToInt32(teeRow["TrainingId"]);
                if (trId == trainingId)
                {
                    Trainee trainee = new Trainee();
                    trainee.Person.Id = Convert.ToInt32(teeRow["PersonId"]);
                    trainee.Person.PersonNo = Convert.ToString(teeRow["PersonNo"]);
                    trainee.Person.Name = Convert.ToString(teeRow["PersonName"]);
                    trainee.Rank.Id = Convert.ToInt32(teeRow["RankId"]);
                    trainee.Rank.Name = Convert.ToString(teeRow["RankName"]);
                    trainees.Add(trainee);
                }
            }
            return trainees;
        }

        public Training GetTraining(int id)
        {
            Training training = new Training();
            OpenConnection();
            try
            {
                using (DataSet ds = GetDataSet("TrainingGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    DataTable trTable = ds.Tables[0];
                    DataTable rdTable = ds.Tables[1];
                    DataTable hrTable = ds.Tables[2];
                    DataTable teeTable = ds.Tables[3];
                    DataTable expTable = ds.Tables[4];
                    DataTable spExpTable = ds.Tables[5];
                    DataTable kpExpTable = ds.Tables[6];
                    DataTable remTable = ds.Tables[7];
                    if (trTable.Rows.Count > 0)
                    {
                        DataRow row = trTable.Rows[0];
                        training.AcceptanceDate = Convert.ToDateTime(row["AcceptanceDate"]).ToString("dd MMM yyyy");
                        training.BriefingDate = Convert.ToDateTime(row["BriefingDate"]).ToString("dd MMM yyyy");
                        training.DocForwardDate = Convert.ToDateTime(row["DocForwardDate"]).ToString("dd MMM yyyy");
                        training.DocumentDate = Convert.ToDateTime(row["DocumentDate"]).ToString("dd MMM yyyy");
                        training.EndDate = Convert.ToDateTime(row["EndDate"]).ToString("dd MMM yyyy");
                        training.MedicalDate = Convert.ToDateTime(row["MedicalDate"]).ToString("dd MMM yyyy");
                        training.NominationDate = Convert.ToDateTime(row["NominationDate"]).ToString("dd MMM yyyy");
                        training.StartDate = Convert.ToDateTime(row["StartDate"]).ToString("dd MMM yyyy");
                        training.PaymentFrom = Convert.ToDateTime(row["PaymentFrom"]).ToString("dd MMM yyyy");
                        training.PaymentTo = Convert.ToDateTime(row["PaymentTo"]).ToString("dd MMM yyyy");
                        training.UsdRate = Convert.ToDouble(row["UsdRate"]);
                        training.Country.Id = Convert.ToInt32(row["CountryId"]);
                        training.Country.Name = Convert.ToString(row["CountryName"]);
                        training.Course.Id = Convert.ToInt32(row["CourseId"]);
                        training.Course.Name = Convert.ToString(row["CourseName"]);
                        training.Id = Convert.ToInt32(row["Id"]);
                        training.IsActive = Convert.ToBoolean(row["IsActive"]);
                    }
                    foreach (DataRow row in rdTable.Rows)
                    {
                        RequiredDoc rd = new RequiredDoc();
                        rd.Id = Convert.ToInt32(row["RequiredDocId"]);
                        rd.Name = Convert.ToString(row["RequiredDocName"]);
                        training.RequiredDocs.Add(rd);
                    }
                    foreach (DataRow row in hrTable.Rows)
                    {
                        ExpenseHead eh = new ExpenseHead();
                        eh.Id = Convert.ToInt32(row["ExpenseHeadId"]);
                        eh.Name = Convert.ToString(row["ExpenseHeadName"]);
                        training.HostResponsibilities.Add(eh);
                    }
                    foreach (DataRow row in teeTable.Rows)
                    {
                        Trainee tee = new Trainee();
                        tee.Person.Id = Convert.ToInt32(row["PersonId"]);
                        tee.Person.Name = Convert.ToString(row["PersonName"]);
                        tee.NoOfKids = Convert.ToInt32(row["NoOfKids"]);
                        tee.Rank.Id = Convert.ToInt32(row["RankId"]);
                        tee.Rank.Name = Convert.ToString(row["RankName"]);
                        foreach (DataRow expRow in expTable.Rows)
                        {
                            if (Convert.ToInt32(expRow["PersonId"]) == tee.Person.Id)
                            {
                                Expense exp = new Expense();
                                exp.Amount = Convert.ToDouble(expRow["Amount"]);
                                exp.Head.Id = Convert.ToInt32(expRow["ExpenseHeadId"]);
                                exp.Head.Name = Convert.ToString(expRow["ExpenseHeadName"]);
                                exp.IsSelected = Convert.ToBoolean(expRow["IsSelected"]);
                                exp.Quantity = Convert.ToInt32(expRow["Quantity"]);
                                tee.Expenses.Add(exp);
                            }
                        }
                        foreach (DataRow expRow in spExpTable.Rows)
                        {
                            if (Convert.ToInt32(expRow["PersonId"]) == tee.Person.Id)
                            {
                                Expense exp = new Expense();
                                exp.Amount = Convert.ToDouble(expRow["Amount"]);
                                exp.Head.Id = Convert.ToInt32(expRow["ExpenseHeadId"]);
                                exp.Head.Name = Convert.ToString(expRow["ExpenseHeadName"]);
                                exp.IsSelected = Convert.ToBoolean(expRow["IsSelected"]);
                                exp.Quantity = Convert.ToInt32(expRow["Quantity"]);
                                tee.SpouseExpenses.Add(exp);
                            }
                        }
                        foreach (DataRow expRow in kpExpTable.Rows)
                        {
                            if (Convert.ToInt32(expRow["PersonId"]) == tee.Person.Id)
                            {
                                Expense exp = new Expense();
                                exp.Amount = Convert.ToDouble(expRow["Amount"]);
                                exp.Head.Id = Convert.ToInt32(expRow["ExpenseHeadId"]);
                                exp.Head.Name = Convert.ToString(expRow["ExpenseHeadName"]);
                                exp.IsSelected = Convert.ToBoolean(expRow["IsSelected"]);
                                exp.Quantity = Convert.ToInt32(expRow["Quantity"]);
                                tee.KidExpenses.Add(exp);
                            }
                        }
                        training.Trainees.Add(tee);
                    }
                    foreach (DataRow row in remTable.Rows)
                    {
                        Reminder rem = new Reminder();
                        rem.ActionsNeeded = Convert.ToString(row["ActionsNeeded"]);
                        rem.RemindFor = Convert.ToString(row["RemindFor"]);
                        rem.RemindOn = Convert.ToDateTime(row["RemindOn"]).ToString("dd MMM yyyy");
                        training.Reminders.Add(rem);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return training;
        }

        public void DeleteTraining(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("TrainingDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveTraining(Training training)
        {
            OpenConnection();
            try
            {
                DataTable traineeTable = CreateTraineeTable(training);
                DataTable reminderTable = CreateReminderTable(training);
                List<DataTable> expenseTables = CreateExpenseTables(training);
                DataTable responsibilityTable = CreateResponsibilityTable(training);
                DataTable reqDocTable = CreateRequiredDocTable(training);
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", training.Id)
                                               ,new SqlParameter("@CourseId", training.Course.Id)
                                               ,new SqlParameter("@CountryId", training.Country.Id)
                                               ,new SqlParameter("@StartDate", DateTime.ParseExact(training.StartDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@EndDate", DateTime.ParseExact(training.EndDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@MedicalDate", DateTime.ParseExact(training.MedicalDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@DocumentDate", DateTime.ParseExact(training.DocumentDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@BriefingDate", DateTime.ParseExact(training.BriefingDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@NominationDate", DateTime.ParseExact(training.NominationDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@AcceptanceDate", DateTime.ParseExact(training.AcceptanceDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@DocForwardDate", DateTime.ParseExact(training.DocForwardDate, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@PaymentFrom", DateTime.ParseExact(training.PaymentFrom, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@PaymentTo", DateTime.ParseExact(training.PaymentTo, "dd MMM yyyy", CultureInfo.InvariantCulture))
                                               ,new SqlParameter("@UsdRate",training.UsdRate)
                                               ,new SqlParameter("@Trainees", traineeTable)
                                               ,new SqlParameter("@HostResponsibilities", responsibilityTable)
                                               ,new SqlParameter("@Reminders", reminderTable)
                                               ,new SqlParameter("@RequiredDocs", reqDocTable)
                                               ,new SqlParameter("@Expenses", expenseTables[0])
                                               ,new SqlParameter("@SpouseExpenses", expenseTables[1])
                                               ,new SqlParameter("@KidExpenses", expenseTables[2])
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("TrainingSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<TrainingReminder> GetReminders()
        {
            List<TrainingReminder> reminders = new List<TrainingReminder>();
            OpenConnection();
            try
            {
                using (IDataReader reader = ExecuteReader("TrainingReminderGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        TrainingReminder reminder = new TrainingReminder();
                        reminder.TrainingId = reader.GetInt32(reader.GetOrdinal("TrainingId"));
                        reminder.CourseName = reader.GetString(reader.GetOrdinal("CourseName"));
                        reminder.RemindFor = reader.GetString(reader.GetOrdinal("Reminder"));
                        reminder.ActionsNeeded = reader.GetString(reader.GetOrdinal("ActionsNeeded"));
                        reminder.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")).ToString("dd MM yyyy");
                        reminder.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")).ToString("dd MM yyyy");
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

        private DataTable CreateRequiredDocTable(Training training)
        {
            DataTable table = new DataTable("IntType");
            table.Clear();
            table.Columns.Add("Id", typeof(int));
            foreach (RequiredDoc doc in training.RequiredDocs)
            {
                DataRow row = table.NewRow();
                row["Id"] = doc.Id;
                table.Rows.Add(row);
            }
            return table;
        }

        private DataTable CreateResponsibilityTable(Training training)
        {
            DataTable table = new DataTable("IntType");
            table.Clear();
            table.Columns.Add("Id", typeof(int));
            foreach (ExpenseHead head in training.HostResponsibilities)
            {
                DataRow row = table.NewRow();
                row["Id"] = head.Id;
                table.Rows.Add(row);
            }
            return table;
        }

        private static DataTable CreateReminderTable(Training training)
        {
            DataTable table = new DataTable("ReminderType");
            table.Clear();
            table.Columns.Add("RemindFor", typeof(string));
            table.Columns.Add("RemindOn", typeof(DateTime));
            table.Columns.Add("ActionsNeeded", typeof(string));
            foreach (Reminder reminder in training.Reminders)
            {
                DataRow row = table.NewRow();
                row["RemindFor"] = reminder.RemindFor;
                row["RemindOn"] = DateTime.ParseExact(reminder.RemindOn, "dd MMM yyyy", CultureInfo.InvariantCulture);
                row["ActionsNeeded"] = reminder.ActionsNeeded;
                table.Rows.Add(row);
            }
            return table;
        }

        private static DataTable CreateTraineeTable(Training training)
        {
            DataTable treeTable = new DataTable("TraineeType");
            treeTable.Clear();
            treeTable.Columns.Add("PersonId", typeof(string));
            treeTable.Columns.Add("RankId", typeof(int));
            treeTable.Columns.Add("NoOfKids", typeof(int));
            foreach (Trainee tree in training.Trainees)
            {
                DataRow row = treeTable.NewRow();
                row["PersonId"] = tree.Person.Id;
                row["RankId"] = tree.Rank.Id;
                row["NoOfKids"] = tree.NoOfKids;
                treeTable.Rows.Add(row);
            }
            return treeTable;
        }

        private static List<DataTable> CreateExpenseTables(Training training)
        {
            List<DataTable> expTables = new List<DataTable>();
            DataTable expTable = new DataTable("ExpenseType");
            expTable.Clear();
            expTable.Columns.Add("PersonId", typeof(int));
            expTable.Columns.Add("ExpenseHeadId", typeof(int));
            expTable.Columns.Add("Amount", typeof(double));
            expTable.Columns.Add("Quantity", typeof(int));
            expTable.Columns.Add("IsSelected", typeof(bool));

            DataTable spExpTable = new DataTable("ExpenseType");
            spExpTable.Clear();
            spExpTable.Columns.Add("PersonId", typeof(int));
            spExpTable.Columns.Add("ExpenseHeadId", typeof(int));
            spExpTable.Columns.Add("Amount", typeof(double));
            spExpTable.Columns.Add("Quantity", typeof(int));
            spExpTable.Columns.Add("IsSelected", typeof(bool));

            DataTable kdExpTable = new DataTable("ExpenseType");
            kdExpTable.Clear();
            kdExpTable.Columns.Add("PersonId", typeof(int));
            kdExpTable.Columns.Add("ExpenseHeadId", typeof(int));
            kdExpTable.Columns.Add("Amount", typeof(double));
            kdExpTable.Columns.Add("Quantity", typeof(int));
            kdExpTable.Columns.Add("IsSelected", typeof(bool));
            if (training.Trainees == null || training.Trainees.Count == 0)
            {
                expTables.Add(expTable);
                expTables.Add(spExpTable);
                expTables.Add(kdExpTable);
            }
            else
            {
                foreach (Trainee tree in training.Trainees)
                {
                    foreach (Expense expense in tree.Expenses)
                    {
                        DataRow row = expTable.NewRow();
                        row["PersonId"] = tree.Person.Id;
                        row["ExpenseHeadId"] = expense.Head.Id;
                        row["Amount"] = expense.Amount;
                        row["Quantity"] = expense.Quantity;
                        row["IsSelected"] = expense.IsSelected;
                        expTable.Rows.Add(row);
                    }
                    expTables.Add(expTable);
                    foreach (Expense expense in tree.SpouseExpenses)
                    {
                        DataRow row = spExpTable.NewRow();
                        row["PersonId"] = tree.Person.Id;
                        row["ExpenseHeadId"] = expense.Head.Id;
                        row["Amount"] = expense.Amount;
                        row["Quantity"] = expense.Quantity;
                        row["IsSelected"] = expense.IsSelected;
                        spExpTable.Rows.Add(row);
                    }
                    expTables.Add(spExpTable);
                    foreach (Expense expense in tree.KidExpenses)
                    {
                        DataRow row = kdExpTable.NewRow();
                        row["PersonId"] = tree.Person.Id;
                        row["ExpenseHeadId"] = expense.Head.Id;
                        row["Amount"] = expense.Amount;
                        row["Quantity"] = expense.Quantity;
                        row["IsSelected"] = expense.IsSelected;
                        kdExpTable.Rows.Add(row);
                    }
                    expTables.Add(kdExpTable);
                }
            }
            return expTables;
        }

        public bool TrainingExists(int id, int name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("Id", id)
                                               ,new SqlParameter("Name", name)
                                            };
                return ExecuteScalar<bool>("TrainingExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
