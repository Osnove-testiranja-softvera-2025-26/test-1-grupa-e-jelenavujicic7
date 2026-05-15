

using System;

namespace OTS2026_GrupaE.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position()
        {

        }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        override
        public bool Equals(Object obj)
        {
            return ((Position)obj).X == X && ((Position)obj).Y == Y && ((Position)obj).Z == Z;
        }
    }
}
