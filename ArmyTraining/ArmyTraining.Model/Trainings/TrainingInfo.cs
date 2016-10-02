using System;

namespace ArmyTraining.Model.Trainings
{
    public class TrainingInfo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CourseName { get; set; }
        public string CountryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Qualifications { get; set; }
        public TraineeInfoCollection TraineeInfos { get; set; }
    }
}
