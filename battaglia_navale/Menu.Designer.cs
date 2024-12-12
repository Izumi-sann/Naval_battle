namespace battaglia_navale
{
    partial class Menu
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
            Width_input = new NumericUpDown();
            Lable1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)Width_input).BeginInit();
            SuspendLayout();
            // 
            // Width_input
            // 
            Width_input.Location = new Point(12, 37);
            Width_input.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            Width_input.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            Width_input.Name = "Width_input";
            Width_input.Size = new Size(87, 27);
            Width_input.TabIndex = 0;
            Width_input.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // Lable1
            // 
            Lable1.AutoSize = true;
            Lable1.Location = new Point(12, 14);
            Lable1.Name = "Lable1";
            Lable1.Size = new Size(119, 20);
            Lable1.TabIndex = 1;
            Lable1.Text = "table dimension:";
            // 
            // button1
            // 
            button1.Location = new Point(12, 86);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "save settings";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DefinisciTabella;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(175, 172);
            Controls.Add(button1);
            Controls.Add(Lable1);
            Controls.Add(Width_input);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Menu";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Menu";
            TopMost = true;
            Load += Menu_Load;
            ((System.ComponentModel.ISupportInitialize)Width_input).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown Width_input;
        private Label Lable1;
        private Button button1;
    }
}