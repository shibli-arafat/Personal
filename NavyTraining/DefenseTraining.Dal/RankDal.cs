using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class RankDal : DalBase
    {
        public List<Rank> GetRanks()
        {
            List<Rank> ranks = new List<Rank>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("RankGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        Rank rank = new Rank();
                        rank.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        rank.Name = reader.GetString(reader.GetOrdinal("Name"));
                        rank.Group.Id = reader.GetInt32(reader.GetOrdinal("RankGroupId"));
                        rank.Group.Name = reader.GetString(reader.GetOrdinal("RankGroupName"));
                        rank.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        ranks.Add(rank);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return ranks;
        }

        public Rank GetRank(int id)
        {
            Rank rank = new Rank();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("RankGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    if (reader.Read())
                    {
                        rank.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        rank.Name = reader.GetString(reader.GetOrdinal("Name"));
                        rank.Group.Id = reader.GetInt32(reader.GetOrdinal("RankGroupId"));
                        rank.Group.Name = reader.GetString(reader.GetOrdinal("RankGroupName"));
                        rank.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return rank;
        }

        public void DeleteRank(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("RankDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveRank(Rank rank)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", rank.Id) 
                                               ,new SqlParameter("@Name", rank.Name)
                                               ,new SqlParameter("@RankGroupId", rank.Group.Id)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("RankSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool RankExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("Id", id)
                                               ,new SqlParameter("Name", name)
                                            };
                return ExecuteScalar<bool>("RankExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<RankGroup> GetRankGroups()
        {
            List<RankGroup> rankGroups = new List<RankGroup>();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("RankGroupGetAll", new SqlParameter[] { }))
                {
                    while (reader.Read())
                    {
                        RankGroup rank = new RankGroup();
                        rank.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        rank.Name = reader.GetString(reader.GetOrdinal("Name"));
                        rank.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        rankGroups.Add(rank);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return rankGroups;
        }

        public RankGroup GetRankGroup(int id)
        {
            RankGroup rankGroup = new RankGroup();
            OpenConnection();
            try
            {
                using (SqlDataReader reader = ExecuteReader("RankGroupGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    if (reader.Read())
                    {
                        rankGroup.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        rankGroup.Name = reader.GetString(reader.GetOrdinal("Name"));
                        rankGroup.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return rankGroup;
        }

        public void DeleteRankGroup(int id)
        {
            OpenConnection();
            try
            {
                ExecuteQuery("RankGroupDelete", new SqlParameter[] { new SqlParameter("@Id", id) });
            }
            finally
            {
                CloseConnection();
            }
        }

        public int SaveRankGroup(RankGroup rank)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", rank.Id) 
                                               ,new SqlParameter("@Name", rank.Name)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("RankGroupSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool RankGroupExists(int id, string name)
        {
            OpenConnection();
            try
            {
                SqlParameter[] parameters = {
                                                new SqlParameter("Id", id)
                                               ,new SqlParameter("Name", name)
                                            };
                return ExecuteScalar<bool>("RankGroupExists", parameters);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
