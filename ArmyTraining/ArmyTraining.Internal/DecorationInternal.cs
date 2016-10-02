using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class DecorationInternal
    {
        private DecorationDataMapper _Data;
        public DecorationInternal()
        {
            _Data = new DecorationDataMapper();
        }
        public DecorationCollection GetCommissions()
        {
            return _Data.GetDecorations();
        }

        public Decoration GetCommissionById(int Id)
        {
            return _Data.GetDecoration(Id);
        }

        public void UpdateCommission(Decoration commission)
        {
            if (_Data.IsDuplicate(commission.Id, commission.Name))
                throw new ArgumentException(string.Format("The decoration {0} already exist.", commission.Name));
            _Data.UpdateDecoration(commission);
        }

        public void AddCommission(Decoration commission)
        {
            if (_Data.IsDuplicate(commission.Id, commission.Name))
                throw new ArgumentException(string.Format("The decoration {0} already exist.", commission.Name));
            _Data.AddDecoration(commission);
        }

        public void DeleteCommission(int id)
        {
            _Data.DeleteDecoration(id);
        }

    }
}
