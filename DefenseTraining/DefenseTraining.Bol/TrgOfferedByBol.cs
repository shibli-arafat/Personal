using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class TrgOfferedByBol
    {
        private TrgOfferedByDal _Dal;

        public TrgOfferedByBol()
        {
            _Dal = new TrgOfferedByDal();
        }

        public List<TrgOfferedBy> GetTrgOfferedBys()
        {
            return _Dal.GetTrgOfferedBys();
        }

        public void DeleteTrgOfferedBy(int id)
        {
            _Dal.DeleteTrgOfferedBy(id);
        }

        public TrgOfferedBy SaveTrgOfferedBy(TrgOfferedBy trgOfferedBy)
        {
            if (_Dal.TrgOfferedByExists(trgOfferedBy.Id, trgOfferedBy.Name))
                throw new Exception("Trainining offered by with the same name already exists. Please enter unique trainining offered by name.");
            trgOfferedBy.Id = _Dal.SaveTrgOfferedBy(trgOfferedBy);
            return trgOfferedBy;
        }
    }
}
