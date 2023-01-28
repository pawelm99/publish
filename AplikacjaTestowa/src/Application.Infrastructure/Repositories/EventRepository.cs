using Application.Core.Domain;
using Application.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private static readonly ISet<Event> _events = new HashSet<Event>() {
            new Event(Guid.NewGuid(),"Event1","EventDesc",DateTime.UtcNow,DateTime.UtcNow.AddMinutes(5))
    };
        

        public async Task<Event> GetAsync(Guid id)
        {
            return await Task.FromResult<Event>(_events.SingleOrDefault(x=>x.Id == id));
        }

        public async Task<Event> GetAsync(string name)
        {
            return await Task.FromResult<Event>(_events.SingleOrDefault(x => x.Name.ToLowerInvariant() == name));
        }

        public async Task AddAsync(Event @event)
        {
            _events.Add(@event);
             await Task.CompletedTask;
        }

        public async Task<IEnumerable<Event>> BrowseAsync(string name = "")
        {
            var eventy = _events.AsEnumerable();
            if(!string.IsNullOrWhiteSpace(name))
            {
                eventy = eventy.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }
            return await Task.FromResult(eventy);
        }

        public async Task DeleteAsync(Event @event)
        {
            _events.Remove(@event);
            await Task.CompletedTask;
        }


        public async Task UpdateAsync(Event @event)
        {
            await Task.CompletedTask;
        }
    }
}
