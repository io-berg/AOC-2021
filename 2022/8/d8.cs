using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day8
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/8/input.txt");
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var forest = new int[][] { };

        foreach (var line in lines)
        {
            var row = line.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            forest = forest.Append(row).ToArray();
        }

        var visibleTrees = 0;
        var bestViewScore = 0;

        for (int i = 0; i < forest.Count(); i++)
        {
            for (int j = 0; j < forest[i].Count(); j++)
            {
                if (IsTreeVisible(i, j, forest))
                    visibleTrees++;

                if (i == 0 || i == forest.Count() - 1 || j == 0 || j == forest[i].Count() - 1)
                    continue;

                var viewScore = GetViewDistanceScore(i, j, forest);
                if (viewScore > bestViewScore)
                    bestViewScore = viewScore;
            }
        }

        Console.WriteLine("Part1: " + visibleTrees);
        Console.WriteLine("Part2: " + bestViewScore);
    }

    private static bool IsTreeVisible(int row, int column, int[][] forest)
    {
        var currentTree = forest[row][column];

        var tressToTheRight = forest[row].Skip(column + 1);
        var treesToTheLeft = forest[row].Take(column);
        var treesToTheTop = forest.Take(row).Select(x => x[column]);
        var treesToTheBottom = forest.Skip(row + 1).Select(x => x[column]);

        if (tressToTheRight.All(x => x < currentTree))
            return true;

        if (treesToTheLeft.All(x => x < currentTree))
            return true;

        if (treesToTheTop.All(x => x < currentTree))
            return true;

        if (treesToTheBottom.All(x => x < currentTree))
            return true;

        return false;
    }

    private static int GetViewDistanceScore(int row, int column, int[][] forest)
    {
        var currentTree = forest[row][column];

        var treesToTheRight = forest[row].Skip(column + 1).ToList();
        var treesToTheLeft = forest[row].Take(column).Reverse().ToList();
        var treesToTheTop = forest.Take(row).Select(x => x[column]).Reverse().ToList();
        var treesToTheBottom = forest.Skip(row + 1).Select(x => x[column]).ToList();

        var rightScore = 0;
        foreach (var tree in treesToTheRight)
        {
            rightScore++;
            if (tree >= currentTree) break;
        }

        var leftScore = 0;
        foreach (var tree in treesToTheLeft)
        {
            leftScore++;
            if (tree >= currentTree) break;
        }

        var topScore = 0;
        foreach (var tree in treesToTheTop)
        {
            topScore++;
            if (tree >= currentTree) break;
        }

        var bottomScore = 0;

        foreach (var tree in treesToTheBottom)
        {
            bottomScore++;
            if (tree >= currentTree) break;
        }

        return topScore * leftScore * rightScore * bottomScore;
    }
}