using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class RankDetailPresenter
    {
        private RankInternal _Internal;
        private DecorationInternal _RankTypeInternal;
        private IRankDetailView _View;

        public RankDetailPresenter(IRankDetailView view)
        {
            _Internal = new RankInternal();
            _RankTypeInternal = new DecorationInternal();
            _View = view;
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                Rank rank = new Rank();
                if (_View.RankId > 0)
                {
                    rank = _Internal.GetRankById(_View.RankId);
                }
                _View.PopulateGUIFromRank(rank);
            }
        }

        public void HandleSave()
        {
            Rank rank = _View.PopulateRankFromGUI();
            if (_View.RankId == 0) AddRank(rank);
            else UpdateRank(rank);
        }

        private void AddRank(Rank rank)
        {
            _Internal.AddRank(rank);
        }

        private void UpdateRank(Rank rank)
        {
            rank.Id = _View.RankId;
            _Internal.UpdateRank(rank);
        }
    }
}
