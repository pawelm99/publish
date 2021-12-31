using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public interface IEventService
    {
        Task<EventDto> GetAsync(Guid id);
        Task<EventDto> GetAsync(string name);
        Task<IEnumerable<EventDto>> BrowseAsync(string name = "");
        Task AddTicketAsync(Guid eventId,int amount, decimal price);
        Task CreateAsync(Guid id, string name, string desc,DateTime startTime, DateTime endDate);
        Task UpdateAsync(Guid id, string name, string desc);
        Task DeleteAsync(Guid id);
    }
}
