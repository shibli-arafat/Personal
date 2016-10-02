
namespace ArmyTraining.Model
{
    public class PersonSearchResult
    {
        public PersonSearchResult()
        {
            Persons = new PersonCollection();
        }
        public PersonCollection Persons { get; set; }
        public int TotalCount { get; set; }
    }
}
