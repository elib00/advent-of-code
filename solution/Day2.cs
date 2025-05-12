using System;
using System.IO;

namespace solution
{
    public class Day2
    {
        public int Solve()
        {
            int[][] matrix = CreateMatrixFromInput();

            int n = matrix.Length;
            int ans = 0;

            for (int i = 0; i < n; i++)
            {
                int checkTrend = GetTrend(matrix[i]);
                if (checkTrend != -1)
                {
                    ans++;
                }
                else
                {
                    bool canBeSaved = false;
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        int[] modified = RemoveAt(matrix[i], j);
                        if (GetTrend(modified) != -1)
                        {
                            canBeSaved = true;
                            break;
                        }
                    }

                    if (canBeSaved) ans++;
                }
            }

            return ans;
        }

        private int[][] CreateMatrixFromInput()
        {
            string path = "./inputs/day2.txt";
            string[] lines = File.ReadAllLines(path);
            int rows = lines.Length;

            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                string[] parts = lines[i].Split(" ");
                int[] row = new int[parts.Length];

                for (int j = 0; j < parts.Length; j++)
                {
                    row[j] = int.Parse(parts[j]);
                }


                matrix[i] = row;
            }

            return matrix;
        }

        private int GetTrend(int[] arr)
        {
            //0 - inc
            //1 - dec

            int trend = -1;
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    //should be increasing
                    if (trend == -1)
                    {
                        trend = 0;
                    }
                    else if (trend == 1) // if the trend is already decreasing
                    {
                        return -1;
                        // return trend;
                    }
                }
                else if (arr[i] > arr[i + 1])
                {
                    if (trend == -1)
                    {
                        trend = 1;
                    }
                    else if (trend == 0)
                    {
                        return -1;
                    }
                }

                int diff = Math.Abs(arr[i + 1] - arr[i]);
                if (diff < 1 || diff > 3)
                {
                    return -1;
                }
            }

            return trend;
        }

        private int[] RemoveAt(int[] arr, int index)
        {
            int n = arr.Length;
            int[] newArray = new int[n - 1];
            int curr = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == index) continue;

                newArray[curr++] = arr[i];
            }

            return newArray;
        }
    }
}
