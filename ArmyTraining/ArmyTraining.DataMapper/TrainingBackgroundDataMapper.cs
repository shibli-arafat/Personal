using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class TrainingBackgroundDataMapper
    {
        private IDatabaseAccess _Db;

        public TrainingBackgroundDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public TrainingBackgroundCollection GetTrainingBackgrounds()
        {
            DataTable table = _Db.GetDataTable(StoredProcedureNames.TrainingBackgroundGetAll, new QueryParameterCollection());
            TrainingBackgroundCollection result = new TrainingBackgroundCollection();
            foreach (DataRow item in table.Rows)
            {
                TrainingBackground data = new TrainingBackground();
                data.Id = (int)item["Id"];
                data.Name = string.Format("{0}", item["Name"]);
                result.Add(data);
            }
            return result;
        }

        public TrainingBackground GetTrainingBackground(int Id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", Id));
            DataTable table = _Db.GetDataTable(StoredProcedureNames.TrainingBackgroundGet, parameters);
            if (table.Rows.Count == 0) return null;
            TrainingBackground data = new TrainingBackground();
            data.Id = (int)table.Rows[0]["Id"];
            data.Name = string.Format("{0}", table.Rows[0]["Name"]);
            return data;
        }

        public void UpdateTrainingBackground(TrainingBackground trainingBkg)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", trainingBkg.Id));
            parameters.Add(new QueryParameter("Name", trainingBkg.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.TrainingBackgroundUpdate, parameters);
        }

        public void AddTrainingBackground(TrainingBackground trainingBkg)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", trainingBkg.Id, true));
            parameters.Add(new QueryParameter("Name", trainingBkg.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.TrainingBackgroundAdd, parameters);
        }

        public void DeleteTrainingBackground(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            _Db.ExecuteNonQuery(StoredProcedureNames.TrainingBackgroundDelete, parameters);
        }

        public bool IsDuplicate(int id, string name)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Name", name));
            DataTable table = _Db.GetDataTable("TrainingBackgroundDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }
    }
}
