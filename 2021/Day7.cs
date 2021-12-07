using System;
using System.IO;
using System.Linq;

namespace Advent2021
{
    public class Day7
    {
        int[] sdata = { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
        int[] data;

        public Day7()
        {
            data = File.ReadAllText("2021/data/Day7.txt").Split(',').Select(x => int.Parse(x)).ToArray();
        }

        internal void Part1()
        {
            int min = data.Min();
            int max = data.Max();
            int bestResult = int.MaxValue;
            int bestVal = -1;

            for (int i = min; i <= max; i++)
            {
                int result = MoveTo(i, data);
                if (result < bestResult)
                {
                    bestResult = result;
                    bestVal = i;
                }
            }
            System.Console.WriteLine("Part1: " + bestResult + " " + bestVal);
        }

        internal void Part2()
        {
            int min = data.Min();
            int max = data.Max();
            int bestResult = int.MaxValue;
            int bestVal = -1;

            for (int i = min; i <= max; i++)
            {
                int result = MoveToP2(i, data);
                if (result < bestResult)
                {
                    bestResult = result;
                    bestVal = i;
                }
            }
            System.Console.WriteLine("Part2: " + bestResult + " " + bestVal);
        }

        private int MoveTo(int x, int[] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > x)
                {
                    counter += arr[i] - x;
                }
                if (arr[i] < x)
                {
                    counter += x - arr[i];
                }
            }
            return counter;
        }

        private int MoveToP2(int x, int[] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > x)
                {
                    for (int j = 0; j <= arr[i] - x; j++)
                    {
                        counter += j;
                    }
                }
                if (arr[i] < x)
                {
                    for (int j = 0; j <= x - arr[i]; j++)
                    {
                        counter += j;
                    }
                }
            }
            return counter;
        }
    }
}