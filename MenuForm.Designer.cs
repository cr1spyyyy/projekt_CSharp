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
            kursyBtn = new Button();
            uczestnicyBtn = new Button();
            panelLeft = new FlowLayoutPanel();
            panelMain = new Panel();
            panelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(398, 3);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(286, 30);
            label1.TabIndex = 3;
            label1.Text = "System zarządzania kursami";
            // 
            // kursyBtn
            // 
            kursyBtn.AutoSize = true;
            kursyBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            kursyBtn.Location = new Point(2, 3);
            kursyBtn.Margin = new Padding(2, 3, 2, 3);
            kursyBtn.Name = "kursyBtn";
            kursyBtn.Size = new Size(194, 31);
            kursyBtn.TabIndex = 0;
            kursyBtn.Text = "Kursy";
            kursyBtn.UseVisualStyleBackColor = true;
            kursyBtn.Click += kursyBtn_Click;
            // 
            // uczestnicyBtn
            // 
            uczestnicyBtn.AutoSize = true;
            uczestnicyBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            uczestnicyBtn.Location = new Point(200, 3);
            uczestnicyBtn.Margin = new Padding(2, 3, 2, 3);
            uczestnicyBtn.Name = "uczestnicyBtn";
            uczestnicyBtn.Size = new Size(194, 31);
            uczestnicyBtn.TabIndex = 1;
            uczestnicyBtn.Text = "Uczestnicy";
            uczestnicyBtn.UseVisualStyleBackColor = true;
            uczestnicyBtn.Click += uczestnicyBtn_Click;
            // 
            // panelLeft
            // 
            panelLeft.AutoSize = true;
            panelLeft.Controls.Add(kursyBtn);
            panelLeft.Controls.Add(uczestnicyBtn);
            panelLeft.Controls.Add(label1);
            panelLeft.Dock = DockStyle.Top;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(938, 37);
            panelLeft.TabIndex = 5;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 37);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(938, 404);
            panelMain.TabIndex = 6;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 441);
            Controls.Add(panelMain);
            Controls.Add(panelLeft);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(2, 3, 2, 3);
            MinimumSize = new Size(345, 429);
            Name = "MenuForm";
            Text = "Menu Główne";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button kursyBtn;
        private Button uczestnicyBtn;
        private FlowLayoutPanel panelLeft;
        private Panel panelMain;
    }
}
