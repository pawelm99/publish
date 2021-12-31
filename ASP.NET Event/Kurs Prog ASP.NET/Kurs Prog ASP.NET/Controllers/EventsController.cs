using Evento.Infrastructure.Commands.Events;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kurs_Prog_ASP.NET.Controllers
{
    [Route("[controller]")]
    public class EventsController: Controller
    {
        private readonly IEventService _eventServices;
        public EventsController(IEventService eventServices)
        {
            _eventServices = eventServices;
        }
       
        [HttpGet]
        public async Task<IActionResult> Get( string name = "")
        {
            var events = await _eventServices.BrowseAsync(name);
            return Json(events);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateEvent command)
        {
            command.EventId = Guid.NewGuid();
            await _eventServices.CreateAsync(command.EventId,command.Name,
                command.Description,command.StartDate,command.EndDate);
            return Created($"/events/{command.EventId}",null);
        }
  
    }
}
