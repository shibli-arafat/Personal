
namespace DefenseTraining.Model
{
    public class Budget : ModelBase
    {
        public Budget()
        {
            BudgetCode = new BudgetCode();
        }

        public int BudgetYear { get; set; }
        public BudgetCode BudgetCode { get; set; }
        public double Amount { get; set; }
        public double AmountPaid { get; set; }
        public string BudgetCodeCode { get { return BudgetCode.Code; } }
        public string YearRange { get { return string.Format("{0} - {1}", BudgetYear, BudgetYear + 1); } }
        public double Balance
        {
            get
            {
                return Amount - AmountPaid;
            }
        }
    }
}
