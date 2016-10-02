using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class YearlyBudgetDataMapper
    {
        private IDatabaseAccess _DbAccess;

        public YearlyBudgetDataMapper()
        {
            _DbAccess = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public void AddYearlyBudget(YearlyBudget budget)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Year", budget.Year));
            parameters.Add(new QueryParameter("Budget", budget.Budget));
            _DbAccess.ExecuteNonQuery(StoredProcedureNames.YearlyBudgetAdd, parameters);
        }

        public void UpdateYearlyBudget(YearlyBudget budget)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", budget.Id));
            parameters.Add(new QueryParameter("Year", budget.Year));
            parameters.Add(new QueryParameter("Budget", budget.Budget));
            _DbAccess.ExecuteNonQuery(StoredProcedureNames.YearlyBudgetUpdate, parameters);
        }

        public void DeleteYearlyBudget(int budgetId)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", budgetId));
            _DbAccess.ExecuteNonQuery(StoredProcedureNames.YearlyBudgetDelete, parameters);
        }

        public YearlyBudget GetYearlyBudget(int budgetId)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", budgetId));
            DataTable table = _DbAccess.GetDataTable(StoredProcedureNames.YearlyBudgetGet, parameters);
            DataRow row = table.Rows[0];
            return MapYearlyBudget(row);
        }

        public YearlyBudgetCollection GetYearlyBudgets()
        {
            YearlyBudgetCollection budgets = new YearlyBudgetCollection();
            DataTable table = _DbAccess.GetDataTable(StoredProcedureNames.YearlyBudgetGetAll, new QueryParameterCollection());
            foreach (DataRow row in table.Rows)
            {
                budgets.Add(MapYearlyBudget(row));
            }
            return budgets;
        }

        private static YearlyBudget MapYearlyBudget(DataRow row)
        {
            YearlyBudget budget = new YearlyBudget();
            if (row != null)
            {
                budget.Id = (int)row["Id"];
                budget.Year = (int)row["Year"];
                budget.Budget = double.Parse(string.Format("{0}", row["Budget"]));
                budget.IsActive = (bool)row["IsActive"];
            }
            return budget;
        }

        public bool IsDuplicate(int id, int year)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Year", year));
            DataTable table = _DbAccess.GetDataTable("YearlyBudgetDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }

        public YearlyBudgetReportCollection GetYearlyBudgetReports()
        {
            YearlyBudgetReportCollection reports = new YearlyBudgetReportCollection();
            QueryParameterCollection parameters = new QueryParameterCollection();
            DataTable table = _DbAccess.GetDataTable("YearlyBudgetReportGetAll", parameters);
            foreach (DataRow row in table.Rows)
            {
                int year = int.Parse(row["BudgetYear"].ToString());
                YearlyBudgetReport report = new YearlyBudgetReport();
                report.BudgetAmount = row["BudgetAmount"].ToString();
                report.BudgetYear = string.Format("{0}- {1}", year, year + 1);
                report.SpentAmount = row["SpentAmount"].ToString();
                reports.Add(report);
            }
            return reports;
        }
    }
}
