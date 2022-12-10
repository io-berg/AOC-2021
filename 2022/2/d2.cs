using System;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day2
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/2/input.txt");
        var scoreP1 = 0;
        var scoreP2 = 0;

        var rounds = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(" ")).ToList();

        foreach (var round in rounds)
        {
            var opp = round[0];
            var me = round[1];
            scoreP1 += P1Solver(opp, me);
            scoreP2 += P2Solver(opp, me);
        }

        Console.WriteLine("Part1: " + scoreP1);
        Console.WriteLine("Part2: " + scoreP2);
    }

    private static int P1Solver(string opp, string me)
    {
        return opp switch
        {
            "A" => me switch
            {
                "X" => 4,
                "Y" => 8,
                "Z" => 3,
                _ => 0
            },
            "B" => me switch
            {
                "X" => 1,
                "Y" => 5,
                "Z" => 9,
                _ => 0
            },
            "C" => me switch
            {
                "X" => 7,
                "Y" => 2,
                "Z" => 6,
                _ => 0
            },
            _ => 0
        };
    }

    private static int P2Solver(string opp, string me)
    {
        return opp switch
        {
            "A" => me switch
            {
                "X" => 3,
                "Y" => 4,
                "Z" => 8,
                _ => 0
            },
            "B" => me switch
            {
                "X" => 1,
                "Y" => 5,
                "Z" => 9,
                _ => 0
            },
            "C" => me switch
            {
                "X" => 2,
                "Y" => 6,
                "Z" => 7,
                _ => 0
            },
            _ => 0
        };
    }
}