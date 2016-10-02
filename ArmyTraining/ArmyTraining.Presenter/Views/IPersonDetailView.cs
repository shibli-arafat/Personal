using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface IPersonDetailView
    {
        bool IsPagePostBack { get; }
        int PersonId { get; }

        void BindRankTypes(DecorationCollection rankTypes);
        void BindRanks(RankCollection ranks);
        void BindArmyServices(ServiceCollection services);
        void PopulateFormData(Person person);
        Person GetFormData();
    }
}
