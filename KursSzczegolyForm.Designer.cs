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
            groupBox2 = new GroupBox();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // gbInformacjeOKursie
            // 
            gbInformacjeOKursie.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            gbInformacjeOKursie.Location = new Point(0, 0);
            gbInformacjeOKursie.Name = "gbInformacjeOKursie";
            gbInformacjeOKursie.Size = new Size(317, 271);
            gbInformacjeOKursie.TabIndex = 0;
            gbInformacjeOKursie.TabStop = false;
            gbInformacjeOKursie.Text = "Informacje o kursie:";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(374, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 100);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 357);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 0;
            // 
            // KursSzczegolyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(gbInformacjeOKursie);
            Name = "KursSzczegolyForm";
            Text = "Szczegóły kursu: ";
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbInformacjeOKursie;
        private GroupBox groupBox2;
        private Panel panel1;
    }
}