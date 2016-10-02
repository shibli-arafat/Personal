using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class InstituteBol
    {
        private InstituteDal _Dal;

        public InstituteBol()
        {
            _Dal = new InstituteDal();
        }

        public List<Institute> GetInstitutes()
        {
            return _Dal.GetInstitutes();
        }

        public void DeleteInstitute(int id)
        {
            _Dal.DeleteInstitute(id);
        }

        public Institute SaveInstitute(Institute institute)
        {
            if (_Dal.InstituteExists(institute.Id, institute.Name))
                throw new Exception("Institute with the same name already exists. Please enter unique institute name.");
            institute.Id = _Dal.SaveInstitute(institute);
            return institute;
        }
    }
}
