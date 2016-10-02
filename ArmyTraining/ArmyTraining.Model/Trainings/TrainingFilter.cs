using System;
using ArmyTraining.Model.Reports;

namespace ArmyTraining.Model.Trainings
{
    public class TrainingFilter
    {
        public TrainingFilter()
        {
            StartDate = new DateTime(1800, 1, 1);
            EndDate = new DateTime(2500, 12, 31);
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public DurationType DurationType { get; set; }
        public bool IsUpto { get; set; }
        public int CourseTypeId { get; set; }
        public int CountryId { get; set; }
        public int SponsorCountryId { get; set; }
        public int CourseId { get; set; }
        public TrainingCompletionType CompletionType { get; set; }
        public int RankId { get; set; }
        public string PersonalNo { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public TrainingLevel TrainingLevel { get; set; }
        public int TrainingBkgId { get; set; }
        public int TrainingId { get; set; }
        public int TrainingYear { get; set; }

        public int PageNumber { get; set; }
        public int Count { get; set; }
    }
}
