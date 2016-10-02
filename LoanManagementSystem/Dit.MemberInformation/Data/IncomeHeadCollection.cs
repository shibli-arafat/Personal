using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class IncomeHeadCollection : List<IncomeHead>
    {
        public void Update(IncomeHead incomeHead)
        {
            this.RemoveAll(x => x.Id == incomeHead.Id);
            if (incomeHead.IsActive) this.Insert(0, incomeHead);
        }

        public bool Exists(int incomeHeadId)
        {
            return this.Exists(x => x.Id == incomeHeadId);
        }
    }
}
