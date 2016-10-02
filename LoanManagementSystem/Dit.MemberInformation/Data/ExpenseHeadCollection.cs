using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class ExpenseHeadCollection : List<ExpenseHead>
    {
        public void Update(ExpenseHead expenseHead)
        {
            this.RemoveAll(x => x.Id == expenseHead.Id);
            if (expenseHead.IsActive) this.Insert(0, expenseHead);
        }

        public bool Exists(int expenseHeadId)
        {
            return this.Exists(x => x.Id == expenseHeadId);
        }
    }
}
