namespace projekt_CSharp
{
    partial class KursSzczegolyForm
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
            gbInformacjeOKursie = new GroupBox();
            numMaxMiejsca = new NumericUpDown();
            label7 = new Label();
            numCena = new NumericUpDown();
            label6 = new Label();
            txtProwadzacy = new TextBox();
            label5 = new Label();
            label4 = new Label();
            dtpDataZakonczenia = new DateTimePicker();
            dtpDataRozpoczecia = new DateTimePicker();
            label3 = new Label();
            txtOpisKursu = new TextBox();
            label2 = new Label();
            txtNazwaKursu = new TextBox();
            label1 = new Label();
            btnAnuluj = new Button();
            btnEdytujKurs = new Button();
            btnZapiszNaKurs = new Button();
            gbZapisaniUczestnicy = new GroupBox();
            dgvZapisaniNaKurs = new DataGridView();
            panel1 = new Panel();
            btnZapiszZmiany = new Button();
            gbInformacjeOKursie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxMiejsca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCena).BeginInit();
            gbZapisaniUczestnicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvZapisaniNaKurs).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbInformacjeOKursie
            // 
            gbInformacjeOKursie.Controls.Add(numMaxMiejsca);
            gbInformacjeOKursie.Controls.Add(label7);
            gbInformacjeOKursie.Controls.Add(numCena);
            gbInformacjeOKursie.Controls.Add(label6);
            gbInformacjeOKursie.Controls.Add(txtProwadzacy);
            gbInformacjeOKursie.Controls.Add(label5);
            gbInformacjeOKursie.Controls.Add(label4);
            gbInformacjeOKursie.Controls.Add(dtpDataZakonczenia);
            gbInformacjeOKursie.Controls.Add(dtpDataRozpoczecia);
            gbInformacjeOKursie.Controls.Add(label3);
            gbInformacjeOKursie.Controls.Add(txtOpisKursu);
            gbInformacjeOKursie.Controls.Add(label2);
            gbInformacjeOKursie.Controls.Add(txtNazwaKursu);
            gbInformacjeOKursie.Controls.Add(label1);
            gbInformacjeOKursie.Dock = DockStyle.Top;
            gbInformacjeOKursie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            gbInformacjeOKursie.Location = new Point(0, 0);
            gbInformacjeOKursie.Name = "gbInformacjeOKursie";
            gbInformacjeOKursie.Size = new Size(800, 281);
            gbInformacjeOKursie.TabIndex = 0;
            gbInformacjeOKursie.TabStop = false;
            gbInformacjeOKursie.Text = "Informacje o kursie:";
            // 
            // numMaxMiejsca
            // 
            numMaxMiejsca.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            numMaxMiejsca.Location = new Point(155, 243);
            numMaxMiejsca.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMaxMiejsca.Name = "numMaxMiejsca";
            numMaxMiejsca.Size = new Size(118, 27);
            numMaxMiejsca.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label7.Location = new Point(12, 243);
            label7.Name = "label7";
            label7.Size = new Size(113, 21);
            label7.TabIndex = 12;
            label7.Text = "Max. miejsca:";
            // 
            // numCena
            // 
            numCena.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            numCena.Location = new Point(155, 209);
            numCena.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numCena.Name = "numCena";
            numCena.Size = new Size(118, 27);
            numCena.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(12, 210);
            label6.Name = "label6";
            label6.Size = new Size(52, 21);
            label6.TabIndex = 10;
            label6.Text = "Cena:";
            // 
            // txtProwadzacy
            // 
            txtProwadzacy.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtProwadzacy.Location = new Point(155, 178);
            txtProwadzacy.Name = "txtProwadzacy";
            txtProwadzacy.Size = new Size(280, 27);
            txtProwadzacy.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.Location = new Point(12, 180);
            label5.Name = "label5";
            label5.Size = new Size(106, 21);
            label5.TabIndex = 8;
            label5.Text = "Prowadzący:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.Location = new Point(12, 149);
            label4.Name = "label4";
            label4.Size = new Size(85, 21);
            label4.TabIndex = 7;
            label4.Text = "Data zak.:";
            // 
            // dtpDataZakonczenia
            // 
            dtpDataZakonczenia.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dtpDataZakonczenia.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dtpDataZakonczenia.ImeMode = ImeMode.NoControl;
            dtpDataZakonczenia.Location = new Point(155, 149);
            dtpDataZakonczenia.MinDate = new DateTime(2025, 5, 14, 0, 0, 0, 0);
            dtpDataZakonczenia.Name = "dtpDataZakonczenia";
            dtpDataZakonczenia.Size = new Size(280, 27);
            dtpDataZakonczenia.TabIndex = 6;
            // 
            // dtpDataRozpoczecia
            // 
            dtpDataRozpoczecia.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dtpDataRozpoczecia.Location = new Point(155, 116);
            dtpDataRozpoczecia.MinDate = new DateTime(2025, 5, 14, 0, 0, 0, 0);
            dtpDataRozpoczecia.Name = "dtpDataRozpoczecia";
            dtpDataRozpoczecia.Size = new Size(280, 27);
            dtpDataRozpoczecia.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(12, 118);
            label3.Name = "label3";
            label3.Size = new Size(92, 21);
            label3.TabIndex = 4;
            label3.Text = "Data rozp.:";
            // 
            // txtOpisKursu
            // 
            txtOpisKursu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtOpisKursu.Location = new Point(155, 61);
            txtOpisKursu.Multiline = true;
            txtOpisKursu.Name = "txtOpisKursu";
            txtOpisKursu.Size = new Size(280, 49);
            txtOpisKursu.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 2;
            label2.Text = "Opis:";
            // 
            // txtNazwaKursu
            // 
            txtNazwaKursu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtNazwaKursu.Location = new Point(155, 26);
            txtNazwaKursu.Name = "txtNazwaKursu";
            txtNazwaKursu.Size = new Size(280, 29);
            txtNazwaKursu.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(116, 21);
            label1.TabIndex = 0;
            label1.Text = "Nazwa kursu: ";
            // 
            // btnAnuluj
            // 
            btnAnuluj.AutoSize = true;
            btnAnuluj.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnAnuluj.Location = new Point(6, 3);
            btnAnuluj.Name = "btnAnuluj";
            btnAnuluj.Size = new Size(75, 30);
            btnAnuluj.TabIndex = 1;
            btnAnuluj.Text = "Anuluj";
            btnAnuluj.UseVisualStyleBackColor = true;
            btnAnuluj.Click += btnAnuluj_Click;
            // 
            // btnEdytujKurs
            // 
            btnEdytujKurs.AutoSize = true;
            btnEdytujKurs.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnEdytujKurs.Location = new Point(204, 163);
            btnEdytujKurs.Name = "btnEdytujKurs";
            btnEdytujKurs.Size = new Size(190, 30);
            btnEdytujKurs.TabIndex = 2;
            btnEdytujKurs.Text = "Edytuj informacje o kursie";
            btnEdytujKurs.UseVisualStyleBackColor = true;
            btnEdytujKurs.Click += btnEdytujKurs_Click;
            // 
            // btnZapiszNaKurs
            // 
            btnZapiszNaKurs.AutoSize = true;
            btnZapiszNaKurs.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnZapiszNaKurs.Location = new Point(6, 163);
            btnZapiszNaKurs.Name = "btnZapiszNaKurs";
            btnZapiszNaKurs.Size = new Size(192, 30);
            btnZapiszNaKurs.TabIndex = 0;
            btnZapiszNaKurs.Text = "Zapisz nowego uczestnika";
            btnZapiszNaKurs.UseVisualStyleBackColor = true;
            btnZapiszNaKurs.Click += btnZapiszNaKurs_Click;
            // 
            // gbZapisaniUczestnicy
            // 
            gbZapisaniUczestnicy.Controls.Add(dgvZapisaniNaKurs);
            gbZapisaniUczestnicy.Controls.Add(btnEdytujKurs);
            gbZapisaniUczestnicy.Controls.Add(btnZapiszNaKurs);
            gbZapisaniUczestnicy.Dock = DockStyle.Fill;
            gbZapisaniUczestnicy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            gbZapisaniUczestnicy.Location = new Point(0, 281);
            gbZapisaniUczestnicy.Name = "gbZapisaniUczestnicy";
            gbZapisaniUczestnicy.Size = new Size(800, 249);
            gbZapisaniUczestnicy.TabIndex = 14;
            gbZapisaniUczestnicy.TabStop = false;
            gbZapisaniUczestnicy.Text = "Zapisani uczestnicy";
            // 
            // dgvZapisaniNaKurs
            // 
            dgvZapisaniNaKurs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvZapisaniNaKurs.Dock = DockStyle.Top;
            dgvZapisaniNaKurs.Location = new Point(3, 29);
            dgvZapisaniNaKurs.Name = "dgvZapisaniNaKurs";
            dgvZapisaniNaKurs.Size = new Size(794, 128);
            dgvZapisaniNaKurs.TabIndex = 1;
            dgvZapisaniNaKurs.CellContentClick += dgvZapisaniNaKurs_CellContentClick;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(btnZapiszZmiany);
            panel1.Controls.Add(btnAnuluj);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 493);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 37);
            panel1.TabIndex = 2;
            // 
            // btnZapiszZmiany
            // 
            btnZapiszZmiany.AutoSize = true;
            btnZapiszZmiany.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnZapiszZmiany.Location = new Point(87, 3);
            btnZapiszZmiany.Name = "btnZapiszZmiany";
            btnZapiszZmiany.Size = new Size(127, 30);
            btnZapiszZmiany.TabIndex = 3;
            btnZapiszZmiany.Text = "Zapisz zmiany";
            btnZapiszZmiany.UseVisualStyleBackColor = true;
            // 
            // KursSzczegolyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(panel1);
            Controls.Add(gbZapisaniUczestnicy);
            Controls.Add(gbInformacjeOKursie);
            MinimumSize = new Size(816, 569);
            Name = "KursSzczegolyForm";
            Text = "Szczegóły kursu: ";
            Load += KursSzczegolyForm_Load;
            gbInformacjeOKursie.ResumeLayout(false);
            gbInformacjeOKursie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxMiejsca).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCena).EndInit();
            gbZapisaniUczestnicy.ResumeLayout(false);
            gbZapisaniUczestnicy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvZapisaniNaKurs).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void BtnEdytujKurs_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private GroupBox gbInformacjeOKursie;
        private Label label1;
        private Label label4;
        private DateTimePicker dtpDataZakonczenia;
        private DateTimePicker dtpDataRozpoczecia;
        private Label label3;
        private TextBox txtOpisKursu;
        private Label label2;
        private TextBox txtNazwaKursu;
        private Label label7;
        private NumericUpDown numCena;
        private Label label6;
        private TextBox txtProwadzacy;
        private Label label5;
        private NumericUpDown numMaxMiejsca;
        private GroupBox gbZapisaniUczestnicy;
        private Button btnZapiszNaKurs;
        private DataGridView dgvZapisaniNaKurs;
        private Button btnAnuluj;
        private Button btnEdytujKurs;
        private Panel panel1;
        private Button btnZapiszZmiany;
    }
}