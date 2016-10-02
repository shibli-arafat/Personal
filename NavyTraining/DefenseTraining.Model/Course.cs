
namespace DefenseTraining.Model
{
    public class Course : ModelBase
    {
        public Course()
        {
            EventType = new EventType();
        }

        public string Name { get; set; }
        public EventType EventType { get; set; }
        public string PreRequisites { get; set; }
    }
}
