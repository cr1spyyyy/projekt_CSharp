using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projekt_CSharp.Data;

namespace projekt_CSharp
{
    public partial class MenuForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KursyContext _context;
        // konstruktor MenuForm
        public MenuForm(IServiceProvider serviceProvider, KursyContext context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
            InitializeComponent();
            // Stylizacja
            this.BackColor = StylAplikacji.Tlo;
            panelMain.BackColor = StylAplikacji.Tlo;
            panelLeft.BackColor = StylAplikacji.Panel;

            StylAplikacji.UstawStylPrzyciskuAkceptacji(kursyBtn);
            StylAplikacji.UstawStylPrzyciskuAkceptacji(uczestnicyBtn);
            var uczestnicyUC = new UczestnicyUC(_context) { Dock = DockStyle.Fill };
            panelMain.Controls.Add(uczestnicyUC);
        }
        // Obs³uguje klikniêcie przycisku "Kursy". Czyœci g³ówny panel i wczytuje do niego kontrolkê KursyUC
        private void kursyBtn_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var kursyUC = new KursyUC(_context) { Dock = DockStyle.Fill };
            panelMain.Controls.Add(kursyUC);
        }
        // Obs³uguje klikniêcie przycisku "Uczestnicy". Czyœci g³ówny panel i wczytuje do niego kontrolkê UczestnicyUC
        private void uczestnicyBtn_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var uczestnicyUC = new UczestnicyUC(_context) { Dock = DockStyle.Fill };
            panelMain.Controls.Add(uczestnicyUC);
        }


    }
}
