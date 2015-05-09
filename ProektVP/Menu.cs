using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProektVP
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HallOfFame highScores = new HallOfFame();
            highScores.easy = Form1.easyHighScores;
            highScores.medium = Form1.mediumHighScores;
            highScores.hard = Form1.hardHighScores;
            highScores.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The player (the dot) always starts at the lower left corner of the maze. The objective is to get to the door (it's easily distinguishable) and save your life from the daunting maze. You may move into tiles that do not have a wall on the (obviously) using the arrow keys (up, down, left, right), however you may not move diagonally. Every time a new game is created the player gets 1000 points at the start. Each second, these points decrease by a certain number, dependant on the difficulty. For the easy difficulty, the penalty is 5 points, for the medium one it's 10 and for the hard one it's 20. The points you get after the game is over are basically the points you have left. Bear in mind that there ARE negative points. After the game is over, you may view your best runs of the maze for each difficulty by clicking the High Scores button. Good luck and have fun!","How to play");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
