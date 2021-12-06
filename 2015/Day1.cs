using System;
using System.IO;

namespace Advent2015
{
    public class Day1
    {
        string data;

        public Day1()
        {
            data = File.ReadAllText("2015/data/Day1.txt");
        }

        public void SolvePart1()
        {
            int floor = 0;

            foreach (char c in data)
            {
                if (c == '(')
                {
                    floor++;
                }
                else if (c == ')')
                {
                    floor--;
                }
            }

            System.Console.WriteLine("Floor: " + floor);
        }

        internal void SolvePart2()
        {
            int floor = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '(')
                {
                    floor++;
                }
                else if (data[i] == ')')
                {
                    floor--;
                }
                if (floor == -1)
                {
                    System.Console.WriteLine("First basement: " + (i + 1));
                    break;
                }
            }
        }
    }
}