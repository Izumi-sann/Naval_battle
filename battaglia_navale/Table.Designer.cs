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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Table));
            User_board = new Panel();
            Cambia_tabella = new Button();
            Computer_board = new Panel();
            button_StartGame = new Button();
            Ship_input = new ComboBox();
            Button_vertical = new RadioButton();
            Button_horizontal = new RadioButton();
            groupBox2 = new GroupBox();
            label1 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // User_board
            // 
            User_board.AutoSize = true;
            User_board.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            User_board.BorderStyle = BorderStyle.Fixed3D;
            User_board.Location = new Point(49, 179);
            User_board.Name = "User_board";
            User_board.Size = new Size(4, 4);
            User_board.TabIndex = 0;
            // 
            // Cambia_tabella
            // 
            Cambia_tabella.Location = new Point(7, 28);
            Cambia_tabella.Name = "Cambia_tabella";
            Cambia_tabella.Size = new Size(174, 31);
            Cambia_tabella.TabIndex = 1;
            Cambia_tabella.Text = "Modify table";
            Cambia_tabella.UseVisualStyleBackColor = true;
            Cambia_tabella.Click += Modifica_tabella_Click;
            // 
            // Computer_board
            // 
            Computer_board.AutoSize = true;
            Computer_board.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Computer_board.BorderStyle = BorderStyle.Fixed3D;
            Computer_board.Location = new Point(13, 177);
            Computer_board.Name = "Computer_board";
            Computer_board.Size = new Size(4, 4);
            Computer_board.TabIndex = 1;
            // 
            // button_StartGame
            // 
            button_StartGame.Location = new Point(7, 76);
            button_StartGame.Name = "button1";
            button_StartGame.Size = new Size(174, 27);
            button_StartGame.TabIndex = 3;
            button_StartGame.Text = "Start game";
            button_StartGame.UseVisualStyleBackColor = true;
            button_StartGame.Click += Start_game_Click;
            // 
            // Ship_input
            // 
            Ship_input.DropDownStyle = ComboBoxStyle.DropDownList;
            Ship_input.FormattingEnabled = true;
            Ship_input.Items.AddRange(new object[] { "Portaerei(5)", "Corazzata(4)", "Incrociatore(3)", "Cacciatorpediniere(3)", "Sottomarino(2)" });
            Ship_input.Location = new Point(338, 28);
            Ship_input.Name = "Ship_input";
            Ship_input.Size = new Size(174, 28);
            Ship_input.TabIndex = 4;
            // 
            // Button_vertical
            // 
            Button_vertical.Location = new Point(338, 79);
            Button_vertical.Name = "Button_vertical";
            Button_vertical.Size = new Size(78, 24);
            Button_vertical.TabIndex = 6;
            Button_vertical.TabStop = true;
            Button_vertical.Text = "vertical";
            Button_vertical.UseVisualStyleBackColor = true;
            // 
            // Button_horizontal
            // 
            Button_horizontal.Checked = true;
            Button_horizontal.Location = new Point(338, 108);
            Button_horizontal.Name = "Button_horizontal";
            Button_horizontal.Size = new Size(97, 24);
            Button_horizontal.TabIndex = 7;
            Button_horizontal.TabStop = true;
            Button_horizontal.Text = "horizontal";
            Button_horizontal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.BackgroundImageLayout = ImageLayout.None;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(Button_vertical);
            groupBox2.Controls.Add(Button_horizontal);
            groupBox2.Controls.Add(Ship_input);
            groupBox2.Controls.Add(button_StartGame);
            groupBox2.Controls.Add(Cambia_tabella);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(2194, 147);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Impostazioni";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 28);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 8;
            label1.Text = "Select ship:";
            // 
            // Table
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1558, 977);
            Controls.Add(groupBox2);
            Controls.Add(Computer_board);
            Controls.Add(User_board);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Table";
            Text = "Naval Battle: the awakening";
            WindowState = FormWindowState.Maximized;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox2;
        private Button button_StartGame;
        private Button Cambia_tabella;
        private Label label1;
        private static RadioButton Button_vertical;
        private static RadioButton Button_horizontal;
        private static ComboBox Ship_input;
        public static Panel Computer_board;
        public static Panel User_board;
    }
}