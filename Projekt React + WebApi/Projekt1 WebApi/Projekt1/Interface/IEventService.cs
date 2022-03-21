using Projekt1.Models;

namespace Projekt1.Interface
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();

        Event GetByName(string name);

        Event AddEvent(Event user);
        void UpdateEvent(Event user);
        void DeleteEvent(Guid id);
    }
}
