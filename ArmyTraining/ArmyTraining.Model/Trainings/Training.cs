
namespace ArmyTraining.Model.Trainings
{
    public class Training
    {
        public Training()
        {
            General = new TrainingGeneral();
            Flows = new TrainingFlow();
            Budget = new TrainingBudgetInfo();
            Trainees = new TraineeCollection();
        }

        public int Id { get; set; }
        public TrainingGeneral General { get; set; }
        public TrainingFlow Flows { get; set; }
        public TrainingBudgetInfo Budget { get; set; }
        public TraineeCollection Trainees { get; set; }
        public TrainingLevel TrainingLevel { get; set; }
    }
}
