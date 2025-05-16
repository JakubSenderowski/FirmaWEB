using Firma.Data.Data;
using Firma.Data.Data.Menu;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        public IActionResult Kontakt()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
