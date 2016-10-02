using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml;

namespace Dit.Common
{
    public class DatabaseHelper
    {
        private SqlConnection _Connection;

        public DatabaseHelper(string connectionString)
        {
            _Connection = new SqlConnection(connectionString);
        }

        public QueryResult<T> ExecuteNonQuery<T>(string spName, DataParamCollection parameters)
        {
            SqlCommand command = CreateCommand(spName, parameters);
            SqlParameter param = new SqlParameter("@Returnvalue", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(param);
            try
            {
                command.ExecuteNonQuery();
                foreach (DataParam dataParam in parameters)
                {
                    if (dataParam.IsOutput)
                    {
                        dataParam.Value = command.Parameters[dataParam.Name].Value;
                    }
                }
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return new QueryResult<T>(parameters, Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value));
        }

        public T ExecuteScaler<T>(string spName, DataParamCollection dataParams)
        {
            SqlCommand command = CreateCommand(spName, dataParams);
            return (T)command.ExecuteScalar();
        }

        public QueryResult<T> ExecuteQuery<T>(string spName, DataParamCollection parameters)
        {
            QueryResult<T> result = null;
            SqlCommand command = CreateCommand(spName, parameters);
            IDataParameter param = new SqlParameter("@Returnvalue", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(param);
            try
            {
                XmlReader reader = command.ExecuteXmlReader();
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                string dataXml = document.OuterXml;
                if (!string.IsNullOrEmpty(dataXml))
                {
                    result = new QueryResult<T>(parameters, Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value), SerializeHelper.Deserialize<T>(dataXml));
                }
                else
                {
                    result = new QueryResult<T>(parameters, Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value), default(T));
                }
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return result;
        }

        public QueryListResult<T> ExecuteListQuery<T>(string spName, DataParamCollection parameters)
        {
            QueryListResult<T> listResult = null;
            SqlCommand command = CreateCommand(spName, parameters);
            SqlParameter param = new SqlParameter("@ReturnValue", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(param);
            param = new SqlParameter("@TotalRows", SqlDbType.Int);
            param.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(param);
            try
            {
                XmlReader reader = command.ExecuteXmlReader();
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                string dataXml = document.OuterXml;
                if (!string.IsNullOrEmpty(dataXml))
                {
                    listResult = new QueryListResult<T>(parameters, Convert.ToInt32(command.Parameters[command.Parameters.Count - 2].Value), SerializeHelper.Deserialize<T>(dataXml), Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value));
                }
                else
                {
                    listResult = new QueryListResult<T>(parameters, Convert.ToInt32(command.Parameters[command.Parameters.Count - 2].Value), default(T), Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value));
                }
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return listResult;
        }

        public bool IsDuplicate(string spName, DataParamCollection parameters)
        {
            bool retVal = false;
            SqlCommand command = CreateCommand(spName, parameters);
            try
            {
                retVal = Convert.ToBoolean(command.ExecuteScalar());
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return retVal;
        }

        public void BackupDatabase(string databaseName, string backupName, string backupPath)
        {
            try
            {
                _Connection.Open();
                SqlCommand command = _Connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "BackupMyDatabase";
                command.Parameters.Add(new SqlParameter("@DatabaseName", databaseName));
                command.Parameters.Add(new SqlParameter("@BackupPath", backupPath));
                command.Parameters.Add(new SqlParameter("@BackupName", backupName));
                command.ExecuteNonQuery();
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
        }

        public void RestoreDatabase(string databaseName, string backupPath)
        {
            string masterDbConn = _Connection.ConnectionString.Replace("LoanManagementSystem", "master");
            SqlConnection connection = new SqlConnection(masterDbConn);
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RestoreMyDatabase";
                command.Parameters.Add(new SqlParameter("@DatabaseName", databaseName));
                command.Parameters.Add(new SqlParameter("@BackupPath", backupPath));
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private SqlCommand CreateCommand(string spName, DataParamCollection parameters)
        {
            _Connection.Open();
            SqlCommand command = _Connection.CreateCommand();
            command.CommandTimeout = 3000;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = spName;
            if (parameters == null) return command;
            foreach (DataParam dataParam in parameters)
            {
                SqlParameter sqlParam = new SqlParameter(dataParam.Name, dataParam.Value);
                if (dataParam.IsOutput)
                {
                    sqlParam.Direction = ParameterDirection.InputOutput;
                }
                command.Parameters.Add(sqlParam);
            }
            return command;
        }

        public string GetLegalSearchString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            Regex regex = new Regex(@"[_%\[\]\^]");
            return regex.Replace(input, "");
        }
    }

    public partial class DataParam
    {
        public DataParam(string name, object value)
            : this(name, value, false)
        {
        }

        public DataParam(string name, object value, bool isOutput)
        {
            Name = name;
            Value = value;
            IsOutput = isOutput;
        }

        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsOutput { get; set; }
        public bool IsReturn { get; set; }
    }

    public partial class DataParamCollection : List<DataParam>
    {
    }

    public class QueryResult<T>
    {
        public QueryResult(DataParamCollection dataParams, int returnValue)
            : this(dataParams, returnValue, default(T))
        {
        }

        public QueryResult(DataParamCollection dataParams, int returnValue, T data)
        {
            DataParams = dataParams;
            ReturnValue = returnValue;
            Data = data;
        }

        public DataParamCollection DataParams { get; set; }
        public int ReturnValue { get; set; }
        public T Data { get; set; }
    }

    public class QueryListResult<T>
    {
        public QueryListResult(DataParamCollection dataParams, int returnValue, T data, int totalData)
        {
            DataParams = dataParams;
            ReturnValue = returnValue;
            Data = data;
            TotalData = totalData;
        }

        public DataParamCollection DataParams { get; set; }
        public int ReturnValue { get; set; }
        public T Data { get; set; }
        public int TotalData { get; set; }
    }
}
