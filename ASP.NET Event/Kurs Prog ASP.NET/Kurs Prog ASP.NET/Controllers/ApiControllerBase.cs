
using Microsoft.AspNetCore.Mvc;

namespace Kurs_Prog_ASP.NET.Controllers
{
    [Route("{controller}")]
    public class ApiControllerBase : Controller
    {
        protected Guid UserId =>User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) : Guid.Empty;
    }
}
