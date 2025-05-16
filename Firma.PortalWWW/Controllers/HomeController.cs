using Firma.Data.Data;
using Firma.Data.Data.Intranet;
using Firma.Data.Data.Menu;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirmaContext _context;
        public HomeController(ILogger<HomeController> logger, FirmaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var dania = _context.Danie.ToList();
            return View(dania);
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Zamow()
        {
            var zamowienia = _context.Zamowienie
            .Include(z => z.Danie)
            .Include(z => z.MetodaPlatnosci)
            .OrderByDescending(z => z.IdZamowienia)
            .Take(10)
            .ToList();


            return View(zamowienia);

           
        }
        public IActionResult Kontakt()
        {
            return View();
        }
        public IActionResult Pracownicy()
        {
            var pracownicy = _context.Pracownik.ToList();
            return View(pracownicy);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
