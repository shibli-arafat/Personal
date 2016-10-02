using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class ServiceDataMapper
    {
        IDatabaseAccess _Db;
        public ServiceDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public ServiceCollection GetServices()
        {
            DataTable table = _Db.GetDataTable(StoredProcedureNames.ServiceGetAll, new QueryParameterCollection());
            ServiceCollection result = new ServiceCollection();
            foreach (DataRow item in table.Rows)
            {
                Service data = new Service();
                data.Id = (int)item["Id"];
                data.Name = string.Format("{0}", item["Name"]);
                result.Add(data);
            }
            return result;
        }

        public Service GetService(int Id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", Id));
            DataTable table = _Db.GetDataTable(StoredProcedureNames.ServiceGet, parameters);
            if (table.Rows.Count == 0) return null;
            Service data = new Service();
            data.Id = (int)table.Rows[0]["Id"];
            data.Name = string.Format("{0}", table.Rows[0]["Name"]);
            return data;
        }

        public void UpdateService(Service service)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", service.Id));
            parameters.Add(new QueryParameter("Name", service.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.ServiceUpdate, parameters);
        }

        public void AddService(Service service)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Name", service.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.ServiceAdd, parameters);
        }

        public void DeleteService(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            _Db.ExecuteNonQuery(StoredProcedureNames.ServiceDelete, parameters);
        }

        public bool IsDuplicate(int id, string name)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Name", name));
            DataTable table = _Db.GetDataTable("ServiceDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }
    }
}
