using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface IServiceDetail
    {
        Service PopulateServiceFromGUI();
        int ServiceId { get; }
        bool IsPagePostBack { get; }
        void PopulateGUIFromService(Service service);
    }
}
