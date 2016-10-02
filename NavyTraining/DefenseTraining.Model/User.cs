using System.Collections.Generic;
using System.Text;

namespace DefenseTraining.Model
{
    public class User : ModelBase
    {
        public User()
        {
            this.Roles = new List<Role>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public List<Role> Roles { get; set; }
        public string RoleNames
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Role role in this.Roles)
                {
                    builder.AppendFormat("{0}, ", role.Name);
                }
                return builder.ToString().TrimEnd(", ".ToCharArray());
            }
        }
    }
}
