using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_CSharp.Models
{
    public class Zapis
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("kursid")]
        public int KursId { get; set; }

        [Required]
        [Column("uczestnikid")]
        public int UczestnikId { get; set; }

        [Required]
        [DataType(DataType.DateTime)] 
        [Column("datazapisu")]
        public DateTime DataZapisu { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        [Column("statusplatnosci")]
        public string? StatusPlatnosci { get; set; } 

        [ForeignKey("KursId")]
        public virtual Kurs Kurs { get; set; }

        [ForeignKey("UczestnikId")]
        public virtual Uczestnik Uczestnik { get; set; }
    }
}
