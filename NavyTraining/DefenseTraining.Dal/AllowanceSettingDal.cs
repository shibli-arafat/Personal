using System;
using System.Data;
using System.Data.SqlClient;
using DefenseTraining.Model;

namespace DefenseTraining.Dal
{
    public class AllowanceSettingDal : DalBase
    {
        public AllowanceSetting GetAllowanceSetting(int id)
        {
            AllowanceSetting setting = new AllowanceSetting();
            OpenConnection();
            try
            {
                using (DataSet ds = GetDataSet("AllowanceSettingGet", new SqlParameter[] { new SqlParameter("@Id", id) }))
                {
                    DataTable settingTable = ds.Tables[0];
                    if (settingTable.Rows.Count > 0)
                    {
                        setting.Id = Convert.ToInt32(settingTable.Rows[0]["Id"]);
                        setting.EligibilityForSpouse = Convert.ToInt32(settingTable.Rows[0]["EligibilityOfSpouse"]);
                        setting.EligibilityForKids = Convert.ToInt32(settingTable.Rows[0]["EligibilityOfKids"]);
                    }
                    DataTable detailTable = ds.Tables[1];
                    foreach (DataRow row in detailTable.Rows)
                    {
                        AllowanceSettingDetail detail = new AllowanceSettingDetail();
                        detail.PaymentType = (AllowancePaymentType)Enum.Parse(typeof(AllowancePaymentType), row["PayentType"].ToString());
                        detail.ForCountryGroup1 = Convert.ToDouble(row["ForCountryGroup1"]);
                        detail.ForCountryGroup2 = Convert.ToDouble(row["ForCountryGroup2"]);
                        detail.ForCountryGroup3 = Convert.ToDouble(row["ForCountryGroup3"]);
                        detail.DetailType = (AllowanceSettingDetailType)Enum.Parse(typeof(AllowanceSettingDetailType), row["DetailType"].ToString());
                        detail.RankGroup.Id = Convert.ToInt32(row["Id"]);
                        detail.RankGroup.Name = Convert.ToString(row["Name"]);
                        setting.AllowanceSettingDetails.Add(detail);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return setting;
        }

        public int SaveAllowanceSetting(AllowanceSetting allowanceSetting)
        {
            OpenConnection();
            try
            {
                DataTable asdTable = new DataTable("AllowanceSettingDetailType");
                asdTable.Clear();
                asdTable.Columns.Add("DetailType", typeof(int));
                asdTable.Columns.Add("RankGroupId", typeof(int));
                asdTable.Columns.Add("ForCountryGroup1", typeof(int));
                asdTable.Columns.Add("ForCountryGroup2", typeof(int));
                asdTable.Columns.Add("ForCountryGroup3", typeof(int));
                asdTable.Columns.Add("PayentType", typeof(int));
                foreach (AllowanceSettingDetail allowanceSettingDetail in allowanceSetting.AllowanceSettingDetails)
                {
                    DataRow row = asdTable.NewRow();
                    row["DetailType"] = allowanceSettingDetail.DetailType;
                    row["RankGroupId"] = allowanceSettingDetail.RankGroup.Id;
                    row["ForCountryGroup1"] = allowanceSettingDetail.ForCountryGroup1;
                    row["ForCountryGroup2"] = allowanceSettingDetail.ForCountryGroup2;
                    row["ForCountryGroup3"] = allowanceSettingDetail.ForCountryGroup3;
                    row["PayentType"] = allowanceSettingDetail.PaymentType;
                    asdTable.Rows.Add(row);
                }

                SqlParameter[] parameters = { 
                                                new SqlParameter("@Id", allowanceSetting.Id) 
                                               ,new SqlParameter("@EligibilityOfSpouse", allowanceSetting.EligibilityForSpouse)
                                               ,new SqlParameter("@EligibilityOfKids", allowanceSetting.EligibilityForKids)
                                               ,new SqlParameter("@AllowanceSettingDetails", asdTable)
                                            };
                parameters[0].Direction = System.Data.ParameterDirection.InputOutput;
                ExecuteQuery("AllowanceSettingSave", parameters);
                return Convert.ToInt32(parameters[0].Value);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
