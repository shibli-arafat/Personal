using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface IDecorationDetail
    {
        Decoration PopulateCommissionFromGUI();
        int CommsionId { get; }
        bool IsPagePostBack { get; }
        void PopulateGUIFromCommission(Decoration commission);
    }
}
