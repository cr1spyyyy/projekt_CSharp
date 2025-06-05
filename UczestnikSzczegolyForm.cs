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
    public partial class UczestnikSzczegolyForm : Form
    {
        private readonly KursyContext _context;
        private readonly int _uczestnikId;
        private Uczestnik _biezacyUczestnik;
        public UczestnikSzczegolyForm(KursyContext context, int uczestnikId)
        {
            InitializeComponent();
            // Stylizacja
            this.BackColor = StylAplikacji.Tlo;
            this.ForeColor = StylAplikacji.Tekst;

            StylAplikacji.UstawStylPrzyciskuAkceptacji(btnEdytujUczestnika);
            StylAplikacji.UstawStylPrzyciskuAkceptacji(btnZapiszNaKurs);
            StylAplikacji.UstawStylPrzyciskuAnulowania(btnZamknij);
            _context = context;
            _uczestnikId = uczestnikId;
        }
        // Konstruktor formularza. Przechowuje kontekst bazy danych i ID uczestnika do wyświetlenia.
        private void UczestnikSzczegolyForm_Load(object sender, EventArgs e) 
        {
            WczytajDaneUczestnika();
            WczytajZapisaneKursy();
            KonfigurujDataGridViewKursow();
        }
        // Metoda wywoływana po załadowaniu formularza. Inicjuje wczytywanie danych o uczestniku i jego kursach.
        private void WczytajDaneUczestnika()
        {
            _biezacyUczestnik = _context.Uczestnicy.Include(u => u.Zapisy).FirstOrDefault(u => u.Id == _uczestnikId);

            if (_biezacyUczestnik != null)
            {
                this.Text = $"Szczegóły uczestnika: {_biezacyUczestnik.PelneImie}";
                txtImie.Text = _biezacyUczestnik.Imie;
                txtNazwisko.Text = _biezacyUczestnik.Nazwisko;
                txtEmail.Text = _biezacyUczestnik.Email;
                txtTelefon.Text = _biezacyUczestnik.NumerTelefonu;
                txtDataUr.Text = _biezacyUczestnik.DataUrodzenia?.ToString("yyyy-MM-dd") ?? "Brak danych";
            }
            else
            {
                MessageBox.Show("Nie można załadować danych uczestnika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        // Pobiera z bazy danych szczegółowe informacje o bieżącym uczestniku i wypełnia nimi kontrolki na formularzu.
        private void WczytajZapisaneKursy()
        {
            if (_biezacyUczestnik == null) return;

            var zapisaneKursy = _context.Zapisy
                .Where(z => z.UczestnikId == _uczestnikId)
                .Include(z => z.Kurs)
                .Select(z => new
                {
                    ZapisId = z.Id,
                    KursId = z.Kurs.Id,
                    z.Kurs.Nazwa,
                    z.Kurs.DataRozpoczecia,
                    z.DataZapisu,
                })
                .OrderBy(k => k.Nazwa)
                .ToList();

            dgvKursyUczestnika.DataSource = zapisaneKursy;
        }
        private void KonfigurujDataGridViewKursow()
        {
            dgvKursyUczestnika.AutoGenerateColumns = false;
            dgvKursyUczestnika.Columns.Clear();

            dgvKursyUczestnika.Columns.Add(new DataGridViewTextBoxColumn { Name = "KursIdColumn", DataPropertyName = "KursId", HeaderText = "ID Kursu", Visible = false });
            dgvKursyUczestnika.Columns.Add(new DataGridViewTextBoxColumn { Name = "ZapisIdColumn", DataPropertyName = "ZapisId", HeaderText = "ID Zapisu", Visible = false });
            dgvKursyUczestnika.Columns.Add(new DataGridViewTextBoxColumn { Name = "NazwaKursuColumn", DataPropertyName = "Nazwa", HeaderText = "Nazwa Kursu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvKursyUczestnika.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataRozpoczeciaKursuColumn", DataPropertyName = "DataRozpoczecia", HeaderText = "Data Rozp. Kursu", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvKursyUczestnika.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataZapisuNaKursColumn", DataPropertyName = "DataZapisu", HeaderText = "Data Zapisu", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });

            var colWypisz = new DataGridViewButtonColumn { Name = "WypiszColumn", HeaderText = "Akcja", Text = "Wypisz", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, FlatStyle = FlatStyle.Popup };
            dgvKursyUczestnika.Columns.Add(colWypisz);

            dgvKursyUczestnika.AllowUserToAddRows = false;
            dgvKursyUczestnika.ReadOnly = true;
            dgvKursyUczestnika.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StylAplikacji.UstawStylDataGridView(dgvKursyUczestnika);
        }
        private void dgvKursyUczestnika_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvKursyUczestnika.Columns[e.ColumnIndex].Name == "WypiszColumn")
            {
                var zapisId = (int)dgvKursyUczestnika.Rows[e.RowIndex].Cells["ZapisIdColumn"].Value;
                var nazwaKursu = dgvKursyUczestnika.Rows[e.RowIndex].Cells["NazwaKursuColumn"].Value.ToString();

                if (MessageBox.Show($"Czy na pewno chcesz wypisać uczestnika '{_biezacyUczestnik.PelneImie}' z kursu '{nazwaKursu}'?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var zapisDoUsuniecia = _context.Zapisy.Find(zapisId);
                    if (zapisDoUsuniecia != null)
                    {
                        _context.Zapisy.Remove(zapisDoUsuniecia);
                        _context.SaveChanges();
                        WczytajZapisaneKursy();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        private void btnEdytujUczestnika_Click(object sender, EventArgs e) 
        {
            if (_biezacyUczestnik == null) return;

            using (var editScope = Program.ServiceProvider.CreateScope())
            {
                var editContext = editScope.ServiceProvider.GetRequiredService<KursyContext>();
                var uczestnikDoEdycji = editContext.Uczestnicy.Find(_biezacyUczestnik.Id);
                if (uczestnikDoEdycji == null)
                {
                    MessageBox.Show("Nie można znaleźć uczestnika do edycji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var edytujUczForm = new EdytujUczForm(editContext, uczestnikDoEdycji);
                if (edytujUczForm.ShowDialog() == DialogResult.OK)
                {
                    WczytajDaneUczestnika(); 
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void btnZapiszNaKurs_Click(object sender, EventArgs e) 
        {
            if (_biezacyUczestnik == null)
            {
                MessageBox.Show("Nie można zidentyfikować bieżącego uczestnika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var scope = Program.ServiceProvider.CreateScope())
            {
                var rejestracjaContext = scope.ServiceProvider.GetRequiredService<KursyContext>();

                var rejestracjaForm = new RejestracjaForm(rejestracjaContext, null, _biezacyUczestnik.Id, null, "uczestnik");
                if (rejestracjaForm.ShowDialog() == DialogResult.OK)
                {
                    WczytajZapisaneKursy();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void btnZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
