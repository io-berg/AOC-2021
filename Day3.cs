using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent
{
    public class Day3
    {
        private static int DayThreePart2()
        {
            int oxyRating = CalcOxyGenRating();
            int co2ScrubRating = CalcCo2ScrubRating();

            return oxyRating * co2ScrubRating;
        }

        private static int CalcCo2ScrubRating()
        {
            List<string> data = new();
            foreach (string s in File.ReadAllLines("data/diagnosticData.txt"))
            {
                data.Add(s);
            }

            for (int i = 0; i < 12; i++)
            {
                if (data.Count() == 1)
                    return Convert.ToInt32(data[0], 2);

                List<string> ones = new();
                List<string> zeros = new();

                foreach (string s in data)
                {
                    if (s[i] == '1') ones.Add(s);
                    else zeros.Add(s);
                }

                if (zeros.Count <= ones.Count())
                    data = zeros;
                else data = ones;
            }

            return Convert.ToInt32(data[0], 2);
        }

        private static int CalcOxyGenRating()
        {
            List<string> data = new();
            foreach (string s in File.ReadAllLines("data/diagnosticData.txt"))
            {
                data.Add(s);
            }

            for (int i = 0; i < 12; i++)
            {
                if (data.Count() == 1)
                    return Convert.ToInt32(data[0], 2);

                List<string> ones = new();
                List<string> zeros = new();

                foreach (string s in data)
                {
                    if (s[i] == '1') ones.Add(s);
                    else zeros.Add(s);
                }

                if (ones.Count >= zeros.Count())
                    data = ones;
                else data = zeros;
            }

            return Convert.ToInt32(data[0], 2);
        }

        private static int DayThreePart1()
        {
            var data = File.ReadAllLines("data/diagnosticData.txt");
            string gammaRate = "";
            string epsilonRate = "";
            int one = 0;
            int zero = 0;

            for (int i = 0; i < data[1].Length; i++)
            {
                foreach (string s in data)
                {
                    if (s[i] == '1') one++;
                    else zero++;
                }
                if (one > zero)
                {
                    gammaRate += "1";
                    epsilonRate += "";
                }
                else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
            }

            return Convert.ToInt32(epsilonRate, 2) * Convert.ToInt32(gammaRate, 2);
        }
    }
}