using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class LoanDisbursementCollection : List<LoanDisbursement>
    {
        public void Update(LoanDisbursement loan)
        {
            this.RemoveAll(x => x.Id == loan.Id);
            if (loan.IsActive) this.Insert(0, loan);
        }
    }
}
