using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Zamowienia
{
    public class MetodaPlatnosci
    {
        [Key]
        public int IdMetodyPlatnosci { get; set; }

        [Required(ErrorMessage = "Podaj nazwę metody płatności")]
        public required string Nazwa { get; set; }

        public string? Opis { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
    }
}
