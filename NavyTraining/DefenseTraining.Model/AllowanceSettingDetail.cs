
namespace DefenseTraining.Model
{
    public class AllowanceSettingDetail
    {
        public AllowanceSettingDetail()
        {
            RankGroup = new RankGroup();
        }

        public AllowanceSettingDetailType DetailType { get; set; }
        public RankGroup RankGroup { get; set; }
        public AllowancePaymentType PaymentType { get; set; }
        public string Description { get { return PaymentType.ToString(); } }
        public double ForCountryGroup1 { get; set; }
        public double ForCountryGroup2 { get; set; }
        public double ForCountryGroup3 { get; set; }

        internal void Merge(AllowanceSettingDetail existingDetail)
        {
            this.DetailType = existingDetail.DetailType;
            this.ForCountryGroup1 = existingDetail.ForCountryGroup1;
            this.ForCountryGroup2 = existingDetail.ForCountryGroup2;
            this.ForCountryGroup3 = existingDetail.ForCountryGroup3;
            this.PaymentType = existingDetail.PaymentType;
            this.RankGroup = existingDetail.RankGroup;
        }
    }
}
