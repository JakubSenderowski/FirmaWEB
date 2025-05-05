using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.Intranet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Firma.Intranet.Controllers
{
    public class UrlopController : Controller
    {
        private readonly FirmaContext _context;

        public UrlopController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Urlopies
        public async Task<IActionResult> Index()
        {
            var firmaIntranetContext = _context.Urlopy.Include(u => u.Pracownik);
            return View(await firmaIntranetContext.ToListAsync());
        }

        // GET: Urlopies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlopy = await _context.Urlopy
                .Include(u => u.Pracownik)
                .FirstOrDefaultAsync(m => m.IdUrlopu == id);
            if (urlopy == null)
            {
                return NotFound();
            }

            return View(urlopy);
        }

        // GET: Urlopies/Create
        public IActionResult Create()
        {
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "FotoURL");
            return View();
        }

        // POST: Urlopies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUrlopu,DataOd,DataDo,FotoURL,IdPracownika")] Urlopy urlopy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urlopy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "FotoURL", urlopy.IdPracownika);
            return View(urlopy);
        }

        // GET: Urlopies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlopy = await _context.Urlopy.FindAsync(id);
            if (urlopy == null)
            {
                return NotFound();
            }
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "FotoURL", urlopy.IdPracownika);
            return View(urlopy);
        }

        // POST: Urlopies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUrlopu,DataOd,DataDo,FotoURL,IdPracownika")] Urlopy urlopy)
        {
            if (id != urlopy.IdUrlopu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urlopy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrlopyExists(urlopy.IdUrlopu))
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
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "FotoURL", urlopy.IdPracownika);
            return View(urlopy);
        }

        // GET: Urlopies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlopy = await _context.Urlopy
                .Include(u => u.Pracownik)
                .FirstOrDefaultAsync(m => m.IdUrlopu == id);
            if (urlopy == null)
            {
                return NotFound();
            }

            return View(urlopy);
        }

        // POST: Urlopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urlopy = await _context.Urlopy.FindAsync(id);
            if (urlopy != null)
            {
                _context.Urlopy.Remove(urlopy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrlopyExists(int id)
        {
            return _context.Urlopy.Any(e => e.IdUrlopu == id);
        }
    }
}
