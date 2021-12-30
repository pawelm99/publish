using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kurs_Prog_ASP.NET.Controllers
{
    public class HomeController : Controller
    {
        
        public string Index()
        {
            return "This is my default action...";
        }

     

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
