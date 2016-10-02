using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class RankInternal
    {
        RankDataMapper _Data;
        public RankInternal()
        {
            _Data = new RankDataMapper();
        }
        public RankCollection GetRanks()
        {
            return _Data.GetRanks();
        }

        public Rank GetRankById(int Id)
        {
            return _Data.GetRank(Id);
        }

        public void UpdateRank(Rank rank)
        {
            if (_Data.IsDuplicate(rank.Id, rank.Name))
                throw new ArgumentException(string.Format("The rank {0} already exist.", rank.Name));
            _Data.UpdateRanks(rank);
        }

        public void AddRank(Rank rank)
        {
            if (_Data.IsDuplicate(rank.Id, rank.Name))
                throw new ArgumentException(string.Format("The rank {0} already exist.", rank.Name));
            _Data.AddRank(rank);
        }

        public void DeleteRank(int id)
        {
            _Data.DeleteRank(id);
        }
    }
}
