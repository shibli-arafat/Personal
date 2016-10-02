using ArmyTraining.Internal;
using ArmyTraining.Model;

namespace ArmyTraining.Presenter
{
    public class CommissionListPresenter
    {
        DecorationInternal _Internal;
        public CommissionListPresenter()
        {
            _Internal = new DecorationInternal();
        }

        public DecorationCollection GetCommissions()
        {
            return _Internal.GetCommissions();
        }

        public void DeleteCommission(int id)
        {
            _Internal.DeleteCommission(id);
        }
    }
}
