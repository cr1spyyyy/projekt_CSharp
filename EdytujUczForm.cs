using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projekt_CSharp.Data;
using projekt_CSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace projekt_CSharp
{
    public partial class EdytujUczForm : Form
    {
        private readonly KursyContext _context;
        public Uczestnik UczestnikDoEdycji { get; private set; }
        private bool _isNewUczestnik;
        // Konstruktor EdytujUczForm
        public EdytujUczForm(KursyContext context, Uczestnik uczestnik = null)
        {
            InitializeComponent();
            _context = context;

            // Stylizacja
            this.BackColor = StylAplikacji.Tlo;
            this.ForeColor = StylAplikacji.Tekst;

            StylAplikacji.UstawStylPrzyciskuAkceptacji(btnZapiszUczestnika);
            StylAplikacji.UstawStylPrzyciskuAnulowania(btnAnulujZapUcz);

            // Ustawienie kolorów dla wszystkich labeli
            foreach (var lbl in this.Controls.OfType<Label>())
            {
                lbl.ForeColor = StylAplikacji.Tekst;
            }

            if (uczestnik == null)
            {
                // Tworzenie nowego uczestnika
                UczestnikDoEdycji = new Uczestnik();
                _isNewUczestnik = true;
                this.Text = "Dodaj Nowego Uczestnika";
            }
            else
            {
                // Edycja istniejącego uczestnika
                UczestnikDoEdycji = uczestnik;
                _isNewUczestnik = false;
                this.Text = $"Edytuj Dane Uczestnika: {UczestnikDoEdycji.PelneImie}";
                WypelnijPola();
            }
        }
        // Wypełnia pola formularza danymi z obiektu UczestnikDoEdycji, gdy formularz jest w trybie edycji.
        private void WypelnijPola()
        {
            txtImie.Text = UczestnikDoEdycji.Imie;
            txtNazwisko.Text = UczestnikDoEdycji.Nazwisko;
            txtEmail.Text = UczestnikDoEdycji.Email;
            txtNumerTelefonu.Text = UczestnikDoEdycji.NumerTelefonu;
            if (UczestnikDoEdycji.DataUrodzenia.HasValue)
            {
                dtpDataUrodzenia.Value = UczestnikDoEdycji.DataUrodzenia.Value;
                dtpDataUrodzenia.Checked = true; 
            }
            else
            {
                dtpDataUrodzenia.Checked = false; 
            }
        }


        private void btnAnulujZapUcz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnZapiszUczestnika_Click(object sender, EventArgs e)
        {
            UczestnikDoEdycji.Imie = txtImie.Text.Trim();
            UczestnikDoEdycji.Nazwisko = txtNazwisko.Text.Trim();
            UczestnikDoEdycji.Email = txtEmail.Text.Trim();
            UczestnikDoEdycji.NumerTelefonu = txtNumerTelefonu.Text.Trim();
            if (string.IsNullOrWhiteSpace(UczestnikDoEdycji.NumerTelefonu)) UczestnikDoEdycji.NumerTelefonu = null;
            UczestnikDoEdycji.DataUrodzenia = dtpDataUrodzenia.Checked ? (DateTime?)dtpDataUrodzenia.Value.ToUniversalTime() : null;

            if (string.IsNullOrWhiteSpace(UczestnikDoEdycji.Imie) || !System.Text.RegularExpressions.Regex.IsMatch(UczestnikDoEdycji.Imie, @"^[A-Za-zĄĆĘŁŃÓŚŹŻąćęłńóśźż\- ]+$"))
            {
                MessageBox.Show("Imię może zawierać tylko litery, myślniki i spacje.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(UczestnikDoEdycji.Nazwisko) || !System.Text.RegularExpressions.Regex.IsMatch(UczestnikDoEdycji.Nazwisko, @"^[A-Za-zĄĆĘŁŃÓŚŹŻąćęłńóśźż\- ]+$"))
            {
                MessageBox.Show("Nazwisko może zawierać tylko litery, myślniki i spacje.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(UczestnikDoEdycji.Email) || !UczestnikDoEdycji.Email.Contains("@"))
            {
                MessageBox.Show("Podaj poprawny adres email zawierający znak @.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool emailExists = _isNewUczestnik
                ? _context.Uczestnicy.Any(u => u.Email == UczestnikDoEdycji.Email)
                : _context.Uczestnicy.Any(u => u.Email == UczestnikDoEdycji.Email && u.Id != UczestnikDoEdycji.Id);
            if (emailExists)
            {
                MessageBox.Show("Uczestnik z podanym adresem email już istnieje w bazie danych.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(UczestnikDoEdycji.NumerTelefonu))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(UczestnikDoEdycji.NumerTelefonu, @"^(\+?\d{1,3}[\s-]?)?\(?\d{2,3}\)?[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$|^(\d{9})$"))
                {
                    MessageBox.Show("Podaj poprawny numer telefonu.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool telExists = _isNewUczestnik
                    ? _context.Uczestnicy.Any(u => u.NumerTelefonu == UczestnikDoEdycji.NumerTelefonu)
                    : _context.Uczestnicy.Any(u => u.NumerTelefonu == UczestnikDoEdycji.NumerTelefonu && u.Id != UczestnikDoEdycji.Id);
                if (telExists)
                {
                    MessageBox.Show("Uczestnik z podanym numerem telefonu już istnieje w bazie danych.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Walidacja atrybutów
            var validationContext = new ValidationContext(UczestnikDoEdycji, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(UczestnikDoEdycji, validationContext, validationResults, true);

            if (!isValid)
            {
                string errorMessages = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show("Popraw następujące błędy:\n" + errorMessages, "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Zapisanie lub aktualizacja uczestnika w bazie danych
                if (_isNewUczestnik)
                {
                    _context.Uczestnicy.Add(UczestnikDoEdycji);
                }
                _context.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisywania danych: {ex.Message}\n{ex.InnerException?.Message}", "Błąd Zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
