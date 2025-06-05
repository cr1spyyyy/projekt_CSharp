using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace projekt_CSharp
{
    public static class StylAplikacji
    {
        // Kolory
        public static readonly Color Tlo = ColorTranslator.FromHtml("#E0FBFC");
        public static readonly Color Panel = ColorTranslator.FromHtml("#98C1D9");
        public static readonly Color Tekst = ColorTranslator.FromHtml("#293241");
        public static readonly Color Akceptacja = ColorTranslator.FromHtml("#3D5A80");
        public static readonly Color Anulowanie = ColorTranslator.FromHtml("#EE6C4D");
        public static readonly Color TekstNaPrzycisku = ColorTranslator.FromHtml("#E0FBFC");

        // Metody pomocnicze do stylizacji
        public static void UstawStylPrzyciskuAkceptacji(Button btn)
        {
            btn.BackColor = Akceptacja;
            btn.ForeColor = TekstNaPrzycisku;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void UstawStylPrzyciskuAnulowania(Button btn)
        {
            btn.BackColor = Anulowanie;
            btn.ForeColor = TekstNaPrzycisku;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void UstawStylDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Tlo;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ForeColor = Tekst;

            // Nagłówki
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Akceptacja;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TekstNaPrzycisku;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;

            // Wiersze
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Panel;
            dgv.RowsDefaultCellStyle.BackColor = Tlo;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Akceptacja;
            dgv.RowsDefaultCellStyle.SelectionForeColor = TekstNaPrzycisku;
        }
    }
}
