using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day6
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/6/input.txt");
        var queue = new Queue<char>(input.Take(4));
        var part1 = 0;

        for (int i = 4; i < input.Length; i++)
        {
            queue.Dequeue();
            queue.Enqueue(input[i]);

            if (queue.Distinct().Count() == 4)
            {
                part1 = i + 1;
                break;
            }
        }

        var queue2 = new Queue<char>(input.Take(14));
        var part2 = 0;

        for (int i = 14; i < input.Length; i++)
        {
            queue2.Dequeue();
            queue2.Enqueue(input[i]);

            if (queue2.Distinct().Count() == 14)
            {
                part2 = i + 1;
                break;
            }
        }

        Console.WriteLine("Part1: " + part1);
        Console.WriteLine("Part2: " + part2);
    }
}