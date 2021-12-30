using AutoMapper;
using Evento.Core.Repositories;
using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public class EventServices : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventServices(IEventRepository eventRepository,IMapper mapper)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
           

            return _mapper.Map<EventDto>(@event);
        }

        public async Task<EventDto> GetAsync(string name)
        {
            var @event = await _eventRepository.GetAsync(name);


            return _mapper.Map<EventDto>(@event);
        }
        

        public async Task<IEnumerable<EventDto>> BrowseAsync(string name = "")
        {
            var events = await _eventRepository.BrowseAsync(name);


            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task CreateAsync(Guid id, string name, string desc, DateTime startTime, DateTime endDate)
        {

            throw new NotImplementedException();
        }

        public async Task AddTicketAsync(Guid eventId, int amount, decimal price)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, string name, string desc, DateTime startTime, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
