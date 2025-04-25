using System.ComponentModel.DataAnnotations;

namespace Firma.Intranet.Models.Menu
{
    public class Kategoria
    {
        [Key]
        public int IdKategorii { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        public required string Nazwa { get; set; }

        public string? Opis { get; set; }
        public ICollection<Danie> Dania { get; set; } = new List<Danie>();
    }
}
