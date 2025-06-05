namespace projekt_CSharp
{
    partial class KursyUC
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
            szukajBtn = new Button();
            txtSzukajKursu = new TextBox();
            label1 = new Label();
            dodajBtn = new Button();
            dgvKursy = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKursy).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(szukajBtn);
            panelTop.Controls.Add(txtSzukajKursu);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(dodajBtn);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(815, 64);
            panelTop.TabIndex = 2;
            // 
            // szukajBtn
            // 
            szukajBtn.AutoSize = true;
            szukajBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            szukajBtn.Location = new Point(702, 18);
            szukajBtn.Name = "szukajBtn";
            szukajBtn.Size = new Size(86, 31);
            szukajBtn.TabIndex = 3;
            szukajBtn.Text = "Wyszukaj";
            szukajBtn.UseVisualStyleBackColor = true;
            szukajBtn.Click += btnSzukaj_Click;
            // 
            // txtSzukajKursu
            // 
            txtSzukajKursu.Location = new Point(343, 21);
            txtSzukajKursu.Name = "txtSzukajKursu";
            txtSzukajKursu.Size = new Size(343, 23);
            txtSzukajKursu.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(279, 21);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 1;
            label1.Text = "Szukaj:";
            // 
            // dodajBtn
            // 
            dodajBtn.AutoSize = true;
            dodajBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dodajBtn.Location = new Point(22, 18);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(163, 31);
            dodajBtn.TabIndex = 0;
            dodajBtn.Text = "Dodaj nowy kurs";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += btnDodaj_Click;
            // 
            // dgvKursy
            // 
            dgvKursy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKursy.Dock = DockStyle.Fill;
            dgvKursy.Location = new Point(0, 64);
            dgvKursy.Name = "dgvKursy";
            dgvKursy.Size = new Size(815, 370);
            dgvKursy.TabIndex = 3;
            dgvKursy.CellContentClick += dgvKursy_CellContentClick;
            // 
            // KursyUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvKursy);
            Controls.Add(panelTop);
            Name = "KursyUC";
            Size = new Size(815, 434);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKursy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button szukajBtn;
        private TextBox txtSzukajKursu;
        private Label label1;
        private Button dodajBtn;
        private DataGridView dgvKursy;
    }
}
