using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Y2022;

public class Day7
{
    public static void Solve()
    {
        var input = File.ReadAllText("./2022/7/input.txt");

        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var dirs = new Dictionary<string, int>();
        var currentPath = "/";

        dirs.Add(currentPath, 0);

        foreach (var line in lines)
        {
            if (line.Contains("$ cd"))
            {
                var path = line.Replace("$ cd ", "");
                if (path == "..")
                    currentPath = currentPath.Substring(0, currentPath.LastIndexOf("/"));
                else if (path == "/")
                    currentPath = "/";
                else
                {
                    if (currentPath != "/")
                        currentPath += "/" + path;
                    else
                        currentPath += path;
                }

                continue;
            }

            if (line.Substring(0, 3) == "dir")
            {
                var dir = line.Substring(4);
                if (!dirs.ContainsKey(currentPath + dir) && !dirs.ContainsKey(currentPath + "/" + dir))
                {
                    if (currentPath != "/")
                        dirs.Add(currentPath + "/" + dir, 0);
                    else
                        dirs.Add(currentPath + dir, 0);
                }

                continue;
            }

            if (line.Contains("$ ls"))
                continue;

            var size = int.Parse(line.Substring(0, line.IndexOf(" ")));
            dirs[currentPath] += size;
        }

        var resultP1 = 0;
        var rootSize = 0;
        foreach (var dir in dirs)
        {
            var path = dir.Key;
            var total = dir.Value;

            var children = dirs.Where(x => x.Key != path && x.Key.StartsWith(path)).ToList();
            children.ForEach(x => total += x.Value);

            if (path == "/")
                rootSize += total;

            if (total <= 100000)
                resultP1 += total;
        }

        var totalSize = 70000000;
        var freeSizeNeeded = 30000000;
        var neededSize = (totalSize - rootSize - freeSizeNeeded) * -1;

        var resultP2 = 0;
        foreach (var dir in dirs)
        {
            var path = dir.Key;
            var total = dir.Value;

            var children = dirs.Where(x => x.Key != path && x.Key.StartsWith(path)).ToList();
            children.ForEach(x => total += x.Value);

            if (total >= neededSize)
                if (resultP2 == 0 || total < resultP2)
                    resultP2 = total;
        }

        Console.WriteLine("Part1: " + resultP1);
        Console.WriteLine("Part2: " + resultP2);
    }
}