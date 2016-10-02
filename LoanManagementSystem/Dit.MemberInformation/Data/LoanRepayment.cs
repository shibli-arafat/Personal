using System;

namespace Dit.Lms.Api
{
    public class LoanRepayment : DreamData
    {
        public LoanRepayment()
        {
            RepaidBy = new Member();
            CollectedBy = new User();
            CollectedOn = DateTime.Today;
        }

        public Member RepaidBy { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public double Amount { get; set; }
        public User CollectedBy { get; set; }
        public DateTime CollectedOn { get; set; }
        public double AmountDue { get; set; }
        public string Comment { get; set; }
        public int MemberId { get { return this.RepaidBy.MemberId; } }
        public string MemberName { get { return this.RepaidBy.Name; } }
    }
}
