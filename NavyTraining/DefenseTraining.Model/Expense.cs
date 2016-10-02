namespace DefenseTraining.Model
{
    public class Expense
    {
        public Expense()
        {
            Head = new ExpenseHead();
        }

        public ExpenseHead Head { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public bool IsSelected { get; set; }
        public string Total
        {
            get
            {
                return (Amount * Quantity) == 0 ? "0.00" : (Amount * Quantity).ToString("########.##");
            }
        }

        public string UsdTotal
        {
            get
            {
                string usdTotal = "0.00";
                if (!Head.IsInBdt)
                {
                    usdTotal = (Amount * Quantity) == 0 ? "0.00" : (Amount * Quantity).ToString("########.##");
                }
                return usdTotal;
            }
        }

        public string BdtTotal
        {
            get
            {
                string bdtTotal = "0.00";
                if (Head.IsInBdt)
                {
                    bdtTotal = (Amount * Quantity) == 0 ? "0.00" : (Amount * Quantity).ToString("########.##");
                }
                return bdtTotal;
            }
        }
    }
}
