using System;

namespace Dit.Lms.Api
{
    public class Income : DreamData
    {
        public Income()
        {
            Head = new IncomeHead();
            IncomeOn = DateTime.Today;
        }

        public DateTime IncomeOn { get; set; }
        public IncomeHead Head { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }

        public IncomeReportData ToReportData()
        {
            IncomeReportData reportData = new IncomeReportData();
            reportData.Amount = this.Amount;
            reportData.Comment = this.Comment;
            reportData.IncomeHead = this.Head.Name;
            reportData.IncomeOn = this.IncomeOn;
            return reportData;
        }
    }
}
