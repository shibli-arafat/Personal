namespace ArmyTraining.Model
{
    public class Person
    {
        public Person()
        {
            this.Decorations = new DecorationCollection();
            this.Rank = new Rank();
            this.Service = new Service();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remaks { get; set; }
        public string PersonNumber { get; set; }
        public DecorationCollection Decorations { get; set; }
        public Rank Rank { get; set; }
        public Service Service { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string GetNameWithRankAndNumber()
        {
            return string.Format("{0} {1} {2}", PersonNumber, Rank.Name, Name);
        }
    }
}
