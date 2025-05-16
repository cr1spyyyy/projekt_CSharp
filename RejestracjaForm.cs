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
        private readonly int? _domyslnyKursId;
        private readonly int? _domyslnyUczestnikId;

        public RejestracjaForm(KursyContext context, int? domyslnyKursId = null, int? domyslnyUczestnikId = null)
        {
            InitializeComponent();
            _context = context;
            _domyslnyKursId = domyslnyKursId;
            _domyslnyUczestnikId = domyslnyUczestnikId;
        }
        public RejestracjaForm(KursyContext context): this(context, null, null)
        {
        }

        private void RejestracjaForm_Load(object sender, EventArgs e)
        {
            try
            {
                WypelnijComboBoxy();
                dtpDataZapisu.Value = DateTime.Now;
                if (_domyslnyKursId.HasValue)
                {
                    var kursDoZaznaczenia = _context.Kursy.Find(_domyslnyKursId.Value);
                    if (kursDoZaznaczenia != null)
                    {
                        cmbKursy.SelectedValue = _domyslnyKursId.Value;
                        cmbKursy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show($"Nie znaleziono kursu o ID: {_domyslnyKursId.Value}.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (_domyslnyUczestnikId.HasValue)
                {
                    var uczestnikDoZaznaczenia = _context.Uczestnicy.Find(_domyslnyUczestnikId.Value);
                    if (uczestnikDoZaznaczenia != null)
                    {
                        cmbUczestnicy.SelectedValue = _domyslnyUczestnikId.Value;
                        cmbUczestnicy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show($"Nie znaleziono uczestnika o ID: {_domyslnyUczestnikId.Value}.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
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


        private void btnAnulujZapis_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
