using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent
{
    public class Day1
    {
        List<int> data = new List<int>();

        public Day1()
        {
            File.ReadAllLines("data/day1.txt").ToList().ForEach(x => data.Add(int.Parse(x)));
        }

        public int part1()
        {
            int depth = 0;
            int last = data[0];

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i] > last)
                {
                    depth++;
                }
                last = data[i];
            }

            return depth;
        }

        public int part2()
        {
            int depth = 0;
            int last = data[0] + data[1] + data[2];

            for (int i = 1; i < data.Count - 2; i++)
            {
                if (data[i] + data[i + 1] + data[i + 2] > last)
                {
                    depth++;
                }
                last = data[i + 2] + data[i + 1] + data[i];
            }

            return depth;
        }


        public void PrintData()
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}