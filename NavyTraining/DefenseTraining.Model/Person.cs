
namespace DefenseTraining.Model
{
    public class Person : ModelBase
    {
        public Person()
        {
            this.Rank = new Rank();
        }

        public string PersonNo { get; set; }
        public string Name { get; set; }
        public Rank Rank { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
