using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class ServiceListPresenter
    {
        ServiceInternal _Internal;
        IServiceListView _View;

        public ServiceListPresenter(IServiceListView view)
        {
            _Internal = new ServiceInternal();
            _View = view;
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                BindServices();
            }
        }

        public void Delete(int id)
        {
            _Internal.DeleteService(id);
            BindServices();
        }

        public void BindServices()
        {
            ServiceCollection ranks = _Internal.GetServices();
            if (ranks.Count > 0) _View.ViewDataInGUI(ranks);
            else _View.ShowEmptyMessage();
        }

    }
}
