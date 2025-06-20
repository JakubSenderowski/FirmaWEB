using Firma.Data.Data;
using Firma.Data.Data.CMS;
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

            var naglowek = _context.Strona.FirstOrDefault(s => s.LinkTytul == "Index_Naglowek");
            ViewBag.NaglowekIndex = naglowek?.Tresc ?? "Brak nag³ówka w bazie";

            var naglowek_menu = _context.Strona.FirstOrDefault(s => s.LinkTytul == "Home_Naglowek_Menu");
            ViewBag.NaglowekMenu = naglowek_menu?.Tresc ?? "Brak nag³ówka w bazie";

            var naglowek_dlaczegomy = _context.Strona.FirstOrDefault(s => s.LinkTytul == "Home_Naglowek_Dlaczegomy");
            ViewBag.NaglowekDlaczegoMy = naglowek_dlaczegomy?.Tresc ?? "Brak nag³ówka w bazie";

            var opis_dlaczegomy = _context.Strona.FirstOrDefault(s => s.LinkTytul == "Home_Opis_Dlaczegomy");
            ViewBag.OpisDlaczegoMy = opis_dlaczegomy?.Tresc ?? "Brak nag³ówka w bazie";

            return View(dania);
        }


        public IActionResult Menu(string szukaj)
        {
            var dania = _context.Danie
                .Include(d => d.Kategoria)
                .Where(d => string.IsNullOrEmpty(szukaj) || d.Nazwa.Contains(szukaj))
                .ToList();

            ViewBag.Search = szukaj;

            return View(dania);
        }

        public IActionResult Zamow()
        {
            var zamowienia = _context.Zamowienie
            .Include(z => z.Danie)
            .Include(z => z.MetodaPlatnosci)
            .OrderByDescending(z => z.IdZamowienia)
            .Take(10)
            .ToList();

            var liczbaZamowien = _context.Zamowienie.Count(); 
            ViewBag.LicznikZamowien = liczbaZamowien;

            var naglowek = _context.Strona.FirstOrDefault(s => s.LinkTytul == "Index_Zamowienia");
            ViewBag.NaglowekZamowienia = naglowek?.Tresc ?? "Brak nag³ówka w bazie.";

            return View(zamowienia);

           
        }
        public IActionResult Kontakt()
        {
            var naglowek = _context.Strona.FirstOrDefault(s => s.LinkTytul == "Index_Wiadomosci");
            ViewBag.NaglowekWiadomosci = naglowek?.Tresc ?? "Brak nag³ówka w bazie.";

            return View(new WiadomoscKontaktowa { Imie = "", Nazwisko = "", Email = "" }
);

        }


        [HttpPost]
        public IActionResult Kontakt(WiadomoscKontaktowa wiadomosc)
        {
            if (ModelState.IsValid)
            {
                _context.WiadomoscKontaktowa.Add(wiadomosc);
                _context.SaveChanges();

                TempData["Sukces"] = "Wiadomosc zostala wyslana - skontaktujemy sie z Panstwem";
                return RedirectToAction("Kontakt");
            }
            return View(wiadomosc);
        }
        public IActionResult Pracownicy()
        {
            var pracownicy = _context.Pracownik.ToList();

            var naglowek = _context.Strona.FirstOrDefault(s => s.LinkTytul == "Index_Pracownicy");
            ViewBag.NaglowekPracownicy = naglowek?.Tresc ?? "Brak nag³ówka w bazie.";

            return View(pracownicy);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
