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
            this.Cambia_tabella = new Button();
            this.Lable1 = new Label();
            Computer_board = new Panel();
            this.button1 = new Button();
            Ship_input = new ComboBox();
            this.label1 = new Label();
            Button_vertical = new RadioButton();
            Button_horizontal = new RadioButton();
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
            this.Cambia_tabella.Location = new Point(12, 69);
            this.Cambia_tabella.Name = "Cambia_tabella";
            this.Cambia_tabella.Size = new Size(174, 48);
            this.Cambia_tabella.TabIndex = 1;
            this.Cambia_tabella.Text = "Cambia caratteristiche tabella";
            this.Cambia_tabella.UseVisualStyleBackColor = true;
            this.Cambia_tabella.Click += Modifica_tabella_Click;
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Location = new Point(31, 9);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new Size(137, 20);
            this.Lable1.TabIndex = 2;
            this.Lable1.Text = "Impostazioni gioco";
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
            // button1
            // 
            this.button1.Location = new Point(12, 556);
            this.button1.Name = "button1";
            this.button1.Size = new Size(174, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Procedi alla partita";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Ship_input
            // 
            Ship_input.FormattingEnabled = true;
            Ship_input.Location = new Point(12, 209);
            Ship_input.Name = "Ship_input";
            Ship_input.Size = new Size(174, 28);
            Ship_input.TabIndex = 4;
            Ship_input.DropDownStyle = ComboBoxStyle.DropDownList;
            Ship_input.Items.AddRange(new string[] { "Portaerei(5)", "Corazzata(4)", "Incrociatore(3)", "Cacciatorpediniere(3)", "Sottomarino(2)" });
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(14, 157);
            this.label1.Name = "label1";
            this.label1.Size = new Size(172, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "segli la nave da piazzare";
            // 
            // Button_vertical
            // 
            Button_vertical.AutoSize = false;
            Button_vertical.Location = new Point(12, 243);
            Button_vertical.Name = "Button_vertical";
            Button_vertical.Size = new Size(78, 24);
            Button_vertical.TabIndex = 6;
            Button_vertical.TabStop = true;
            Button_vertical.Text = "vertical";
            Button_vertical.UseVisualStyleBackColor = true;
            // 
            // Button_horizontal
            // 
            Button_horizontal.AutoSize = false;
            Button_horizontal.Location = new Point(12, 273);
            Button_horizontal.Name = "Button_horizontal";
            Button_horizontal.Size = new Size(97, 24);
            Button_horizontal.TabIndex = 7;
            Button_horizontal.TabStop = true;
            Button_horizontal.Text = "horizontal";
            Button_horizontal.UseVisualStyleBackColor = true;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ClientSize = new Size(830, 610);
            this.Controls.Add(Button_vertical);
            this.Controls.Add(Button_horizontal);
            this.Controls.Add(label1);
            this.Controls.Add(Ship_input);
            this.Controls.Add(button1);
            this.Controls.Add(Computer_board);
            this.Controls.Add(Lable1);
            this.Controls.Add(Cambia_tabella);
            this.Controls.Add(User_board);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Name = "Table";
            this.Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Lable1;
        private Label label1;
        private Button button1;
        private Button Cambia_tabella;
        private static RadioButton Button_vertical;
        private static RadioButton Button_horizontal;
        private static ComboBox Ship_input;
        public static Panel Computer_board;
        public static Panel User_board;
    }
}