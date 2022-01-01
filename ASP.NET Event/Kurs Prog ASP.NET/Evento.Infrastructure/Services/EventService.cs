using AutoMapper;
using Evento.Core.Domain;
using Evento.Core.Repositories;
using Evento.Infrastructure.DTO;
using Evento.Infrastructure.Extensions;
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
            _mapper = mapper;
        }
        public async Task<EventDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
           

            return _mapper.Map<EventDto>(@event);
        }

        public async Task<EventDto> GetAsync(string name)
        {
            var @event = await _eventRepository.GetAsync(name);
            var a = new EventDto()
            {
                Id = Guid.NewGuid(),
                Name = @event.Name,
                Description = @event.Description,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(4),
                TicketsCount = 2,
                UpdateAt = DateTime.UtcNow.AddHours(10),

            };

            return _mapper.Map<EventDto>(@event);
        }
        

        public async Task<IEnumerable<EventDto>> BrowseAsync(string name = "")
        {
            var events = await _eventRepository.BrowseAsync(name);
          

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task CreateAsync(Guid id, string name, string desc, DateTime startTime, DateTime endDate)
        {

            var @event = await _eventRepository.GetAsync(name);
            if(@event != null)
            {
                throw new Exception($"Event named: '{name}' alredy existed");
            }
            @event = new Event(id,name,desc,startTime,endDate);
            await _eventRepository.AddAsync(@event);
        }

        public async Task AddTicketAsync(Guid eventId, int amount, decimal price)
        {
            var @event = await _eventRepository.GetOrFailAsync(eventId);
            @event.AddTickets(amount, price);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task UpdateAsync(Guid id, string name, string desc)
        {

            var @event = await _eventRepository.GetAsync(name);
            if (@event != null)
            {
                throw new Exception($"Event with name: '{name}' does not exist.");
            }
            @event = await _eventRepository.GetOrFailAsync(id);


            @event.SetName(name);
            @event.SetDesc(desc);
            await _eventRepository.UpdateAsync(@event);

        }
        public async Task DeleteAsync(Guid id)
        {
            var @event = await _eventRepository.GetOrFailAsync(id);
            await _eventRepository.DeleteAsync(@event);
        }
    }
}
