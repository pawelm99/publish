using Application.Core.Domain;
using Application.Core.Repository;
using Application.Infrastructure.DTO;
using Application.Infrastructure.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;   

        }

        public async Task<EventsDetailsDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);

            return _mapper.Map<EventsDetailsDto>(@event);
        }

        public async Task<EventsDetailsDto> GetAsync(string name)
        {
            var @event = await _eventRepository.GetAsync(@name);

            return _mapper.Map<EventsDetailsDto>(@event);
        }

        public async Task<IEnumerable<EventDto>> BrowseAsync(string name = "null")
        {
            var events = await _eventRepository.BrowseAsync(name);

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }


        public async  Task AddTicketsAsync(Guid eventId, int amount, decimal price)
        {
            var @event = await _eventRepository.GetOrFailAsync(eventId);
            @event.AddTickets(amount, price);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task CreateAsync(Guid id, string name, string description, DateTime startDate, DateTime endData)
        {
            var @event = await _eventRepository.GetAsync(name);
            if(@event != null)
            {
                throw new Exception($"Name is exsist : {name}");

            }
            @event = new Event(id, name, description, startDate, endData);
            await _eventRepository.AddAsync(@event);
        }

        public async Task DeleteAsync(Guid id)
        {
            var @event = await _eventRepository.GetOrFailAsync(id);
            await _eventRepository.DeleteAsync(@event);
        }


        public async Task UpdateAsync(Guid eventId, string name, string description)
        {
            var @event = await _eventRepository.GetAsync(eventId);
            if (@event == null)
            {
                throw new Exception($"Name is not exsist : {eventId}");

            }
            var nameGet = await _eventRepository.GetAsync(name);
            if (nameGet != null)
            {
                throw new Exception($"Name is exsist : {nameGet}");

            }
            @event.SetName(name);
            @event.SetDescription(description);
            await _eventRepository.UpdateAsync(@event);

        }
    }
}
