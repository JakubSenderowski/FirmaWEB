using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")]
        [MaxLength(25, ErrorMessage = "Link może zawierać maksymalnie 20 znaków.")]
        [Display(Name = "Tytuł Odnośnika")]
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł strony jest wymagany")]
        [MaxLength(50, ErrorMessage = "Link może zawierać maksymalnie 50 znaków.")]
        [Display(Name = "Tytuł Strony")]
        public required string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")] //Tu decydujemy jaki jest typ tego pola w bazie danych
        public required string Tresc { get; set; }

        [Display(Name = "Pozycja Wyświetlania")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")]
        public int Pozycja { get; set; }
    }
}
