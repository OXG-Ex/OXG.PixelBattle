using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OXG.PixelBattle.Models
{
    public class Cell //Представляет закрашенную клетку
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Color { get; set; }

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
