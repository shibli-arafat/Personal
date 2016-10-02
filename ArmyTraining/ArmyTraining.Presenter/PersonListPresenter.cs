using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Model.Filters;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class PersonListPresenter
    {
        IPersonListView _View;
        PersonInternal _Internal;

        public PersonListPresenter(IPersonListView view)
        {
            _View = view;
            _Internal = new PersonInternal();
        }

        public void OnViewLoaded()
        {
        }

        public void BindData(PersonFilter filter)
        {
            PersonSearchResult persons = _Internal.GetPersons(filter);
            if (persons.Persons.Count > 0)
            {
                _View.PopulateListInGUI(persons, filter);
            }
            else
            {
                _View.ShowEmptyMessage();
            }
        }

        public void DeletePerson(int id, PersonFilter filter)
        {
            _Internal.DeletePerson(id);
            BindData(filter);
        }
    }
}
