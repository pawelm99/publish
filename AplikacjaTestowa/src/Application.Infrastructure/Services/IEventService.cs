using Application.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services
{
    public interface IEventService
    {
        Task<EventsDetailsDto> GetAsync(Guid id);
        Task<EventsDetailsDto> GetAsync(string name);
        Task<IEnumerable<EventDto>> BrowseAsync(string name = "null");
        Task CreateAsync(Guid id, string name, string description, DateTime dateTime, DateTime endData);
        Task AddTicketsAsync(Guid eventId, int amount, decimal price);
        Task UpdateAsync(Guid eventId, string name , string description);
        Task DeleteAsync(Guid id);

    }
}
