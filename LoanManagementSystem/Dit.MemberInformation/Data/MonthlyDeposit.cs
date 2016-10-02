using System;

namespace Dit.Lms.Api
{
    public class MonthlyDeposit : DreamData
    {
        public MonthlyDeposit()
        {
            DepositedBy = new Member();
            CollectedBy = new User();
            DepositedOn = DateTime.Today;
        }

        public Member DepositedBy { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public User CollectedBy { get; set; }
        public DateTime DepositedOn { get; set; }
        public int MemberId { get { return this.DepositedBy.MemberId; } }
        public string MemberName { get { return this.DepositedBy.Name; } }

        public MonthlyDepositReportData ToReportData()
        {
            MonthlyDepositReportData reportData = new MonthlyDepositReportData();
            reportData.Amount = this.Amount;
            reportData.CollectedBy = this.CollectedBy.Name;
            reportData.Comment = this.Comment;
            reportData.MemberId = this.DepositedBy.MemberId;
            reportData.MemberName = this.DepositedBy.Name;
            reportData.DepositedOn = this.DepositedOn;
            reportData.Month = this.Month.ToString();
            reportData.Year = this.Year;
            return reportData;
        }

        public double GetAmountDue(double monthlyDepositAmount)
        {
            int months = ((DateTime.Today.Year - this.Year) * 12) + (DateTime.Today.Month - (int)this.Month);
            return months * monthlyDepositAmount;
        }
    }
}
