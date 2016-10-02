
namespace ArmyTraining.Model.Trainings
{
    public class TrainingBudgetInfo
    {
        public TrainingBudgetInfo()
        {
            AdditionalExpences = new AdditionalExpenditureCollection();
        }
        public AdditionalExpenditureCollection AdditionalExpences { get; set; }
    }
}
