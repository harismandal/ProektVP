using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProektVP
{
    public partial class Form1 : Form
    {
        Player player;
        public static readonly int WORLD_WIDTH = 15;        // 15, 15 med 28,28 hard
        public static readonly int WORLD_HEIGHT = 15;
        public static int SIDE = 50;
        public static readonly int STEPS = 3;
        private static readonly int TIMER_INTERVAL = 50;
        private static readonly int SLEEP_INTERVAL = 3000;
       // private static readonly int SEE_DISTANCE = 5;
        public bool isAtStart;
        bool[,] maze;
        bool canMove;
        Door door;

        public Form1()
        {      
                InitializeComponent();
                isAtStart = true;
                newGame(WORLD_HEIGHT,WORLD_WIDTH);
        }

        public void newGame(int height,int width)
        {
             player = new Player(height, 1);
             MazeGenerator mg = new MazeGenerator(WORLD_HEIGHT, WORLD_WIDTH);
             maze = mg.generate();
             mg = null;
             door= new Door(1,WORLD_WIDTH);
           //  this.Width = SIDE * (width + 2)+16;         //to fix
           //  this.Height = SIDE * (height + 2)+42;             //to fix
             this.Width = 600+16;
             this.Height = 600+42;
             SIDE =600/Math.Max(WORLD_WIDTH+2, WORLD_HEIGHT+2);
             this.FormBorderStyle = FormBorderStyle.FixedSingle; //disables resize
             this.MaximizeBox = false;
             this.MinimizeBox = false;
             canMove = false;
             playSimpleSound();
        }

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Haris_2\Documents\Visual Studio 2013\Projects\ProektVP\ProektVP\assets\tank.wav");
            //SoundPlayer simpleSound = new SoundPlayer(@"assets\tank.wav");
            simpleSound.Play();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (canMove)
            {
                canMove = false;
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        player.direction = DIRECTION.Down;
                        if (maze[player.Y + 1, player.X])
                        {
                            canMove = true;
                            return;
                        }
                        break;
                    case Keys.Up:
                        player.direction = DIRECTION.Up;
                        if (maze[player.Y - 1, player.X])
                        {
                            canMove = true;
                            return;
                        }
                        break;
                    case Keys.Left:
                        player.direction = DIRECTION.Left;
                        if (maze[player.Y, player.X - 1])
                        {
                            canMove = true;
                            return;
                        }
                        break;
                    case Keys.Right:
                        player.direction = DIRECTION.Right;
                        if (maze[player.Y, player.X + 1])
                        {
                            canMove = true;
                            return;
                        }
                        break;
                    default:
                        break;
                }


                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (isAtStart == true)
            {
                Start(sender, e);
                Thread.Sleep(500);
                isAtStart = false;
            }
            Camera(sender, e);
        }


        private void Start(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.Black);
            player.drawX = player.X * SIDE;
            player.drawY = player.Y * SIDE;
            g.Clear(Color.White);
            door.Draw(g);
                for (int i = 0; i < WORLD_HEIGHT+2; i++)
                {
                    for (int j = 0; j < WORLD_WIDTH+2; j++)
                    {
                        if (maze[i, j])
                        {
                            g.FillRectangle(brush, j * SIDE, i * SIDE, SIDE, SIDE);
                        }
                    }
                }
                
              player.Draw(g);
             Thread.Sleep(SLEEP_INTERVAL);
            
            canMove = true;
            SIDE = 120;
        }

        
        private void Camera(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.Black);
            player.drawX = 2 * SIDE;
            player.drawY = 2 * SIDE;
            player.Move();
            for (int k = 0; k < STEPS; k++)
            {
                g.Clear(Color.White);
                Tuple<int, int> selectedDirection = player.GetOffset();
               // door.Draw(g);   //to fix
                int xOffset = selectedDirection.Item2 * (k - 2) * SIDE / STEPS;
                int yOffset = selectedDirection.Item1 * (k - 2) * SIDE / STEPS;
                for (int i = -3; i < 5; i++)
                {
                    for (int j = -3; j < 5; j++)
                    {

                        if (outOfBounds(player.Y + i, player.X + j)) g.FillRectangle(brush, (j + 2) * SIDE + xOffset, (i + 2) * SIDE + yOffset, SIDE, SIDE);
                        else if (maze[player.Y + i, player.X + j])
                        {
                            g.FillRectangle(brush, (j + 2) * SIDE + xOffset, (i + 2) * SIDE + yOffset, SIDE, SIDE);
                        }
                        else if ((player.Y+i)==1&&(player.X+j)==WORLD_WIDTH){
                            g.FillRectangle(new SolidBrush(Color.Brown), (j+2) * SIDE + xOffset, (i+2) * SIDE+yOffset, SIDE, SIDE); //door
                        }
                    }
                }

                /*int centerX = player.Y * SIDE + SIDE / 2;
                int centerY = player.X * SIDE + SIDE / 2;
                for (int i = 0; i < SIDE * (WORLD_HEIGHT + 1); i+=10)
                {
                    for (int j = 0; j < SIDE * (WORLD_WIDTH + 1); j+=10)
                    {
                        if (Math.Sqrt((centerX - j) * (centerX - j) + (centerY - i) * (centerY - i)) > (double)5*SIDE/2)
                            g.FillRectangle(new SolidBrush(Color.Gray), i, j, 10, 10);

                    }
                }*/
                
                
                //player.MoveAnimation();
                player.Draw(g);
                Thread.Sleep(TIMER_INTERVAL);
            }
            

            if (player.X == WORLD_WIDTH && player.Y == 1)
                Application.Exit();
            canMove = true;
        }

        private Boolean outOfBounds(int yCoordinate, int xCoordinate)
        {
            return (xCoordinate < 0 || xCoordinate > WORLD_WIDTH + 1 || yCoordinate < 0 || yCoordinate > WORLD_HEIGHT + 1);
        }

    }
}
