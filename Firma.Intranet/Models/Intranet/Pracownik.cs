using Firma.Intranet.Models.Menu;
using System.ComponentModel.DataAnnotations;

namespace Firma.Intranet.Models.Intranet
{
    public class Pracownik
    {
        [Key]
        public int IdPracownika { get; set; }

        [Required (ErrorMessage = "Imie pracownika jest wymagane.")]
        public required string Imie {  get; set; }

        [Required (ErrorMessage = "Nazwisko pracownika jest wymagane.")]
        public required string Nazwisko { get; set; }

        [Required (ErrorMessage = "Stanowisko pracownika jest wymagane.")]
        public required string Stanowisko { get; set; }

        [Required (ErrorMessage = "Zdjęcie pracownika jest wymagane.")]
        public required string FotoURL { get; set; }

        public ICollection<Urlopy> Urlop { get; set; } = new List<Urlopy>();
    }
}
