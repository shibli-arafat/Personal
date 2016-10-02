using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class UserBol
    {
        private UserDal _Dal;

        public UserBol()
        {
            _Dal = new UserDal();
        }

        public User SaveUser(User user)
        {
            if (_Dal.UserExists(user.Id, user.UserName))
            {
                throw new Exception("A user with same user name already exists. Please enter a unique user name.");
            }
            user.Id = _Dal.SaveUser(user);
            return user;
        }

        public void DeleteUser(int id)
        {
            _Dal.DeleteUser(id);
        }

        public User GetUser(int id)
        {
            return _Dal.GetUser(id);
        }

        public List<User> GetUsers(string keyword, int roleId, int rankId)
        {
            return _Dal.GetUsers(keyword, roleId, rankId);
        }

        public User Login(string userName, string password)
        {
            User user = _Dal.GetUser(userName, password);
            if (user == null || string.Compare(user.Password, password) != 0)
                throw new Exception("You have entered invalid user name or password.");
            return user;
        }

        public Role SaveRole(Role role)
        {
            if (_Dal.RoleExists(role.Id, role.Name))
            {
                throw new Exception("A role with the same name already exists. Please enter unique role name.");
            }
            role.Id = _Dal.SaveRole(role);
            return role;
        }

        public void DeleteRole(int id)
        {
            _Dal.DeleteRole(id);
        }

        public Role GetRole(int id)
        {
            return _Dal.GetRole(id);
        }

        public List<Role> GetRoles()
        {
            return _Dal.GetRoles();
        }

        public void ChangePassword(int id, string oldPassword, string newPassword)
        {
            User user = _Dal.GetUser(id);
            if (string.Compare(user.Password, oldPassword) != 0)
            {
                throw new Exception("You've entered wrong old password.");
            }
            _Dal.ChangePassword(id, newPassword);
        }
    }
}
