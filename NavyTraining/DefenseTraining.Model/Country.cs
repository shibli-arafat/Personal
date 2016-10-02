
namespace DefenseTraining.Model
{
    public class Country : ModelBase
    {
        public string Name { get; set; }
        public string GroupName { get { return this.Group.ToString(); } }
        public CountryGroup Group { get; set; }
    }
}
