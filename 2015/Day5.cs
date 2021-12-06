using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2015
{
    public class Day5
    {
        string[] data;

        public Day5()
        {
            data = File.ReadAllLines("2015/data/Day5.txt");
        }

        public void Part2()
        {
            int niceStrings = 0;
            foreach (string s in data)
            {
                bool hasSeparatedPair = false;
                bool hasTwoPairs = false;
                List<string> pp = new(); // potential pairs

                pp.Add(s[0].ToString() + s[1].ToString() + 1);

                for (int i = 2; i < s.Length; i++)
                {
                    if (s[i] == s[i - 2]) hasSeparatedPair = true;
                    pp.Add(s[i - 1].ToString() + s[i].ToString() + i);
                }

                for (int i = 0; i < pp.Count; i++)
                {
                    for (int j = i + 1; j < pp.Count; j++)
                    {
                        if (pp[i][0] == pp[j][0] && pp[i][1] == pp[j][1] && j - 1 != i) hasTwoPairs = true;
                    }
                }
                if (hasSeparatedPair && hasTwoPairs) niceStrings++;
            }
            System.Console.WriteLine(niceStrings);
        }

        public void Part1()
        {
            string[] badStrings = { "ab", "cd", "pq", "xy" };
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int niceStrings = 0;

            foreach (string s in data)
            {
                int vowelCounter = 0;
                bool hasDouble = false;
                bool hasBadStrings = false;
                char lastC = s[0];

                if (vowels.Contains(lastC)) vowelCounter++;

                for (int i = 1; i < s.Length; i++)
                {
                    if (badStrings.Contains(lastC.ToString() + s[i].ToString())) hasBadStrings = true;
                    if (vowels.Contains(s[i])) vowelCounter++;
                    if (lastC == s[i]) hasDouble = true;
                    lastC = s[i];
                }

                if (vowelCounter >= 3 && hasDouble && hasBadStrings == false) niceStrings++;
            }

            System.Console.WriteLine(niceStrings);
        }
    }
}