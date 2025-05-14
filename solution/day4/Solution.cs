using System.Numerics;

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
                        if (DFS(matrix, word, 0, i, j))
                        {
                            ans++;
                        }
                    }

                }
            }

            return ans;
        }

        private bool DFS(char[][] matrix, string word, int index, int i, int j)
        {
            if (i < 0 || i >= matrix.Length) return false;
            if (j < 0 || j >= matrix[0].Length) return false;
            if (matrix[i][j] != word[index]) return false;

            if (index == word.Length - 1) return true;

            char temp = matrix[i][j];
            matrix[i][j] = '#';

            bool up = DFS(matrix, word, index + 1, i - 1, j);
            bool down = DFS(matrix, word, index + 1, i + 1, j);
            bool left = DFS(matrix, word, index + 1, i, j - 1);
            bool right = DFS(matrix, word, index + 1, i, j + 1);
            bool upLeft = DFS(matrix, word, index + 1, i - 1, j - 1);
            bool upRight = DFS(matrix, word, index + 1, i - 1, j + 1);
            bool downLeft = DFS(matrix, word, index + 1, i + 1, j - 1);
            bool downRight = DFS(matrix, word, index + 1, i + 1, j + 1);

            matrix[i][j] = temp;

            return up || down || left || right || upLeft || upRight || downLeft || downRight;
        }


    }
}