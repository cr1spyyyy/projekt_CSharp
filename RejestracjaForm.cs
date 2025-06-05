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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace projekt_CSharp
{
    public partial class RejestracjaForm : Form
    {
        private readonly string _nazwaKursu;
        private readonly KursyContext _context;
        private readonly int? _domyslnyKursId;
        private readonly int? _domyslnyUczestnikId;
        private readonly string _trybOtwarcia;
        // Konstruktor formularza rejestracji. Przyjmuje kontekst bazy danych oraz opcjonalne parametry domyślne dla kursu i uczestnika.
        public RejestracjaForm(KursyContext context, int? domyslnyKursId = null, int? domyslnyUczestnikId = null, string nazwaKursu = null, string trybOtwarcia = null)
        {
            InitializeComponent();
            // Stylizacja
            this.BackColor = StylAplikacji.Tlo;
            this.ForeColor = StylAplikacji.Tekst;
            StylAplikacji.UstawStylPrzyciskuAkceptacji(btnDokonajZapisu);
            StylAplikacji.UstawStylPrzyciskuAnulowania(btnAnulujZapis);

            _context = context;
            _domyslnyKursId = domyslnyKursId;
            _domyslnyUczestnikId = domyslnyUczestnikId;
            _nazwaKursu = nazwaKursu;
            _trybOtwarcia = trybOtwarcia;
        }
        // Metoda wywoływana po załadowaniu formularza. Wypełnia listy wyboru i ustawia domyślne wartości.
        private void RejestracjaForm_Load(object sender, EventArgs e)
        {
            try
            {
                WypelnijKursy();

                if (_trybOtwarcia == "kurs" && _domyslnyKursId.HasValue)
                {
                    cmbKursy.SelectedValue = _domyslnyKursId.Value;
                    cmbKursy.Enabled = false;
                }

                if (_trybOtwarcia == "uczestnik" && _domyslnyUczestnikId.HasValue)
                {
                    cmbUczestnicy.Enabled = false;
                }

                WypelnijDostepnychUczestnikow();

                if (_trybOtwarcia == "uczestnik" && _domyslnyUczestnikId.HasValue)
                {
                    cmbUczestnicy.SelectedValue = _domyslnyUczestnikId.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych formularza rejestracji: {ex.Message}\n{ex.InnerException?.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Wypełnia listę rozwijaną (ComboBox) wszystkimi dostępnymi kursami.
        private void WypelnijKursy()
        {
            var kursy = _context.Kursy
                .AsNoTracking()
                .OrderBy(k => k.Nazwa)
                .ToList();

            cmbKursy.DataSource = kursy;
            cmbKursy.DisplayMember = "Nazwa";
            cmbKursy.ValueMember = "Id";

            if (cmbKursy.Items.Count > 0)
            {
                cmbKursy.SelectedIndex = 0;
            }
        }
        // Wypełnia listę rozwijaną uczestnikami, którzy NIE są jeszcze zapisani na aktualnie wybrany kurs.
        private void WypelnijDostepnychUczestnikow()
        {
            var wybranyKurs = cmbKursy.SelectedItem as Kurs;

            if (wybranyKurs == null)
            {
                cmbUczestnicy.DataSource = null;
                return;
            }

            int kursId = wybranyKurs.Id; // Bezpieczne pobranie ID
            // Pobiera ID uczestnikow juz zapisanych na wybranu kurs
            List<int> zapisaniIds = _context.Zapisy
                .Where(z => z.KursId == kursId)
                .Select(z => z.UczestnikId)
                .ToList();
            // pobiera uczestnikow, ktorych nie ma na liscie zapisanych
            var uczestnicy = _context.Uczestnicy
                .AsNoTracking()
                .Where(u => !zapisaniIds.Contains(u.Id))
                .OrderBy(u => u.Nazwisko)
                .ThenBy(u => u.Imie)
                .ToList();

            object selectedUczestnik = cmbUczestnicy.SelectedValue;

            cmbUczestnicy.DataSource = uczestnicy;
            cmbUczestnicy.DisplayMember = "PelneImie";
            cmbUczestnicy.ValueMember = "Id";

            if (_trybOtwarcia == "uczestnik" && selectedUczestnik != null)
            {
                cmbUczestnicy.SelectedValue = selectedUczestnik;
            }
            else if (cmbUczestnicy.Items.Count > 0)
            {
                cmbUczestnicy.SelectedIndex = 0;
            }

            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(uczestnicy.Select(u => u.PelneImie).ToArray());
            cmbUczestnicy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUczestnicy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbUczestnicy.AutoCompleteCustomSource = autoComplete;
        }

        private void cmbKursy_SelectedIndexChanged(object sender, EventArgs e)
        {
            WypelnijDostepnychUczestnikow();
        }

        private void btnDokonajZapisu_Click(object sender, EventArgs e)
        {
            if (!(cmbKursy.SelectedItem is Kurs wybranyKurs) || !(cmbUczestnicy.SelectedItem is Uczestnik wybranyUczestnik))
            {
                MessageBox.Show("Proszę wybrać kurs i uczestnika.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int kursId = wybranyKurs.Id;
            int uczestnikId = wybranyUczestnik.Id;

            bool juzZapisany = _context.Zapisy.Any(z => z.KursId == kursId && z.UczestnikId == uczestnikId);
            if (juzZapisany)
            {
                MessageBox.Show("Ten uczestnik jest już zapisany na wybrany kurs.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kurs = _context.Kursy.Include(k => k.Zapisy).FirstOrDefault(k => k.Id == kursId);
            if (kurs != null)
            {
                if (kurs.DataRozpoczecia <= DateTime.Now)
                {
                    MessageBox.Show("Nie można zapisać na kurs, który już się rozpoczął lub zakończył.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (kurs.Zapisy.Count >= kurs.MaksymalnaLiczbaUczestnikow)
                {
                    MessageBox.Show("Brak wolnych miejsc na tym kursie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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