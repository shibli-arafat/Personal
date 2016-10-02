using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class EventTypeBol
    {
        private EventTypeDal _Dal;

        public EventTypeBol()
        {
            _Dal = new EventTypeDal();
        }

        public List<EventType> GetEventTypes()
        {
            return _Dal.GetEventTypes();
        }

        public void DeleteEventType(int id)
        {
            _Dal.DeleteEventType(id);
        }

        public EventType SaveEventType(EventType eventType)
        {
            eventType.Id = _Dal.SaveEventType(eventType);
            return eventType;
        }
    }
}
