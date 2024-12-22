using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battaglia_navale
{
    internal class SeaTile : Button
    {
        public bool isHit { get; set; }

        public SeaTile()
        {
            isHit = false;
        }

        public void HitTile()
        {
            isHit = true;
            BackColor = System.Drawing.Color.LightBlue;
        }
    }
}
