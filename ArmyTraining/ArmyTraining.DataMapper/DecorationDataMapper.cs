using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class DecorationDataMapper
    {
        IDatabaseAccess _Db;
        public DecorationDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public DecorationCollection GetDecorations()
        {
            DataTable table = _Db.GetDataTable(StoredProcedureNames.DecorationGetAll, new QueryParameterCollection());
            DecorationCollection result = new DecorationCollection();
            foreach (DataRow item in table.Rows)
            {
                Decoration data = new Decoration();
                data.Id = (int)item["Id"];
                data.Name = string.Format("{0}", item["Name"]);
                result.Add(data);
            }
            return result;
        }

        public Decoration GetDecoration(int Id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", Id));
            DataTable table = _Db.GetDataTable(StoredProcedureNames.DecorationGet, parameters);
            if (table.Rows.Count == 0) return null;
            Decoration data = new Decoration();
            data.Id = (int)table.Rows[0]["Id"];
            data.Name = string.Format("{0}", table.Rows[0]["Name"]);
            return data;
        }

        public void UpdateDecoration(Decoration decoration)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", decoration.Id));
            parameters.Add(new QueryParameter("Name", decoration.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.DecorationUpdate, parameters);
        }

        public void AddDecoration(Decoration decoration)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Name", decoration.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.DecorationAdd, parameters);
        }

        public void DeleteDecoration(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            _Db.ExecuteNonQuery(StoredProcedureNames.DecorationDelete, parameters);
        }

        public bool IsDuplicate(int id, string name)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Name", name));
            DataTable table = _Db.GetDataTable("DecorationDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }
    }
}
