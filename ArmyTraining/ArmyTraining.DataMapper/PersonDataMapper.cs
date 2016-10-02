using System;
using System.Data;
using ArmyTraining.Model;
using ArmyTraining.Model.Filters;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class PersonDataMapper
    {
        IDatabaseAccess _Db;
        public PersonDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        private static Person MapPerson(DataRow drPerson)
        {
            Person person = new Person();
            person.Id = (int)drPerson["Id"];
            person.Name = string.Format("{0}", drPerson["Name"]);
            person.Remaks = string.Format("{0}", drPerson["Remarks"]);
            person.PersonNumber = string.Format("{0}", drPerson["PersonalNumber"]); ;
            person.Rank.Id = (int)drPerson["RankId"];
            person.Rank.Name = string.Format("{0}", drPerson["RankName"]);
            person.Service.Id = (int)drPerson["ServiceId"];
            person.Service.Name = string.Format("{0}", drPerson["ServiceName"]);
            person.Email = string.Format("{0}", drPerson["Email"]);
            person.Mobile = string.Format("{0}", drPerson["Mobile"]);

            return person;
        }



        public Person GetPerson(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            DataSet ds = _Db.GetDataSet(StoredProcedureNames.PersonGet, parameters);

            foreach (DataRow drPerson in ds.Tables[0].Rows)
            {
                Person person = MapPerson(drPerson);

                person.Decorations = new DecorationCollection();
                DataRow[] countries = ds.Tables[1].Select("PersonId = " + person.Id.ToString());
                foreach (DataRow drCountry in countries)
                {
                    Decoration d = new Decoration();
                    d.Id = (int)drCountry["Id"];
                    d.Name = string.Format("{0}", drCountry["Name"]);
                    person.Decorations.Add(d);
                }

                return person;
            }
            return null;

        }

        public void DeletePerson(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));

            _Db.ExecuteNonQuery(StoredProcedureNames.PersonDelete, parameters);
        }

        public void AddPerson(Person person)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();

            parameters.Add(new QueryParameter("Name", person.Name));
            parameters.Add(new QueryParameter("Remarks", person.Remaks));
            parameters.Add(new QueryParameter("ServiceId", person.Service.Id));
            parameters.Add(new QueryParameter("RankId", person.Rank.Id));
            parameters.Add(new QueryParameter("PersonalNumber", person.PersonNumber));
            parameters.Add(new QueryParameter("Email", person.Email));
            parameters.Add(new QueryParameter("Mobile", person.Mobile));
            parameters.Add(new QueryParameter("Decorations", XmlSerializeHelper<DecorationCollection>.Serialize(person.Decorations)));

            _Db.ExecuteNonQuery(StoredProcedureNames.PersonAdd, parameters);
        }

        public void UpdatePerson(Person person)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();

            parameters.Add(new QueryParameter("Id", person.Id));
            parameters.Add(new QueryParameter("Name", person.Name));
            parameters.Add(new QueryParameter("Remarks", person.Remaks));
            parameters.Add(new QueryParameter("ServiceId", person.Service.Id));
            parameters.Add(new QueryParameter("RankId", person.Rank.Id));
            parameters.Add(new QueryParameter("PersonalNumber", person.PersonNumber));
            parameters.Add(new QueryParameter("Email", person.Email));
            parameters.Add(new QueryParameter("Mobile", person.Mobile));
            parameters.Add(new QueryParameter("Decorations", XmlSerializeHelper<DecorationCollection>.Serialize(person.Decorations)));
            _Db.ExecuteNonQuery(StoredProcedureNames.PersonUpdate, parameters);
        }


        public PersonSearchResult GetPersons(PersonFilter filter)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("PersonNumber", filter.PersonNumber));
            parameters.Add(new QueryParameter("RankName", filter.RankName));
            parameters.Add(new QueryParameter("PageNumber", filter.PageNumber));
            parameters.Add(new QueryParameter("Count", filter.Count));
            parameters.Add(new QueryParameter("TotalCount", 0, true));

            DataSet ds = _Db.GetDataSet("GetFilteredPersons", parameters);
            PersonSearchResult result = new PersonSearchResult();
            foreach (DataRow drPerson in ds.Tables[0].Rows)
            {
                /*
                    SELECT p.ID, p.Name, p.Description, p.Remarks, p.PersonalNumber,r.Id as RankID, r.Name AS C,a.ID AS ServiceID, a.Name AS ServiceName
                    FROM Person p INNER JOIN Rank r ON p.RankID = r.Id
                    INNER JOIN ArmyService a ON p.ArmyServiceID = a.ID

                 */
                Person person = MapPerson(drPerson);

                result.Persons.Add(person);
            }
            result.TotalCount = (int)parameters.GetParameterByName("TotalCount").Value;
            return result;
        }

        public int GetPersonIdByPersonalNo(string personalNo)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("PersonalNo", personalNo));
            DataTable table = _Db.GetDataTable("PersonIdGetByPersonalNo", parameters);
            if (table.Rows.Count == 0) return 0;
            DataRow row = table.Rows[0];
            if (row["Id"] != DBNull.Value)
            {
                return (int)row["Id"];
            }
            else
            {
                return 0;
            }
        }
    }
}
