using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class RankBol
    {
        private RankDal _Dal;

        public RankBol()
        {
            _Dal = new RankDal();
        }

        public List<Rank> GetRanks()
        {
            return _Dal.GetRanks();
        }

        public Rank GetRank(int id)
        {
            return _Dal.GetRank(id);
        }

        public void DeleteRank(int id)
        {
            _Dal.DeleteRank(id);
        }

        public Rank SaveRank(Rank rank)
        {
            if (_Dal.RankExists(rank.Id, rank.Name))
            {
                throw new Exception("Rank with the same name already exists. Please enter unique rank name.");
            }
            rank.Id = _Dal.SaveRank(rank);
            return rank;
        }

        public List<RankGroup> GetRankGroups()
        {
            return _Dal.GetRankGroups();
        }

        public RankGroup GetRankGroup(int id)
        {
            return _Dal.GetRankGroup(id);
        }

        public void DeleteRankGroup(int id)
        {
            _Dal.DeleteRankGroup(id);
        }

        public RankGroup SaveRankGroup(RankGroup rankGroup)
        {
            if (_Dal.RankGroupExists(rankGroup.Id, rankGroup.Name))
            {
                throw new Exception("Rank group with the same name already exists. Please enter unique rank group name.");
            }
            rankGroup.Id = _Dal.SaveRankGroup(rankGroup);
            return rankGroup;
        }
    }
}
