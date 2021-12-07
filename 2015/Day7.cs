using System;
using System.Collections.Generic;
using System.IO;

namespace Advent2015
{
    public class Day7
    {
        string[] data;

        public Day7()
        {
            data = File.ReadAllLines("2015/data/Day7.txt");

            // data = new string[] {"123 -> x",
            //                      "456 -> y",
            //                      "x AND y -> d",
            //                      "x OR y -> e",
            //                      "x LSHIFT 2 -> f",
            //                      "y RSHIFT 2 -> g",
            //                      "NOT x -> h",
            //                      "NOT y -> i"};


        }

        public void Part2()
        {
            Dictionary<string, ushort> wires = new Dictionary<string, ushort>();
            wires.Add("b", (ushort)Part1());


            for (int i = 0; i < data.Length; i++)
                foreach (string line in data)
                {
                    string[] split = line.Split(' ');
                    if (split.Length == 3)
                    {
                        if (wires.ContainsKey(split[2]) == false)
                        {
                            if (int.TryParse(split[0], out int value))
                            {
                                if (CheckExcists(split[2], wires))
                                {
                                    wires[split[2]] = (ushort)(value);
                                }
                            }

                            else if (CheckExcists(split[0], split[2], wires)) wires[split[2]] = wires[split[0]];
                        }
                    }
                    else if (split[1] == "AND")
                    {
                        if (int.TryParse(split[0], out int value))
                        {
                            if (CheckExcists(split[2], split[4], wires))
                            {
                                wires[split[4]] = (ushort)(value & wires[split[2]]);
                            }
                        }
                        else if (CheckExcists(split[0], split[2], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] & wires[split[2]]);
                        }
                    }
                    else if (split[1] == "OR")
                    {
                        if (CheckExcists(split[0], split[2], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] | wires[split[2]]);
                        }
                    }
                    else if (split[1] == "LSHIFT")
                    {
                        if (CheckExcists(split[0], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] << int.Parse(split[2]));
                        }
                    }
                    else if (split[1] == "RSHIFT")
                    {
                        if (CheckExcists(split[0], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] >> int.Parse(split[2]));
                        }
                    }
                    else if (split[0] == "NOT")
                    {
                        if (CheckExcists(split[1], split[3], wires))
                        {
                            wires[split[3]] = (ushort)~wires[split[1]];
                        }
                    }
                }

            System.Console.WriteLine("Part2 a = " + wires["a"]);
        }

        public ushort Part1()
        {
            Dictionary<string, ushort> wires = new Dictionary<string, ushort>();
            for (int i = 0; i < data.Length; i++)
                foreach (string line in data)
                {
                    string[] split = line.Split(' ');
                    if (split.Length == 3)
                    {
                        if (wires.ContainsKey(split[2]) == false)
                        {
                            if (int.TryParse(split[0], out int value))
                            {
                                if (CheckExcists(split[2], wires))
                                {
                                    wires[split[2]] = (ushort)(value);
                                }
                            }

                            else if (CheckExcists(split[0], split[2], wires)) wires[split[2]] = wires[split[0]];
                        }
                    }
                    else if (split[1] == "AND")
                    {
                        if (int.TryParse(split[0], out int value))
                        {
                            if (CheckExcists(split[2], split[4], wires))
                            {
                                wires[split[4]] = (ushort)(value & wires[split[2]]);
                            }
                        }
                        else if (CheckExcists(split[0], split[2], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] & wires[split[2]]);
                        }
                    }
                    else if (split[1] == "OR")
                    {
                        if (CheckExcists(split[0], split[2], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] | wires[split[2]]);
                        }
                    }
                    else if (split[1] == "LSHIFT")
                    {
                        if (CheckExcists(split[0], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] << int.Parse(split[2]));
                        }
                    }
                    else if (split[1] == "RSHIFT")
                    {
                        if (CheckExcists(split[0], split[4], wires))
                        {
                            wires[split[4]] = (ushort)(wires[split[0]] >> int.Parse(split[2]));
                        }
                    }
                    else if (split[0] == "NOT")
                    {
                        if (CheckExcists(split[1], split[3], wires))
                        {
                            wires[split[3]] = (ushort)~wires[split[1]];
                        }
                    }
                }

            System.Console.WriteLine("Part1 a = " + wires["a"]);

            return wires["a"];
        }

        private bool CheckExcists(string s, Dictionary<string, ushort> wires)
        {
            if (!(wires.ContainsKey(s)))
            {
                wires.Add(s, USP("0"));
                return true;
            }

            return false;
        }

        private bool CheckExcists(string s, string s2, string s3, Dictionary<string, ushort> wires)
        {
            if (wires.ContainsKey(s))
            {
                if (wires.ContainsKey(s2))
                {
                    if (!(wires.ContainsKey(s3)))
                    {
                        wires.Add(s3, USP("0"));
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckExcists(string s, string s2, Dictionary<string, ushort> wires)
        {
            if (wires.ContainsKey(s))
            {
                if (!(wires.ContainsKey(s2)))
                {
                    wires.Add(s2, USP("0"));
                    return true;
                }
            }
            return false;
        }

        private ushort USP(string value)
        {
            return UInt16.Parse(value);
        }

        private void addWire(string w, int value)
        {

        }
    }
}