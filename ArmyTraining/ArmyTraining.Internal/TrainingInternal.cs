using System;
using System.IO;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;
using ArmyTraining.Model.Trainings;

namespace ArmyTraining.Internal
{
    public class TrainingInternal
    {
        private TrainingDataMapper _Data;

        public decimal GetBalanceForSameYearExceptThisTraining(int trainingId, int trainingYear, int trainingMonth)
        {
            if (trainingMonth < 7)
            {
                trainingYear = trainingYear - 1;
            }
            return _Data.GetBalanceForSameYearExceptThisTraining(trainingId, trainingYear);
        }

        public TrainingInternal()
        {
            _Data = new TrainingDataMapper();
        }

        public TrainingSearchResult GetTrainingInfos(TrainingFilter filter)
        {
            return _Data.GetTrainings(filter);
        }

        public Training GetTraining(int id)
        {
            return _Data.GetTraining(id);
        }

        public void SaveTraining(Training training)
        {
            if (_Data.IsDuplicate(training.Id, training.General.CourseId, training.General.StartDate))
            {
                throw new Exception("This training has alreayd been entered. Please enter a new one.");
            }
            _Data.UpdateTraining(training);
        }

        public int AddTraining(Training training)
        {
            if (_Data.IsDuplicate(training.Id, training.General.CourseId, training.General.StartDate))
            {
                throw new Exception("This training has alreayd been entered. Please enter a new one.");
            }
            return _Data.AddTraining(training);
        }

        public void DeleteTraining(int id)
        {
            _Data.DeleteTraining(id);
        }

        public TrainingReportCollection GetTrainingReports(ReportFilter filter)
        {
            return _Data.GetTrainingReports(filter);
        }

        public void BackupDatabase(string backupDir)
        {
            if (!Directory.Exists(backupDir))
            {
                throw new ApplicationException("The backup directory doesn't exixt.");
            }
            string backupFileName = string.Format("ArmyTraining_{0}-{1}-{2}-{3}-{4}.bak", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year, DateTime.Now.Hour, DateTime.Now.Minute);
            string backupPath = Path.Combine(backupDir, backupFileName);
            if (File.Exists(backupPath)) return;
            _Data.BackupDatabase(backupPath);
        }
    }
}
