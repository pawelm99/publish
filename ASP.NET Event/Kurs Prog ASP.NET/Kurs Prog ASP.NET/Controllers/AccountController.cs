using Evento.Infrastructure.Commands.Users;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kurs_Prog_ASP.NET.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private IUserService _userService;
        private ITicketsService _ticketService;
        public AccountController(IUserService userService,ITicketsService ticketsService)
        {
            _userService= userService;
            _ticketService= ticketsService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
       =>Json(await _userService.GetAccountAsync(UserId));

        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets()
        => Json(await _ticketService.GetForUserAsyc(UserId));

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(),
                command.Email, command.Name, command.Password, command.Role);
            return Created("/account", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(Login command)
        => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}
