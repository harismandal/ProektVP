using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProektVP
{
    public enum DIRECTION { Up, Down, Left, Right, None };
    public class Player
    {
        public int score;
        public string name;
        public Brush brush = new SolidBrush(Color.Red);
        public int X { get; set; }
        public int Y { get; set; }
        public int drawX { get; set; }
        public int drawY { get; set; }
        public DIRECTION direction { get; set; }

        public Player(int yCoordinate,int xCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
            direction = DIRECTION.None;
            score=1000;
        }

        public void Move()
        {
            if (direction == DIRECTION.Right)
            {
                X++;
                return;
            }
            if (direction == DIRECTION.Left)
            {
                X--;
                return;
            }
            if (direction == DIRECTION.Up)
            {
                Y--;
                return;
            }
            if (direction == DIRECTION.Down)
            {
                Y++;
                return;
            }
        }

        public Tuple<int,int> GetOffset()
        {
            if (direction == DIRECTION.Right)
            {
                return new Tuple<int, int>(0, -1); 
            }
            else if (direction == DIRECTION.Left)
            {
                return new Tuple<int, int>(0, 1); 
            }
            else if (direction == DIRECTION.Up)
            {
                return new Tuple<int, int>(1, 0); 
            }
            else  if (direction == DIRECTION.Down)
            {
                return new Tuple<int, int>(-1, 0); 
            }
            return new Tuple<int, int>(0, 0); 
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(brush, drawX, drawY, Form1.SIDE, Form1.SIDE);
        }


    }
}
