using Firma.Intranet.Models.Menu;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Intranet.Models.Intranet
{
    public class Urlopy
    {
        [Key]
        public int IdUrlopu { get; set; }

        [Required (ErrorMessage = "Wybierz datę OD")]
        public required DateTime DataOd {  get; set; }

        [Required (ErrorMessage = "Wybierz datę DO")]
        public required DateTime DataDo {  get; set; }

        [Required (ErrorMessage = "Zdjęcie urlopowanego pracownika jest wymagane")]
        public required string FotoURL { get; set; }

        [ForeignKey("Pracownik")]
        public int IdPracownika { get; set; }
        public Pracownik? Pracownik { get; set; }
    }
}
