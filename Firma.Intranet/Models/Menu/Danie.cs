using Firma.Intranet.Models.Zamowienia;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Intranet.Models.Menu
{
    public class Danie
    {
        [Key]

        public int IdDania { get; set; }

        [Required (ErrorMessage = "Nazwa dania jest wymagana")]
        [MaxLength (10, ErrorMessage = "Nazwa dania może zawierać maksymalnie 10 znaków")]
        public required string Nazwa { get; set; }

        [Required (ErrorMessage = "Cena dania jest wymagana")]
        [Column(TypeName = "money")]
        [Display (Name = "Cena w PLN")]
        public required decimal Cena { get; set; }

        public string? Opis { get; set; }

        [Required (ErrorMessage = "Wybranie zdjęcia dania jest wymagane")]
        public required string FotoURL { get; set; }

        [ForeignKey("Kategoria")]
        public int IdKategorii { get; set; }
        public Kategoria? Kategoria { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
    }
}
