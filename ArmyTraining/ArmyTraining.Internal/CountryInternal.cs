using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class CountryInternal
    {
        CountryDataMapper _Data;
        public CountryInternal()
        {
            _Data = new CountryDataMapper();
        }
        public CountryCollection GetCountrys()
        {
            return _Data.GetCountries();
        }

        public Country GetCountryById(int Id)
        {
            return _Data.GetCountry(Id);
        }

        public void UpdateCountry(Country country)
        {
            if (_Data.IsDuplicate(country.Id, country.Name))
                throw new ArgumentException(string.Format("The country {0} already exists.", country.Name));
            _Data.UpdateCountry(country);
        }

        public void AddCountry(Country country)
        {
            if (_Data.IsDuplicate(country.Id, country.Name))
                throw new ArgumentException(string.Format("The country {0} already exists.", country.Name));
            _Data.AddCountry(country);
        }

        public void DeleteCountry(int id)
        {
            _Data.DeleteCountry(id);
        }


        public CountryCollection GetCountrysByCourse(int courseId)
        {
            return _Data.GetCountriesByCourse(courseId);
        }
    }
}
