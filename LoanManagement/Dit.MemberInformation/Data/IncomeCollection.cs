using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class IncomeCollection : List<Income>
    {
        public void Update(Income income)
        {
            this.RemoveAll(x => x.Id == income.Id);
            if (income.IsActive) this.Insert(0, income);
        }

        public IncomeReportDataCollection ToReportData()
        {
            IncomeReportDataCollection reportData = new IncomeReportDataCollection();
            foreach (Income income in this)
            {
                reportData.Add(income.ToReportData());
            }
            return reportData;
        }
    }
}
