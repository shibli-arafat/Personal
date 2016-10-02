using System;

namespace Dit.Lms.Api.Data
{
    public class LoanDisbursementReportData
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime DisbursedOn { get; set; }
        public double Amount { get; set; }
        public string DisbursedBy { get; set; }
    }
}
