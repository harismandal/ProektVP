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
    public partial class HallOfFame : Form
    {
        public List<Player> easy = new List<Player>();
        public List<Player> medium = new List<Player>();
        public List<Player> hard = new List<Player>();
        public HallOfFame()
        {
            InitializeComponent();
        }

        private void listBox1_Enter_1(object sender, EventArgs e)
        {
            highScoresLb.Items.Add("Easy difficulty:");
            easy = easy.OrderByDescending(x => x.score).ToList();
            foreach (Player player in easy)
            {
                if (player.name != null)
                {
                    String entry = player.name + "    " + player.score.ToString();
                    highScoresLb.Items.Add(entry);
                }
            }
            highScoresLb.Items.Add("Medium difficulty:");
            medium = medium.OrderByDescending(x => x.score).ToList();
            foreach (Player player in medium)
            {
                if (player.name != null)
                {
                    String entry = player.name + "    " + player.score.ToString();
                    highScoresLb.Items.Add(entry);
                }
            }
            highScoresLb.Items.Add("Hard difficulty:");
            hard = hard.OrderByDescending(x => x.score).ToList();
            foreach (Player player in hard)
            {
                if (player.name != null)
                {
                    String entry = player.name + "    " + player.score.ToString();
                    highScoresLb.Items.Add(entry);
                }
            }
        }
    }
}
