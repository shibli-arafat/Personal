using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class CommissionDetailPresenter
    {
        private DecorationInternal _Internal;
        private IDecorationDetail _View;
        public CommissionDetailPresenter(IDecorationDetail view)
        {
            _Internal = new DecorationInternal();
            _View = view;
        }

        public void OnPageLoad()
        {
            if (!_View.IsPagePostBack)
            {
                Decoration commission = new Decoration();
                if (_View.CommsionId > 0)
                {
                    commission = _Internal.GetCommissionById(_View.CommsionId);
                }
                _View.PopulateGUIFromCommission(commission);
            }
        }

        public void HandleSave()
        {
            Decoration commission = _View.PopulateCommissionFromGUI();
            if (_View.CommsionId == 0)
            {
                AddCommission(commission);
            }
            else
            {
                UpdateCommission(commission);
            }
        }

        private void AddCommission(Decoration commission)
        {
            _Internal.AddCommission(commission);
        }

        private void UpdateCommission(Decoration commission)
        {
            commission.Id = _View.CommsionId;
            _Internal.UpdateCommission(commission);
        }

        public Decoration LoadCommission()
        {
            return _Internal.GetCommissionById(_View.CommsionId);
        }
    }
}
