namespace battaglia_navale
{
    partial class Table
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
            Playing_board = new Panel();
            Cambia_tabella = new Button();
            Lable1 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // Playing_board
            // 
            Playing_board.AutoSize = true;
            Playing_board.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Playing_board.Location = new Point(203, 12);
            Playing_board.Name = "Playing_board";
            Playing_board.Size = new Size(0, 0);
            Playing_board.TabIndex = 0;
            // 
            // Cambia_tabella
            // 
            Cambia_tabella.Location = new Point(12, 69);
            Cambia_tabella.Name = "Cambia_tabella";
            Cambia_tabella.Size = new Size(174, 48);
            Cambia_tabella.TabIndex = 1;
            Cambia_tabella.Text = "Cambia caratteristiche tabella";
            Cambia_tabella.UseVisualStyleBackColor = true;
            Cambia_tabella.Click += Modifica_tabella_Click;
            // 
            // Lable1
            // 
            Lable1.AutoSize = true;
            Lable1.Location = new Point(35, 12);
            Lable1.Name = "Lable1";
            Lable1.Size = new Size(137, 20);
            Lable1.TabIndex = 2;
            Lable1.Text = "Impostazioni gioco";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Location = new Point(323, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 1;
            // 
            // Table
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(830, 610);
            Controls.Add(panel1);
            Controls.Add(Lable1);
            Controls.Add(Cambia_tabella);
            Controls.Add(Playing_board);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Table";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Cambia_tabella;
        private Label Lable1;
        public Panel panel1;
        public Panel Playing_board;
    }
}