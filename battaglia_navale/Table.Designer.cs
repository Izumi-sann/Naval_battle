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
            User_board = new Panel();
            Cambia_tabella = new Button();
            Lable1 = new Label();
            Computer_board = new Panel();
            SuspendLayout();
            // 
            // User_board
            // 
            User_board.AutoSize = true;
            User_board.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            User_board.BorderStyle = BorderStyle.Fixed3D;
            User_board.Location = new Point(250, 12);
            User_board.Name = "User_board";
            User_board.Size = new Size(4, 4);
            User_board.TabIndex = 0;
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
            // Computer_board
            // 
            Computer_board.AutoSize = true;
            Computer_board.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Computer_board.BorderStyle = BorderStyle.Fixed3D;
            Computer_board.Location = new Point(343, 12);
            Computer_board.Name = "Computer_board";
            Computer_board.Size = new Size(4, 4);
            Computer_board.TabIndex = 1;
            // 
            // Table
            // 
            Name = "Table";
            Text = "Form1";
            AutoSize = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(830, 610);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = true;
            MinimizeBox = true;
            Controls.Add(Computer_board);
            Controls.Add(Lable1);
            Controls.Add(Cambia_tabella);
            Controls.Add(User_board);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Cambia_tabella;
        private Label Lable1;
        public static Panel Computer_board;
        public static Panel User_board;
    }
}