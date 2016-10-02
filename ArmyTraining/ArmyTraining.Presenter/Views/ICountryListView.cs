using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ICountryListView
    {
        bool IsPagePostBack { get; }
        void ViewDataInGUI(CountryCollection ranks);
        void ShowEmptyMessage();

    }
}
