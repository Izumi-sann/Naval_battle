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

        public Ship(bool IsVertical, int lenght, int[] coordinates ,string name) {
            if (!VerificaSpazio(Table.user_board_matrix, lenght, IsVertical, coordinates))
                throw new ArgumentException("position is not acceppted, the selected ship is too big.");

            this.name = name;
            this.length = lenght;
            this.isDestroyed = false;
            this.IsVertical = IsVertical;
            this.coordinates = coordinates;
            this.ship_tiles = SetTiles(name, lenght, coordinates, IsVertical);
        }


        private bool VerificaSpazio(Button[,] user_board, int lenght, bool IsVertical, int[] coordinates) {//verifica intersezione con altre navi
            if (IsVertical)
                return coordinates[1] + lenght - 1 < user_board.GetLength(1) ? true : false;

            //is horizontal
            return coordinates[0] + lenght -1 < user_board.GetLength(1) ? true : false;
        }

        //funzione che crea le caselle della nave
        private Ship_tile[] SetTiles(string name, int lenght, int[] coordinates, bool IsVertical) {
            Ship_tile[] ship_tiles = new Ship_tile[lenght];

            if (IsVertical) { 
                for (int i = 0; i < lenght; i++)
                    ship_tiles[i] = new Ship_tile(name, new int[]{coordinates[0], coordinates[1]+i});
            }
            else//horizontal
                for (int i = 0; i < lenght; i++)
                    ship_tiles[i] = new Ship_tile(name, new int[] { coordinates[0] + i, coordinates[1] });


            return ship_tiles;
        }
    }
}
