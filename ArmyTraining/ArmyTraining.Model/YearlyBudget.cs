namespace ArmyTraining.Model
{
    public class YearlyBudget
    {
        public YearlyBudget()
        {
        }

        public YearlyBudget(int year, double budget)
        {
            this.Year = year;
            this.Budget = budget;
        }

        public YearlyBudget(int id, int year, double budget)
            : this(year, budget)
        {
            this.Id = id;
        }

        public YearlyBudget(int id, int year, double budget, bool isActive)
            : this(id, year, budget)
        {
            this.IsActive = isActive;
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public double Budget { get; set; }
        public bool IsActive { get; set; }
    }
}
