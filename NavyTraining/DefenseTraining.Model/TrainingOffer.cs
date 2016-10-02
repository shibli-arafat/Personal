using System.Collections.Generic;

namespace DefenseTraining.Model
{
    public class TrainingOffer : ModelBase
    {
        public TrainingOffer()
        {
            EventType = new EventType();
            RankGroup = new RankGroup();
            Country = new Country();
            HostResponsibilities = new List<ExpenseHead>();
            RequiredDocs = new List<RequiredDoc>();
        }

        public EventType EventType { get; set; }
        public string Name { get; set; }
        public RankGroup RankGroup { get; set; }
        public Country Country { get; set; }
        public int NoOfVacancies { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<ExpenseHead> HostResponsibilities { get; set; }
        public List<RequiredDoc> RequiredDocs { get; set; }
    }
}
