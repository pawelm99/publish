using Projekt1.Interface;
using Projekt1.Models;

namespace Projekt1.Repository
{
    public class EventRepository : IEventRepository
    {

        private static List<Event> _events = new List<Event>() {
            new Event(Guid.NewGuid(), "Zbieranie_jablek", new DateTime(2022,11,16)),
            new Event(Guid.NewGuid(), "Walka_o_honor", new DateTime(2022,09,05)),
            new Event(Guid.NewGuid(), "Melanz_w_katowicach", new DateTime(2023,01,03))
        };



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
            @event.id= Guid.NewGuid();
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
        public void DeleteEvent(Guid id)
        {
            var eventid = _events.SingleOrDefault(x => x.id == id);
            _events.Remove(eventid);
        }

    }
}

