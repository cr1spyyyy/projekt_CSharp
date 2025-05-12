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

namespace projekt_CSharp
{
    public partial class EdytujUczForm : Form
    {
        private readonly KursyContext _context;
        public Uczestnik UczestnikDoEdycji { get; private set; }
        private bool _isNewUczestnik;

        public EdytujUczForm(KursyContext context, Uczestnik uczestnik = null)
        {
            InitializeComponent();
            _context = context;

            if (uczestnik == null)
            {
                UczestnikDoEdycji = new Uczestnik();
                _isNewUczestnik = true;
                this.Text = "Dodaj Nowego Uczestnika";
            }
            else
            {
                UczestnikDoEdycji = uczestnik;
                _isNewUczestnik = false;
                this.Text = $"Edytuj Dane Uczestnika: {UczestnikDoEdycji.PelneImie}";
                WypelnijPola();
            }
        }

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

        private void label1_Click(object sender, EventArgs e)
        {

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

            UczestnikDoEdycji.DataUrodzenia = dtpDataUrodzenia.Checked ? (DateTime?)dtpDataUrodzenia.Value.Date : null;

            var validationContext = new ValidationContext(UczestnikDoEdycji, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(UczestnikDoEdycji, validationContext, validationResults, true);

            if (!isValid)
            {
                string errorMessages = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show("Popraw następujące błędy:\n" + errorMessages, "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdzenie unikalności emaila, jeśli to nowy uczestnik lub email został zmieniony
            bool emailExists;
            if (_isNewUczestnik)
            {
                emailExists = _context.Uczestnicy.Any(u => u.Email == UczestnikDoEdycji.Email);
            }
            else
            {
                emailExists = _context.Uczestnicy.Any(u => u.Email == UczestnikDoEdycji.Email && u.Id != UczestnikDoEdycji.Id);
            }

            if (emailExists)
            {
                MessageBox.Show("Uczestnik z podanym adresem email już istnieje w bazie danych.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                if (_isNewUczestnik)
                {
                    _context.Uczestnicy.Add(UczestnikDoEdycji);
                }
                else
                {
                    _context.Uczestnicy.Update(UczestnikDoEdycji);
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
