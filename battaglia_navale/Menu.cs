﻿using System;
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

        public async void DefinisciTabella(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Table.Computer_board.Invoke((MethodInvoker)delegate {
                Table.Computer_board.Location = new Point(Table.User_board.Location.X + Convert.ToInt32(Width_input.Value) * 68 +40, 12);
            });

            Thread user = new Thread(Define_UserTable);
            Thread computer = new Thread(Define_ComputerTable);

            //define user and computer table
            user.Start();
            computer.Start();
            MessageBox.Show("Tabella creata con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            user.Join();
            computer.Join();

            MessageBox.Show($"{Convert.ToInt32(Width_input.Value)} | {Table.table_dimension}");
            Table.table_dimension = Convert.ToInt32(Width_input.Value);
            MessageBox.Show($"{Table.computer_board_matrix.GetLength(1)} | {Table.table_dimension}");

            Cursor = Cursors.Default;

            //close the form
            Close();
        }

        private void Define_UserTable()
        {
            int table_width = Convert.ToInt32(Width_input.Value);
            int table_height = table_width;
            

            //verify whether the new table is smaller than the previous one, and delete the extra buttons
            if (VerifyTableDimension(table_width, Table.User_board, Table.user_board_matrix))
                return;

            //define the table 
            Table.user_board_matrix = new Button[table_width, table_height];
            Button[,] matrice_tabella = Table.user_board_matrix;

            //create the buttons matrix
            for (int row = 0; row < table_width; row++)
                for (int column = 0; column < table_height; column++)
                    DefineButton(matrice_tabella, Table.User_board, row, column);
        }
        
        private void Define_ComputerTable()
        {
            int table_width = Convert.ToInt32(Width_input.Value);
            int table_height = table_width;

            //verify whether the new table is smaller than the previous one, and delete the extra buttons
            if (VerifyTableDimension(table_width, Table.Computer_board, Table.computer_board_matrix))
                return;

            //define the table 
            Table.computer_board_matrix = new Button[table_width, table_height];
            Button[,] matrice_tabella = Table.computer_board_matrix;
            
            //create the buttons matrix
            for (int row = 0; row < table_width; row++)
                for (int column = 0; column < table_height; column++)
                    DefineButton(matrice_tabella, Table.Computer_board, row, column);
        }

        private static void DefineButton(Button[,] matrice_tabella, Panel Playing_board, int row, int column)
        {
            Button tile = new Button();

            // Utilizza Invoke per assegnare il Parent del bottone
            if (Playing_board.InvokeRequired)
                Playing_board.Invoke((MethodInvoker)delegate {
                    create_button();
                });
            else
                create_button();


            void create_button() {
                tile.Parent = Playing_board;
                tile.Top = row * 52;
                tile.Left = column * 70;
                tile.Width = 68;
                tile.Height = 50;
                tile.Text = $"{row + 1} - {column + 1}";

                // Apparence
                tile.FlatStyle = FlatStyle.Flat;
                tile.FlatAppearance.BorderSize = 0;
                tile.BackColor = Color.LightBlue;

                // Events
                tile.Click += new EventHandler(Table.HitTile);
                matrice_tabella[row, column] = tile;
            
            }
        }

        private static bool VerifyTableDimension(int table_width, Panel board, Button[,] board_matrix)
        {

            if (table_width < Table.table_dimension) { 
                for (int x = Table.table_dimension - 1; x >= table_width; x--)
                    for (int y = Table.table_dimension - 1; y >= 0; y--)
                    {
                        Table.Computer_board.Invoke((MethodInvoker)delegate {
                            board.Controls.Remove(board_matrix[x, y]);
                            board.Controls.Remove(board_matrix[y, x]);
                            board_matrix[x, y].Dispose();
                            board_matrix[y, x].Dispose();
                        });
                    }

                board_matrix = new Button[table_width, table_width];

                return true;
            }

            return false;
        }




    }
}

