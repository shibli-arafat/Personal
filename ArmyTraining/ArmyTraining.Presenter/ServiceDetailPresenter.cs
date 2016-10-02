using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class ServiceDetailPresenter
    {
        private ServiceInternal _Internal;
        private IServiceDetail _View;

        public ServiceDetailPresenter(IServiceDetail view)
        {
            _Internal = new ServiceInternal();
            _View = view;
        }

        public void OnPageLoad()
        {
            if (!_View.IsPagePostBack)
            {
                Service service = new Service();
                if (_View.ServiceId > 0)
                {
                    service = _Internal.GetServiceById(_View.ServiceId);
                }
                _View.PopulateGUIFromService(service);
            }
        }

        public void HandleSave()
        {
            Service service = _View.PopulateServiceFromGUI();
            if (_View.ServiceId == 0)
            {
                AddService(service);
            }
            else
            {
                UpdateService(service);
            }
        }

        private void AddService(Service service)
        {
            _Internal.AddService(service);
        }

        private void UpdateService(Service service)
        {
            service.Id = _View.ServiceId;
            _Internal.UpdateService(service);
        }

        public Service LoadService()
        {
            return _Internal.GetServiceById(_View.ServiceId);
        }
    }
}
