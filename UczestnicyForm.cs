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
using projekt_CSharp.Data;
using projekt_CSharp.Models;

namespace projekt_CSharp
{
    public partial class UczestnicyForm : Form
    {
        private readonly KursyContext _context;

        public UczestnicyForm(KursyContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void UczestnicyForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUczestnicy();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Krytyczny błąd podczas ładowania uczestników: {ex.Message}\n{ex.InnerException?.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadUczestnicy(string searchTerm = null)
        {
            try
            {
                IQueryable<Uczestnik> query = _context.Uczestnicy.Include(u => u.Zapisy);

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    string lowerSearchTerm = searchTerm.ToLower();
                    query = query.Where(u => (u.Imie + " " + u.Nazwisko).ToLower().Contains(lowerSearchTerm) ||
                                             u.Email.ToLower().Contains(lowerSearchTerm));
                }

                var uczestnicyList = query.OrderBy(u => u.Nazwisko).ThenBy(u => u.Imie).ToList();

                ConfigureDataGridView();

                if (uczestnicyList.Any())
                {
                    dvgUczestnicy.DataSource = uczestnicyList;
                }
                else
                {
                    dvgUczestnicy.DataSource = null;
                    string message = string.IsNullOrWhiteSpace(searchTerm)
                        ? "Brak uczestników w bazie danych."
                        : $"Nie znaleziono uczestników dla frazy: '{searchTerm}'.";
                    MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych uczestników: {ex.Message}\n{ex.InnerException?.Message}", "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureDataGridView()
        {
            dvgUczestnicy.AutoGenerateColumns = false;
            dvgUczestnicy.Columns.Clear();

            dvgUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdColumn", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dvgUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "ImieColumn", DataPropertyName = "Imie", HeaderText = "Imię", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dvgUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "NazwiskoColumn", DataPropertyName = "Nazwisko", HeaderText = "Nazwisko", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dvgUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmailColumn", DataPropertyName = "Email", HeaderText = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dvgUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "NumerTelefonuColumn", DataPropertyName = "NumerTelefonu", HeaderText = "Telefon", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dvgUczestnicy.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataUrodzeniaColumn", DataPropertyName = "DataUrodzenia", HeaderText = "Data Ur.", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });



            var colEdit = new DataGridViewButtonColumn { Name = "EditColumn", HeaderText = "Akcje", Text = "Edytuj", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 60, FlatStyle = FlatStyle.Popup };
            dvgUczestnicy.Columns.Add(colEdit);
            var colDelete = new DataGridViewButtonColumn { Name = "DeleteColumn", HeaderText = "", Text = "Usuń", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 60, FlatStyle = FlatStyle.Popup };
            dvgUczestnicy.Columns.Add(colDelete);

            dvgUczestnicy.AllowUserToAddRows = false;
            dvgUczestnicy.AllowUserToDeleteRows = false;
            dvgUczestnicy.ReadOnly = true;
            dvgUczestnicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgUczestnicy.MultiSelect = false;
            dvgUczestnicy.ColumnHeadersDefaultCellStyle.Font = new Font(dvgUczestnicy.Font, FontStyle.Bold);
        }
        private void btnWyszukajUcz_Click(object sender, EventArgs e)
        {
            LoadUczestnicy(txtSzukajUczestnika.Text);
        }

        private void btnDodajUczestnika_Click(object sender, EventArgs e)
        {
            var edytujUczForm = new EdytujUczForm(_context, null); // null dla nowego uczestnika
            if (edytujUczForm.ShowDialog() == DialogResult.OK)
            {
                LoadUczestnicy();
            }
        }

        private void dvgUczestnicy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Uczestnik wybranyUczestnik = dvgUczestnicy.Rows[e.RowIndex].DataBoundItem as Uczestnik;
            if (wybranyUczestnik == null) return;

            int uczestnikId = wybranyUczestnik.Id;

            if (dvgUczestnicy.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                var uczestnikDoEdycjiZBazy = _context.Uczestnicy.AsNoTracking().FirstOrDefault(u => u.Id == uczestnikId);
                if (uczestnikDoEdycjiZBazy == null)
                {
                    MessageBox.Show("Nie znaleziono uczestnika do edycji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var edytujUczForm = new EdytujUczForm(_context, uczestnikDoEdycjiZBazy);
                if (edytujUczForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUczestnicy();
                }
            }
            else if (dvgUczestnicy.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                if (MessageBox.Show($"Czy na pewno chcesz usunąć uczestnika: '{wybranyUczestnik.PelneImie}'?", "Potwierdzenie Usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        bool czySaZapisy = _context.Zapisy.Any(z => z.UczestnikId == uczestnikId);
                        if (czySaZapisy)
                        {
                            MessageBox.Show("Nie można usunąć uczestnika, ponieważ jest zapisany na kurs(y). Najpierw usuń powiązane zapisy.", "Błąd Usuwania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var uczestnikDoUsuniecia = _context.Uczestnicy.Find(uczestnikId);
                        if (uczestnikDoUsuniecia != null)
                        {
                            _context.Uczestnicy.Remove(uczestnikDoUsuniecia);
                            _context.SaveChanges();
                            LoadUczestnicy();
                            MessageBox.Show("Uczestnik został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd podczas usuwania uczestnika: {ex.Message}", "Błąd Usuwania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
