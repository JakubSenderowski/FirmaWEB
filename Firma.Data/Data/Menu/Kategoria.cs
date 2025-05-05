using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Menu
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
