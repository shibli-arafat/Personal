using System;
using System.Collections.Generic;
using System.Web.Services;
using DefenseTraining.Bol;
using DefenseTraining.Model;

namespace DefenseTraining.Web
{
    public partial class AllowanceSettingEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static AjaxData GetAllowanceSetting()
        {
            try
            {
                RankBol bol = new RankBol();
                List<RankGroup> rankGroups = bol.GetRankGroups();
                AllowanceSetting proposed = new AllowanceSetting();
                foreach (RankGroup rnkGroup in rankGroups)
                {
                    AllowanceSettingDetail casd = new AllowanceSettingDetail();
                    casd.RankGroup = rnkGroup;
                    casd.DetailType = AllowanceSettingDetailType.Comp;
                    proposed.AllowanceSettingDetails.Add(casd);

                    casd = new AllowanceSettingDetail();
                    casd.RankGroup = rnkGroup;
                    casd.DetailType = AllowanceSettingDetailType.HotenInCash;
                    casd.PaymentType = AllowancePaymentType.Hotel;
                    proposed.AllowanceSettingDetails.Add(casd);
                    casd = new AllowanceSettingDetail();
                    casd.DetailType = AllowanceSettingDetailType.HotenInCash;
                    casd.RankGroup = rnkGroup;
                    casd.PaymentType = AllowancePaymentType.Cash;
                    proposed.AllowanceSettingDetails.Add(casd);
                }
                AllowanceSettingBol asBol = new AllowanceSettingBol();
                AllowanceSetting existing = asBol.GetAllowanceSetting(1);
                proposed.Merge(existing);
                return new AjaxData(true, proposed, string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }

        [WebMethod]
        public static AjaxData SaveAllowanceSetting(AllowanceSetting allowanceSetting)
        {
            AllowanceSettingBol _bol = new AllowanceSettingBol();
            try
            {
                return new AjaxData(true, _bol.SaveAllowanceSetting(allowanceSetting), string.Empty);
            }
            catch (Exception ex)
            {
                return new AjaxData(false, null, ex.Message);
            }
        }
    }
}