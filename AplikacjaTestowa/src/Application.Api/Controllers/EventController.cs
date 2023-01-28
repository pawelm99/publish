using Application.Infrastructure.Commands;
using Application.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var events = await eventService.BrowseAsync(name);

            return Ok(events);
        }
        [HttpGet("{eventId}")]
        public async Task<IActionResult> Get(Guid eventId)
        {
            var events = await eventService.GetAsync(eventId);
            if(events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEvent command)
        {
            command.EventId = Guid.NewGuid();
            await eventService.CreateAsync(command.EventId, command.Name, command.Description, command.StartDate, command.EndDate);
            await eventService.AddTicketsAsync(command.EventId,command.Tickets,command.Price);
            return Created($"/events/{command.EventId}",null);
        }
        [HttpPut("{eventId}")]
        public async Task<IActionResult> Put([FromBody] UpdateEvent command)
        {
            await eventService.UpdateAsync(command.EventId,command.Name, command.Description);

            return NoContent();
        }
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> Delete(Guid eventId)
        {
            await eventService.DeleteAsync(eventId);

            return NoContent();
        }
    }
}
