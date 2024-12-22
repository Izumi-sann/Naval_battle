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

        public void DefinisciTabella(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Table.Computer_board.Invoke((MethodInvoker)delegate {
                Table.Computer_board.Location = new Point(Table.User_board.Location.X + Convert.ToInt32(Width_input.Value) * 68 +40, Table.User_board.Location.Y);
            });

            Thread user = new Thread(Define_UserTable);
            Thread computer = new Thread(Define_ComputerTable);

            //define user and computer table
            user.Start();
            computer.Start();
            MessageBox.Show("Tabella creata con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            user.Join();
            computer.Join();

            Table.table_dimension = Convert.ToInt32(Width_input.Value);

            Cursor = Cursors.Default;
            
            //close the form
            Close();
        }

        private void Define_UserTable()
        {
            int table_width = Convert.ToInt32(Width_input.Value);
            int table_height = table_width;


            if (VerifyTableDimension(table_width, Table.User_board, Table.user_board_matrix))
            {
                Button[,] matrice_resized = ResizeMatrix(Table.user_board_matrix, table_width, table_height);
                Table.user_board_matrix = matrice_resized;
                return;
            }

            //define the table 
            Button[,] matrice_tabella = ResizeMatrix(Table.user_board_matrix, table_width, table_height);

            //create the buttons matrix
            for (int row = 0; row < table_height; row++)
                for (int column = 0; column < table_width; column++)
                    Table.User_board.Invoke((MethodInvoker)delegate
                    {
                        DefineButton(matrice_tabella, Table.User_board, new int[] { column, row});
                    });

            Table.user_board_matrix = matrice_tabella;
        }
        
        private void Define_ComputerTable()
        {
            int table_width = Convert.ToInt32(Width_input.Value);
            int table_height = table_width;


            //verify whether the new table is smaller than the previous one, and delete the extra buttons
            if(VerifyTableDimension(table_width, Table.Computer_board, Table.computer_board_matrix)) {
                Table.computer_board_matrix = ResizeMatrix(Table.computer_board_matrix, table_width, table_height);
                return;
            }

            //define the table 
            Button[,] matrice_tabella = ResizeMatrix(Table.computer_board_matrix, table_width, table_height);
            
            //create the buttons matrix
            for (int row = 0; row < table_height; row++)
                for (int column = 0; column < table_width; column++)
                    Table.Computer_board.Invoke((MethodInvoker)delegate{
                            DefineButton(matrice_tabella, Table.Computer_board, new int[] { column, row });
                    });

            //aggiorna matrice
            Table.computer_board_matrix = matrice_tabella;
        }
        
        public void create_computer_ship(string key) { 
            Random generatore = new Random();
            Ship new_ship;

            //define parameters
            bool IsVertical = generatore.Next(0, 2) == 0 ? false : true;
            int lenght = Table.GetLenght(key);
            int dimension = Convert.ToInt32(Width_input.Value);
            while (true) {
                //define coordinates until they're accepted
                int x = generatore.Next(0, IsVertical ? dimension : dimension - lenght +1);//get the second value considering the ship's lenght and table dimension
                int y = generatore.Next(0, IsVertical ? dimension - lenght +1 : dimension);
                int[] coordinates = new int[] { x, y };

                try { 
                    if (Table.Computer_board.InvokeRequired)
                        Table.Computer_board.Invoke((MethodInvoker)delegate {
                            new_ship = new Ship(IsVertical, lenght, coordinates, key, "computer");
                        });
                    else
                        new_ship = new Ship(IsVertical, lenght, coordinates, key, "computer");
                    break;// if the ship is created, exit the loop  
                } catch (Exception) {
                    continue; //else , try again
                }
            }
        }

        private static Button[,] ResizeMatrix(Button[,] oldMatrix, int newRows, int newCols)
        {
            if (oldMatrix == null) return new Button[newRows, newCols];
            int oldRows = oldMatrix.GetLength(0);
            int oldCols = oldMatrix.GetLength(1);

            // Crea una nuova matrice con le nuove dimensioni
            Button[,] newMatrix = new Button[newRows, newCols];

            // Copia i valori dalla vecchia matrice alla nuova matrice
            for (int i = 0; i < Math.Min(oldRows, newRows); i++) // Evita fuoriuscite di indice
            {
                for (int j = 0; j < Math.Min(oldCols, newCols); j++)
                {
                    newMatrix[i, j] = oldMatrix[i, j];
                }
            }

            return newMatrix;
        }

        public static void DefineButton(Button[,] matrice_tabella, Panel Playing_board, int[] coordinates)
        {
            int column = coordinates[0];
            int row = coordinates[1];
            SeaTile tile = new SeaTile();

            // Utilizza Invoke per assegnare il Parent del bottone
            if (matrice_tabella[column, row] == null)
                Playing_board.Invoke((MethodInvoker)delegate {
                    create_button();
                });


            void create_button() {
                tile.Parent = Playing_board;
                tile.Top = row * 52;
                tile.Left = column * 70;
                tile.Width = 68;
                tile.Height = 50;
                tile.Tag = $"{column}|{row}";
                tile.Text = $"";

                // Apparence
                tile.FlatStyle = FlatStyle.Flat;
                tile.FlatAppearance.BorderSize = 0;
                tile.BackColor = Color.SkyBlue;

                // Events
                tile.Click += new EventHandler(Table.Board_buttonClick);
                matrice_tabella[column, row] = tile;            
            }
        }

        private static bool VerifyTableDimension(int table_width, Panel board, Button[,] board_matrix)
        {

            if (table_width < Table.table_dimension) {
                for (int x = Table.table_dimension - 1; x >= table_width; x--)
                {
                    for (int y = x; y >= 0; y--)
                    {
                        Table.Computer_board.Invoke((MethodInvoker)delegate
                        {
                                board.Controls.Remove(board_matrix[x, y]);
                                board.Controls.Remove(board_matrix[y, x]);
                                
                                board_matrix[y, x].Dispose();
                                board_matrix[x, y].Dispose();
                                
                                board_matrix[x, y] = null;
                                board_matrix[y, x] = null;
                        });
                    }
                }


                //board_matrix = new Button[table_width, table_width];

                return true;
            }

            return false;
        }
    }
}

