using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class RankDataMapper
    {
        IDatabaseAccess _Db;
        public RankDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public RankCollection GetRanks()
        {
            DataTable table = _Db.GetDataTable(StoredProcedureNames.RankGetAll, new QueryParameterCollection());
            RankCollection result = new RankCollection();
            foreach (DataRow item in table.Rows)
            {
                Rank data = new Rank();
                data.Id = (int)item["Id"];
                data.Name = string.Format("{0}", item["Name"]);
                result.Add(data);
            }
            return result;
        }

        public Rank GetRank(int Id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", Id));
            DataTable table = _Db.GetDataTable(StoredProcedureNames.RankGet, parameters);
            if (table.Rows.Count == 0) return null;
            Rank data = new Rank();
            data.Id = (int)table.Rows[0]["Id"];
            data.Name = string.Format("{0}", table.Rows[0]["Name"]);
            return data;
        }

        public void UpdateRanks(Rank rank)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", rank.Id));
            parameters.Add(new QueryParameter("Name", rank.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.RankUpdate, parameters);
        }

        public void AddRank(Rank rank)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Name", rank.Name));

            _Db.ExecuteNonQuery(StoredProcedureNames.RankAdd, parameters);
        }

        public void DeleteRank(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            _Db.ExecuteNonQuery(StoredProcedureNames.RankDelete, parameters);
        }

        public bool IsDuplicate(int id, string name)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Name", name));
            DataTable table = _Db.GetDataTable("RankDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }
    }
}
