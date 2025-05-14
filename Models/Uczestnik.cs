using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_CSharp.Models
{
    public class Uczestnik
    {
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Imię musi mieć od 2 do 100 znaków.")]
        [Column("imie")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Nazwisko musi mieć od 2 do 150 znaków.")]
        [Column("nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres email jest wymagany.")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email.")]
        [Column("email")]
        public string Email { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^(\+?\d{1,3}[\s-]?)?\(?\d{2,3}\)?[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$|^(\d{9})$", ErrorMessage = "Niepoprawny format numeru telefonu.")]
        [Column("numertelefonu")]
        public string? NumerTelefonu { get; set; }

        [DataType(DataType.Date)]
        [Column("dataurodzenia")]
        public DateTime? DataUrodzenia { get; set; }

        public virtual ICollection<Zapis> Zapisy { get; set; } = new List<Zapis>();

        [NotMapped]
        public string PelneImie => $"{Imie} {Nazwisko}";
    }
}
