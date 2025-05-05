using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Firma.Intranet.Controllers
{
    public class DanieController : Controller
    {
        private readonly FirmaContext _context;

        public DanieController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Danie
        public async Task<IActionResult> Index()
        {
            var firmaIntranetContext = _context.Danie.Include(d => d.Kategoria);
            return View(await firmaIntranetContext.ToListAsync());
        }

        // GET: Danie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danie = await _context.Danie
                .Include(d => d.Kategoria)
                .FirstOrDefaultAsync(m => m.IdDania == id);
            if (danie == null)
            {
                return NotFound();
            }

            return View(danie);
        }

        // GET: Danie/Create
        public IActionResult Create()
        {
            ViewData["IdKategorii"] = new SelectList(_context.Set<Kategoria>(), "IdKategorii", "Nazwa");
            return View();
        }

        // POST: Danie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDania,Nazwa,Cena,Opis,FotoURL,IdKategorii")] Danie danie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKategorii"] = new SelectList(_context.Set<Kategoria>(), "IdKategorii", "Nazwa", danie.IdKategorii);
            return View(danie);
        }

        // GET: Danie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danie = await _context.Danie.FindAsync(id);
            if (danie == null)
            {
                return NotFound();
            }
            ViewData["IdKategorii"] = new SelectList(_context.Set<Kategoria>(), "IdKategorii", "Nazwa", danie.IdKategorii);
            return View(danie);
        }

        // POST: Danie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDania,Nazwa,Cena,Opis,FotoURL,IdKategorii")] Danie danie)
        {
            if (id != danie.IdDania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanieExists(danie.IdDania))
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
            ViewData["IdKategorii"] = new SelectList(_context.Set<Kategoria>(), "IdKategorii", "Nazwa", danie.IdKategorii);
            return View(danie);
        }

        // GET: Danie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danie = await _context.Danie
                .Include(d => d.Kategoria)
                .FirstOrDefaultAsync(m => m.IdDania == id);
            if (danie == null)
            {
                return NotFound();
            }

            return View(danie);
        }

        // POST: Danie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danie = await _context.Danie.FindAsync(id);
            if (danie != null)
            {
                _context.Danie.Remove(danie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanieExists(int id)
        {
            return _context.Danie.Any(e => e.IdDania == id);
        }
    }
}
