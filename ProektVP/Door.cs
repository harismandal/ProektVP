using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektVP
{
    class Door
    {
        public int X { get; set; }
        public int Y { get; set; }
        static Brush brush = new SolidBrush(Color.Brown);
        public Door(int yCoordinate, int xCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }
        public void Draw(Graphics g)
        {
            g.FillRectangle(brush, X * Form1.SIDE, Y * Form1.SIDE, Form1.SIDE, Form1.SIDE);
        }
    }
}
