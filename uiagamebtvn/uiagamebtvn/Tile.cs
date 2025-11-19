using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    public class Tile
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public Character Occupant { get; set; }

        public Tile(int x, int y)
        {
            PosX = x;
            PosY = y;
            Occupant = null;
        }

        public bool IsOccupied()
        {
            return Occupant != null;
        }

        public string GetDisplaySymbol()
        {
            if (!IsOccupied()) return "X";
            return Occupant.Symbol;
        }
    }
}

