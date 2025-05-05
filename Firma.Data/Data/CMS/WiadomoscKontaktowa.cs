using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class WiadomoscKontaktowa
    {
        [Key]
        public int IdWiadomosciKontaktowej { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public required string Nazwisko { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        public required string Email { get; set; }

        public string? Uwagi { get; set; }
    }
}
