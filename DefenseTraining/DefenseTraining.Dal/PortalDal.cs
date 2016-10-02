using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class PortalDal : DalBase
    {
        public List<JointStatement> GetJointStatements(int year)
        {
            List<JointStatement> statements = new List<JointStatement>();
            List<TempAllotment> tAllotments = new List<TempAllotment>();
            List<TempAllotment> tmpReAllotments = new List<TempAllotment>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("AllotmentStatementGetAll", new SqlParameter[] { new SqlParameter("@Year", year) }))
                {
                    while (reader.Read())
                    {
                        TempAllotment tAllotment = new TempAllotment();
                        tAllotment.Service = reader.GetString(reader.GetOrdinal("Service"));
                        tAllotment.EventType = reader.GetString(reader.GetOrdinal("EventType"));
                        tAllotment.Allotted = reader.GetInt32(reader.GetOrdinal("Allotted"));
                        tAllotment.Availed = reader.GetInt32(reader.GetOrdinal("Availed"));
                        tAllotments.Add(tAllotment);
                    }
                }
                statements = MakeJointStatements(tAllotments);
            }
            finally
            {
                CloseConnection();
            }
            return statements;
        }

        private List<JointStatement> MakeJointStatements(List<TempAllotment> allotments)
        {
            List<JointStatement> statements = new List<JointStatement>();
            List<Service> services = new ServiceDal().GetServices();
            foreach (Service service in services)
            {
                JointStatement statement = new JointStatement();
                statement.Service = service.Name;
                AllotmentTotal allotTot = GetAllotmentTotal(allotments, service.Name, EventCategory.Competition);
                statement.CompetitionAllotted = allotTot.Allotted;
                statement.CompetitionAvailed = allotTot.Availed;

                allotTot = GetAllotmentTotal(allotments, service.Name, EventCategory.Course);
                statement.CourseAvailed = allotTot.Availed;
                statement.CourseAllotted = allotTot.Allotted;

                allotTot = GetAllotmentTotal(allotments, service.Name, EventCategory.Excercise);
                statement.ExcerciseAvailed = allotTot.Availed;
                statement.ExcerciseAllotted = allotTot.Allotted;

                allotTot = GetAllotmentTotal(allotments, service.Name, EventCategory.Seminar);
                statement.SeminarAvailed = allotTot.Availed;
                statement.SeminarAllotted = allotTot.Allotted;

                allotTot = GetAllotmentTotal(allotments, service.Name, EventCategory.SMEE);
                statement.SmeeAvailed = allotTot.Availed;
                statement.SmeeAllotted = allotTot.Allotted;

                allotTot = GetAllotmentTotal(allotments, service.Name, EventCategory.Visit);
                statement.VisitAvailed = allotTot.Availed;
                statement.VisitAllotted = allotTot.Allotted;

                statements.Add(statement);
            }
            return statements;
        }

        private AllotmentTotal GetAllotmentTotal(List<TempAllotment> allotments, string service, EventCategory eventCat)
        {
            AllotmentTotal allotTot = new AllotmentTotal(0, 0);
            foreach (TempAllotment allotment in allotments)
            {
                if (string.Compare(allotment.Service, service, true) == 0 && string.Compare(allotment.EventType, eventCat.ToString(), true) == 0)
                {
                    allotTot.Allotted += allotment.Allotted;
                    allotTot.Availed += allotment.Availed;
                }
            }
            return allotTot;
        }
    }

    class AllotmentTotal
    {
        public AllotmentTotal(int allotted, int availde)
        {
            Allotted = allotted;
            Availed = availde;
        }

        public int Allotted { get; set; }
        public int Availed { get; set; }
    }
}
