using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day5
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/5/input.txt").Split(Environment.NewLine);
        var crates = input.TakeWhile(x => x != "").ToList();
        var amountOfColumns = crates.Last().Split(" ").Where(x => x != "").Count();
        crates.RemoveAt(crates.Count - 1);

        var instructions = input.SkipWhile(x => x != "")
            .Skip(1)
            .Select(x => x.Split(" "))
            .Where(x => x.Length > 1)
            .ToList();

        List<Stack<Char>> columns = new List<Stack<char>>(amountOfColumns);
        List<Stack<Char>> columnsP2 = new List<Stack<char>>(amountOfColumns);
        List<List<Char>> starterColumns = new List<List<char>>(amountOfColumns);
        for (int i = 0; i < amountOfColumns; i++)
        {
            starterColumns.Add(new List<Char>());
        }

        foreach (var crateLine in crates)
        {
            for (int i = 0; i < amountOfColumns; i++)
            {
                var crate = crateLine[i * 4 + 1];
                if (crate != ' ')
                    starterColumns[i].Add(crate);
            }
        }

        foreach (var column in starterColumns)
        {
            column.Reverse();
            columns.Add(new Stack<Char>(column));
            columnsP2.Add(new Stack<Char>(column));
        }

        foreach (var instruction in instructions)
        {
            var amount = int.Parse(instruction[1]);
            var from = int.Parse(instruction[3]) - 1;
            var too = int.Parse(instruction[5]) - 1;

            for (int i = 0; i < amount; i++)
            {
                columns[too].Push(columns[from].Pop());
            }

            var temp = new Stack<Char>();
            for (int i = 0; i < amount; i++)
            {
                temp.Push(columnsP2[from].Pop());
            }

            for (int i = amount - 1; i >= 0; i--)
            {
                columnsP2[too].Push(temp.Pop());
            }
        }

        var result = columns.Select(x => x.Peek()).ToList();
        var resultP2 = columnsP2.Select(x => x.Peek()).ToList();

        Console.WriteLine("Part1: " + string.Join("", result));
        Console.WriteLine("Part2: " + string.Join("", resultP2));
    }
}