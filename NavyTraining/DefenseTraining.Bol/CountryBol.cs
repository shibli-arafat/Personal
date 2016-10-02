using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class CountryBol
    {
        private CountryDal _Dal;

        public CountryBol()
        {
            _Dal = new CountryDal();
        }

        public List<Country> GetCountries(CountryGroup group)
        {
            return _Dal.GetCountries(group);
        }

        public void DeleteCountry(int id)
        {
            _Dal.DeleteCountry(id);
        }

        public Country SaveCountry(Country country)
        {
            country.Id = _Dal.SaveCountry(country);
            return country;
        }

        public Country GetCountry(int id)
        {
            return _Dal.GetCountry(id);
        }
    }
}
