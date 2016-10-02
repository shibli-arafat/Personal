using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class ExpenseCollection : List<Expense>
    {
        public void Update(Expense expense)
        {
            this.RemoveAll(x => x.Id == expense.Id);
            if (expense.IsActive) this.Insert(0, expense);
        }

        public ExpenseReportDataCollection ToReportData()
        {
            ExpenseReportDataCollection reportData = new ExpenseReportDataCollection();
            foreach (Expense expense in this)
            {
                reportData.Add(expense.ToReportData());
            }
            return reportData;
        }
    }
}
