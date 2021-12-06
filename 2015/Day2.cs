using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2015
{
    public class Day2
    {
        List<int[]> dimensions;

        public Day2()
        {
            dimensions = ParseData();
        }

        private List<int[]> ParseData()
        {
            return File.ReadAllLines("2015/data/Day2.txt")
                .Select(line => line.Split("x").Select(int.Parse).ToArray())
                .ToList();
        }

        internal void SolvePart1()
        {
            int total = 0;
            foreach (var test in dimensions)
            {
                int[] d = { (test[0] * test[1]) * 2,
                            (test[1] * test[2]) * 2,
                            (test[0] * test[2]) * 2, };

                total += d.Sum() + (d.Min() / 2);
            }
            System.Console.WriteLine("Total: " + total);
        }

        internal void SolvePart2()
        {
            int total = 0;
            foreach (var test in dimensions)
            {
                int max = test.Max();
                int area = test[0] * test[1] * test[2];

                int bowL = (test[0] * 2) + (test[1] * 2) + (test[2] * 2) - (max * 2);

                total += area + bowL;
            }
            System.Console.WriteLine("Total: " + total);
        }

        public void PrintArray()
        {
            foreach (var item in dimensions)
            {
                foreach (var n in item) System.Console.Write(n + " ");
                System.Console.WriteLine();
            }
        }
    }
}