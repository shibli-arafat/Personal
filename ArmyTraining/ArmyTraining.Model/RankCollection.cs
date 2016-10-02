using System.Collections.Generic;

namespace ArmyTraining.Model
{
    public class RankCollection : List<Rank>
    {
        public Rank GetById(int id)
        {
            return Find(x => x.Id == id);
        }
    }
}
