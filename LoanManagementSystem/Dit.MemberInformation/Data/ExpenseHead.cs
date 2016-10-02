namespace Dit.Lms.Api
{
    public class ExpenseHead : DreamData
    {
        public ExpenseHead()
        {
        }

        public ExpenseHead(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
