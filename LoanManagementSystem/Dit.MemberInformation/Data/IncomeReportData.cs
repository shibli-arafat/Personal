using System;

namespace Dit.Lms.Api
{
    public class IncomeReportData
    {
        public DateTime IncomeOn { get; set; }
        public string IncomeHead { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}
