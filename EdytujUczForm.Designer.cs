namespace projekt_CSharp
{
    partial class EdytujUczForm
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
            txtImie = new TextBox();
            label2 = new Label();
            txtNazwisko = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtNumerTelefonu = new TextBox();
            label5 = new Label();
            dtpDataUrodzenia = new DateTimePicker();
            btnZapiszUczestnika = new Button();
            btnAnulujZapUcz = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(34, 25);
            label1.Name = "label1";
            label1.Size = new Size(65, 32);
            label1.TabIndex = 0;
            label1.Text = "Imie:";
            label1.Click += label1_Click;
            // 
            // txtImie
            // 
            txtImie.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtImie.Location = new Point(172, 25);
            txtImie.Name = "txtImie";
            txtImie.Size = new Size(300, 35);
            txtImie.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(34, 83);
            label2.Name = "label2";
            label2.Size = new Size(119, 32);
            label2.TabIndex = 2;
            label2.Text = "Nazwisko:";
            // 
            // txtNazwisko
            // 
            txtNazwisko.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtNazwisko.Location = new Point(172, 83);
            txtNazwisko.Name = "txtNazwisko";
            txtNazwisko.Size = new Size(300, 35);
            txtNazwisko.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(34, 151);
            label3.Name = "label3";
            label3.Size = new Size(86, 32);
            label3.TabIndex = 4;
            label3.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtEmail.Location = new Point(172, 148);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 35);
            txtEmail.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(34, 214);
            label4.Name = "label4";
            label4.Size = new Size(79, 32);
            label4.TabIndex = 6;
            label4.Text = "Nr tel:";
            // 
            // txtNumerTelefonu
            // 
            txtNumerTelefonu.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtNumerTelefonu.Location = new Point(172, 213);
            txtNumerTelefonu.Name = "txtNumerTelefonu";
            txtNumerTelefonu.Size = new Size(300, 35);
            txtNumerTelefonu.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(34, 279);
            label5.Name = "label5";
            label5.Size = new Size(102, 32);
            label5.TabIndex = 8;
            label5.Text = "Data ur.:";
            // 
            // dtpDataUrodzenia
            // 
            dtpDataUrodzenia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtpDataUrodzenia.Location = new Point(172, 282);
            dtpDataUrodzenia.Name = "dtpDataUrodzenia";
            dtpDataUrodzenia.Size = new Size(300, 29);
            dtpDataUrodzenia.TabIndex = 9;
            // 
            // btnZapiszUczestnika
            // 
            btnZapiszUczestnika.AutoSize = true;
            btnZapiszUczestnika.DialogResult = DialogResult.OK;
            btnZapiszUczestnika.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnZapiszUczestnika.Location = new Point(172, 399);
            btnZapiszUczestnika.Name = "btnZapiszUczestnika";
            btnZapiszUczestnika.Size = new Size(113, 31);
            btnZapiszUczestnika.TabIndex = 10;
            btnZapiszUczestnika.Text = "Zapisz";
            btnZapiszUczestnika.UseVisualStyleBackColor = true;
            btnZapiszUczestnika.Click += btnZapiszUczestnika_Click;
            // 
            // btnAnulujZapUcz
            // 
            btnAnulujZapUcz.AutoSize = true;
            btnAnulujZapUcz.DialogResult = DialogResult.Cancel;
            btnAnulujZapUcz.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnAnulujZapUcz.Location = new Point(364, 399);
            btnAnulujZapUcz.Name = "btnAnulujZapUcz";
            btnAnulujZapUcz.Size = new Size(108, 31);
            btnAnulujZapUcz.TabIndex = 11;
            btnAnulujZapUcz.Text = "Anuluj";
            btnAnulujZapUcz.UseVisualStyleBackColor = true;
            btnAnulujZapUcz.Click += btnAnulujZapUcz_Click;
            // 
            // EdytujUczForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 450);
            Controls.Add(btnAnulujZapUcz);
            Controls.Add(btnZapiszUczestnika);
            Controls.Add(dtpDataUrodzenia);
            Controls.Add(label5);
            Controls.Add(txtNumerTelefonu);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtNazwisko);
            Controls.Add(label2);
            Controls.Add(txtImie);
            Controls.Add(label1);
            MinimumSize = new Size(517, 489);
            Name = "EdytujUczForm";
            Text = "Edytuj Uczestnika";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtImie;
        private Label label2;
        private TextBox txtNazwisko;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtNumerTelefonu;
        private Label label5;
        private DateTimePicker dtpDataUrodzenia;
        private Button btnZapiszUczestnika;
        private Button btnAnulujZapUcz;
    }
}