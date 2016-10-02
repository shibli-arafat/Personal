using System;
namespace Dit.Lms.Api
{
    public class Expense : DreamData
    {
        public Expense()
        {
            Head = new ExpenseHead();
            ExpenseOn = DateTime.Today;
        }

        public DateTime ExpenseOn { get; set; }
        public ExpenseHead Head { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }

        internal ExpenseReportData ToReportData()
        {
            ExpenseReportData reportData = new ExpenseReportData();
            reportData.Amount = this.Amount;
            reportData.Comment = this.Comment;
            reportData.ExpenseHead = this.Head.Name;
            reportData.ExpenseOn = this.ExpenseOn;
            return reportData;
        }
    }
}
