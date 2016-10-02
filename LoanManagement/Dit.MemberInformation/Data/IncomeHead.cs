namespace Dit.Lms.Api
{
    public class IncomeHead : DreamData
    {
        public IncomeHead()
        {
        }

        public IncomeHead(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
