using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmyTraining.Model.Trainings;
using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ITrainingDetailView
    {
        TrainingBudgetCollection BudgetsInState { get; set; }
        AdditionalExpenditureCollection AdditionalExpencesInState { get; set; }
        bool IsPagePostBack { get; }
        int TrainingId { get; }
        void PopulateGUIForGeneral(TrainingGeneral general);
        void PopulateGUIForTrainee(TraineeCollection traineess);
        void PopulateGUIForBudget(TrainingBudgetInfo budgetInfo);
        void PopulateGUIForFlow(TrainingFlowCollection flows);
        TrainingGeneral PopulateGeneralFromGUI();
        TraineeCollection PopulateTraineesFromGUI();
        TrainingBudgetInfo PopulateBudgetInfoFromGUI();
        TrainingFlowCollection PopulateFlowsFromGUI();

        void RedirectToEdit(int id);

        void BindCourseTypes(CourseTypeCollection courseTypes);
        void BindCourses(CourseCollection courses);
        void BindCountries(CountryCollection countries);
        void BindSponsorCountries(CountryCollection countries);
    }
}
