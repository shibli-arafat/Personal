using System;

namespace DefenseTraining.Model
{
    public class ExpenseHead : ModelBase
    {
        public ExpenseHead()
        {
            BudgetCode = new BudgetCode();
        }

        public string Name { get; set; }
        public bool IsAutoCalc { get; set; }
        public AutoCalcBase BasedOn { get; set; }
        public double Value { get; set; }
        public bool IsDaily { get; set; }
        public bool ApplicableForSpouse { get; set; }
        public bool ApplicableForKids { get; set; }
        public BudgetCode BudgetCode { get; set; }
        public bool IsInBdt { get; set; }
        public string BasedOnToString
        {
            get
            {
                if (BasedOn == AutoCalcBase.None) return "None";
                if (BasedOn == AutoCalcBase.PercentageOfComprehensiveDA) return "Percentage of Comprehensive DA";
                else throw new Exception("Not an auto calculation enum value.");
            }
        }
    }
}
