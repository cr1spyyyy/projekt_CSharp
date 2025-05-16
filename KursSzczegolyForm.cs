using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projekt_CSharp.Data;
using projekt_CSharp.Models;

namespace projekt_CSharp
{
    public partial class KursSzczegolyForm : Form
    {
        private readonly KursyContext _context;
        private readonly int _kursId;
        private Kurs _biezacyKurs;
        public KursSzczegolyForm(KursyContext context, int kursId)
        {
            InitializeComponent();
            _context = context;
            _kursId = kursId;
            UstawKontrolkiKursuReadOnly(true);
        }
        private void KursSzczegolyForm_Load(object sender, EventArgs e) 
        {
            WczytajDaneKursu();
            WczytajZapisanychUczestnikow();
            KonfigurujDataGridViewUczestnikow();
        }
        private void UstawKontrolkiKursuReadOnly(bool isReadOnly)
        {
            txtNazwaKursu.ReadOnly = isReadOnly;
            txtOpisKursu.ReadOnly = isReadOnly;
            dtpDataRozpoczecia.Enabled = !isReadOnly;
            dtpDataZakonczenia.Enabled = !isReadOnly;
            txtProwadzacy.ReadOnly = isReadOnly;
            numCena.ReadOnly = isReadOnly;
            numMaxMiejsca.ReadOnly = isReadOnly;

            if (isReadOnly)
            {
                btnEdytujKurs.Text = "Edytuj Dane Kursu";
            }
            else
            {
                btnEdytujKurs.Text = "Zapisz Zmiany";
            }
        }
        private void WczytajDaneKursu()
        {
            _biezacyKurs = _context.Kursy.Include(k => k.Zapisy).FirstOrDefault(k => k.Id == _kursId);

            if (_biezacyKurs != null)
            {
                this.Text = $"Szczegóły kursu: {_biezacyKurs.Nazwa}";
                txtNazwaKursu.Text = _biezacyKurs.Nazwa;
                txtOpisKursu.Text = _biezacyKurs.Opis;
                dtpDataRozpoczecia.Value = _biezacyKurs.DataRozpoczecia;
                if (_biezacyKurs.DataZakonczenia.HasValue)
                {
                    dtpDataZakonczenia.Value = _biezacyKurs.DataZakonczenia.Value;
                    dtpDataZakonczenia.Checked = true;
                    dtpDataZakonczenia.Enabled = false;
                }
                else
                {
                    dtpDataZakonczenia.Checked = false;
                    dtpDataZakonczenia.Enabled = false;
                }
                dtpDataRozpoczecia.Enabled = false; 
                txtProwadzacy.Text = _biezacyKurs.Prowadzacy;
                numCena.Value = _biezacyKurs.Cena;
                numMaxMiejsca.Value = _biezacyKurs.MaksymalnaLiczbaUczestnikow;
            }
            else
            {
                MessageBox.Show("Nie można załadować danych kursu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void WczytajZapisanychUczestnikow()
        {
            if (_biezacyKurs == null) return;

            var zapisani = _context.Zapisy
                .Where(z => z.KursId == _kursId)
                .Include(z => z.Uczestnik) 
                .Select(z => new
                {
                    ZapisId = z.Id, 
                    UczestnikId = z.Uczestnik.Id,
                    z.Uczestnik.Imie,
                    z.Uczestnik.Nazwisko,
                    z.Uczestnik.Email,
                    z.DataZapisu
                })
                .OrderBy(u => u.Nazwisko).ThenBy(u => u.Imie)
                .ToList();

            dgvZapisaniNaKurs.DataSource = zapisani;
        }
        private void KonfigurujDataGridViewUczestnikow()
        {
            dgvZapisaniNaKurs.AutoGenerateColumns = false;
            dgvZapisaniNaKurs.Columns.Clear();

            dgvZapisaniNaKurs.Columns.Add(new DataGridViewTextBoxColumn { Name = "UczestnikIdColumn", DataPropertyName = "UczestnikId", HeaderText = "ID Ucz.", Visible = false });
            dgvZapisaniNaKurs.Columns.Add(new DataGridViewTextBoxColumn { Name = "ZapisIdColumn", DataPropertyName = "ZapisId", HeaderText = "ID Zapisu", Visible = false });
            dgvZapisaniNaKurs.Columns.Add(new DataGridViewTextBoxColumn { Name = "ImieColumn", DataPropertyName = "Imie", HeaderText = "Imię", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvZapisaniNaKurs.Columns.Add(new DataGridViewTextBoxColumn { Name = "NazwiskoColumn", DataPropertyName = "Nazwisko", HeaderText = "Nazwisko", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvZapisaniNaKurs.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmailColumn", DataPropertyName = "Email", HeaderText = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvZapisaniNaKurs.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataZapisuColumn", DataPropertyName = "DataZapisu", HeaderText = "Data Zapisu", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });

            var colWypisz = new DataGridViewButtonColumn { Name = "WypiszColumn", HeaderText = "Akcja", Text = "Wypisz", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, FlatStyle = FlatStyle.Popup };
            dgvZapisaniNaKurs.Columns.Add(colWypisz);

            dgvZapisaniNaKurs.AllowUserToAddRows = false;
            dgvZapisaniNaKurs.ReadOnly = true; 
            dgvZapisaniNaKurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void dgvZapisaniNaKurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvZapisaniNaKurs.Columns[e.ColumnIndex].Name == "WypiszColumn")
            {
                var zapisId = (int)dgvZapisaniNaKurs.Rows[e.RowIndex].Cells["ZapisIdColumn"].Value;
                var imieUczestnika = dgvZapisaniNaKurs.Rows[e.RowIndex].Cells["ImieColumn"].Value.ToString();
                var nazwiskoUczestnika = dgvZapisaniNaKurs.Rows[e.RowIndex].Cells["NazwiskoColumn"].Value.ToString();

                if (MessageBox.Show($"Czy na pewno chcesz wypisać uczestnika '{imieUczestnika} {nazwiskoUczestnika}' z tego kursu?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var zapisDoUsuniecia = _context.Zapisy.Find(zapisId);
                    if (zapisDoUsuniecia != null)
                    {
                        _context.Zapisy.Remove(zapisDoUsuniecia);
                        _context.SaveChanges();
                        WczytajZapisanychUczestnikow();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }

        }
        private void btnEdytujKurs_Click(object sender, EventArgs e) 
        {
            if (txtNazwaKursu.ReadOnly)
            {
                UstawKontrolkiKursuReadOnly(false);
            }
            else
            {
                if (_biezacyKurs == null) return;

                _biezacyKurs.Nazwa = txtNazwaKursu.Text.Trim();
                _biezacyKurs.Opis = txtOpisKursu.Text.Trim();
                _biezacyKurs.DataRozpoczecia = dtpDataRozpoczecia.Value.Date;
                _biezacyKurs.DataZakonczenia = dtpDataZakonczenia.Checked ? (DateTime?)dtpDataZakonczenia.Value.Date : null;
                _biezacyKurs.Prowadzacy = txtProwadzacy.Text.Trim();
                _biezacyKurs.Cena = numCena.Value;
                _biezacyKurs.MaksymalnaLiczbaUczestnikow = (int)numMaxMiejsca.Value;

                var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(_biezacyKurs);
                var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
                if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(_biezacyKurs, validationContext, validationResults, true))
                {
                    MessageBox.Show(string.Join("\n", validationResults.Select(r => r.ErrorMessage)), "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_biezacyKurs.DataZakonczenia.HasValue && _biezacyKurs.DataZakonczenia < _biezacyKurs.DataRozpoczecia)
                {
                    MessageBox.Show("Data zakończenia nie może być wcześniejsza niż data rozpoczęcia.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    _context.SaveChanges();
                    MessageBox.Show("Zmiany w kursie zostały zapisane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UstawKontrolkiKursuReadOnly(true);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd zapisu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnZapiszNaKurs_Click(object sender, EventArgs e)
        {
            if (_kursId <= 0)
            {
                MessageBox.Show("Nie można zidentyfikować bieżącego kursu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var scope = Program.ServiceProvider.CreateScope())
            {
                var rejestracjaContext = scope.ServiceProvider.GetRequiredService<KursyContext>();
                var rejestracjaForm = new RejestracjaForm(rejestracjaContext, _kursId, null);
                if (rejestracjaForm.ShowDialog() == DialogResult.OK)
                {
                    WczytajDaneKursu();
                    WczytajZapisanychUczestnikow();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            if (!txtNazwaKursu.ReadOnly)
            {
                WczytajDaneKursu();
                UstawKontrolkiKursuReadOnly(true);
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}

