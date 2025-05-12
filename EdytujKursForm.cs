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
using Microsoft.EntityFrameworkCore;
using projekt_CSharp.Data;
using projekt_CSharp.Models;
using Microsoft.Extensions.DependencyInjection;
namespace projekt_CSharp
{
    public partial class EdytujKursForm : Form
    {
        private readonly KursyContext _context;
        public Kurs KursDoEdycji { get; private set; }
        private bool _isNewKurs;

        public EdytujKursForm(KursyContext context, Kurs kurs = null)
        {
            InitializeComponent();
            _context = context;

            if (kurs == null)
            {
                KursDoEdycji = new Kurs(); // Tworzenie nowego kursu
                _isNewKurs = true;
                this.Text = "Dodaj Nowy Kurs";
            }
            else
            {
                KursDoEdycji = kurs;
                _isNewKurs = false;
                this.Text = $"Edytuj Kurs: {KursDoEdycji.Nazwa}";
                WypelnijPola();
            }
        }
        private void WypelnijPola()
        {
            txtNazwaKursu.Text = KursDoEdycji.Nazwa;
            txtOpisKursu.Text = KursDoEdycji.Opis;
            dtpDataRozpoczecia.Value = KursDoEdycji.DataRozpoczecia;
            if (KursDoEdycji.DataZakonczenia.HasValue)
            {
                dtpDataZakonczenia.Value = KursDoEdycji.DataZakonczenia.Value;
                dtpDataZakonczenia.Checked = true; 
            }
            else
            {
                dtpDataZakonczenia.Checked = false; 
            }
            numMaxUczestnikow.Value = KursDoEdycji.MaksymalnaLiczbaUczestnikow > 0 ? KursDoEdycji.MaksymalnaLiczbaUczestnikow : 1;
            txtProwadzacy.Text = KursDoEdycji.Prowadzacy;
            numCena.Value = KursDoEdycji.Cena;
        }
        private void numMaxUczestnikow_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnZapiszKurs_Click(object sender, EventArgs e)
        {
            KursDoEdycji.Nazwa = txtNazwaKursu.Text.Trim();
            KursDoEdycji.Opis = txtOpisKursu.Text.Trim();
            KursDoEdycji.DataRozpoczecia = dtpDataRozpoczecia.Value.ToUniversalTime();
            KursDoEdycji.DataZakonczenia = dtpDataZakonczenia.Checked ? (DateTime?)dtpDataZakonczenia.Value.ToUniversalTime() : null;
            KursDoEdycji.MaksymalnaLiczbaUczestnikow = (int)numMaxUczestnikow.Value;
            KursDoEdycji.Prowadzacy = txtProwadzacy.Text.Trim();
            KursDoEdycji.Cena = numCena.Value;

            // Walidacja 
            var validationContext = new ValidationContext(KursDoEdycji, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(KursDoEdycji, validationContext, validationResults, true);

            if (!isValid)
            {
                string errorMessages = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show("Popraw następujące błędy:\n" + errorMessages, "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (KursDoEdycji.DataZakonczenia.HasValue && KursDoEdycji.DataZakonczenia.Value < KursDoEdycji.DataRozpoczecia)
            {
                MessageBox.Show("Data zakończenia nie może być wcześniejsza niż data rozpoczęcia.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (_isNewKurs)
                {
                    _context.Kursy.Add(KursDoEdycji);
                }
                else
                {
                    _context.Kursy.Update(KursDoEdycji);
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

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numCena_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDataRozpoczecia_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
