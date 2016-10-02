using System;
namespace Dit.Lms.Api
{
    public class SystemConfig
    {
        public SystemConfig()
        {
            ConfigDetails = new SystemConfigDetailCollection();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyRegNo { get; set; }
        public SystemConfigDetailCollection ConfigDetails { get; set; }

        public SystemConfigDetail GetCurrentConfigDetail()
        {
            return ConfigDetails.Find(x => ((x.YearFrom == DateTime.Today.Year && DateTime.Today.Month > 6) || (x.YearFrom + 1 == DateTime.Today.Year && DateTime.Today.Month <= 6)));
        }
    }
}
