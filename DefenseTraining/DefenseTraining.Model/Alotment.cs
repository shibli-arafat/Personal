namespace DefenseTraining.Model
{
    public class Alotment
    {
        public Alotment()
        {
            Service = new Service();
        }

        public Service Service { get; set; }
        public int Allotted { get; set; }
        public int Availed { get; set; }
        public int NotAvailed { get { return Allotted - Availed; } }
        public string ReasonOfNotAvailing { get; set; }
    }
}
