using Microsoft.AspNetCore.Mvc;
using Projekt1.Interface;
using Projekt1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService=eventService;
        }

        // GET: api/<EventController>
        [HttpGet]
        public IActionResult Get()
        {
           var events = _eventService.GetAllEvents();
            return Ok(events);
        }

        // GET api/<EventController>/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var @event = _eventService.GetByName(name);
            return Ok(@event);
        }

        // POST api/<EventController>
        [HttpPost]
        public IActionResult Post(Event @event)
        {
            _eventService.AddEvent(@event);
            return Ok("event created!");
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Event @event)
        {
            _eventService.UpdateEvent(@event);
            return NoContent();
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _eventService.DeleteEvent(id);
            return NoContent();
        }
    }
}
