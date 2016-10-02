using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class CountryDetailPresenter
    {
        CountryInternal _Internal;
        ICountryDetail _View;
        public CountryDetailPresenter(ICountryDetail view)
        {
            _Internal = new CountryInternal();
            _View = view;
        }

        public void OnPageLoad()
        {
            if (!_View.IsPagePostBack)
            {
                Country country = new Country();
                if (_View.CountryId > 0)
                {
                    country = _Internal.GetCountryById(_View.CountryId);
                }
                _View.PopulateGUIFromCountry(country);
            }
        }

        public void HandleSave()
        {
            Country country = _View.PopulateCountryFromGUI();
            if (_View.CountryId == 0)
            {
                AddCountry(country);
            }
            else
            {
                UpdateCountry(country);
            }
        }

        private void AddCountry(Country country)
        {
            _Internal.AddCountry(country);
        }

        private void UpdateCountry(Country country)
        {
            country.Id = _View.CountryId;
            _Internal.UpdateCountry(country);
        }

        public Country LoadCountry()
        {
            return _Internal.GetCountryById(_View.CountryId);
        }
    }
}
