using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektVP
{
    public enum DIFFICULTY { easy = 5, medium = 15, hard = 28 };
    public class GameDifficulty
    {
        public DIFFICULTY difficulty { get; set; }

        public GameDifficulty(DIFFICULTY Difficulty)
        {
            difficulty = Difficulty;
        }
    }
}
