using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class RankListPresenter
    {
        RankInternal _Internal;
        DecorationCollection _RankTypes;
        IRankListView _View;

        public RankListPresenter(IRankListView view)
        {
            _Internal = new RankInternal();
            _RankTypes = new DecorationInternal().GetCommissions();
            _View = view;
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                BindRanks();
            }
        }

        public void Delete(int id)
        {
            _Internal.DeleteRank(id);
            BindRanks();
        }

        public void BindRanks()
        {
            RankCollection ranks = _Internal.GetRanks();
            if (ranks.Count > 0) _View.ViewDataInGUI(ranks);
            else _View.ShowEmptyMessage();
        }

        public string GetRankTypeName(int rankType)
        {
            Decoration commission = _RankTypes.GetById(rankType);
            if (commission != null) return commission.Name;
            return "N/A";
        }
    }
}
