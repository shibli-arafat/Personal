using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class PersonDetailPresenter
    {
        IPersonDetailView _View;
        PersonInternal _Internal;

        public PersonDetailPresenter(IPersonDetailView view)
        {
            _View = view;
            _Internal = new PersonInternal();
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                _View.BindRankTypes(new DecorationInternal().GetCommissions());
                _View.BindArmyServices(new ServiceInternal().GetServices());
                _View.BindRanks(new RankInternal().GetRanks());
                Person person = new Person();
                if (_View.PersonId > 0)
                {
                    person = _Internal.GetPersonById(_View.PersonId);
                }
                _View.PopulateFormData(person);
            }
        }

        public void HandleRankTypeChange(int rankType)
        {
            _View.BindRanks(new RankInternal().GetRanks());
        }

        private void PersonAdd(Person person)
        {
            _Internal.AddPerson(person);
        }

        private void PersonUpdate(Person person)
        {
            person.Id = _View.PersonId;
            _Internal.UpdatePerson(person);
        }

        public void HandleSave()
        {
            Person person = _View.GetFormData();
            if (_View.PersonId > 0)
            {
                PersonUpdate(person);
            }
            else
            {
                PersonAdd(person);
            }
        }

        public bool IsDuplicate(int personId, string personalNo)
        {
            return _Internal.IsDuplicate(personId, personalNo);
        }
    }
}
