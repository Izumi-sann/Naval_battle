using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battaglia_navale
{
    internal class Ship
    {
        private string name { get; set; } public string Name { get => name; }
        private int length{ get; set; } public int Length { get => length; }
        public bool isDestroyed; 
        public bool IsVertical;
        public List<Ship_tile> ship_tiles;

        public Ship(bool IsVertical, int lenght) {
            this.name = name;
            this.length = lenght;
            this.isDestroyed = false;
            this.IsVertical = IsVertical;
            this.ship_tiles = new List<Ship_tile>();
        }

        //funzione che crea le caselle della nave
        //verifica prima disponibilità di spazio, altrimenti elimina nave
    }
}
