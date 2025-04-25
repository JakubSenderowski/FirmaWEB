using System.ComponentModel.DataAnnotations;

namespace Firma.Intranet.Models.CMS
{
    public class WiadomoscKontaktowa
    {
        [Key]
        public int IdWiadomosciKontaktowej {  get; set; }

        [Required (ErrorMessage = "Imię jest wymagane")]
        public required string Imie {  get; set; }

        [Required (ErrorMessage = "Nazwisko jest wymagane")]
        public required string Nazwisko { get; set; }

        [Required (ErrorMessage = "Email jest wymagany")]
        public required string Email { get; set; }

        public string? Uwagi { get; set; }
    }
}
