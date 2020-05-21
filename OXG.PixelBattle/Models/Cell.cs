using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OXG.PixelBattle.Models
{
    public class Cell
    {
        public int Id { get; set; }

        private int X { get; set; }

        private int Y { get; set; }

        public string Color { get; set; }

        public string GetElemId() => X.ToString() + "-" + Y.ToString();

        public Cell(int X, int Y, string color)
        {
            this.X = X;
            this.Y = Y;
            Color = color;
        }

        public Cell()
        {

        }
    }
}
