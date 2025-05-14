using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_CSharp.Models
{
    public class Kurs
    {

        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa kursu jest wymagana.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Nazwa kursu musi mieć od 3 do 255 znaków.")]
        [Column("nazwa")]
        public string Nazwa { get; set; }

        [StringLength(2000, ErrorMessage = "Opis nie może przekraczać 2000 znaków.")]
        [Column("opis")]
        public string? Opis { get; set; }

        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana.")]
        [DataType(DataType.Date)]
        [Column("datarozpoczecia")]
        public DateTime DataRozpoczecia { get; set; }

        [DataType(DataType.Date)]
        [Column("datazakonczenia")]

        public DateTime? DataZakonczenia { get; set; }

        [Required(ErrorMessage = "Maksymalna liczba uczestników jest wymagana.")]
        [Range(1, 500, ErrorMessage = "Maksymalna liczba uczestników musi być wartością dodatnią (1-500).")] 
        [Column("maksymalnaliczbauczestnikow")]
        public int MaksymalnaLiczbaUczestnikow { get; set; }

        [StringLength(150, ErrorMessage = "Nazwa prowadzącego nie może przekraczać 150 znaków.")]
        [Column("prowadzacy")]
        public string? Prowadzacy { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Range(0.00, 100000.00, ErrorMessage = "Cena musi być wartością nieujemną (0.00 - 100000.00).")]
        [Column("cena")]
        public decimal Cena { get; set; }

        public virtual ICollection<Zapis> Zapisy { get; set; } = new List<Zapis>();

        [NotMapped]
        public string InfoOMiejscach
        {
            get
            {
                
                return $"{(Zapisy?.Count ?? 0)}/{MaksymalnaLiczbaUczestnikow}";
            }
        }
    }
}
