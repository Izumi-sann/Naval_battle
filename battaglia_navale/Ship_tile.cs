using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace battaglia_navale
{
    internal class Ship_tile : Button
    {
        public Point position;
        public bool isPlaced;
        public bool isDestroyed;

        public Ship_tile()
        {
            this.isPlaced = false;
            this.isDestroyed = false;
            this.BackColor = System.Drawing.Color.DarkGray;
        }

        public void SetPosition(int[] position)
        {
            this.position = new Point(position[0], position[1]);
        }

        public void SetPlaced(bool isPlaced)
        {
            this.isPlaced = isPlaced;
        }

        public void SetDestroyed(bool isDestroyed)
        {
            this.isDestroyed = isDestroyed;
            this.BackColor = System.Drawing.Color.Red;
        }
    }
}
