using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projekt_CSharp.Data;
using Microsoft.EntityFrameworkCore;
using projekt_CSharp.Models;
namespace projekt_CSharp
{
    public partial class RejestracjaForm : Form
    {
        private readonly KursyContext _context;

        public RejestracjaForm(KursyContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void RejestracjaForm_Load(object sender, EventArgs e)
        {
            try
            {
                WypelnijComboBoxy();
                dtpDataZapisu.Value = DateTime.Now; 
                cmbStatusPlatnosci.Items.AddRange(new string[] { "Nieopłacony", "Zaliczka", "Opłacony" });
                cmbStatusPlatnosci.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych formularza rejestracji: {ex.Message}\n{ex.InnerException?.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void WypelnijComboBoxy()
        {
            // Ładowanie kursów
            cmbKursy.DataSource = _context.Kursy.AsNoTracking().OrderBy(k => k.Nazwa).ToList();
            cmbKursy.DisplayMember = "Nazwa";
            cmbKursy.ValueMember = "Id";
            if (cmbKursy.Items.Count > 0) cmbKursy.SelectedIndex = 0;

            // Ładowanie uczestników
            cmbUczestnicy.DataSource = _context.Uczestnicy.AsNoTracking().OrderBy(u => u.Nazwisko).ThenBy(u => u.Imie).ToList();
            cmbUczestnicy.DisplayMember = "PelneImie";
            cmbUczestnicy.ValueMember = "Id";
            if (cmbUczestnicy.Items.Count > 0) cmbUczestnicy.SelectedIndex = 0;
        }

        private void btnDokonajZapisu_Click(object sender, EventArgs e)
        {
            if (cmbKursy.SelectedValue == null || cmbUczestnicy.SelectedValue == null)
            {
                MessageBox.Show("Proszę wybrać kurs i uczestnika.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int kursId = (int)cmbKursy.SelectedValue;
            int uczestnikId = (int)cmbUczestnicy.SelectedValue;

            // Sprawdzenie, czy uczestnik nie jest już zapisany na ten kurs
            bool juzZapisany = _context.Zapisy.Any(z => z.KursId == kursId && z.UczestnikId == uczestnikId);
            if (juzZapisany)
            {
                MessageBox.Show("Ten uczestnik jest już zapisany na wybrany kurs.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sprawdzenie, czy są wolne miejsca na kursie
            var kurs = _context.Kursy.Include(k => k.Zapisy).FirstOrDefault(k => k.Id == kursId);
            if (kurs != null && kurs.Zapisy.Count >= kurs.MaksymalnaLiczbaUczestnikow)
            {
                MessageBox.Show("Brak wolnych miejsc na tym kursie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nowyZapis = new Zapis
            {
                KursId = kursId,
                UczestnikId = uczestnikId,
                DataZapisu = DateTime.UtcNow,
                StatusPlatnosci = cmbStatusPlatnosci.SelectedItem?.ToString()
            };

            try
            {
                _context.Zapisy.Add(nowyZapis);
                _context.SaveChanges();
                MessageBox.Show("Uczestnik został pomyślnie zapisany na kurs.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas tworzenia zapisu: {ex.Message}\n{ex.InnerException?.Message}", "Błąd Zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
