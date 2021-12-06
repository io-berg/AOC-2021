using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2021
{
    public class Day6
    {
        List<int> fish = new List<int>();

        long[] fishPerAge = new long[9];

        public Day6()
        {
            File.ReadAllLines("2021/data/GlowFishData.txt").ToList().ForEach(line => line.Split(",").ToList().ForEach(x => fish.Add(int.Parse(x))));

            foreach (int s in fish)
            {
                fishPerAge[s]++;
            }
        }

        public void FishCalculator(int days)
        {
            for (int i = 0; i < days; i++)
            {
                long temp = fishPerAge[0];

                for (int j = 0; j < fishPerAge.Length - 1; j++)
                {
                    if (j == 6)
                    {
                        fishPerAge[j] = fishPerAge[j + 1] + temp;
                    }
                    else
                    {
                        fishPerAge[j] = fishPerAge[j + 1];
                    }
                }
                fishPerAge[8] = temp;
            }
        }

        public void PrintFish()
        {
            int age = 0;
            foreach (var item in fishPerAge)
            {
                Console.WriteLine(age + " : " + item);
                age++;
            }

            System.Console.WriteLine("sum = " + fishPerAge.Sum());
        }
    }
}