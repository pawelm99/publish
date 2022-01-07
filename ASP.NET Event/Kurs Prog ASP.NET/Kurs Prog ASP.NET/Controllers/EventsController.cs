using Evento.Infrastructure.Commands.Events;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kurs_Prog_ASP.NET.Controllers
{
    [Route("[controller]")]
    public class EventsController : ApiControllerBase
    {
        private readonly IEventService _eventServices;
        public EventsController(IEventService eventServices)
        {
            _eventServices = eventServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name = "")
        {
            var events = await _eventServices.BrowseAsync(name);
            return Json(events);
        }

        [HttpGet("eventId")]
        public async Task<IActionResult> Get(Guid eventId)
        {
            var @event = await _eventServices.GetAsync(eventId);
            if(@event==null)
            {
                return NotFound();
            }
            return Json(@event);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEvent command)
        {
            command.EventId = Guid.NewGuid();
            await _eventServices.CreateAsync(command.EventId, command.Name,
                command.Description, command.StartDate, command.EndDate);
            await _eventServices.AddTicketAsync(command.EventId, command.Tickets,
                command.Price);

            return Created($"/events/{command.EventId}", null);
        }

       
        [HttpPut("{eventId}")]
        public async Task<IActionResult> Put(Guid eventId,[FromBody] UpdateEvent command)
        {
            
            await _eventServices.UpdateAsync(eventId, command.Name,
                command.Description);
          

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> Delete(Guid eventId)
        {

            await _eventServices.DeleteAsync(eventId);


            return NoContent();
        }

    }
}
