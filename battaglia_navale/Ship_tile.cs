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
        public int[] position;
        public bool isDestroyed;

        public Ship_tile()
        {
            this.isDestroyed = false;
            this.BackColor = System.Drawing.Color.DarkGray;
        }

        public void SetPosition(int[] position)
        {
            this.position = position;
        }

        public void SetDestroyed(bool isDestroyed)
        {
            this.isDestroyed = isDestroyed;
            this.BackColor = System.Drawing.Color.Red;
        }

    }
}
