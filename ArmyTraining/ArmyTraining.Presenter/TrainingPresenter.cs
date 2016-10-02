using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmyTraining.Presenter.Views;
using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Model.Trainings;

namespace ArmyTraining.Presenter
{
    public class TrainingPresenter
    {
        ITrainingDetailView _View;
        TrainingInternal _Internal;

        public TrainingPresenter(ITrainingDetailView view)
        {
            _View = view;
            _Internal = new TrainingInternal();
        }

        public TrainingStatusCollection GetAllowedStatusList(int statusId)
        {
            TrainingStatus status = TrainingStatusCollection.GetInstance().GetStatusById(statusId);
            TrainingStatusCollection allowedStatus = TrainingStatusCollection.GetInstance().GetAllowedStatusList(
            status.AllowedStatuses);
            allowedStatus.Items.Insert(0, status);
            return allowedStatus;
        }

        public void OnViewLoad()
        {
            if (!_View.IsPagePostBack)
            {
                _View.BindCourseTypes(new CourseTypeInternal().GetCourseTypes());
                _View.BindSponsorCountries(new CountryInternal().GetCountrys());
                Training training = new Training();
                if (_View.TrainingId > 0)
                {
                    training = _Internal.LoadTraining(_View.TrainingId);
                }
                _View.PopulateGUIForGeneral(training.General);
                _View.BudgetsInState = training.Budget.Budgets;
                _View.AdditionalExpencesInState = training.Budget.AdditionalExpences;
                _View.PopulateGUIForBudget(training.Budget);
                //_View.PopulateGUIForFlow(training.Flows);
                //_View.PopulateGUIForTrainee(training.Trainees);
            }
        }

        public int GetCourseTypeId(int courseId)
        {
            if (courseId == 0) return 0;
            return new CourseInternal().GetCourseById(courseId).CourseType.Id;
        }

        public void HandleCourseTypeSelection(int courseTypeId)
        {
            _View.BindCourses(new CourseInternal().GetCoursesByType(courseTypeId));
        }

        public void HandleCourseSelection(int courseId)
        {
            CountryCollection countries = new CountryInternal().GetCountrysByCourse(courseId);
            _View.BindCountries(countries);
        }

        public void HandleSave()
        {
            Training training = new Training();
            training.General = _View.PopulateGeneralFromGUI();
            training.Budget = _View.PopulateBudgetInfoFromGUI();
            //training.Trainees = _View.PopulateTraineesFromGUI();
            //training.Flows = _View.PopulateFlowsFromGUI();

            if (_View.TrainingId > 0)
            {
                SaveTraining(training);
            }
            else
            {
                int id = AddTraining(training);
                if (id > 0)
                {
                    _View.RedirectToEdit(id);
                }
            }
        }

        private int AddTraining(Training training)
        {
            return _Internal.AddTraining(training);
        }

        private void SaveTraining(Training training)
        {
            training.Id = _View.TrainingId;
            _Internal.SaveTraining(training);
        }

        List<KeyValuePair<int, string>> GetStatusList()
        {
            List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();
            //result.Add(new KeyValuePair<int, string>((int)TrainingStatus.Offered, "Offered"));
            //result.Add(new KeyValuePair<int, string>((int)TrainingStatus.Processing, "Processing"));
            //result.Add(new KeyValuePair<int, string>((int)TrainingStatus.Ongoing, "Ongoing"));
            //result.Add(new KeyValuePair<int, string>((int)TrainingStatus.Completed, "Completed"));
            //result.Add(new KeyValuePair<int, string>((int)TrainingStatus.Cancelled, "Cancelled"));
            //result.Add(new KeyValuePair<int, string>((int)TrainingStatus.Unknown, "Unknown"));
            return result;
        }
        
    }
}
