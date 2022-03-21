using Projekt1.Models;

namespace Projekt1.Interface
{
    public interface IEventRepository
    {
        public IEnumerable<Event> GetAllUser();

        public Event GetByName(string name);

        public Event AddEvent(Event @event);

        public void UpdateEvent(Event @event);


        public void DeleteEvent(Guid id);

    }
}


}
}
