using System.Collections.Generic;

namespace ArmyTraining.Model
{
    public class CountryCollection : List<Country>
    {
        public string GetCommaSeperatedIds()
        {
            string[] ids = new string[this.Count];
            for (int index = 0; index < this.Count; index++)
            {
                ids[index] = this[index].Id.ToString();
            }
            return string.Join(",", ids);
        }

        public string GetCommaSeperatedNames()
        {
            string[] names = new string[this.Count];
            for (int index = 0; index < this.Count; index++)
            {
                names[index] = this[index].Name;
            }
            return string.Join(",", names);
        }

        public bool CountryExists(int countryId)
        {
            return Exists(x => x.Id == countryId);
        }
    }
}
