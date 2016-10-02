namespace ArmyTraining.Model
{
    public class YearlyBudgetReport
    {
        public YearlyBudgetReport()
            : this("0", "0", "0")
        {
        }

        public YearlyBudgetReport(string budgetYear, string budgetAmount, string spentAmount)
        {
            this.BudgetYear = budgetYear;
            this.BudgetAmount = budgetAmount;
            this.SpentAmount = spentAmount;
        }

        public string BudgetYear { get; set; }
        public string BudgetAmount { get; set; }
        public string SpentAmount { get; set; }
        public string Balance
        {
            get
            {
                return (double.Parse(BudgetAmount) - double.Parse(SpentAmount)).ToString("##########.00");
            }
        }
    }
}
