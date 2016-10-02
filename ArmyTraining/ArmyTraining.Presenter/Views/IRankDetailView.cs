using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface IRankDetailView
    {
        bool IsPagePostBack { get; }
        int RankId { get; }

        void PopulateGUIFromRank(Rank rank);

        Rank PopulateRankFromGUI();
    }
}
