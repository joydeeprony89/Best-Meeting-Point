using System;
using System.Collections.Generic;
using System.Linq;

namespace Best_Meeting_Point
{

    /*
     * A group of two or more people wants to meet and minimize the total travel distance. You are given a 2D grid of values 0 or 1, where each 1 marks the home of someone in the group. The distance is calculated using Manhattan Distance, where distance(p1, p2) = |p2.x - p1.x| + |p2.y - p1.y|.

        Example:

        Input: 

        1 - 0 - 0 - 0 - 1
        |   |   |   |   |
        0 - 0 - 0 - 0 - 0
        |   |   |   |   |
        0 - 0 - 1 - 0 - 0

        Output: 6 

        Explanation: Given three people living at (0,0), (0,4), and (2,2):
                     The point (0,2) is an ideal meeting point, as the total travel distance 
                     of 2+2+2=6 is minimal. So return 6.
     * 
     *// https://leetcode.com/problems/best-meeting-point/discuss/74186/14ms-java-solution
     * */
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[3][];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new int[5];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if ((i == 0 && j == 0) || (i == 0 && j == 4) || (i == 2 && j == 2))
                        grid[i][j] = 1;
                    else
                        grid[i][j] = 0;
                }
            }

            Console.WriteLine(MinTotalDistance(grid));
        }

        static int MinTotalDistance(int[][] grid)
        {
            int row = grid.Length;
            int column = grid[0].Length;
            List<int> listRow = new List<int>();
            List<int> listColumn = new List<int>();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    if (grid[i][j] == 1)
                    {
                        listRow.Add(i);
                        listColumn.Add(j);
                    }
            return GetMin(listRow) + GetMin(listColumn);
        }

        static int GetMin(List<int> list)
        {
            list.Sort();
            int sum = 0;
            int i = 0, j = list.Count - 1;
            while (i <= j)
            {
                sum += list[j--] - list[i++];
            }
            return sum;
        }
    }
}
