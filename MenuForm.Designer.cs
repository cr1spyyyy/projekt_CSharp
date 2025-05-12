namespace projekt_CSharp
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            buttonPanel = new Panel();
            wyjdzBtn = new Button();
            rejestracjaBtn = new Button();
            uczestnicyBtn = new Button();
            kursyBtn = new Button();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 123);
            label1.TabIndex = 0;
            label1.Text = "Rejestr kursów i uczestników";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(0, 123);
            label2.Name = "label2";
            label2.Size = new Size(800, 54);
            label2.TabIndex = 1;
            label2.Text = "Wybierz, którą tabele otworzyć:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonPanel
            // 
            buttonPanel.Anchor = AnchorStyles.Top;
            buttonPanel.Controls.Add(wyjdzBtn);
            buttonPanel.Controls.Add(rejestracjaBtn);
            buttonPanel.Controls.Add(uczestnicyBtn);
            buttonPanel.Controls.Add(kursyBtn);
            buttonPanel.Location = new Point(288, 180);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(229, 261);
            buttonPanel.TabIndex = 2;
            // 
            // wyjdzBtn
            // 
            wyjdzBtn.AutoSize = true;
            wyjdzBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            wyjdzBtn.Location = new Point(0, 227);
            wyjdzBtn.Name = "wyjdzBtn";
            wyjdzBtn.Size = new Size(226, 31);
            wyjdzBtn.TabIndex = 3;
            wyjdzBtn.Text = "Wyjdź";
            wyjdzBtn.UseVisualStyleBackColor = true;
            wyjdzBtn.Click += wyjdzBtn_Click;
            // 
            // rejestracjaBtn
            // 
            rejestracjaBtn.AutoSize = true;
            rejestracjaBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            rejestracjaBtn.Location = new Point(0, 118);
            rejestracjaBtn.Name = "rejestracjaBtn";
            rejestracjaBtn.Size = new Size(226, 31);
            rejestracjaBtn.TabIndex = 2;
            rejestracjaBtn.Text = "Zarejestruj";
            rejestracjaBtn.UseVisualStyleBackColor = true;
            rejestracjaBtn.Click += rejestracjaBtn_Click;
            // 
            // uczestnicyBtn
            // 
            uczestnicyBtn.AutoSize = true;
            uczestnicyBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            uczestnicyBtn.Location = new Point(0, 61);
            uczestnicyBtn.Name = "uczestnicyBtn";
            uczestnicyBtn.Size = new Size(226, 31);
            uczestnicyBtn.TabIndex = 1;
            uczestnicyBtn.Text = "Uczestnicy";
            uczestnicyBtn.UseVisualStyleBackColor = true;
            uczestnicyBtn.Click += uczestnicyBtn_Click;
            // 
            // kursyBtn
            // 
            kursyBtn.AutoSize = true;
            kursyBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            kursyBtn.Location = new Point(0, 3);
            kursyBtn.Name = "kursyBtn";
            kursyBtn.Size = new Size(226, 31);
            kursyBtn.TabIndex = 0;
            kursyBtn.Text = "Kursy";
            kursyBtn.UseVisualStyleBackColor = true;
            kursyBtn.Click += kursyBtn_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonPanel);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MinimumSize = new Size(400, 489);
            Name = "MenuForm";
            Text = "Menu Główne";
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel buttonPanel;
        private Button wyjdzBtn;
        private Button rejestracjaBtn;
        private Button uczestnicyBtn;
        private Button kursyBtn;
    }
}
