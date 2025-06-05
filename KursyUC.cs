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
    public partial class KursyUC : UserControl
    {
        private readonly KursyContext _context;
        private BindingSource _kursyBinding = new BindingSource();
        // Konstruktor kontrolki KursyUC
        public KursyUC(KursyContext context)
        {
            InitializeComponent();
            _context = context;
            // Stylizacja
            this.BackColor = StylAplikacji.Tlo;
            this.ForeColor = StylAplikacji.Tekst;
            panelTop.BackColor = StylAplikacji.Panel;
            label1.ForeColor = StylAplikacji.Tekst;

            StylAplikacji.UstawStylPrzyciskuAkceptacji(szukajBtn);
            StylAplikacji.UstawStylPrzyciskuAkceptacji(dodajBtn);
            dgvKursy.DataSource = _kursyBinding;
            this.Load += KursyUC_Load;

        }

        private void KursyUC_Load(object sender, EventArgs e)
        {
            WczytajKursy();
        }
        // Pobiera dane o kursach z bazy, filtruje je na podstawie kryterium wyszukiwania i przypisuje do tabeli.
        private void WczytajKursy(string search = null)
        {
            try
            {
                _context.ChangeTracker.Clear();
                IQueryable<Kurs> query = _context.Kursy.Include(k => k.Zapisy);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    string lowerSearchTerm = search.ToLower();
                    query = query.Where(k => k.Nazwa.ToLower().Contains(lowerSearchTerm) ||
                                             (k.Prowadzacy != null && k.Prowadzacy.ToLower().Contains(lowerSearchTerm)));
                }

                var kursyList = query
                    .OrderBy(k => k.Nazwa)
                    .Select(k => new
                    {
                        k.Id,
                        k.Nazwa,
                        k.Prowadzacy,
                        k.DataRozpoczecia,
                        k.DataZakonczenia,
                        Miejsca = $"{k.Zapisy.Count}/{k.MaksymalnaLiczbaUczestnikow}",
                        k.Cena
                    })
                    .ToList();

                ConfigureDataGridView();

                dgvKursy.DataSource = kursyList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania danych kursów: {ex.Message}\n\nSzczegóły: {ex.InnerException?.Message}", "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Obsługuje kliknięcie przycisku "Szukaj". Uruchamia ponowne wczytanie kursów z filtrowaniem.
        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            WczytajKursy(txtSzukajKursu.Text);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (var form = new EdytujKursForm(_context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    WczytajKursy(txtSzukajKursu.Text);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvKursy.AutoGenerateColumns = false;
            dgvKursy.Columns.Clear();

            dgvKursy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NazwaColumn",
                DataPropertyName = "Nazwa",
                HeaderText = "Nazwa Kursu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            });
            dgvKursy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProwadzacyColumn",
                DataPropertyName = "Prowadzacy",
                HeaderText = "Prowadzący",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FillWeight = 20
            });
            dgvKursy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataRozpoczeciaColumn",
                DataPropertyName = "DataRozpoczecia",
                HeaderText = "Data Rozp.",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FillWeight = 15
            });
            dgvKursy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataZakonczeniaColumn",
                DataPropertyName = "DataZakonczenia",
                HeaderText = "Data Zak.",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FillWeight = 15
            });
            dgvKursy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MiejscaColumn",
                DataPropertyName = "Miejsca",
                HeaderText = "Ilosc zapisanych",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FillWeight = 15
            });
            dgvKursy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CenaColumn",
                DataPropertyName = "Cena",
                HeaderText = "Cena (PLN)",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FillWeight = 10
            });

            var colEdit = new DataGridViewButtonColumn { Name = "EditColumn", HeaderText = "Akcje", Text = "Edytuj", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 60, FlatStyle = FlatStyle.Popup };
            dgvKursy.Columns.Add(colEdit);
            var colDetails = new DataGridViewButtonColumn { Name = "DetailsColumn", HeaderText = "", Text = "Szczegóły", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 75, FlatStyle = FlatStyle.Popup };
            dgvKursy.Columns.Add(colDetails);
            var colDelete = new DataGridViewButtonColumn { Name = "DeleteColumn", HeaderText = "", Text = "Usuń", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 60, FlatStyle = FlatStyle.Popup };
            dgvKursy.Columns.Add(colDelete);

            dgvKursy.AllowUserToAddRows = false;
            dgvKursy.AllowUserToDeleteRows = false;
            dgvKursy.ReadOnly = true;
            dgvKursy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKursy.MultiSelect = false;
            dgvKursy.ColumnHeadersDefaultCellStyle.Font = new Font(dgvKursy.Font, FontStyle.Bold);
            dgvKursy.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            StylAplikacji.UstawStylDataGridView(dgvKursy);
        }


        private void dgvKursy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rowObj = dgvKursy.Rows[e.RowIndex].DataBoundItem;
            if (rowObj == null) return;
            int kursId = (int)rowObj.GetType().GetProperty("Id").GetValue(rowObj);

            if (dgvKursy.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                using (var editScope = Program.ServiceProvider.CreateScope())
                {
                    var editContext = editScope.ServiceProvider.GetRequiredService<KursyContext>();
                    var kursDoEdycji = editContext.Kursy.FirstOrDefault(k => k.Id == kursId);

                    if (kursDoEdycji == null)
                    {
                        MessageBox.Show("Nie znaleziono kursu do edycji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var edytujKursForm = new EdytujKursForm(editContext, kursDoEdycji);
                    if (edytujKursForm.ShowDialog() == DialogResult.OK)
                    {
                        WczytajKursy(txtSzukajKursu.Text);
                    }
                }
            }
            else if (dgvKursy.Columns[e.ColumnIndex].Name == "DetailsColumn")
            {
                using (var detailsScope = Program.ServiceProvider.CreateScope())
                {
                    var detailsContext = detailsScope.ServiceProvider.GetRequiredService<KursyContext>();
                    var kursSzczegolyForm = new KursSzczegolyForm(detailsContext, kursId);
                    if (kursSzczegolyForm.ShowDialog() == DialogResult.OK)
                    {
                        WczytajKursy(txtSzukajKursu.Text);
                    }
                }
            }
            else if (dgvKursy.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                string nazwaKursu = dgvKursy.Rows[e.RowIndex].Cells["NazwaColumn"].Value?.ToString() ?? "";
                if (MessageBox.Show($"Czy na pewno chcesz usunąć kurs: '{nazwaKursu}'? Wszyscy zapisani uczestnicy zostaną z niego wypisani.", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var kursDoUsuniecia = _context.Kursy.Include(k => k.Zapisy).FirstOrDefault(k => k.Id == kursId);
                    if (kursDoUsuniecia != null)
                    {
                        // Usuń wszystkie zapisy powiązane z tym kursem
                        _context.Zapisy.RemoveRange(kursDoUsuniecia.Zapisy);
                        // A następnie sam kurs
                        _context.Kursy.Remove(kursDoUsuniecia);
                        _context.SaveChanges();
                        WczytajKursy();
                        MessageBox.Show("Kurs i wszystkie powiązane z nim zapisy zostały pomyślnie usunięte.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}