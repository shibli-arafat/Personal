using System.Collections.Generic;
namespace DefenseTraining.Model
{
    public class PaymentSchedule : ModelBase
    {
        public PaymentSchedule()
        {
            Payments = new List<Payment>();
        }

        public int TrainingId { get; set; }
        public string CourseName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PaymentDate { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
