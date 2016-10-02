namespace ArmyTraining.Model
{
    public class Course
    {
        public Course()
        {
            Level = new CourseType();
            TrainingBkg = new TrainingBackground();
        }
        public int Id { get; set; }
        public CourseType Level { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TrainingBackground TrainingBkg { get; set; }
    }
}
