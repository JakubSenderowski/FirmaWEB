using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Intranet
{
    public class Pracownik
    {
        [Key]
        public int IdPracownika { get; set; }

        [Required(ErrorMessage = "Imie pracownika jest wymagane.")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko pracownika jest wymagane.")]
        public required string Nazwisko { get; set; }

        [Required(ErrorMessage = "Stanowisko pracownika jest wymagane.")]
        public required string Stanowisko { get; set; }

        [Required(ErrorMessage = "Zdjęcie pracownika jest wymagane.")]
        public required string FotoURL { get; set; }

        public ICollection<Urlopy> Urlop { get; set; } = new List<Urlopy>();
    }
}
