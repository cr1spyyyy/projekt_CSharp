using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using projekt_CSharp.Models;
using projekt_CSharp.Data;
using Microsoft.Extensions.DependencyInjection;
namespace projekt_CSharp
{
    public partial class KursyForm : Form
    {
        private readonly KursyContext _context;

        public KursyForm(KursyContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void KursyForm_Load(object sender, EventArgs e)
        {
            LoadKursy();
        }

        private void LoadKursy(string searchTerm = null)
        {
            try
            {
                IQueryable<Kurs> query = _context.Kursy
                                                 .Include(k => k.Zapisy);

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    string lowerSearchTerm = searchTerm.ToLower();
                    query = query.Where(k => k.Nazwa.ToLower().Contains(lowerSearchTerm) ||
                                             (k.Prowadzacy != null && k.Prowadzacy.ToLower().Contains(lowerSearchTerm)));
                }

                var kursyList = query.OrderBy(k => k.Nazwa).ToList();

                ConfigureDataGridView();

                if (kursyList.Any())
                {
                    dgvKursy.DataSource = kursyList;
                }
                else
                {
                    dgvKursy.DataSource = null;
                    string message = string.IsNullOrWhiteSpace(searchTerm)
                        ? "Brak kursów w bazie danych."
                        : $"Nie znaleziono kursów dla frazy: '{searchTerm}'.";
                    MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania danych kursów: {ex.Message}\n\nSzczegóły: {ex.InnerException?.Message}", "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvKursy.AutoGenerateColumns = false;
            dgvKursy.Columns.Clear();

            dgvKursy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdColumn",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false
            });
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
                DataPropertyName = "InfoOMiejscach",
                HeaderText = "Miejsca",
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
            var colDelete = new DataGridViewButtonColumn { Name = "DeleteColumn", HeaderText = "", Text = "Usuń", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, MinimumWidth = 60, FlatStyle = FlatStyle.Popup };
            dgvKursy.Columns.Add(colDelete);

            dgvKursy.AllowUserToAddRows = false;
            dgvKursy.AllowUserToDeleteRows = false;
            dgvKursy.ReadOnly = true;
            dgvKursy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKursy.MultiSelect = false;
            dgvKursy.ColumnHeadersDefaultCellStyle.Font = new Font(dgvKursy.Font, FontStyle.Bold);
            dgvKursy.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        }


        private void dgvKursy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int kursId = (int)dgvKursy.Rows[e.RowIndex].Cells["IdColumn"].Value;

            if (dgvKursy.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                var kursDoEdycjiZBazy = _context.Kursy.AsNoTracking().FirstOrDefault(k => k.Id == kursId);
                if (kursDoEdycjiZBazy == null)
                {
                    MessageBox.Show("Nie znaleziono kursu do edycji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var edytujKursForm = new EdytujKursForm(_context, kursDoEdycjiZBazy);
                if (edytujKursForm.ShowDialog() == DialogResult.OK)
                {
                    LoadKursy();
                }
            }
            else if (dgvKursy.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                string nazwaKursu = dgvKursy.Rows[e.RowIndex].Cells["NazwaColumn"].Value.ToString();
                if (MessageBox.Show($"Czy na pewno chcesz usunąć kurs: '{nazwaKursu}'?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var kursDoUsuniecia = _context.Kursy.Include(k => k.Zapisy).FirstOrDefault(k => k.Id == kursId);
                    if (kursDoUsuniecia != null)
                    {
                        if (kursDoUsuniecia.Zapisy.Any())
                        {
                            MessageBox.Show("Nie można usunąć kursu, ponieważ są do niego zapisani uczestnicy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _context.Kursy.Remove(kursDoUsuniecia);
                        _context.SaveChanges();
                        LoadKursy();
                    }
                }
            }
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<EdytujKursForm>())
            {
                var edytujKursForm = new EdytujKursForm(_context, null);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadKursy();
                }
            }
        }

        private void szukajBtn_Click(object sender, EventArgs e)
        {
            LoadKursy(txtSzukajKursu.Text);
        }

        private void txtSzukajKursu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
