using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day10
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/10/input.txt");
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int cycle = -20;
        int value = 1;
        Dictionary<int, int> cycleValues = new Dictionary<int, int>();

        foreach (string line in lines)
        {
            var split = line.Split(' ');
            if (split[0] == "noop")
            {
                cycle++;
            }
            else
            {
                if (++cycle % 40 == 0)
                {
                    cycleValues.Add(cycle, value);
                    ++cycle;
                }
                else if (++cycle % 40 == 0)
                {
                    cycleValues.Add(cycle, value);
                }
                value += int.Parse(split[1]);
            }
        }

        var total = 0;
        var group = 0;
        foreach (var report in cycleValues)
        {
            var groupCycle = report.Key + 20;
            group = groupCycle * report.Value;
            total += group;
            Console.WriteLine(groupCycle + " : " + report.Value + " = " + group);
        }
        Console.WriteLine("Part1 : " + total);
    }
}