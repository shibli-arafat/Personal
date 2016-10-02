using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;
using ArmyTraining.Model.Filters;

namespace ArmyTraining.Internal
{
    public class PersonInternal
    {
        PersonDataMapper _Data;
        public PersonInternal()
        {
            _Data = new PersonDataMapper();
        }

        public PersonSearchResult GetPersons(PersonFilter filter)
        {
            return _Data.GetPersons(filter);
        }

        public Person GetPersonById(int Id)
        {
            return _Data.GetPerson(Id);
        }

        public void UpdatePerson(Person person)
        {
            if (_Data.GetPersonIdByPersonalNo(person.PersonNumber) != person.Id)
                throw new Exception("This personal number already exists.\nPlease enter unique personal number.");
            _Data.UpdatePerson(person);
        }

        public void AddPerson(Person person)
        {
            if (_Data.GetPersonIdByPersonalNo(person.PersonNumber) != person.Id)
                throw new Exception("This personal number already exists.\nPlease enter unique personal number.");
            _Data.AddPerson(person);
        }

        public void DeletePerson(int id)
        {
            _Data.DeletePerson(id);
        }

        public bool IsDuplicate(int personId, string personalNo)
        {
            return _Data.GetPersonIdByPersonalNo(personalNo) != personId;
        }
    }
}
