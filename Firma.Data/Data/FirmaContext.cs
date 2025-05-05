using Firma.Data.Data.CMS;
using Firma.Data.Data.Intranet;
using Firma.Data.Data.Menu;
using Firma.Data.Data.Zamowienia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<Strona> Strona { get; set; } = default!;
        public DbSet<WiadomoscKontaktowa> WiadomoscKontaktowa { get; set; } = default!;
        public DbSet<Danie> Danie { get; set; } = default!;
        public DbSet<Kategoria> Kategoria { get; set; } = default!;
        public DbSet<Pracownik> Pracownik { get; set; } = default!;
        public DbSet<Urlopy> Urlopy { get; set; } = default!;
        public DbSet<MetodaPlatnosci> MetodaPlatnosci { get; set; } = default!;
        public DbSet<Zamowienie> Zamowienie { get; set; } = default!;
    }
}

