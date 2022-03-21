using Projekt1.Models;

namespace Projekt1.Interface
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();

        Event GetByName(string name);

        Event AddEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(int id);
    }
}
