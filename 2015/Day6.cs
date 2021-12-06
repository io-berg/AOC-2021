using System;
using System.Collections.Generic;
using System.IO;

namespace Advent2015
{
    public class Day6
    {
        List<string> instructions;
        int[][] grid = new int[1000][];

        public Day6()
        {
            instructions = ParseData();

            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new int[1000];

                for (int j = 0; j < grid[i].Length; j++)
                {
                    grid[i][j] = 0;
                }
            }
        }

        internal void Part2()
        {
            foreach (var item in instructions)
            {

                string[] ss = item.Split(" ");
                int[] start = new int[2];
                int[] end = new int[2];

                if (ss[0] == "turn")
                {
                    start[0] = int.Parse(ss[2].Split(",")[0]);
                    start[1] = int.Parse(ss[2].Split(",")[1]);
                    end[0] = int.Parse(ss[4].Split(",")[0]);
                    end[1] = int.Parse(ss[4].Split(",")[1]);

                    if (ss[1] == "off")
                    {
                        TurnOffP2(start, end);
                    }
                    else TurnOnP2(start, end);
                }
                else
                {
                    start[0] = int.Parse(ss[1].Split(",")[0]);
                    start[1] = int.Parse(ss[1].Split(",")[1]);
                    end[0] = int.Parse(ss[3].Split(",")[0]);
                    end[1] = int.Parse(ss[3].Split(",")[1]);
                    ToggleP2(start, end);
                }
            }

            int lightCount = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    lightCount += grid[i][j];
                }
            }
            System.Console.WriteLine(lightCount);
        }

        internal void Part1()
        {
            foreach (var item in instructions)
            {
                string[] ss = item.Split(" ");
                int[] start = new int[2];
                int[] end = new int[2];

                if (ss[0] == "turn")
                {
                    start[0] = int.Parse(ss[2].Split(",")[0]);
                    start[1] = int.Parse(ss[2].Split(",")[1]);
                    end[0] = int.Parse(ss[4].Split(",")[0]);
                    end[1] = int.Parse(ss[4].Split(",")[1]);

                    if (ss[1] == "off")
                    {
                        TurnOff(start, end);
                    }
                    else TurnOn(start, end);
                }
                else
                {
                    start[0] = int.Parse(ss[1].Split(",")[0]);
                    start[1] = int.Parse(ss[1].Split(",")[1]);
                    end[0] = int.Parse(ss[3].Split(",")[0]);
                    end[1] = int.Parse(ss[3].Split(",")[1]);
                    Toggle(start, end);
                }
            }

            int lightCount = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) lightCount++;
                }
            }
            System.Console.WriteLine(lightCount);
        }

        private void TurnOn(int[] start, int[] end)
        {
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {
                    grid[i][j] = 1;
                }
            }
        }

        private void Toggle(int[] start, int[] end)
        {
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {
                    if (grid[i][j] == 0) grid[i][j] = 1;
                    else grid[i][j] = 0;
                }
            }
        }

        private void TurnOff(int[] start, int[] end)
        {
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {
                    grid[i][j] = 0;
                }
            }
        }

        private void TurnOnP2(int[] start, int[] end)
        {
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {
                    grid[i][j]++;
                }
            }
        }

        private void ToggleP2(int[] start, int[] end)
        {
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {
                    grid[i][j] += 2;
                }
            }
        }

        private void TurnOffP2(int[] start, int[] end)
        {
            for (int i = start[0]; i <= end[0]; i++)
            {
                for (int j = start[1]; j <= end[1]; j++)
                {
                    if (grid[i][j] > 0) grid[i][j]--;
                }
            }
        }

        private List<string> ParseData()
        {
            List<string> inst = new();

            foreach (string s in File.ReadAllLines("2015/data/Day6.txt"))
            {
                inst.Add(s);
            }

            return inst;
        }
    }
}