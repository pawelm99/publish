using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Data;
using Domain.Entities;

namespace Biblioteka.Controllers
{
    public class UzytkowniksController : Controller
    {
        private readonly BibliotekaContext _context;

        public UzytkowniksController(BibliotekaContext context)
        {
            _context = context;
        }

        // GET: Uzytkowniks/Create
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

      /*  // GET: Ksiazkas
        public async Task<IActionResult> Login()
        {
            return View(await _context.Uzytkownik.ToListAsync());
        }*/

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Loginby([Bind("Id,Login,Haslo")] Uzytkownik uzytkownik)
        {

            var loginIsTrue = _context.Uzytkownik.SingleOrDefault(x => x.Login == uzytkownik.Login);
            
            if((loginIsTrue.Haslo==uzytkownik.Haslo))
            {
                return RedirectToAction(nameof(Login));
            }
            /*if (ModelState.IsValid)
            {
                _context.Add(uzytkownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
            return View(uzytkownik);
        }

        private bool UzytkownikExists(int id)
        {
            return _context.Uzytkownik.Any(e => e.Id == id);
        }
    }
}
