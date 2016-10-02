using System.Collections.Generic;

namespace Dit.Lms.Api
{
    public class UserCollection : List<User>
    {
        public void Update(User user)
        {
            this.RemoveAll(x => x.Id == user.Id);
            if (user.IsActive) this.Insert(0, user);
        }
    }
}
