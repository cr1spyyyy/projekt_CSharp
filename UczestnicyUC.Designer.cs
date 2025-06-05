namespace projekt_CSharp
{
    partial class UczestnicyUC
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            btnWyszukajUcz = new Button();
            txtSzukajUczestnika = new TextBox();
            label1 = new Label();
            btnDodajUczestnika = new Button();
            dgvUczestnicy = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUczestnicy).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnWyszukajUcz);
            panelTop.Controls.Add(txtSzukajUczestnika);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(btnDodajUczestnika);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(861, 65);
            panelTop.TabIndex = 2;
            // 
            // btnWyszukajUcz
            // 
            btnWyszukajUcz.AutoSize = true;
            btnWyszukajUcz.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnWyszukajUcz.Location = new Point(690, 19);
            btnWyszukajUcz.Name = "btnWyszukajUcz";
            btnWyszukajUcz.Size = new Size(86, 31);
            btnWyszukajUcz.TabIndex = 3;
            btnWyszukajUcz.Text = "Wyszukaj";
            btnWyszukajUcz.UseVisualStyleBackColor = true;
            btnWyszukajUcz.Click += btnWyszukajUcz_Click;
            // 
            // txtSzukajUczestnika
            // 
            txtSzukajUczestnika.Location = new Point(385, 24);
            txtSzukajUczestnika.Name = "txtSzukajUczestnika";
            txtSzukajUczestnika.Size = new Size(285, 23);
            txtSzukajUczestnika.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(321, 24);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 1;
            label1.Text = "Szukaj:";
            // 
            // btnDodajUczestnika
            // 
            btnDodajUczestnika.AutoSize = true;
            btnDodajUczestnika.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnDodajUczestnika.Location = new Point(12, 17);
            btnDodajUczestnika.Name = "btnDodajUczestnika";
            btnDodajUczestnika.Size = new Size(197, 31);
            btnDodajUczestnika.TabIndex = 0;
            btnDodajUczestnika.Text = "Dodaj nowego uczestnika";
            btnDodajUczestnika.UseVisualStyleBackColor = true;
            btnDodajUczestnika.Click += btnDodajUczestnika_Click;
            // 
            // dgvUczestnicy
            // 
            dgvUczestnicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUczestnicy.Dock = DockStyle.Fill;
            dgvUczestnicy.Location = new Point(0, 65);
            dgvUczestnicy.Name = "dgvUczestnicy";
            dgvUczestnicy.Size = new Size(861, 366);
            dgvUczestnicy.TabIndex = 3;
            // 
            // UczestnicyUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvUczestnicy);
            Controls.Add(panelTop);
            Name = "UczestnicyUC";
            Size = new Size(861, 431);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUczestnicy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnWyszukajUcz;
        private TextBox txtSzukajUczestnika;
        private Label label1;
        private Button btnDodajUczestnika;
        private DataGridView dgvUczestnicy;
    }
}
