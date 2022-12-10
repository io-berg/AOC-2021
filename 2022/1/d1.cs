

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022
{
    public class Day1
    {
        public static void Solve()
        {
            var biggest = new List<int>() { 0, 0, 0 };
            int current = 0;

            try
            {
                using (StreamReader sr = new StreamReader("./2022/1/input.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (String.IsNullOrWhiteSpace(line))
                        {
                            if (biggest.Any(e => e < current))
                            {
                                biggest.Remove(biggest.Min());
                                biggest.Add(current);
                            }

                            current = 0;
                            continue;
                        }

                        current += int.Parse(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            biggest.Sort();

            Console.WriteLine("Part1: " + biggest.Last());
            Console.WriteLine("Part2: " + biggest.Sum());
        }
    }
}