using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class BudgetBol
    {
        private BudgetDal _Dal;

        public BudgetBol()
        {
            _Dal = new BudgetDal();
        }

        public List<Budget> GetBudgets()
        {
            return _Dal.GetBudgets();
        }

        public Budget GetBudget(int id)
        {
            return _Dal.GetBudget(id);
        }

        public void DeleteBudget(int id)
        {
            _Dal.DeleteBudget(id);
        }

        public Budget SaveBudget(Budget budget)
        {
            if (_Dal.BudgetExists(budget.Id, budget.BudgetYear, budget.BudgetCode.Id))
            {
                throw new Exception("Budget in the same year already exists. Please enter unique year.");
            }
            budget.Id = _Dal.SaveBudget(budget);
            return budget;
        }

        public List<BudgetCode> GetBudgetCodes()
        {
            return _Dal.GetBudgetCodes();
        }
    }
}
