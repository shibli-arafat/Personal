namespace DefenseTraining.Model
{
    public class TrainingReminder
    {
        public int TrainingId { get; set; }
        public string CourseName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string RemindFor { get; set; }
        public string ActionsNeeded { get; set; }
    }
}
