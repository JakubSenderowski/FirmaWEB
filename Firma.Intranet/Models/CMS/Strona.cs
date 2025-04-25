using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Intranet.Models.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }

        [Required (ErrorMessage = "Tytuł odnośnika jest wymagany")]
        [MaxLength(10, ErrorMessage = "Link może zawierać maksymalnie 10 znaków.")]
        [Display(Name = "Tytuł Odnośnika")]
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł strony jest wymagany")]
        [MaxLength(50, ErrorMessage = "Link może zawierać maksymalnie 50 znaków.")]
        [Display(Name = "Tytuł Strony")]
        public required string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")] //Tu decydujemy jaki jest typ tego pola w bazie danych
        public required string Tresc {  get; set; }

        [Display(Name = "Pozycja Wyświetlania")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")]
        public int Pozycja { get; set; }
    }
}
