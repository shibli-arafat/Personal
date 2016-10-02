using ArmyTraining.Model;
using ArmyTraining.Model.Filters;

namespace ArmyTraining.Presenter.Views
{
    public interface IPersonListView
    {
        bool IsPagePostBack { get; }
        void PopulateListInGUI(PersonSearchResult persons, PersonFilter filter);
        void ShowEmptyMessage();
    }
}
