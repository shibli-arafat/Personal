using System;

namespace Dit.Lms.Api
{
    public class MonthlyDepositReportData
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public string CollectedBy { get; set; }
        public DateTime DepositedOn { get; set; }
    }
}
