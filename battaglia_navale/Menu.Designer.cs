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
            this.Width_input = new System.Windows.Forms.NumericUpDown();
            this.Lable1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Width_input)).BeginInit();
            this.SuspendLayout();
            // 
            // Width_input
            // 
            this.Width_input.Location = new System.Drawing.Point(74, 43);
            this.Width_input.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Width_input.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.Width_input.Name = "Width_input";
            this.Width_input.Size = new System.Drawing.Size(87, 27);
            this.Width_input.TabIndex = 0;
            this.Width_input.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Location = new System.Drawing.Point(12, 9);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(119, 20);
            this.Lable1.TabIndex = 1;
            this.Lable1.Text = "table dimension:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "save settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DefinisciTabella);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 172);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lable1);
            this.Controls.Add(this.Width_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.Width_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown Width_input;
        private Label Lable1;
        private Button button1;
    }
}