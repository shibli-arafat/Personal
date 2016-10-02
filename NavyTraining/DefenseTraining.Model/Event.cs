using System.Collections.Generic;

namespace DefenseTraining.Model
{
    public class Event : ModelBase
    {
        public Event()
        {
            Type = new EventType();
            Country = new Country();
            Reminders = new List<Reminder>();
        }

        public string Name { get; set; }
        public EventType Type { get; set; }
        public Country Country { get; set; }
        public List<ExpenseHead> HostResponsibilities { get; set; }
        public List<RequiredDoc> RequiredDocs { get; set; }
        public string City { get; set; }
        public string Institute { get; set; }
        public string StartsOn { get; set; }
        public string EndsOn { get; set; }
        public List<Reminder> Reminders { get; set; }
    }
}
