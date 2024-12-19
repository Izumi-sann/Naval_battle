using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace battaglia_navale
{
    internal class Ship_tile : Button
    {
        private int[] position_matrix { get; set; } public int[] Position { get => position_matrix; } // posizione della casella
        private bool isDestroyed { get; set; } public bool IsDestroyed { get => isDestroyed; } // casella distrutta


        public Ship_tile(string name, int[] position, string sender)
        {
            this.isDestroyed = false;
            this.position_matrix = position;

            Panel board = sender == "user" ? Table.User_board : Table.Computer_board;
            Button[,] board_matrix = sender == "user" ? Table.user_board_matrix : Table.computer_board_matrix;

            DefineButtonStyle(name, sender, board);
            InitializeComponent(position, sender);
        }
        
        /// <summary>
        /// insert the new button in the panel and replace the previows one
        /// </summary>
        /// <param name="position"></param>
        /// <param name="name"></param>
        private void InitializeComponent(int[] position, string sender)
        {
            this.Location = Table.user_board_matrix[position[0], position[1]].Location;//set location in the panel

            Table.User_board.Controls.Remove(Table.user_board_matrix[position[0], position[1]]); //remove the old button

            Table.user_board_matrix[position[0], position[1]] = this;//add the new button
            Table.User_board.Controls.Add(this);
        }

        private void DefineButtonStyle(string name, string sender, Panel board) 
        {
            
            this.Parent = board;
            this.Width = 68;
            this.Height = 50;

            //info
            char[] name_array = name.ToArray();
            this.Tag = "ship tile";
            this.Text = sender == "user" ? new string(new char[] { name_array[0], name_array[1] }).ToUpper() : ""; //se è nel campo dell'utente aggiunge le prime due lettere; es: portaerei -> po

            // Apparence
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = sender == "user" ? 1 : 0;
            this.BackColor = sender == "user" ? System.Drawing.Color.DarkGray : System.Drawing.Color.LightBlue;

            // Events
            this.Click += new EventHandler(Table.Board_buttonClick);
        }

        public void SetDestroyed()
        {
            this.isDestroyed = true;
            this.BackColor = System.Drawing.Color.Red;
        }
    }
}
