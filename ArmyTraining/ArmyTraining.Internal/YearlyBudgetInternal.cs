using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class YearlyBudgetInternal
    {
        private YearlyBudgetDataMapper _DataMapper;

        public YearlyBudgetInternal()
        {
            _DataMapper = new YearlyBudgetDataMapper();
        }

        public void AddYearlyBudget(YearlyBudget budget)
        {
            if (_DataMapper.IsDuplicate(budget.Id, budget.Year))
                throw new ArgumentException(string.Format("Budget for the year {0} already exists.", budget.Year));
            _DataMapper.AddYearlyBudget(budget);
        }

        public void UpdateYearlyBudget(YearlyBudget budget)
        {
            if (_DataMapper.IsDuplicate(budget.Id, budget.Year))
                throw new ArgumentException(string.Format("Budget for the year {0} already exists.", budget.Year));
            _DataMapper.UpdateYearlyBudget(budget);
        }

        public void DeleteYearlyBudget(int budgetId)
        {
            _DataMapper.DeleteYearlyBudget(budgetId);
        }

        public YearlyBudget GetYearlyBudget(int budgetId)
        {
            return _DataMapper.GetYearlyBudget(budgetId);
        }

        public YearlyBudgetCollection GetYearlyBudgets()
        {
            return _DataMapper.GetYearlyBudgets();
        }

        public YearlyBudgetReportCollection GetYearlyBudgetReports()
        {
            return _DataMapper.GetYearlyBudgetReports();
        }
    }
}
