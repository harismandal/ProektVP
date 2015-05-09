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
            listBox1.Items.Add("Easy difficulty:");
            easy = easy.OrderByDescending(x => x.score).ToList();
            foreach (Player player in easy)
            {
                String entry = player.name + "    " + player.score.ToString();
                listBox1.Items.Add(entry);
            }
            listBox1.Items.Add("Medium difficulty:");
            medium = medium.OrderByDescending(x => x.score).ToList();
            foreach (Player player in medium)
            {
                String entry = player.name + "    " + player.score.ToString();
                listBox1.Items.Add(entry);
            }
            listBox1.Items.Add("Hard difficulty:");
            hard = hard.OrderByDescending(x => x.score).ToList();
            foreach (Player player in hard)
            {
                String entry = player.name + "    " + player.score.ToString();
                listBox1.Items.Add(entry);
            }
        }
    }
}
