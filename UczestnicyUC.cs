using System;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projekt_CSharp.Data;
using projekt_CSharp.Models;

namespace projekt_CSharp
{
    public partial class UczestnicyUC : UserControl
    {
        private readonly KursyContext _context;

        public UczestnicyUC(KursyContext context)
        {
            InitializeComponent();
            _context = context;
            // Stylizacja
            this.BackColor = StylAplikacji.Tlo;
            this.ForeColor = StylAplikacji.Tekst;
            panelTop.BackColor = StylAplikacji.Panel;
            label1.ForeColor = StylAplikacji.Tekst;

            StylAplikacji.UstawStylPrzyciskuAkceptacji(btnWyszukajUcz);
            StylAplikacji.UstawStylPrzyciskuAkceptacji(btnDodajUczestnika);
            this.Load += UczestnicyUC_Load;
            dgvUczestnicy.CellContentClick += dgvUczestnicy_CellContentClick;
            ConfigureDataGridView();
        }

        private void UczestnicyUC_Load(object sender, EventArgs e)
        {
            LoadUczestnicy();
        }
        // Obsługuje kliknięcie przycisku "Wyszukaj", filtruje uczestników na podstawie tekstu w polu wyszukiwania
        private void btnWyszukajUcz_Click(object sender, EventArgs e)
        {
            LoadUczestnicy(txtSzukajUczestnika.Text);
        }
        // Obsługuje kliknięcie przycisku "Dodaj", otwiera formularz EdytujUczForm
        private void btnDodajUczestnika_Click(object sender, EventArgs e)
        {
            using (var addScope = Program.ServiceProvider.CreateScope())
            {
                var addContext = addScope.ServiceProvider.GetRequiredService<KursyContext>();

                var edytujUczForm = new EdytujUczForm(addContext, null);
                if (edytujUczForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUczestnicy(txtSzukajUczestnika.Text);
                }
            }
        }
        // Pobiera dane o uczestnikach z bazy, filtruje je na podstawie kryterium wyszukiwania i przypisuje do tabeli.
        private void LoadUczestnicy(string searchTerm = null)
        {
            _context.ChangeTracker.Clear();
            IQueryable<Uczestnik> query = _context.Uczestnicy.Include(u => u.Zapisy);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string lowerSearchTerm = searchTerm.ToLower();
                query = query.Where(u => (u.Imie + " " + u.Nazwisko).ToLower().Contains(lowerSearchTerm) ||
                                         u.Email.ToLower().Contains(lowerSearchTerm));
            }

            var uczestnicyList = query
                .OrderBy(u => u.Nazwisko)
                .ThenBy(u => u.Imie)
                .Select(u => new
                {
                    u.Id,
                    u.Imie,
                    u.Nazwisko,
                    u.Email,
                    LiczbaKursow = u.Zapisy.Count,
                    u.NumerTelefonu,
                    u.DataUrodzenia
                })
                .ToList();

            dgvUczestnicy.DataSource = uczestnicyList;
        }

