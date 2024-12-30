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
        private void InitializeComponent_reset()
        {
            Width_input = new NumericUpDown();
            button1 = new Button();
            Lable1 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            aircraft_input = new NumericUpDown();
            armored_input = new NumericUpDown();
            cruiser_input = new NumericUpDown();
            destroyer_input = new NumericUpDown();
            submarine_input = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)Width_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aircraft_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)armored_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cruiser_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)destroyer_input).BeginInit();
            ((System.ComponentModel.ISupportInitialize)submarine_input).BeginInit();
            SuspendLayout();
            // 
            // Width_input
            // 
            Width_input.Location = new Point(12, 32);
            Width_input.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            Width_input.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            Width_input.Name = "Width_input";
            Width_input.Size = new Size(87, 27);
            Width_input.TabIndex = 0;
            Width_input.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(5, 198);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "save settings";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DefinisciTabella;
            // 
            // Lable1
            // 
            Lable1.AutoSize = true;
            Lable1.Location = new Point(12, 9);
            Lable1.Name = "Lable1";
            Lable1.Size = new Size(119, 20);
            Lable1.TabIndex = 1;
            Lable1.Text = "table dimension:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(209, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 3;
            label1.Text = "ships number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 34);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 5;
            label2.Text = "Aircraft carrier:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(238, 67);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 6;
            label3.Text = "Armored:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(238, 102);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 7;
            label4.Text = "Cruiser:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(238, 171);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 11;
            label5.Text = "Submarine:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(238, 136);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 10;
            label6.Text = "Destroyer:";
            // 
            // aircraft_input
            // 
            aircraft_input.Location = new Point(356, 32);
            aircraft_input.Name = "aircraft_input";
            aircraft_input.Size = new Size(150, 27);
            aircraft_input.TabIndex = 4;
            aircraft_input.Value = 1;
            aircraft_input.Maximum = 100;
            aircraft_input.Minimum = 1;
            // 
            // armored_input
            // 
            armored_input.Location = new Point(356, 65);
            armored_input.Name = "armored_input";
            armored_input.Size = new Size(150, 27);
            armored_input.TabIndex = 8;
            armored_input.Value = 1;
            armored_input.Maximum = 100;
            armored_input.Minimum = 1;
            // 
            // cruiser_input
            // 
            cruiser_input.Location = new Point(356, 100);
            cruiser_input.Name = "cruiser_input";
            cruiser_input.Size = new Size(150, 27);
            cruiser_input.TabIndex = 9;
            cruiser_input.Value = 1;
            cruiser_input.Maximum = 100;
            cruiser_input.Minimum = 1;
            // 
            // destroyer_input
            // 
            destroyer_input.Location = new Point(356, 134);
            destroyer_input.Name = "destroyer_input";
            destroyer_input.Size = new Size(150, 27);
            destroyer_input.TabIndex = 12;
            destroyer_input.Value = 1;
            destroyer_input.Maximum = 100;
            destroyer_input.Minimum = 1;
            // 
            // submarine_input
            // 
            submarine_input.Location = new Point(356, 169);
            submarine_input.Name = "submarine_input";
            submarine_input.Size = new Size(150, 27);
            submarine_input.TabIndex = 13;
            submarine_input.Value = 1;
            submarine_input.Maximum = 100;
            submarine_input.Minimum = 1;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 239);
            Controls.Add(submarine_input);
            Controls.Add(destroyer_input);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(cruiser_input);
            Controls.Add(armored_input);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(aircraft_input);
            Controls.Add(label1);
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
            ((System.ComponentModel.ISupportInitialize)Width_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)aircraft_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)armored_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)cruiser_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)destroyer_input).EndInit();
            ((System.ComponentModel.ISupportInitialize)submarine_input).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

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
            Width_input.Location = new Point(12, 32);
            Width_input.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            Width_input.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            Width_input.Name = "Width_input";
            Width_input.Size = new Size(87, 27);
            Width_input.TabIndex = 0;
            Width_input.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // Lable1
            // 
            Lable1.AutoSize = true;
            Lable1.Location = new Point(12, 9);
            Lable1.Name = "Lable1";
            Lable1.Size = new Size(119, 20);
            Lable1.TabIndex = 1;
            Lable1.Text = "table dimension:";
            // 
            // button1
            // 
            button1.Location = new Point(182, 131);
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
            ClientSize = new Size(285, 166);
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
            ((System.ComponentModel.ISupportInitialize)Width_input).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown Width_input;
        private Label Lable1;
        private Button button1;
        private NumericUpDown armored_input;
        private NumericUpDown cruiser_input;
        private NumericUpDown submarine_input;
        private NumericUpDown destroyer_input;
        private NumericUpDown numericUpDown5;
        private NumericUpDown aircraft_input;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}