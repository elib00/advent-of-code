namespace solution.day4
{
    public class Solution
    {
        private char[][] CreateCharacterMatrix()
        {
            string path = "./inputs/day4.txt";
            string[] lines = File.ReadAllLines(path);

            int rows = lines.Length;
            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                string currRow = lines[i];
                int cols = currRow.Length;
                char[] copy = new char[cols];

                for (int j = 0; j < cols; j++)
                {
                    copy[j] = currRow[j];
                }

                matrix[i] = copy;
            }

            return matrix;
        }


        public int Solve()
        {
            char[][] matrix = CreateCharacterMatrix();

            bool[][] visited = new bool[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                visited[i] = new bool[matrix[i].Length];
            }

            int n = matrix.Length;
            int m = matrix[0].Length;
            int ans = 0;
            string word = "XMAS";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //meaning kakita tag sugod nga letter
                    if (matrix[i][j] == 'X')
                    {
                        // if (DFS(matrix, word, 0, i, j))
                        // {
                        //     ans++;
                        // }
                        ans += Traverse(matrix, word, i, j);
                    }
                }

            }

            return ans;
        }


        private int Traverse(char[][] matrix, string word, int i, int j)
        {
            int count = 0;
            string currWord = "";
            int ctr;
            int timesRepeat;
            //traverse left

            ctr = j;
            timesRepeat = 4;

            while (ctr >= 0 && timesRepeat != 0)
            {
                currWord += matrix[i][ctr--];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray()))
            {
                count++;
            }

            //right
            currWord = "";
            ctr = j;
            timesRepeat = 4;

            while (ctr < matrix[i].Length && timesRepeat != 0)
            {
                currWord += matrix[i][ctr++];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray()))
            {
                count++;
            }

            //up
            currWord = "";
            ctr = i;
            timesRepeat = 4;

            while (ctr >= 0 && timesRepeat != 0)
            {
                currWord += matrix[ctr--][j];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray()))
            {
                count++;
            }

            //down
            currWord = "";
            ctr = i;
            timesRepeat = 4;

            while (ctr < matrix.Length && timesRepeat != 0)
            {
                currWord += matrix[ctr++][j];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray()))
            {
                count++;
            }

            //top left
            int ctr2;

            currWord = "";
            ctr = i;
            ctr2 = j;
            timesRepeat = 4;

            while (ctr >= 0 && ctr2 >= 0 && timesRepeat != 0)
            {
                currWord += matrix[ctr--][ctr2--];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray()))
            {
                count++;
            }

            //top right
            currWord = "";
            ctr = i;
            ctr2 = j;
            timesRepeat = 4;

            while (ctr >= 0 && ctr2 < matrix[0].Length && timesRepeat != 0)
            {
                currWord += matrix[ctr--][ctr2++];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray())) count++;

            //bottom left
            currWord = "";
            ctr = i;
            ctr2 = j;
            timesRepeat = 4;

            while (ctr < matrix.Length && ctr2 >= 0 && timesRepeat != 0)
            {
                currWord += matrix[ctr++][ctr2--];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray())) count++;

            //bottom right
            currWord = "";
            ctr = i;
            ctr2 = j;
            timesRepeat = 4;

            while (ctr < matrix.Length && ctr2 < matrix[0].Length && timesRepeat != 0)
            {
                currWord += matrix[ctr++][ctr2++];
                timesRepeat--;
            }

            if (currWord == word || currWord == new string(word.Reverse().ToArray()))
            {
                count++;
            }

            return count;
        }
    }
}