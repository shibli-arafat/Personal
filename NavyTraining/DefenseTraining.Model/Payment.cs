namespace DefenseTraining.Model
{
    public class Payment
    {
        public Payment()
        {
            BudgetCode = new BudgetCode();
        }

        public BudgetCode BudgetCode { get; set; }
        public double AmountPaid { get; set; }
        public double AmountTobePaid { get; set; }
        public double Amount { get; set; }
    }
}
