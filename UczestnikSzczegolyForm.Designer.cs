namespace projekt_CSharp
{
    partial class UczestnikSzczegolyForm
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
            gbDaneUczestnika = new GroupBox();
            txtDataUr = new TextBox();
            txtTelefon = new TextBox();
            txtEmail = new TextBox();
            txtNazwisko = new TextBox();
            txtImie = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            gbZapisanyNaKursy = new GroupBox();
            btnEdytujUczestnika = new Button();
            btnZapiszNaKurs = new Button();
            dgvKursyUczestnika = new DataGridView();
            panel1 = new Panel();
            btnZamknij = new Button();
            gbDaneUczestnika.SuspendLayout();
            gbZapisanyNaKursy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKursyUczestnika).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbDaneUczestnika
            // 
            gbDaneUczestnika.Controls.Add(txtDataUr);
            gbDaneUczestnika.Controls.Add(txtTelefon);
            gbDaneUczestnika.Controls.Add(txtEmail);
            gbDaneUczestnika.Controls.Add(txtNazwisko);
            gbDaneUczestnika.Controls.Add(txtImie);
            gbDaneUczestnika.Controls.Add(label5);
            gbDaneUczestnika.Controls.Add(label4);
            gbDaneUczestnika.Controls.Add(label3);
            gbDaneUczestnika.Controls.Add(label2);
            gbDaneUczestnika.Controls.Add(label1);
            gbDaneUczestnika.Dock = DockStyle.Top;
            gbDaneUczestnika.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            gbDaneUczestnika.Location = new Point(0, 0);
            gbDaneUczestnika.Name = "gbDaneUczestnika";
            gbDaneUczestnika.Size = new Size(800, 190);
            gbDaneUczestnika.TabIndex = 0;
            gbDaneUczestnika.TabStop = false;
            gbDaneUczestnika.Text = "Dane uczestnika: ";
            // 
            // txtDataUr
            // 
            txtDataUr.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtDataUr.Location = new Point(125, 153);
            txtDataUr.Name = "txtDataUr";
            txtDataUr.ReadOnly = true;
            txtDataUr.Size = new Size(171, 29);
            txtDataUr.TabIndex = 9;
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtTelefon.Location = new Point(125, 121);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.ReadOnly = true;
            txtTelefon.Size = new Size(171, 29);
            txtTelefon.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtEmail.Location = new Point(125, 88);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(171, 29);
            txtEmail.TabIndex = 7;
            // 
            // txtNazwisko
            // 
            txtNazwisko.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtNazwisko.Location = new Point(125, 56);
            txtNazwisko.Name = "txtNazwisko";
            txtNazwisko.ReadOnly = true;
            txtNazwisko.Size = new Size(171, 29);
            txtNazwisko.TabIndex = 6;
            // 
            // txtImie
            // 
            txtImie.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtImie.Location = new Point(125, 26);
            txtImie.Name = "txtImie";
            txtImie.ReadOnly = true;
            txtImie.Size = new Size(171, 29);
            txtImie.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.Location = new Point(6, 156);
            label5.Name = "label5";
            label5.Size = new Size(73, 21);
            label5.TabIndex = 4;
            label5.Text = "Data ur.:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.Location = new Point(6, 124);
            label4.Name = "label4";
            label4.Size = new Size(71, 21);
            label4.TabIndex = 3;
            label4.Text = "Telefon:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(6, 91);
            label3.Name = "label3";
            label3.Size = new Size(57, 21);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(6, 59);
            label2.Name = "label2";
            label2.Size = new Size(88, 21);
            label2.TabIndex = 1;
            label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(48, 21);
            label1.TabIndex = 0;
            label1.Text = "Imie:";
            // 
            // gbZapisanyNaKursy
            // 
            gbZapisanyNaKursy.Controls.Add(btnEdytujUczestnika);
            gbZapisanyNaKursy.Controls.Add(btnZapiszNaKurs);
            gbZapisanyNaKursy.Controls.Add(dgvKursyUczestnika);
            gbZapisanyNaKursy.Dock = DockStyle.Fill;
            gbZapisanyNaKursy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            gbZapisanyNaKursy.Location = new Point(0, 190);
            gbZapisanyNaKursy.Name = "gbZapisanyNaKursy";
            gbZapisanyNaKursy.Size = new Size(800, 340);
            gbZapisanyNaKursy.TabIndex = 10;
            gbZapisanyNaKursy.TabStop = false;
            gbZapisanyNaKursy.Text = "Zapisany na kursy:";
            // 
            // btnEdytujUczestnika
            // 
            btnEdytujUczestnika.AutoSize = true;
            btnEdytujUczestnika.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnEdytujUczestnika.Location = new Point(173, 185);
            btnEdytujUczestnika.Name = "btnEdytujUczestnika";
            btnEdytujUczestnika.Size = new Size(177, 31);
            btnEdytujUczestnika.TabIndex = 2;
            btnEdytujUczestnika.Text = "Edytuj dane uczestnika";
            btnEdytujUczestnika.UseVisualStyleBackColor = true;
            btnEdytujUczestnika.Click += btnEdytujUczestnika_Click;
            // 
            // btnZapiszNaKurs
            // 
            btnZapiszNaKurs.AutoSize = true;
            btnZapiszNaKurs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnZapiszNaKurs.Location = new Point(6, 185);
            btnZapiszNaKurs.Name = "btnZapiszNaKurs";
            btnZapiszNaKurs.Size = new Size(161, 31);
            btnZapiszNaKurs.TabIndex = 1;
            btnZapiszNaKurs.Text = "Zapisz na nowy kurs";
            btnZapiszNaKurs.UseVisualStyleBackColor = true;
            btnZapiszNaKurs.Click += btnZapiszNaKurs_Click;
            // 
            // dgvKursyUczestnika
            // 
            dgvKursyUczestnika.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKursyUczestnika.Dock = DockStyle.Top;
            dgvKursyUczestnika.Location = new Point(3, 29);
            dgvKursyUczestnika.Name = "dgvKursyUczestnika";
            dgvKursyUczestnika.Size = new Size(794, 150);
            dgvKursyUczestnika.TabIndex = 0;
            dgvKursyUczestnika.CellContentClick += dgvKursyUczestnika_CellContentClick;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(btnZamknij);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 492);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 38);
            panel1.TabIndex = 1;
            // 
            // btnZamknij
            // 
            btnZamknij.AutoSize = true;
            btnZamknij.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnZamknij.Location = new Point(6, 3);
            btnZamknij.Name = "btnZamknij";
            btnZamknij.Size = new Size(82, 31);
            btnZamknij.TabIndex = 3;
            btnZamknij.Text = "Zamknij";
            btnZamknij.UseVisualStyleBackColor = true;
            btnZamknij.Click += btnZamknij_Click;
            // 
            // UczestnikSzczegolyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(panel1);
            Controls.Add(gbZapisanyNaKursy);
            Controls.Add(gbDaneUczestnika);
            MinimumSize = new Size(816, 569);
            Name = "UczestnikSzczegolyForm";
            Text = "UczestnikSzczegolyForm";
            Load += UczestnikSzczegolyForm_Load;
            gbDaneUczestnika.ResumeLayout(false);
            gbDaneUczestnika.PerformLayout();
            gbZapisanyNaKursy.ResumeLayout(false);
            gbZapisanyNaKursy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKursyUczestnika).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbDaneUczestnika;
        private TextBox txtEmail;
        private TextBox txtNazwisko;
        private TextBox txtImie;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTelefon;
        private TextBox txtDataUr;
        private GroupBox gbZapisanyNaKursy;
        private DataGridView dgvKursyUczestnika;
        private Button btnEdytujUczestnika;
        private Button btnZapiszNaKurs;
        private Panel panel1;
        private Button btnZamknij;
    }
}