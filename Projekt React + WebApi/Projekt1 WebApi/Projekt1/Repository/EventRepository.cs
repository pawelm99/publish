using Projekt1.Interface;
using Projekt1.Models;

namespace Projekt1.Repository
{
    public class EventRepository : IEventRepository
    {

        private static List<Event> _events = new List<Event>() {
            new Event(1, "Zbieranie_jablek", "2019-01-02"),
            new Event(2, "Walka_o_honor", "2019-01-02"),
            new Event(3, "Melanz_w_katowicach", "2019-01-02")
        };

        public EventRepository()
        {

        }

        public IEnumerable<Event> GetAllEvent()
        {
            return _events;
        }
        public Event GetByName(string name)
        {
            var userId = _events.SingleOrDefault(x => x.name == name);
            return userId;
            
        }
        public Event AddEvent(Event @event)
        {
            @event.id= _events.Count()+1;
            _events.Add(@event);
            return @event;
        }
     
        public void UpdateEvent(Event @event)
        {
            var userId = _events.SingleOrDefault(x => x.id == @event.id); // nwm czy dobrze
            if (userId == null)
            {
                throw new Exception("Brak pszypisanego id eventu!");
            }
            userId.name = @event.name;
            userId.date = @event.date;

        }
        public void DeleteEvent(int id)
        {
            var eventid = _events.SingleOrDefault(x => x.id == id);
            _events.Remove(eventid);
        }

    }
}

