using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ICountryDetail
    {
        Country PopulateCountryFromGUI();
        int CountryId { get; }
        bool IsPagePostBack { get; }
        void PopulateGUIFromCountry(Country service);
    }
}
