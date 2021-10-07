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

        // GET: Uzytkowniks
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Uzytkowniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkowniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,Haslo")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Haslo")] Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownikExists(uzytkownik.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzytkownik = await _context.Uzytkownik.FindAsync(id);
            _context.Uzytkownik.Remove(uzytkownik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownikExists(int id)
        {
            return _context.Uzytkownik.Any(e => e.Id == id);
        }
    }
}
