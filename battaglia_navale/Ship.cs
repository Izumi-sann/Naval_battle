using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battaglia_navale
{
    internal class Ship
    {
        private string name { get; set; } public string Name { get => name; } // lettera iniziale della barca
        private int length{ get; set; } public int Length { get => length; } // caselle occupate
        private int[] coordinates { get; set; } public int[] Coordinates { get => coordinates; }
        
        public bool isDestroyed; //tutte le tiles della barca sono distrutte
        public bool IsVertical; //true: vertical; false:horizontal
        public Ship_tile[] ship_tiles; //le tiles della barca

        public Ship(bool IsVertical, int lenght, int[] coordinates, string name, string sender) {
            Panel board = sender == "user" ? Table.User_board : Table.Computer_board;
            Button[,] board_matrix = sender == "user" ? Table.user_board_matrix : Table.computer_board_matrix;

            if (!VerificaSpazio(board_matrix, lenght, IsVertical, coordinates))
                throw new ArgumentException("position is not acceppted, the selected ship is too big.");

            this.name = name;
            this.length = lenght;
            this.isDestroyed = false;
            this.IsVertical = IsVertical;
            this.coordinates = coordinates;
            this.ship_tiles = SetTiles(name, lenght, coordinates, IsVertical, sender);
        }

        private bool VerificaSpazio(Button[,] board, int lenght, bool IsVertical, int[] coordinates) {//verifica intersezione con altre navi

            if (IsVertical) {
                if (!(coordinates[1] + lenght - 1 < board.GetLength(1)))
                    return false;

                for(int i = 0; i<lenght; i++) 
                    if (board[coordinates[0], coordinates[1] + i].Tag.ToString() == "ship tile")
                        return false;
            }
            else {
                if (!(coordinates[0] + lenght - 1 < board.GetLength(0)))
                    return false;

                for (int i = 0; i < lenght; i++)
                    if (board[coordinates[0] + i, coordinates[1]].Tag.ToString() == "ship tile")
                        return false;
            }

            return true;
        }

        private Ship_tile[] SetTiles(string name, int lenght, int[] coordinates, bool IsVertical, string sender) {
            Ship_tile[] ship_tiles = new Ship_tile[lenght];

            if (IsVertical) { 
                for (int i = 0; i < lenght; i++)
                    ship_tiles[i] = new Ship_tile(name, new int[]{coordinates[0], coordinates[1]+i}, sender);
            }
            else { //horizontal 
                for (int i = 0; i < lenght; i++)
                    ship_tiles[i] = new Ship_tile(name, new int[] { coordinates[0] + i, coordinates[1] }, sender);
            }


            return ship_tiles;
        }
    
        public void RemoveShip()
        {
            int[] coordinates = this.coordinates;
            int lenght = this.length;

            //rimuovere controllo, rimuovere da matrix, dispose elemento, aggiunta nuovo pulsante
            if (this.IsVertical) { 
                for (int i = 0; i < length; i++) {
                    Table.User_board.Controls.Remove(Table.user_board_matrix[coordinates[0], coordinates[1] + i]);
                    Table.user_board_matrix[coordinates[0], coordinates[1] + i].Dispose();
                    Table.user_board_matrix[coordinates[0], coordinates[1] + i] = null;
                    Menu.DefineButton(Table.user_board_matrix, Table.User_board, new int[] { coordinates[0], coordinates[1] + i });
                }
            }
            else {
                for (int i = 0; i < length; i++) { 
                    Table.User_board.Controls.Remove(Table.user_board_matrix[coordinates[0] + i, coordinates[1]]);
                    Table.user_board_matrix[coordinates[0] + i, coordinates[1]].Dispose();
                    Table.user_board_matrix[coordinates[0] + i, coordinates[1]] = null;
                    Menu.DefineButton(Table.user_board_matrix, Table.User_board, new int[] { coordinates[0] + i, coordinates[1]});
                }
            }
        }
    }
}
