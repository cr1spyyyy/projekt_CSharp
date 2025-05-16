namespace projekt_CSharp
{
    partial class UczestnicyForm
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
            panel1 = new Panel();
            btnWyszukajUcz = new Button();
            txtSzukajUczestnika = new TextBox();
            label2 = new Label();
            btnDodajUczestnika = new Button();
            dvgUczestnicy = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgUczestnicy).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(214, 32);
            label1.TabIndex = 0;
            label1.Text = "Lista uczestników";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnWyszukajUcz);
            panel1.Controls.Add(txtSzukajUczestnika);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnDodajUczestnika);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 65);
            panel1.TabIndex = 1;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(321, 24);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 1;
            label2.Text = "Szukaj:";
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
            // dvgUczestnicy
            // 
            dvgUczestnicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgUczestnicy.Dock = DockStyle.Fill;
            dvgUczestnicy.Location = new Point(0, 97);
            dvgUczestnicy.Name = "dvgUczestnicy";
            dvgUczestnicy.Size = new Size(800, 353);
            dvgUczestnicy.TabIndex = 2;
            dvgUczestnicy.CellContentClick += dvgUczestnicy_CellContentClick;
            // 
            // UczestnicyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dvgUczestnicy);
            Controls.Add(panel1);
            Controls.Add(label1);
            MinimumSize = new Size(816, 489);
            Name = "UczestnicyForm";
            Text = "UczestnicyForm";
            Load += UczestnicyForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dvgUczestnicy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnDodajUczestnika;
        private Label label2;
        private TextBox txtSzukajUczestnika;
        private Button btnWyszukajUcz;
        private DataGridView dvgUczestnicy;
    }
}