﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DefenseTraining.Model;
using System.Globalization;

namespace DefenseTraining.Dal
{
    public class UserDal : DalBase
    {
        public List<User> GetUsers(string keyword, int roleId, int rankId)
        {
            List<User> users = new List<User>();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Keyword", keyword) 
                                               ,new SqlParameter("@RoleId", roleId)
                                               ,new SqlParameter("@RankId", rankId)
                                            };
                DataSet ds = GetDataSet("UserGetAll", parameters);
                foreach (DataRow userRow in ds.Tables[0].Rows)
                {
                    User user = MapUser(userRow);
                    foreach (DataRow roleRow in ds.Tables[1].Rows)
                    {
                        if (user.Id == Convert.ToInt32(roleRow["UserId"]))
                        {
                            Role role = MapRole(roleRow);
                            user.Roles.Add(role);
                        }
                    }
                    users.Add(user);
                }
            }
            finally
            {
                CloseConnection();
            }
            return users;
        }

        public User GetUser(int id)
        {
            User user = new User();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@Id", id)
                                            };
                DataSet ds = GetDataSet("UserGet", parameters);
                user = MapUser(ds.Tables[0].Rows[0]);
                foreach (DataRow roleRow in ds.Tables[1].Rows)
                {
                    Role role = MapRole(roleRow);
                    user.Roles.Add(role);
                }
            }
            finally
            {
                CloseConnection();
            }
            return user;
        }

        public User GetUser(string userName, string password)
        {
            User user = new User();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@UserName", userName)
                                               ,new SqlParameter("@Password", password)
                                            };
                DataSet ds = GetDataSet("UserLogin", parameters);
                if (ds.Tables[0].Rows.Count == 0) throw new Exception("You've entered either wong user name or password. Please correct and try again.");
                user = MapUser(ds.Tables[0].Rows[0]);
                foreach (DataRow roleRow in ds.Tables[1].Rows)
                {
                    if (Convert.ToInt32(roleRow["Id"]) == user.Id)
                    {
                        Role role = MapRole(roleRow);
                        user.Roles.Add(role);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return user;
        }

        public void DeleteUser(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("UserDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveUser(User user)
        {
            OpenConnection();
            try
            {
                DataTable roles = new DataTable("IntType");
                roles.Clear();
                roles.Columns.Add("Id", typeof(int));
                foreach (Role role in user.Roles)
                {
                    DataRow row = roles.NewRow();
                    row["Id"] = role.Id;
                    roles.Rows.Add(row);
                }

                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", user.Id) 
                                               ,new SqlParameter("@UserName", user.UserName)
                                               ,new SqlParameter("@Password", user.Password)
                                               ,new SqlParameter("@FullName", user.FullName)
                                               ,new SqlParameter("@Email", user.Email)
                                               ,new SqlParameter("@PhoneNo", user.PhoneNo)
                                               ,new SqlParameter("@Roles", roles)
                                               ,new SqlParameter("@PersonalNo", user.PersonalNo)
                                               ,new SqlParameter("@RankId", user.Rank.Id)
                                               ,new SqlParameter("@Appointment", user.Appointment)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("UserSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UserExists(int id, string userName)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", id) 
                                               ,new SqlParameter("@UserName", userName)
                                            };
                return ExecuteScalar<bool>("UserExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            OpenConnection();
            try
            {
                DataSet ds = GetDataSet("RoleGetAll", new SqlParameter[] { });
                DataTable roleTable = ds.Tables[0];
                foreach (DataRow userRow in roleTable.Rows)
                {
                    Role role = MapRole(userRow);
                    roles.Add(role);
                }
            }
            finally
            {
                CloseConnection();
            }
            return roles;
        }

        public void ChangePassword(int id, string newPassword)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", id) 
                                               ,new SqlParameter("@NewPassword", newPassword)
                                            };
                ExecuteQuery("UserPasswordChange", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Role GetRole(int id)
        {
            Role role = new Role();
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("@Id", id)
                                            };
                DataSet ds = GetDataSet("RoleGet", parameters);
                DataRow roleRow = ds.Tables[0].Rows[0];
                DataTable privTable = ds.Tables[1];
                role = MapRole(roleRow);
            }
            finally
            {
                CloseConnection();
            }
            return role;
        }

        public void DeleteRole(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("RoleDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveRole(Role role)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", role.Id) 
                                               ,new SqlParameter("@Name", role.Name)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("RoleSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool RoleExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", id) 
                                               ,new SqlParameter("@Name", name)
                                            };
                return ExecuteScalar<bool>("RoleExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }

        private User MapUser(DataRow row)
        {
            User user = new User();
            user.Id = Convert.ToInt32(row["Id"]);
            user.UserName = Convert.ToString(row["UserName"]);
            user.Password = Convert.ToString(row["Password"]);
            user.FullName = Convert.ToString(row["FullName"]);
            user.Email = Convert.ToString(row["Email"]);
            user.PhoneNo = Convert.ToString(row["PhoneNo"]);
            user.IsActive = Convert.ToBoolean(row["IsActive"]);
            if (row["PersonalNo"] != DBNull.Value)
            {
                user.PersonalNo = Convert.ToString(row["PersonalNo"]);
            }
            else
            {
                user.PersonalNo = string.Empty;
            }
            if (row["RankId"] != DBNull.Value)
            {
                user.Rank.Id = Convert.ToInt32(row["RankId"]);
            }
            else
            {
                user.Rank.Id = 0;
            }
            if (row["RankName"] != DBNull.Value)
            {
                user.Rank.Name = Convert.ToString(row["RankName"]);
            }
            else
            {
                user.Rank.Name = string.Empty;
            }
            if (row["Appointment"] != DBNull.Value)
            {
                user.Appointment = Convert.ToString(row["Appointment"]);
            }
            else
            {
                user.Appointment = string.Empty;
            }
            return user;
        }

        private Role MapRole(DataRow row)
        {
            Role role = new Role();
            role.Id = Convert.ToInt32(row["Id"]);
            role.Name = Convert.ToString(row["Name"]);
            return role;
        }
    }
}
