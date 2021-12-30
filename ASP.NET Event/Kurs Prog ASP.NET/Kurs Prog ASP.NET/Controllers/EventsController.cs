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
        public async Task<IActionResult> Get( string name = "Event1")
        {
            var events = await _eventServices.GetAsync(name);
            return Json(events);
        }
  
    }
}
