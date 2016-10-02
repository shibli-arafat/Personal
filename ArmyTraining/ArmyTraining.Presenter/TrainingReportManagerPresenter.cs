using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class TrainingReportManagerPresenter
    {
        private ITrainingReportManagerView _View;
        private CountryInternal _Country;
        private RankInternal _Rank;
        private CourseInternal _Course;
        private TrainingInternal _Training;
        private CourseTypeInternal _CourseType;

        public TrainingReportManagerPresenter(ITrainingReportManagerView view)
        {
            _View = view;
            _Country = new CountryInternal();
            _Rank = new RankInternal();
            _CourseType = new CourseTypeInternal();
            _Course = new CourseInternal();
            _Training = new TrainingInternal();
        }

        public void PopulateInitialData()
        {
            _View.PopulateCountryList(_Country.GetCountrys());
            _View.PopulateCourseTypeList(_CourseType.GetCourseTypes());
            _View.PopulateCourseList(new CourseCollection());
            _View.PopulateRankList(_Rank.GetRanks());
            _View.PopulateCourseLevel();
            _View.PopulateTrainingBkg();
            _View.PopulateTrainingLevel();
        }

        public TrainingReportCollection GetTrainingReports(ReportFilter filter)
        {
            return _Training.GetTrainingReports(filter);
        }
    }
}
