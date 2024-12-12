using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace battaglia_navale
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void DefinisciTabella(object sender, EventArgs e)
        {
            int table_width = Convert.ToInt32(Width_input.Value);
            int table_height = table_width;

            //verify whether the new table is smaller than the previous one, and delete the extra buttons
            if (table_width < Table.table_dimension)
                for (int x = Table.table_dimension - 1; x >= table_width; x--)
                    for (int y = Table.table_dimension - 1; y >= 0; y--) { 
                        Table.Playing_board.Controls.Remove(Table.matrice_tabella[x, y]);
                        Table.Playing_board.Controls.Remove(Table.matrice_tabella[y, x]);
                        Table.matrice_tabella[x, y].Dispose();
                        Table.matrice_tabella[y, x].Dispose();
                    }

            //define the table 
            Table.matrice_tabella = new Button[table_width, table_height];
            Table.table_dimension = table_width;
            Button[,] matrice_tabella = Table.matrice_tabella;
            Panel Playing_board = Table.Playing_board;

            //create the buttons matrix
            for (int row = 0; row < table_width; row++)
                for (int column = 0; column < table_height; column++)
                    DefineButton(matrice_tabella, Playing_board, row, column);

            //close the form
            Close();
        }

        private static void DefineButton(Button[,] matrice_tabella, Panel Playing_board, int row, int column)
        {
            Button tile = new Button();
            tile.Parent = Playing_board;
            tile.Top = row * 50;
            tile.Left = column * 68;//68
            tile.Width = 68;
            tile.Height = 50;
            tile.Text = $"{row + 1} - {column + 1}";
            tile.Click += new EventHandler(Table.HitTile);
            matrice_tabella[row, column] = tile;
        }

    }
}

