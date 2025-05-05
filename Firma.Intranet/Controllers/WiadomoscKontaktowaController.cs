using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Firma.Intranet.Controllers
{
    public class WiadomoscKontaktowaController : Controller
    {
        private readonly FirmaContext _context;

        public WiadomoscKontaktowaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: WiadomoscKontaktowa
        public async Task<IActionResult> Index()
        {
            return View(await _context.WiadomoscKontaktowa.ToListAsync());
        }

        // GET: WiadomoscKontaktowa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomoscKontaktowa = await _context.WiadomoscKontaktowa
                .FirstOrDefaultAsync(m => m.IdWiadomosciKontaktowej == id);
            if (wiadomoscKontaktowa == null)
            {
                return NotFound();
            }

            return View(wiadomoscKontaktowa);
        }

        // GET: WiadomoscKontaktowa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WiadomoscKontaktowa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWiadomosciKontaktowej,Imie,Nazwisko,Email,Uwagi")] WiadomoscKontaktowa wiadomoscKontaktowa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wiadomoscKontaktowa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wiadomoscKontaktowa);
        }

        // GET: WiadomoscKontaktowa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomoscKontaktowa = await _context.WiadomoscKontaktowa.FindAsync(id);
            if (wiadomoscKontaktowa == null)
            {
                return NotFound();
            }
            return View(wiadomoscKontaktowa);
        }

        // POST: WiadomoscKontaktowa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWiadomosciKontaktowej,Imie,Nazwisko,Email,Uwagi")] WiadomoscKontaktowa wiadomoscKontaktowa)
        {
            if (id != wiadomoscKontaktowa.IdWiadomosciKontaktowej)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wiadomoscKontaktowa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WiadomoscKontaktowaExists(wiadomoscKontaktowa.IdWiadomosciKontaktowej))
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
            return View(wiadomoscKontaktowa);
        }

        // GET: WiadomoscKontaktowa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomoscKontaktowa = await _context.WiadomoscKontaktowa
                .FirstOrDefaultAsync(m => m.IdWiadomosciKontaktowej == id);
            if (wiadomoscKontaktowa == null)
            {
                return NotFound();
            }

            return View(wiadomoscKontaktowa);
        }

        // POST: WiadomoscKontaktowa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wiadomoscKontaktowa = await _context.WiadomoscKontaktowa.FindAsync(id);
            if (wiadomoscKontaktowa != null)
            {
                _context.WiadomoscKontaktowa.Remove(wiadomoscKontaktowa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WiadomoscKontaktowaExists(int id)
        {
            return _context.WiadomoscKontaktowa.Any(e => e.IdWiadomosciKontaktowej == id);
        }
    }
}
