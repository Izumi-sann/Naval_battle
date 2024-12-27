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
        public string tile_type;
        public SeaTile()
        {
            isHit = false;
            this.tile_type = "sea";
        }

        public void HitTile()
        {
            isHit = true;
            BackColor = System.Drawing.Color.LightBlue;
        }
    }
}
