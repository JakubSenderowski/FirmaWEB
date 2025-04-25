using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Firma.Intranet.Models.CMS;
using Firma.Intranet.Models.Menu;
using Firma.Intranet.Models.Intranet;
using Firma.Intranet.Models.Zamowienia;

namespace Firma.Intranet.Data
{
    public class FirmaIntranetContext : DbContext
    {
        public FirmaIntranetContext (DbContextOptions<FirmaIntranetContext> options)
            : base(options)
        {
        }

        public DbSet<Firma.Intranet.Models.CMS.Strona> Strona { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.CMS.WiadomoscKontaktowa> WiadomoscKontaktowa { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Menu.Danie> Danie { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Menu.Kategoria> Kategoria { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Intranet.Pracownik> Pracownik { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Intranet.Urlopy> Urlopy { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Zamowienia.MetodaPlatnosci> MetodaPlatnosci { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Zamowienia.Zamowienie> Zamowienie { get; set; } = default!;
    }
}
