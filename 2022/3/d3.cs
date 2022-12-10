using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day3
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/3/input.txt");
        var bags = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

        int resultP1 = 0;
        int resultP2 = 0;

        foreach (var bag in bags)
        {
            var box1 = bag.Substring(0, bag.Length / 2);
            var box2 = bag.Substring(bag.Length / 2);

            var common = box1.Intersect(box2).FirstOrDefault();
            resultP1 += GetScore(common);
        }

        var groups = new List<List<string>>();
        for (int i = 0; i < bags.Count; i += 3)
        {
            groups.Add(bags.Skip(i).Take(3).ToList());
        }

        foreach (var group in groups)
        {
            var box1 = group[0];
            var box2 = group[1];
            var box3 = group[2];

            var common = box1.Intersect(box2).Intersect(box3).FirstOrDefault();
            resultP2 += GetScore(common);
        }

        Console.WriteLine("Part1: " + resultP1);
        Console.WriteLine("Part2: " + resultP2);
    }

    private static int GetScore(char c)
    {
        if (Char.IsUpper(c))
        {
            return c - 'A' + 27;
        }
        else
        {
            return c - 'a' + 1;
        }
    }
}