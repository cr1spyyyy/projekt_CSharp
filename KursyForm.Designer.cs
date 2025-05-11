namespace projekt_CSharp
{
    partial class KursyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listaLbl = new Label();
            panel1 = new Panel();
            szukajBtn = new Button();
            txtSzukajKursu = new TextBox();
            label1 = new Label();
            dodajBtn = new Button();
            dgvKursy = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKursy).BeginInit();
            SuspendLayout();
            // 
            // listaLbl
            // 
            listaLbl.AutoSize = true;
            listaLbl.Dock = DockStyle.Top;
            listaLbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            listaLbl.Location = new Point(0, 0);
            listaLbl.Margin = new Padding(10, 10, 3, 0);
            listaLbl.Name = "listaLbl";
            listaLbl.Size = new Size(159, 32);
            listaLbl.TabIndex = 0;
            listaLbl.Text = "Lista Kursów";
            // 
            // panel1
            // 
            panel1.Controls.Add(szukajBtn);
            panel1.Controls.Add(txtSzukajKursu);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dodajBtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 64);
            panel1.TabIndex = 1;
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
            dodajBtn.Location = new Point(22, 16);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(137, 31);
            dodajBtn.TabIndex = 0;
            dodajBtn.Text = "Dodaj nowy kurs";
            dodajBtn.UseVisualStyleBackColor = true;
            // 
            // dgvKursy
            // 
            dgvKursy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKursy.Dock = DockStyle.Fill;
            dgvKursy.Location = new Point(0, 96);
            dgvKursy.Name = "dgvKursy";
            dgvKursy.Size = new Size(800, 354);
            dgvKursy.TabIndex = 2;
            dgvKursy.CellContentClick += dgvKursy_CellContentClick;
            // 
            // KursyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvKursy);
            Controls.Add(panel1);
            Controls.Add(listaLbl);
            Name = "KursyForm";
            Text = "Kursy";
            Load += KursyForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKursy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label listaLbl;
        private Panel panel1;
        private Button dodajBtn;
        private Button szukajBtn;
        private TextBox txtSzukajKursu;
        private Label label1;
        private DataGridView dgvKursy;
    }
}