using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace battaglia_navale
{
    internal class Ship_tile : Button
    {
        private int[] position_matrix { get; set; } public int[] Position { get => position_matrix; } // posizione della casella
        private bool isDestroyed { get; set; } public bool IsDestroyed { get => isDestroyed; } // casella distrutta


        public Ship_tile(string name, int[] position)
        {
            this.isDestroyed = false;
            this.position_matrix = position;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Text = name;
            InitializeComponent(position);
        }

        private void CreateButton() { //da fare, pensare anche allo spawn automatico
            this.Parent = Table.User_board;
            tile.Top = row * 52;
            tile.Left = column * 70;
            tile.Width = 68;
            tile.Height = 50;
            tile.Tag = $"{column}|{row}";
            tile.Text = $"{column + 1} - {row + 1}";

            // Apparence
            tile.FlatStyle = FlatStyle.Flat;
            tile.FlatAppearance.BorderSize = 0;
            tile.BackColor = Color.LightBlue;

            // Events
            tile.Click += new EventHandler(Table.Board_buttonClick);
            matrice_tabella[column, row] = tile;
        }

        public void SetDestroyed(bool isDestroyed)
        {
            this.isDestroyed = isDestroyed;
            this.BackColor = System.Drawing.Color.Red;
        }

        private void InitializeComponent(int[] position)
        {
            this.Location = Table.user_board_matrix[position[0], position[1]].Location;//set location in the panel

            Table.User_board.Controls.Remove(Table.user_board_matrix[position[0], position[1]]); //remove the old button

            Table.user_board_matrix[position[0], position[1]] = this;//add the new button
            Table.User_board.Controls.Add(this);
        }
    }
}
