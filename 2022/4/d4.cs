using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day4
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/4/input.txt");
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(","));

        int resultP1 = 0;
        int resultP2 = 0;

        foreach (var line in lines)
        {
            var elf1 = line[0].Split("-").Select(x => int.Parse(x)).ToArray();
            var elf2 = line[1].Split("-").Select(x => int.Parse(x)).ToArray();

            if (FullyContains(elf1, elf2))
                resultP1++;

            if (Overlaps(elf1, elf2))
                resultP2++;
        }

        Console.WriteLine("Part1 : " + resultP1);
        Console.WriteLine("Part2 : " + resultP2);
    }

    private static bool FullyContains(int[] elf1, int[] elf2)
    {
        return elf1[0] <= elf2[0] && elf1[1] >= elf2[1] ||
                elf2[0] <= elf1[0] && elf2[1] >= elf1[1];
    }

    private static bool Overlaps(int[] elf1, int[] elf2)
    {
        return elf1[0] <= elf2[0] && elf1[1] >= elf2[0] ||
                elf2[0] <= elf1[0] && elf2[1] >= elf1[0];
    }
}
