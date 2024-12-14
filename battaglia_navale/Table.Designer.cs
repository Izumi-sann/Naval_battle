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
            User_board = new System.Windows.Forms.Panel();
            this.Cambia_tabella = new System.Windows.Forms.Button();
            this.Lable1 = new System.Windows.Forms.Label();
            Computer_board = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // User_board
            // 
            User_board.AutoSize = true;
            User_board.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            User_board.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            User_board.Location = new System.Drawing.Point(250, 12);
            User_board.Name = "User_board";
            User_board.Size = new System.Drawing.Size(4, 4);
            User_board.TabIndex = 0;
            // 
            // Cambia_tabella
            // 
            this.Cambia_tabella.Location = new System.Drawing.Point(12, 69);
            this.Cambia_tabella.Name = "Cambia_tabella";
            this.Cambia_tabella.Size = new System.Drawing.Size(174, 48);
            this.Cambia_tabella.TabIndex = 1;
            this.Cambia_tabella.Text = "Cambia caratteristiche tabella";
            this.Cambia_tabella.UseVisualStyleBackColor = true;
            this.Cambia_tabella.Click += new System.EventHandler(this.Modifica_tabella_Click);
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Location = new System.Drawing.Point(35, 12);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(137, 20);
            this.Lable1.TabIndex = 2;
            this.Lable1.Text = "Impostazioni gioco";
            // 
            // Computer_board
            // 
            Computer_board.AutoSize = true;
            Computer_board.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Computer_board.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Computer_board.Location = new System.Drawing.Point(343, 12);
            Computer_board.Name = "Computer_board";
            Computer_board.Size = new System.Drawing.Size(4, 4);
            Computer_board.TabIndex = 1;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(830, 610);
            this.Controls.Add(Computer_board);
            this.Controls.Add(this.Lable1);
            this.Controls.Add(this.Cambia_tabella);
            this.Controls.Add(User_board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Table";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button Cambia_tabella;
        private Label Lable1;
        public static Panel Computer_board;
        public static Panel User_board;
    }
}