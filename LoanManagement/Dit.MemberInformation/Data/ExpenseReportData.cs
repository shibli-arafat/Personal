using System;

namespace Dit.Lms.Api
{
    public class ExpenseReportData
    {
        public DateTime ExpenseOn { get; set; }
        public string ExpenseHead { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}
