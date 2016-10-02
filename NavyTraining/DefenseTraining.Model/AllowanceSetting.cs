using System.Collections.Generic;

namespace DefenseTraining.Model
{
    public class AllowanceSetting
    {
        public AllowanceSetting()
        {
            AllowanceSettingDetails = new List<AllowanceSettingDetail>();
        }

        public int Id { get; set; }
        public int EligibilityForSpouse { get; set; }
        public int EligibilityForKids { get; set; }
        public List<AllowanceSettingDetail> AllowanceSettingDetails { get; set; }

        public List<AllowanceSettingDetail> CompAllowanceSettingDetails
        {
            get
            {
                List<AllowanceSettingDetail> details = new List<AllowanceSettingDetail>();
                foreach (AllowanceSettingDetail detail in AllowanceSettingDetails)
                {
                    if (detail.DetailType == AllowanceSettingDetailType.Comp)
                    {
                        details.Add(detail);
                    }
                }
                return details;
            }
        }

        public List<AllowanceSettingDetail> HotelInCashAllowanceSettingDetails
        {
            get
            {
                List<AllowanceSettingDetail> details = new List<AllowanceSettingDetail>();
                foreach (AllowanceSettingDetail detail in AllowanceSettingDetails)
                {
                    if (detail.DetailType == AllowanceSettingDetailType.HotenInCash)
                    {
                        details.Add(detail);
                    }
                }
                return details;
            }
        }

        public void Merge(AllowanceSetting existing)
        {
            this.Id = existing.Id;
            this.EligibilityForKids = existing.EligibilityForKids;
            this.EligibilityForSpouse = existing.EligibilityForSpouse;
            foreach (AllowanceSettingDetail detail in this.AllowanceSettingDetails)
            {
                AllowanceSettingDetail existingDetail = existing.AllowanceSettingDetails.Find(x => x.DetailType == detail.DetailType && x.RankGroup.Id == detail.RankGroup.Id && x.PaymentType == detail.PaymentType);
                if (existingDetail != null)
                {
                    detail.Merge(existingDetail);
                }
            }
        }
    }
}