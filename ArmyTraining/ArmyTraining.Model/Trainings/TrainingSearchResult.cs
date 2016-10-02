
namespace ArmyTraining.Model.Trainings
{
    public class TrainingSearchResult
    {
        public TrainingSearchResult()
        {
            Result = new TrainingInfoCollection();
        }
        public TrainingInfoCollection Result { get; set; }
        public int TotalCount { get; set; }
    }
}
