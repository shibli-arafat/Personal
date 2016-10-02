using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class CountryListPresenter
    {
        CountryInternal _Internal;
        ICountryListView _View;

        public CountryListPresenter(ICountryListView view)
        {
            _Internal = new CountryInternal();
            _View = view;
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                BindCountrys();
            }
        }

        public void Delete(int id)
        {
            _Internal.DeleteCountry(id);
            BindCountrys();
        }

        public void BindCountrys()
        {
            CountryCollection ranks = _Internal.GetCountrys();
            if (ranks.Count > 0) _View.ViewDataInGUI(ranks);
            else _View.ShowEmptyMessage();
        }

    }
}
