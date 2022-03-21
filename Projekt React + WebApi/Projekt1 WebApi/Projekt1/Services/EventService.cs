using Projekt1.Interface;
using Projekt1.Models;

namespace Projekt1.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventService;

        public EventService(IEventRepository eventService)
        {
            _eventService=eventService;
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return _eventService.GetAllEvent();
        }
        public Event GetByName(string name)
        {
            return _eventService.GetByName(name);
        }
        public Event AddEvent(Event user)
        {
            _eventService.AddEvent(user);
            return user;
        }
        

        public void UpdateEvent(Event user)
        {
            _eventService.UpdateEvent(user);
        }

        public void DeleteEvent(int id)
        {
            _eventService.DeleteEvent(id);
        }
    }
}
