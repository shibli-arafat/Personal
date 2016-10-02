using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class ExpenseHeadBol
    {
        private ExpenseHeadDal _Dal;

        public ExpenseHeadBol()
        {
            _Dal = new ExpenseHeadDal();
        }

        public List<ExpenseHead> GetExpenseHeads()
        {
            return _Dal.GetExpenseHeads();
        }

        public ExpenseHead GetExpenseHead(int id)
        {
            return _Dal.GetExpenseHead(id);
        }

        public void DeleteExpenseHead(int id)
        {
            _Dal.DeleteExpenseHead(id);
        }

        public ExpenseHead SaveExpenseHead(ExpenseHead expenseHead)
        {
            if (_Dal.ExpenseHeadExists(expenseHead.Id, expenseHead.Name))
            {
                throw new Exception("Expense head with the same name already exists. Please enter unique expense head name.");
            }
            expenseHead.Id = _Dal.SaveExpenseHead(expenseHead);
            return expenseHead;
        }
    }
}
