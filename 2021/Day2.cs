using System;
using System.IO;

namespace Advent2021
{
    public class Day2
    {
        private static void DayTwoPart2()
        {
            int aim = 0;
            int horizontal = 0;
            int vertical = 0;

            var input = File.ReadAllLines("2021/data/pilotingData.txt");

            foreach (var s in input)
            {
                if (s.Contains("forward"))
                {
                    int distance = int.Parse(s.Split(' ')[1]);
                    horizontal += distance;
                    vertical += aim * distance;
                }
                else if (s.Contains("down"))
                {
                    aim += int.Parse(s.Split(' ')[1]);
                }
                else if (s.Contains("up"))
                {
                    aim -= int.Parse(s.Split(' ')[1]);
                }
            }

            int position = vertical * horizontal;

            System.Console.WriteLine(position);
        }

        static void DayTwoPart1()
        {
            int horizontal = 0;
            int vertical = 0;

            foreach (string s in File.ReadLines("2021/data/pilotingData.txt"))
            {
                if (s.Contains("forward"))
                {
                    horizontal += Convert.ToInt32(s.Split(' ')[1]);
                }
                else if (s.Contains("down"))
                {
                    vertical += Convert.ToInt32(s.Split(' ')[1]);
                }
                else if (s.Contains("up"))
                {
                    vertical -= Convert.ToInt32(s.Split(' ')[1]);
                }
            }

            Console.WriteLine("Horizontal: " + horizontal);
            Console.WriteLine("Vertical: " + vertical);
            System.Console.WriteLine("Position: " + (horizontal * vertical));
        }
    }
}