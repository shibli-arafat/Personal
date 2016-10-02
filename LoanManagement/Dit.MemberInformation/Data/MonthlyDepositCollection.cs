using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class MonthlyDepositCollection : List<MonthlyDeposit>
    {
        public void Update(MonthlyDeposit deposit)
        {
            this.RemoveAll(x => x.Id == deposit.Id);
            if (deposit.IsActive) this.Insert(0, deposit);
        }

        public void Update(MonthlyDepositCollection gridData)
        {
            foreach (MonthlyDeposit deposit in gridData)
            {
                Update(deposit);
            }
        }

        public MonthlyDepositReportDataCollection ToReportData()
        {
            MonthlyDepositReportDataCollection reportData = new MonthlyDepositReportDataCollection();
            foreach (MonthlyDeposit deposit in this)
            {
                reportData.Add(deposit.ToReportData());
            }
            return reportData;
        }
    }
}
