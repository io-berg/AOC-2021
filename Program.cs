using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "2021/data/Day9.txt";

            Advent2021.Day9 d = new(path);
            // d.testData();
            // d.Part1();
            d.Part2ButGood();


            // List<int[]> list1 = new();
            // List<int[]> list2 = new();

            // list1.Add(new[] { 1, 2, 4 });
            // list1.Add(new[] { 1, 1, 4 });
            // list1.Add(new[] { 1, 2, 5 });

            // list2.Add(new[] { 2, 2, 3 });
            // list2.Add(new[] { 1, 2, 7 });

            // int[] a = new int[] { 1, 2, 3 };

            // if (list1.Any(x => x.SequenceEqual(a)))
            // {
            //     Console.WriteLine("Found");
            // }

        }
    }
}
