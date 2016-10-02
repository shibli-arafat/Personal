namespace Dit.Lms.Api
{
    public class SystemConfigDetail
    {
        public int Id { get; set; }
        public int SysConfigId { get; set; }
        public int YearFrom { get; set; }
        public int MaxLoanAmountInPercent { get; set; }
        public double MonthlyDepositAmount { get; set; }
        public double DepositCharge { get; set; }
        public string FiscalYear
        {
            get
            {
                return string.Format("{0} - {1}", this.YearFrom, this.YearFrom + 1);
            }
        }

        public override string ToString()
        {
            return string.Format("Fiscal year: {0}\nMonthly deposit amount: {1}\nMax loan percent: {2}", FiscalYear, MonthlyDepositAmount, MaxLoanAmountInPercent);
        }
    }
}
