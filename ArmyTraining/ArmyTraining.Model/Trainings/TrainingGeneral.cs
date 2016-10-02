using System;

namespace ArmyTraining.Model.Trainings
{
    public class TrainingGeneral
    {
        public TrainingGeneral()
        {
            Prerequisites = string.Empty;
            Remarks = string.Empty;
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int SponsorCountryId { get; set; }
        public string SponsorCountryName { get; set; }
        public string Prerequisites { get; set; }
        public string Remarks { get; set; }
        public TrainingLevel TrainingLevel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
