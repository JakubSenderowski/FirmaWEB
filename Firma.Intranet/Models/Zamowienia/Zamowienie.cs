using Firma.Intranet.Models.Intranet;
using Firma.Intranet.Models.Menu;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Intranet.Models.Zamowienia
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }

        [Required (ErrorMessage = "Podaj Imię")]
        public required string Imie {  get; set; }

        [Required(ErrorMessage = "Podaj Nazwisko")]
        public required string Nazwisko { get; set; }

        [Required(ErrorMessage = "Podaj Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Podaj Adres")]
        public required string Adres {  get; set; }

        public string? Uwagi { get; set; }

        [ForeignKey("Danie")]
        public int IdDania { get; set; }
        public Danie? Danie{ get; set; }

        [ForeignKey("MetodaPlatnosci")]
        public int IdMetodyPlatnosci { get; set; }
        public MetodaPlatnosci? MetodaPlatnosci { get; set; }
    }
}
