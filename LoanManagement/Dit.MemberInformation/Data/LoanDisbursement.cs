using System;

namespace Dit.Lms.Api
{
    public class LoanDisbursement : DreamData
    {
        public LoanDisbursement()
        {
            DisbursedTo = new Member();
            DisbursedBy = new User();
            DisbursedOn = DateTime.Today;
        }

        public Member DisbursedTo { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public double Amount { get; set; }
        public User DisbursedBy { get; set; }
        public DateTime DisbursedOn { get; set; }
        public string Comment { get; set; }
        public int MemberId { get { return this.DisbursedTo.MemberId; } }
        public string MemberName { get { return this.DisbursedTo.Name; } }
    }
}
