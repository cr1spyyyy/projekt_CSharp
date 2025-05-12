using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projekt_CSharp.Models;
namespace projekt_CSharp.Data
{
    public class KursyContext : DbContext
    {
        public KursyContext(DbContextOptions<KursyContext> options) : base(options)
        {
        }

        public DbSet<Kurs> Kursy { get; set; }
        public DbSet<Uczestnik> Uczestnicy { get; set; }
        public DbSet<Zapis> Zapisy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja dla tabeli Kursy
            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.Property(e => e.Cena).HasPrecision(10, 2); 

            });

            // Konfiguracja dla tabeli Uczestnicy
            modelBuilder.Entity<Uczestnik>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique(); 
            });


            // Konfiguracja dla tabeli Zapisy
            modelBuilder.Entity<Zapis>(entity =>
            {
                // Klucz złożony 
                entity.HasIndex(z => new { z.KursId, z.UczestnikId }).IsUnique();


                entity.HasOne(z => z.Kurs)
                      .WithMany(k => k.Zapisy) 
                      .HasForeignKey(z => z.KursId)
                      .OnDelete(DeleteBehavior.Restrict); 


                entity.HasOne(z => z.Uczestnik)
                      .WithMany(u => u.Zapisy) 
                      .HasForeignKey(z => z.UczestnikId)
                      .OnDelete(DeleteBehavior.Restrict); 


            });
        }
    }
}
