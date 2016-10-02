
namespace DefenseTraining.Model
{
    public class Rank : ModelBase
    {
        public Rank()
        {
            this.Group = new RankGroup();
        }

        public string Name { get; set; }
        public RankGroup Group { get; set; }
    }
}
