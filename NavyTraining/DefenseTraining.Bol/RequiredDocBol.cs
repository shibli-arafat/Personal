using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class RequiredDocBol
    {
        private RequiredDocDal _Dal;

        public RequiredDocBol()
        {
            _Dal = new RequiredDocDal();
        }

        public List<RequiredDoc> GetRequiredDocs()
        {
            return _Dal.GetRequiredDocs();
        }

        public void DeleteRequiredDoc(int id)
        {
            _Dal.DeleteRequiredDoc(id);
        }

        public RequiredDoc SaveRequiredDoc(RequiredDoc requiredDoc)
        {
            requiredDoc.Id = _Dal.SaveRequiredDoc(requiredDoc);
            return requiredDoc;
        }
    }
}
