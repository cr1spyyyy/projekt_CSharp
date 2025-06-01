namespace projekt_CSharp
{
    partial class RejestracjaForm
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
            cmbKursy = new ComboBox();
            label2 = new Label();
            cmbUczestnicy = new ComboBox();
            label3 = new Label();
            dtpDataZapisu = new DateTimePicker();
            btnDokonajZapisu = new Button();
            btnAnulujZapis = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(25, 35);
            label1.Name = "label1";
            label1.Size = new Size(137, 30);
            label1.TabIndex = 0;
            label1.Text = "Wybierz kurs:";
            // 
            // cmbKursy
            // 
            cmbKursy.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbKursy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            cmbKursy.FormattingEnabled = true;
            cmbKursy.Location = new Point(239, 35);
            cmbKursy.Name = "cmbKursy";
            cmbKursy.Size = new Size(316, 33);
            cmbKursy.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(25, 91);
            label2.Name = "label2";
            label2.Size = new Size(196, 30);
            label2.TabIndex = 2;
            label2.Text = "Wybierz uczestnika:";
            // 
            // cmbUczestnicy
            // 
            cmbUczestnicy.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbUczestnicy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            cmbUczestnicy.FormattingEnabled = true;
            cmbUczestnicy.Location = new Point(239, 88);
            cmbUczestnicy.Name = "cmbUczestnicy";
            cmbUczestnicy.Size = new Size(316, 33);
            cmbUczestnicy.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(25, 146);
            label3.Name = "label3";
            label3.Size = new Size(127, 30);
            label3.TabIndex = 4;
            label3.Text = "Data zapisu:";
            // 
            // dtpDataZapisu
            // 
            dtpDataZapisu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpDataZapisu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtpDataZapisu.Location = new Point(239, 147);
            dtpDataZapisu.Name = "dtpDataZapisu";
            dtpDataZapisu.Size = new Size(316, 29);
            dtpDataZapisu.TabIndex = 5;
            // 
            // btnDokonajZapisu
            // 
            btnDokonajZapisu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDokonajZapisu.AutoSize = true;
            btnDokonajZapisu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnDokonajZapisu.Location = new Point(239, 271);
            btnDokonajZapisu.Name = "btnDokonajZapisu";
            btnDokonajZapisu.Size = new Size(119, 31);
            btnDokonajZapisu.TabIndex = 8;
            btnDokonajZapisu.Text = "Zapisz na kurs";
            btnDokonajZapisu.UseVisualStyleBackColor = true;
            btnDokonajZapisu.Click += btnDokonajZapisu_Click;
            // 
            // btnAnulujZapis
            // 
            btnAnulujZapis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnulujZapis.AutoSize = true;
            btnAnulujZapis.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnAnulujZapis.Location = new Point(465, 271);
            btnAnulujZapis.Name = "btnAnulujZapis";
            btnAnulujZapis.Size = new Size(90, 31);
            btnAnulujZapis.TabIndex = 9;
            btnAnulujZapis.Text = "Anuluj";
            btnAnulujZapis.UseVisualStyleBackColor = true;
            btnAnulujZapis.Click += btnAnulujZapis_Click;
            // 
            // RejestracjaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 323);
            Controls.Add(btnAnulujZapis);
            Controls.Add(btnDokonajZapisu);
            Controls.Add(dtpDataZapisu);
            Controls.Add(label3);
            Controls.Add(cmbUczestnicy);
            Controls.Add(label2);
            Controls.Add(cmbKursy);
            Controls.Add(label1);
            MinimumSize = new Size(595, 362);
            Name = "RejestracjaForm";
            Text = "Rejestracja";
            Load += RejestracjaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbKursy;
        private Label label2;
        private ComboBox cmbUczestnicy;
        private Label label3;
        private DateTimePicker dtpDataZapisu;
        private Button btnDokonajZapisu;
        private Button btnAnulujZapis;
    }
}