        private void ConfigureDataGridView()
        {
            dgvUczestnicy.AutoGenerateColumns = false;
            dgvUczestnicy.Columns.Clear();

            // Konfiguracja kolumn z responsywnością
            dgvUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdColumn", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "ImieColumn", DataPropertyName = "Imie", HeaderText = "Imię", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 20 });
            dgvUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "NazwiskoColumn", DataPropertyName = "Nazwisko", HeaderText = "Nazwisko", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 25 });
            dgvUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmailColumn", DataPropertyName = "Email", HeaderText = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 35 });
            dgvUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "LiczbaKursowColumn", DataPropertyName = "LiczbaKursow", HeaderText = "Ilość kursów", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "NumerTelefonuColumn", DataPropertyName = "NumerTelefonu", HeaderText = "Telefon", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataUrodzeniaColumn", DataPropertyName = "DataUrodzenia", HeaderText = "Data ur.", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });

            // Konfiguracja przycisków
            var colEdit = new DataGridViewButtonColumn { Name = "EditColumn", HeaderText = "Akcje", Text = "Edytuj", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 60, FlatStyle = FlatStyle.Popup };
            dgvUczestnicy.Columns.Add(colEdit);
            var colDetails = new DataGridViewButtonColumn { Name = "DetailsColumn", HeaderText = "", Text = "Szczegóły", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 75, FlatStyle = FlatStyle.Popup };
            dgvUczestnicy.Columns.Add(colDetails);
            var colDelete = new DataGridViewButtonColumn { Name = "DeleteColumn", HeaderText = "", Text = "Usuń", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 60, FlatStyle = FlatStyle.Popup };
            dgvUczestnicy.Columns.Add(colDelete);

            // Ustawienia ogólne i style (takie same jak w KursyUC)
            dgvUczestnicy.AllowUserToAddRows = false;
            dgvUczestnicy.AllowUserToDeleteRows = false;
            dgvUczestnicy.ReadOnly = true;
            dgvUczestnicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUczestnicy.MultiSelect = false;
            dgvUczestnicy.ColumnHeadersDefaultCellStyle.Font = new Font(dgvUczestnicy.Font, FontStyle.Bold);
            StylAplikacji.UstawStylDataGridView(dgvUczestnicy);
        }
        // Obsługuje kliknięcia w komórkach tabeli. W zależności od klikniętej kolumny ('EditColumn', 'DetailsColumn', 'DeleteColumn')
        private void dgvUczestnicy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int uczestnikId = (int)dgvUczestnicy.Rows[e.RowIndex].Cells["IdColumn"].Value;

            if (dgvUczestnicy.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                using (var editScope = Program.ServiceProvider.CreateScope())
                {
                    var editContext = editScope.ServiceProvider.GetRequiredService<KursyContext>();
                    var uczestnikDoEdycji = editContext.Uczestnicy.FirstOrDefault(u => u.Id == uczestnikId);
                    if (uczestnikDoEdycji == null)
                    {
                        MessageBox.Show("Nie znaleziono uczestnika do edycji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var edytujUczForm = new EdytujUczForm(editContext, uczestnikDoEdycji);
                    if (edytujUczForm.ShowDialog() == DialogResult.OK)
                        LoadUczestnicy(txtSzukajUczestnika.Text);
                }
            }
            else if (dgvUczestnicy.Columns[e.ColumnIndex].Name == "DetailsColumn")
            {
                using (var detailsScope = Program.ServiceProvider.CreateScope())
                {
                    var detailsContext = detailsScope.ServiceProvider.GetRequiredService<KursyContext>();
                    var uczestnikSzczegolyForm = new UczestnikSzczegolyForm(detailsContext, uczestnikId);
                    if (uczestnikSzczegolyForm.ShowDialog() == DialogResult.OK)
                        LoadUczestnicy(txtSzukajUczestnika.Text);
                }
            }
            else if (dgvUczestnicy.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                string pelneImie = $"{dgvUczestnicy.Rows[e.RowIndex].Cells["ImieColumn"].Value} {dgvUczestnicy.Rows[e.RowIndex].Cells["NazwiskoColumn"].Value}";
                if (MessageBox.Show($"Czy na pewno chcesz usunąć uczestnika: '{pelneImie}'? Zostanie on również wypisany ze wszystkich kursów.", "Potwierdzenie Usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (var deleteScope = Program.ServiceProvider.CreateScope())
                    {
                        var deleteContext = deleteScope.ServiceProvider.GetRequiredService<KursyContext>();
                        var uczestnikDoUsuniecia = deleteContext.Uczestnicy.Find(uczestnikId);

                        if (uczestnikDoUsuniecia != null)
                        {
                            var zapisyDoUsuniecia = deleteContext.Zapisy.Where(z => z.UczestnikId == uczestnikId);
                            deleteContext.Zapisy.RemoveRange(zapisyDoUsuniecia);
                            deleteContext.Uczestnicy.Remove(uczestnikDoUsuniecia);
                            deleteContext.SaveChanges();
                            LoadUczestnicy(txtSzukajUczestnika.Text);
                            MessageBox.Show("Uczestnik oraz wszystkie jego zapisy na kursy zostały pomyślnie usunięte.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono uczestnika do usunięcia.", "Błąd Usuwania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LoadUczestnicy(txtSzukajUczestnika.Text);
                        }
                    }
                }
            }
        }
    }
}