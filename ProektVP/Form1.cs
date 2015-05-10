using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ProektVP
{
    public partial class Form1 : Form
    {
        private SoundPlayer simpleSound;
        public static Player player;
        public static List<Player> easyHighScores = new List<Player>();
        public static List<Player> mediumHighScores = new List<Player>();
        public static List<Player> hardHighScores = new List<Player>();
        public static int WORLD_WIDTH = 15;        //5,5 easy 15, 15 medium 28,28 hard
        public static int WORLD_HEIGHT = 15;
        public static int SIDE = 50;
        public static readonly int STEPS = 3;
        private static readonly int TIMER_INTERVAL = 40;
        private static readonly int SLEEP_INTERVAL = 1200;
        private static int difficultyPenalty;
        private static DIFFICULTY difficulty;
        private int timePassed;
        public bool isAtStart;
        bool[,] maze;
        private static bool canMove;
        Door door;
        private static Brush brush = new SolidBrush(Color.Black);
        private static Brush doorBrush = new SolidBrush(Color.Brown);
        private static int animCount;
        private static int xOffset;
        private static int yOffset;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerAnim;
        private bool startGame;

        public Form1(GameDifficulty Difficulty)
        {
            InitializeComponent();
            isAtStart = true;
            canMove = false;
            DoubleBuffered = true;
            difficulty = Difficulty.difficulty;
            if (difficulty == DIFFICULTY.easy)
                difficultyPenalty = 5;
            if (difficulty == DIFFICULTY.medium)
                difficultyPenalty = 10;
            if (difficulty == DIFFICULTY.hard)
                difficultyPenalty = 20;
            WORLD_WIDTH = (int)difficulty;
            WORLD_HEIGHT = (int)difficulty;
            newGame(WORLD_WIDTH, WORLD_HEIGHT);
        }

        public void newGame(int height, int width)
        {
            player = new Player(height, 1);
            scoreCounterLbl.Text = "Score: 1000";
            startGame = false;
            timePassed = 0;
            MazeGenerator mg = new MazeGenerator(WORLD_HEIGHT, WORLD_WIDTH);
            maze = mg.generate();
            mg = null;
            door = new Door(1, WORLD_WIDTH);
            this.Width = 600 + 16;
            this.Height = 600 + 42;
            SIDE = 600 / Math.Max(WORLD_WIDTH + 2, WORLD_HEIGHT + 2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //disables resize
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            playSimpleSound();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = SLEEP_INTERVAL;
            timer.Start();
            timerAnim = new System.Windows.Forms.Timer();
            timerAnim.Tick += new EventHandler(timerAnim_Tick);
            timerAnim.Interval = 1000 / TIMER_INTERVAL;
            Invalidate();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (startGame)
            {
                SIDE = 120;
                player.drawX = 2 * SIDE;
                player.drawY = 2 * SIDE;
                isAtStart = false;
                canMove = true;
                scoreCounterLbl.Visible = true;
                timer.Stop();
                scoreTimer.Start();
            }
            else startGame = true;
        }
        private void timerAnim_Tick(object sender, EventArgs e)
        {
            Tuple<int, int> selectedDirection = player.GetOffset();
            xOffset = selectedDirection.Item2 * (animCount - 2) * SIDE / STEPS;
            yOffset = selectedDirection.Item1 * (animCount - 2) * SIDE / STEPS;
            if (animCount == 2)
            {
                canMove = true;
                timerAnim.Stop();
                if (player.X == WORLD_WIDTH && player.Y == 1)
                {
                    scoreTimer.Stop();
                    simpleSound.Stop();
                    Invalidate();
                    String message = "You beat the game in " + timePassed.ToString() + " seconds and won " + player.score.ToString() + " points!";
                    MessageBox.Show(message, "CONGRATULATIONS!");
                    NameInput nameInput = new NameInput();
                    nameInput.Show();
                    player.name = nameInput.name;
                    if (difficulty == DIFFICULTY.easy)
                        easyHighScores.Add(player);
                    if (difficulty == DIFFICULTY.medium)
                        mediumHighScores.Add(player);
                    if (difficulty == DIFFICULTY.hard)
                        hardHighScores.Add(player);

                    Close();
                }
            }
            else animCount++;
            Invalidate();
        }
        private void playSimpleSound()
        {
            simpleSound = new SoundPlayer(@"tank.wav");
            simpleSound.PlayLooping();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isAtStart)
            {
                player.direction = DIRECTION.None;
                canMove = true;
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                simpleSound.Stop();
                Close();
            }
            if (canMove)
            {
                canMove = false;
            }
            else return;

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (maze[player.Y + 1, player.X])
                    {
                        player.direction = DIRECTION.None;
                        canMove = true;
                        return;
                    }
                    else player.direction = DIRECTION.Down;
                    break;
                case Keys.Up:
                    if (maze[player.Y - 1, player.X])
                    {
                        player.direction = DIRECTION.None;
                        canMove = true;
                        return;
                    }
                    else player.direction = DIRECTION.Up;
                    break;
                case Keys.Left:
                    if (maze[player.Y, player.X - 1])
                    {
                        player.direction = DIRECTION.None;
                        canMove = true;
                        return;
                    }
                    else player.direction = DIRECTION.Left;
                    break;
                case Keys.Right:
                    if (maze[player.Y, player.X + 1])
                    {
                        player.direction = DIRECTION.None;
                        canMove = true;
                        return;
                    }
                    else player.direction = DIRECTION.Right;
                    break;
                default:
                    {
                        player.direction = DIRECTION.None;
                        canMove = true;
                        return;
                    }
            }

            player.Move();
            animCount = 0;
            timerAnim.Start();
        }

        private void Start(object sender, Graphics g)
        {
            scoreCounterLbl.Visible = false;
            player.drawX = player.X * SIDE;
            player.drawY = player.Y * SIDE;

            door.Draw(g);
            for (int i = 0; i < WORLD_HEIGHT + 2; i++)
            {
                for (int j = 0; j < WORLD_WIDTH + 2; j++)
                {
                    if (maze[i, j])
                    {
                        g.FillRectangle(brush, j * SIDE, i * SIDE, SIDE, SIDE);
                    }
                }
            }
        }

        private void Camera(object sender, Graphics g)
        {
            for (int i = -3; i < 5; i++)
            {
                for (int j = -3; j < 5; j++)
                {
                    if (outOfBounds(player.Y + i, player.X + j)) g.FillRectangle(brush, (j + 2) * SIDE + xOffset, (i + 2) * SIDE + yOffset, SIDE, SIDE);
                    else if (maze[player.Y + i, player.X + j])
                    {
                        g.FillRectangle(brush, (j + 2) * SIDE + xOffset, (i + 2) * SIDE + yOffset, SIDE, SIDE);
                    }
                    else if ((player.Y + i) == 1 && (player.X + j) == WORLD_WIDTH)
                    {
                        g.FillRectangle(doorBrush, (j + 2) * SIDE + xOffset, (i + 2) * SIDE + yOffset, SIDE, SIDE); //door
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            if (isAtStart)
                Start(sender, g);
            else
                Camera(sender, g);
            player.Draw(g);
        }

        private Boolean outOfBounds(int yCoordinate, int xCoordinate)
        {
            return (xCoordinate < 0 || xCoordinate > WORLD_WIDTH + 1 || yCoordinate < 0 || yCoordinate > WORLD_HEIGHT + 1);
        }

        private void scoreTimer_Tick(object sender, EventArgs e)
        {
            player.score -= difficultyPenalty;
            timePassed++;
            scoreCounterLbl.Text = "Score: " + player.score.ToString();
        }

    }
}
