using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektVP
{
    class MazeGenerator
    {
        int n, m;
        bool[,] maze;
        readonly int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

        Random rnd;
        public MazeGenerator(int rN, int rM)
        {
            n = rN + 2;
            m = rM + 2;
            maze = new bool[n, m];
            rnd = new Random();
        }

        public bool[,] generate()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    maze[i, j] = false;
            Tuple<int, int> firstCell = new Tuple<int, int>(rnd.Next(1, n - 1), rnd.Next(1, m - 1));
            dfs(firstCell);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    maze[i, j] = !maze[i, j];
            for (int ctr1 = n - 2; maze[ctr1, 1];ctr1--)
                maze[ctr1, 1] = false;
            for (int ctr1 = 1; maze[ctr1, m-2];ctr1++)
                maze[ctr1, m-2] = false;
                    return maze;
        }

        void dfs(Tuple<int, int> currentCell)
        {
            maze[currentCell.Item1, currentCell.Item2] = true;
            int[] order = shuffleArray();
            for (int ctr1 = 0; ctr1 < 4; ctr1++)
            {
                Tuple<int, int> nextCell = new Tuple<int, int>(currentCell.Item1 + directions[order[ctr1], 0], currentCell.Item2 + directions[order[ctr1], 1]);
                if (checkCell(nextCell))
                {
                    dfs(nextCell);
                }
            }
        }

        int[] shuffleArray()
        {
            int[] order = { 0, 1, 2, 3 };
            for (int ctr1 = 0; ctr1 < 4; ctr1++)
            {
                int goesHere = rnd.Next(ctr1, 4);
                int temp = order[ctr1];
                order[ctr1] = order[goesHere];
                order[goesHere] = temp;
            }
            return order;
        }
        bool checkCell(Tuple<int, int> currentCell)
        {
            if (currentCell.Item1 <= 0 || currentCell.Item1 >= n - 1)
                return false;
            if (currentCell.Item2 <= 0 || currentCell.Item2 >= m - 1)
                return false;
            if (maze[currentCell.Item1, currentCell.Item2])
                return false;
            int doneNeighbours = 0;
            for (int ctr1 = 0; ctr1 < 4; ctr1++)
            {
                Tuple<int, int> nextCell = new Tuple<int, int>(currentCell.Item1 + directions[ctr1, 0], currentCell.Item2 + directions[ctr1, 1]);
                if (maze[nextCell.Item1, nextCell.Item2])
                    doneNeighbours++;
            }
            if (doneNeighbours > 1)
                return false;
            return true;
        }


    }
}
