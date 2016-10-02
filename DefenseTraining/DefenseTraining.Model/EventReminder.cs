
namespace DefenseTraining.Model
{
    public class EventReminder
    {
        public int SlNo { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string RemindFor { get; set; }
        public string RespAgency { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Country { get; set; }
        public string RemindOn { get; set; }
    }
}
