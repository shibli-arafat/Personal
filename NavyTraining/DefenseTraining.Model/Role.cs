using System.Collections.Generic;

namespace DefenseTraining.Model
{
    public class Role : ModelBase
    {
        public Role()
        {
            this.Privileges = new List<Privilege>();
        }

        public string Name { get; set; }
        public List<Privilege> Privileges { get; set; }
    }
}
