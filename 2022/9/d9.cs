using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day9
{
    public static void Solve()
    {
        Console.WriteLine("Part1: " + RopeSolver9000(0));
        Console.WriteLine("Part2: " + RopeSolver9000(8));
    }

    private static int RopeSolver9000(int length)
    {
        var input = File.ReadAllText("./2022/9/input.txt");
        //         var input = @"R 5
        // U 8
        // L 8
        // D 3
        // R 17
        // D 10
        // L 25
        // U 20";
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var rope = new List<Pos>();
        for (int i = 0; i < length + 2; i++)
            rope.Add(new Pos(0, 0));

        var visited = new HashSet<(int x, int y)>();
        visited.Add(rope.Last().xy);

        foreach (var line in lines)
        {
            var split = line.Split(" ");
            var direction = split[0];
            var distance = int.Parse(split[1]);

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case "U":
                        rope[0].y += 1;
                        break;
                    case "D":
                        rope[0].y -= 1;
                        break;
                    case "R":
                        rope[0].x += 1;
                        break;
                    case "L":
                        rope[0].x -= 1;
                        break;
                    default:
                        break;
                }

                for (int j = 1; j < rope.Count; j++)
                {
                    var needToMove = Math.Abs(rope[j - 1].x - rope[j].x) > 1 ||
                                     Math.Abs(rope[j - 1].y - rope[j].y) > 1;

                    if (needToMove)
                    {
                        if (rope[j - 1].x != rope[j].x)
                        {
                            var xDiff = (rope[j - 1].x - rope[j].x) / Math.Abs(rope[j - 1].x - rope[j].x);
                            rope[j].x += xDiff;
                        }

                        if (rope[j - 1].y != rope[j].y)
                        {
                            var yDiff = (rope[j - 1].y - rope[j].y) / Math.Abs(rope[j - 1].y - rope[j].y);
                            rope[j].y += yDiff;
                        }
                    }

                    if (j == rope.Count - 1)
                    {
                        visited.Add(rope.Last().xy);
                    }
                }
            }
        }

        return visited.Count;
    }

    public class Pos
    {
        public int x { get; set; }
        public int y { get; set; }

        public (int x, int y) xy { get { return (x, y); } }

        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    };
}