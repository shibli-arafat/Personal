using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class PersonBol
    {
        private PersonDal _Dal;

        public PersonBol()
        {
            _Dal = new PersonDal();
        }

        public List<Person> GetPersons(string personNo, string name, int rankId)
        {
            return _Dal.GetPersons(personNo, name, rankId);
        }

        public void DeletePerson(int id)
        {
            _Dal.DeletePerson(id);
        }

        public Person SavePerson(Person person)
        {
            if (_Dal.PersonExists(person.Id, person.PersonNo))
                throw new Exception("A person with the same person no already exists. Please enter unique person no.");
            person.Id = _Dal.SavePerson(person);
            return person;
        }

        public Person GetPerson(int id)
        {
            return _Dal.GetPerson(id);
        }
    }
}
