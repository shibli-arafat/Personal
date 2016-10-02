using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ITrainingReportManagerView
    {
        void PopulateCountryList(CountryCollection countries);
        void PopulateCourseTypeList(CourseTypeCollection courseTypes);
        void PopulateCourseList(CourseCollection courses);
        void PopulateRankList(RankCollection ranks);
        void PopulateCourseLevel();
        void PopulateTrainingBkg();
        void PopulateTrainingLevel();
    }
}
