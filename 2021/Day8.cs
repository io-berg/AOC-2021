using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2021
{
    public class Day8
    {
        int[] goodnums = new int[] { 2, 4, 3, 7 };
        List<string[]> data = new List<string[]>();


        public Day8(string path)
        {
            foreach (string s in File.ReadAllLines(path))
            {
                data.Add(ParseLine(s));
            }
        }

        private string[] ParseLine(string s)
        {
            return new string[] { s.Split("|")[0].Trim(), s.Split("|")[1].Trim() };
        }

        internal void Part2()
        {
            int sum = 0;

            foreach (string[] s in data)
            {
                Dictionary<int, string> keys = new();
                string combined = s[0] + " " + s[1];

                for (int i = 0; i < 10; i++)
                {
                    keys.Add(i, "");
                }

                foreach (string blink in combined.Split(" "))
                {
                    if (goodnums.Contains(blink.Length))
                    {
                        if (isNewNum(blink.Length, keys))
                            SetGoodNum(keys, blink);
                    }
                }
                if (keys[3] == "") Set3(keys, combined);
                if (keys[6] == "") Set6(keys, combined);
                if (keys[5] == "") Set5(keys, combined);
                if (keys[2] == "") Set2(keys, combined);
                if (keys[9] == "") Set9(keys, combined);
                if (keys[0] == "") Set0(keys, combined);

                string output = "";

                foreach (string st in s[1].Split(" "))
                {
                    foreach (var k in keys)
                    {
                        if (k.Value.Length == st.Length)
                        {
                            int matches = 0;
                            foreach (char c in st)
                            {
                                if (k.Value.Contains(c))
                                {
                                    matches++;
                                }
                            }
                            if (matches == st.Length)
                            {
                                output += k.Key;
                                break;
                            }
                        }
                    }
                }

                sum += int.Parse(output);
            }

            System.Console.WriteLine(sum);
        }

        private void Set0(Dictionary<int, string> keys, string combined)
        {
            foreach (string s in combined.Split(" "))
            {
                if (s.Length == 6)
                {
                    if (keys.Values.Contains(s) == false)
                    {
                        keys[0] = s;
                        break;
                    }
                }
            }
        }

        private void Set9(Dictionary<int, string> keys, string combined)
        {
            foreach (string s in combined.Split(" "))
            {
                if (s.Length == 6)
                {
                    int matches = 0;
                    foreach (char c in keys[3])
                    {
                        if (s.Contains(c))
                        {
                            matches++;
                        }
                    }
                    if (matches == 5)
                    {
                        keys[9] = s;
                        break;
                    }
                }
            }
        }

        private void Set2(Dictionary<int, string> keys, string combined)
        {
            foreach (string s in combined.Split(" "))
            {
                if (s.Length == 5)
                {
                    int matches = 0;
                    foreach (char c in s)
                    {
                        if (keys[5].Contains(c)) matches++;
                    }
                    if (matches == 3) keys[2] = s;
                }
            }
        }

        private void Set5(Dictionary<int, string> keys, string combined)
        {
            foreach (string s in combined.Split(" "))
            {
                if (s.Length == 5)
                {
                    int matches = 0;
                    foreach (char c in keys[6])
                    {
                        if (s.Contains(c)) matches++;
                    }
                    if (matches == 5)
                    {
                        keys[5] = s;
                        break;
                    }
                }
            }
        }

        private void Set6(Dictionary<int, string> keys, string combined)
        {
            foreach (string s in combined.Split(" "))
            {
                if (s.Length == 6)
                {
                    if (s.Contains(keys[1][0]) ^ s.Contains(keys[1][1]))
                    {
                        keys[6] = s;
                        break;
                    }
                }
            }
        }

        private void Set3(Dictionary<int, string> keys, string fullLine)
        {
            foreach (string s in fullLine.Split(" "))
            {
                if (s.Length == 5)
                {
                    if (s.Contains(keys[1][0]) && s.Contains(keys[1][1]))
                    {
                        keys[3] = s;
                    }
                }
            }
        }

        private bool isNewNum(int length, Dictionary<int, string> keys)
        {
            if (keys.ContainsKey(length))
                return true;

            else return false;
        }

        public void SetGoodNum(Dictionary<int, string> keys, string s)
        {
            if (s.Length == 2)
                keys[1] = s;
            else if (s.Length == 4)
                keys[4] = s;
            else if (s.Length == 3)
                keys[7] = s;
            else if (s.Length == 7)
                keys[8] = s;
        }

        // 1 = 2
        // 4 = 4
        // 7 = 3
        // 8 = 7

        internal void Part1()
        {
            int counter = 0;

            foreach (string[] item in data)
            {
                foreach (string s in item[1].Split(" "))
                {
                    if (goodnums.Contains(s.Length))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
        public void testData()
        {
            int count8 = 0;
            int count1 = 0;
            int count4 = 0;
            int count7 = 0;

            foreach (string s in File.ReadAllLines("2021/data/Day8.txt"))
            {
                foreach (string x in s.Split(" "))
                {
                    if (x.Length == 7)
                    {
                        count8++;

                    }
                    if (x.Length == 2)
                    {
                        count1++;

                    }
                    if (x.Length == 4)
                    {
                        count4++;

                    }
                    if (x.Length == 3)
                    {
                        count7++;

                    }
                }
            }
            Console.WriteLine(count8);
            Console.WriteLine(count1);
            Console.WriteLine(count4);
            Console.WriteLine(count7);
        }
    }
}