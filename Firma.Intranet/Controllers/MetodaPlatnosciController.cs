using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.Zamowienia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Firma.Intranet.Controllers
{
    public class MetodaPlatnosciController : Controller
    {
        private readonly FirmaContext _context;

        public MetodaPlatnosciController(FirmaContext context)
        {
            _context = context;
        }

        // GET: MetodaPlatnosci
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodaPlatnosci.ToListAsync());
        }

        // GET: MetodaPlatnosci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodaPlatnosci = await _context.MetodaPlatnosci
                .FirstOrDefaultAsync(m => m.IdMetodyPlatnosci == id);
            if (metodaPlatnosci == null)
            {
                return NotFound();
            }

            return View(metodaPlatnosci);
        }

        // GET: MetodaPlatnosci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodaPlatnosci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMetodyPlatnosci,Nazwa,Opis")] MetodaPlatnosci metodaPlatnosci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodaPlatnosci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodaPlatnosci);
        }

        // GET: MetodaPlatnosci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodaPlatnosci = await _context.MetodaPlatnosci.FindAsync(id);
            if (metodaPlatnosci == null)
            {
                return NotFound();
            }
            return View(metodaPlatnosci);
        }

        // POST: MetodaPlatnosci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMetodyPlatnosci,Nazwa,Opis")] MetodaPlatnosci metodaPlatnosci)
        {
            if (id != metodaPlatnosci.IdMetodyPlatnosci)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodaPlatnosci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodaPlatnosciExists(metodaPlatnosci.IdMetodyPlatnosci))
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
            return View(metodaPlatnosci);
        }

        // GET: MetodaPlatnosci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodaPlatnosci = await _context.MetodaPlatnosci
                .FirstOrDefaultAsync(m => m.IdMetodyPlatnosci == id);
            if (metodaPlatnosci == null)
            {
                return NotFound();
            }

            return View(metodaPlatnosci);
        }

        // POST: MetodaPlatnosci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodaPlatnosci = await _context.MetodaPlatnosci.FindAsync(id);
            if (metodaPlatnosci != null)
            {
                _context.MetodaPlatnosci.Remove(metodaPlatnosci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodaPlatnosciExists(int id)
        {
            return _context.MetodaPlatnosci.Any(e => e.IdMetodyPlatnosci == id);
        }
    }
}
