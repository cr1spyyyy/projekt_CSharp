namespace projekt_CSharp
{
    partial class EdytujKursForm
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
            label1 = new Label();
            txtNazwaKursu = new TextBox();
            label2 = new Label();
            txtOpisKursu = new TextBox();
            label3 = new Label();
            dtpDataRozpoczecia = new DateTimePicker();
            label4 = new Label();
            dtpDataZakonczenia = new DateTimePicker();
            label5 = new Label();
            numMaxUczestnikow = new NumericUpDown();
            label6 = new Label();
            txtProwadzacy = new TextBox();
            label7 = new Label();
            numCena = new NumericUpDown();
            btnZapiszKurs = new Button();
            btnAnuluj = new Button();
            ((System.ComponentModel.ISupportInitialize)numMaxUczestnikow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCena).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(124, 25);
            label1.TabIndex = 0;
            label1.Text = "Nazwa kursu:";
            // 
            // txtNazwaKursu
            // 
            txtNazwaKursu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtNazwaKursu.Location = new Point(152, 9);
            txtNazwaKursu.Name = "txtNazwaKursu";
            txtNazwaKursu.Size = new Size(424, 29);
            txtNazwaKursu.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 2;
            label2.Text = "Opis:";
            // 
            // txtOpisKursu
            // 
            txtOpisKursu.Location = new Point(152, 49);
            txtOpisKursu.Multiline = true;
            txtOpisKursu.Name = "txtOpisKursu";
            txtOpisKursu.Size = new Size(424, 48);
            txtOpisKursu.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(12, 111);
            label3.Name = "label3";
            label3.Size = new Size(102, 25);
            label3.TabIndex = 4;
            label3.Text = "Data rozp.:";
            // 
            // dtpDataRozpoczecia
            // 
            dtpDataRozpoczecia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtpDataRozpoczecia.Location = new Point(152, 113);
            dtpDataRozpoczecia.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            dtpDataRozpoczecia.MinDate = new DateTime(2025, 5, 14, 0, 0, 0, 0);
            dtpDataRozpoczecia.Name = "dtpDataRozpoczecia";
            dtpDataRozpoczecia.Size = new Size(285, 29);
            dtpDataRozpoczecia.TabIndex = 5;
            dtpDataRozpoczecia.Value = new DateTime(2025, 6, 5, 22, 58, 48, 0);
            dtpDataRozpoczecia.ValueChanged += dtpDataRozpoczecia_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(12, 162);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 6;
            label4.Text = "Data zak.:";
            // 
            // dtpDataZakonczenia
            // 
            dtpDataZakonczenia.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtpDataZakonczenia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtpDataZakonczenia.Location = new Point(152, 164);
            dtpDataZakonczenia.MaxDate = new DateTime(2040, 12, 31, 0, 0, 0, 0);
            dtpDataZakonczenia.MinDate = new DateTime(2025, 5, 14, 0, 0, 0, 0);
            dtpDataZakonczenia.Name = "dtpDataZakonczenia";
            dtpDataZakonczenia.Size = new Size(285, 29);
            dtpDataZakonczenia.TabIndex = 7;
            dtpDataZakonczenia.Value = new DateTime(2025, 6, 5, 22, 59, 36, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(12, 210);
            label5.Name = "label5";
            label5.Size = new Size(120, 25);
            label5.TabIndex = 8;
            label5.Text = "Max. Uczest.:";
            // 
            // numMaxUczestnikow
            // 
            numMaxUczestnikow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            numMaxUczestnikow.Location = new Point(152, 210);
            numMaxUczestnikow.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMaxUczestnikow.Name = "numMaxUczestnikow";
            numMaxUczestnikow.Size = new Size(120, 29);
            numMaxUczestnikow.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(12, 259);
            label6.Name = "label6";
            label6.Size = new Size(117, 25);
            label6.TabIndex = 10;
            label6.Text = "Prowadzący:";
            // 
            // txtProwadzacy
            // 
            txtProwadzacy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtProwadzacy.Location = new Point(152, 259);
            txtProwadzacy.Name = "txtProwadzacy";
            txtProwadzacy.Size = new Size(424, 29);
            txtProwadzacy.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label7.Location = new Point(12, 309);
            label7.Name = "label7";
            label7.Size = new Size(110, 25);
            label7.TabIndex = 12;
            label7.Text = "Cena (PLN):";
            // 
            // numCena
            // 
            numCena.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            numCena.Location = new Point(152, 310);
            numCena.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCena.Name = "numCena";
            numCena.Size = new Size(120, 29);
            numCena.TabIndex = 13;
            numCena.ValueChanged += numCena_ValueChanged;
            // 
            // btnZapiszKurs
            // 
            btnZapiszKurs.AutoSize = true;
            btnZapiszKurs.DialogResult = DialogResult.OK;
            btnZapiszKurs.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnZapiszKurs.Location = new Point(152, 403);
            btnZapiszKurs.Name = "btnZapiszKurs";
            btnZapiszKurs.Size = new Size(101, 35);
            btnZapiszKurs.TabIndex = 14;
            btnZapiszKurs.Text = "Zapisz";
            btnZapiszKurs.UseVisualStyleBackColor = true;
            btnZapiszKurs.Click += btnZapiszKurs_Click;
            // 
            // btnAnuluj
            // 
            btnAnuluj.AutoSize = true;
            btnAnuluj.DialogResult = DialogResult.Cancel;
            btnAnuluj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnAnuluj.Location = new Point(488, 403);
            btnAnuluj.Name = "btnAnuluj";
            btnAnuluj.Size = new Size(88, 35);
            btnAnuluj.TabIndex = 15;
            btnAnuluj.Text = "Anuluj";
            btnAnuluj.UseVisualStyleBackColor = true;
            btnAnuluj.Click += btnAnuluj_Click;
            // 
            // EdytujKursForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 450);
            Controls.Add(btnAnuluj);
            Controls.Add(btnZapiszKurs);
            Controls.Add(numCena);
            Controls.Add(label7);
            Controls.Add(txtProwadzacy);
            Controls.Add(label6);
            Controls.Add(numMaxUczestnikow);
            Controls.Add(label5);
            Controls.Add(dtpDataZakonczenia);
            Controls.Add(label4);
            Controls.Add(dtpDataRozpoczecia);
            Controls.Add(label3);
            Controls.Add(txtOpisKursu);
            Controls.Add(label2);
            Controls.Add(txtNazwaKursu);
            Controls.Add(label1);
            MinimumSize = new Size(604, 489);
            Name = "EdytujKursForm";
            Text = "Edytuj Kurs";
            ((System.ComponentModel.ISupportInitialize)numMaxUczestnikow).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCena).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private TextBox txtNazwaKursu;
        private Label label2;
        private TextBox txtOpisKursu;
        private Label label3;
        private DateTimePicker dtpDataRozpoczecia;
        private Label label4;
        private DateTimePicker dtpDataZakonczenia;
        private Label label5;
        private NumericUpDown numMaxUczestnikow;
        private Label label6;
        private TextBox txtProwadzacy;
        private Label label7;
        private NumericUpDown numCena;
        private Button btnZapiszKurs;
        private Button btnAnuluj;
    }
}