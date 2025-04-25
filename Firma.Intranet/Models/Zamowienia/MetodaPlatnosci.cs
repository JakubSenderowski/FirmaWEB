using System.ComponentModel.DataAnnotations;

namespace Firma.Intranet.Models.Zamowienia
{
    public class MetodaPlatnosci
    {
        [Key]
        public int IdMetodyPlatnosci { get; set; }

        [Required (ErrorMessage = "Podaj nazwę metody płatności")]
        public required string Nazwa {  get; set; }

        public string? Opis { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
    }
}
