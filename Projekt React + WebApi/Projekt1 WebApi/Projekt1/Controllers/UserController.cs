using Microsoft.AspNetCore.Mvc;
using Projekt1.Interface;
using Projekt1.Models;

namespace Projekt1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAllUser();
            return  Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var user = _userService.GetByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post(User user)
        {
            var userAd = _userService.AddUser(user);
            return Ok("User Created");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(User user)
        {
             _userService.UpdateUser(user);
            return NoContent();

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
