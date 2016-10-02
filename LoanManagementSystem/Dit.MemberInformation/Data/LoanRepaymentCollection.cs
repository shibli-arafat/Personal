using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class LoanRepaymentCollection : List<LoanRepayment>
    {
        public void Update(LoanRepayment repayment)
        {
            this.RemoveAll(x => x.Id == repayment.Id);
            if (repayment.IsActive) this.Insert(0, repayment);
        }
    }
}
