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
    public partial class Difficulty : Form
    {
        public GameDifficulty difficulty;
        public Difficulty()
        {
            InitializeComponent();
        }

        private void easyDifficultyBtn_Click(object sender, EventArgs e)
        {
            difficulty = new GameDifficulty(DIFFICULTY.easy);
            Form1 Game = new Form1(difficulty);
            Game.Show();
            Close();
        }

        private void mediumDifficultyBtn_Click(object sender, EventArgs e)
        {
            difficulty = new GameDifficulty(DIFFICULTY.medium);
            Form1 Game = new Form1(difficulty);
            Game.Show();
            Close();
        }

        private void hardDifficultyBtn_Click(object sender, EventArgs e)
        {
            difficulty = new GameDifficulty(DIFFICULTY.hard);
            Form1 Game = new Form1(difficulty);
            Game.Show();
            Close();
        }
    }
}
