using System.Collections.Generic;

namespace DefenseTraining.Model
{
    public class Trainee
    {
        public Trainee()
        {
            Person = new Person();
            Rank = new Rank();
            Expenses = new List<Expense>();
            SpouseExpenses = new List<Expense>();
            KidExpenses = new List<Expense>();
        }

        public Person Person { get; set; }
        public Rank Rank { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Expense> SpouseExpenses { get; set; }
        public List<Expense> KidExpenses { get; set; }
        public int NoOfKids { get; set; }
        public string Total
        {
            get
            {
                double total = 0;
                foreach (Expense expense in Expenses)
                {
                    if (expense.IsSelected)
                    {
                        total += double.Parse(expense.Total);
                    }
                }

                foreach (Expense expense in SpouseExpenses)
                {
                    if (expense.IsSelected)
                    {
                        total += double.Parse(expense.Total);
                    }
                }

                foreach (Expense expense in KidExpenses)
                {
                    if (expense.IsSelected)
                    {
                        total += double.Parse(expense.Total);
                    }
                }

                return total == 0 ? "0.00" : total.ToString("########.##");
            }
        }
    }
}
