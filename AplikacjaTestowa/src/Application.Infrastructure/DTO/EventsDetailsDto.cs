using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.DTO
{
    public class EventsDetailsDto : EventDto
    {
        public IEnumerable<TicketsDto> Tickets { get; set; }
    }
}
