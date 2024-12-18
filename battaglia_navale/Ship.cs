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
        public List<Ship_tile> ship_tiles; //le tiles della barca

        public Ship(bool IsVertical, int lenght, int[] coordinates ,string name) {
            if (!VerificaSpazio(Table.user_board_matrix, lenght, IsVertical, coordinates))
                throw new ArgumentException("position is not acceppted, the selected ship is too big.");

            this.name = name;
            this.length = lenght;
            this.isDestroyed = false;
            this.IsVertical = IsVertical;
            this.coordinates = coordinates;
            this.ship_tiles = new List<Ship_tile>();
        }


        private bool VerificaSpazio(Button[,] user_board, int lenght, bool IsVertical, int[] coordinates) {
            if (IsVertical)
                return coordinates[1] + lenght - 1 < user_board.GetLength(1) ? true : false;

            //is horizontal
            return coordinates[0] + lenght -1 < user_board.GetLength(1) ? true : false;


        }

        //funzione che crea le caselle della nave
    }
}
