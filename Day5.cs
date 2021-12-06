using System;
using System.IO;

namespace Advent
{
    public class Day5
    {
        int[][] thermalField = new int[1000][];

        public string[] data;


        public Day5()
        {
            for (int i = 0; i < 1000; i++)
            {
                thermalField[i] = new int[1000];
            }

            data = File.ReadAllLines("data/thermalVentData.txt");
        }

        public int CountOverlaps()
        {
            int count = 0;
            foreach (int[] row in thermalField)
            {
                foreach (int cell in row)
                {
                    if (cell > 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void FillThermalFieldPart2()
        {
            for (int i = 0; i < data.Length; i++)
            {
                int x1 = Convert.ToInt32(data[i].Split(" ")[0].Split(",")[0]);
                int y1 = Convert.ToInt32(data[i].Split(" ")[0].Split(",")[1]);
                int x2 = Convert.ToInt32(data[i].Split(" ")[2].Split(",")[0]);
                int y2 = Convert.ToInt32(data[i].Split(" ")[2].Split(",")[1]);

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        for (int j = y2; j <= y1; j++)
                        {
                            thermalField[j][x1]++;
                        }
                    }
                    else
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            thermalField[j][x1]++;
                        }
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        for (int j = x2; j <= x1; j++)
                        {
                            thermalField[y1][j]++;
                        }
                    }
                    else
                    {
                        for (int j = x1; j <= x2; j++)
                        {
                            thermalField[y1][j]++;
                        }
                    }
                }
                else
                {
                    int[] start = new int[] { x1, y1 };
                    int[] end = new int[] { x2, y2 };

                    if (start[0] < end[0])
                    {
                        if (start[1] > end[1])
                        {
                            for (int j = start[0]; j <= end[0]; j++)
                            {
                                thermalField[start[1]][start[0]]++;
                                start[0]++;
                                start[1]--;
                            }
                        }
                        else if (start[1] < end[1])
                        {
                            for (int j = start[0]; j <= end[0]; j++)
                            {
                                thermalField[start[1]][start[0]]++;
                                start[0]++;
                                start[1]++;
                            }
                        }
                    }
                    else if (start[0] > end[0])
                    {
                        if (start[1] > end[1])
                        {
                            for (int j = end[0]; j <= start[0]; j++)
                            {
                                thermalField[end[1]][end[0]]++;
                                end[0]++;
                                end[1]++;
                            }
                        }
                        else if (start[1] < end[1])
                        {
                            for (int j = end[1]; j >= start[1]; j--)
                            {
                                thermalField[end[1]][end[0]]++;
                                end[0]++;
                                end[1]--;
                            }
                        }
                    }
                }
            }
        }
        public void FillThermalFieldPart1()
        {
            for (int i = 0; i < data.Length; i++)
            {
                int x1 = Convert.ToInt32(data[i].Split(" ")[0].Split(",")[0]);
                int y1 = Convert.ToInt32(data[i].Split(" ")[0].Split(",")[1]);
                int x2 = Convert.ToInt32(data[i].Split(" ")[2].Split(",")[0]);
                int y2 = Convert.ToInt32(data[i].Split(" ")[2].Split(",")[1]);

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        for (int j = y2; j <= y1; j++)
                        {
                            thermalField[j][x1]++;
                        }
                    }
                    else
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            thermalField[j][x1]++;
                        }
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        for (int j = x2; j <= x1; j++)
                        {
                            thermalField[y1][j]++;
                        }
                    }
                    else
                    {
                        for (int j = x1; j <= x2; j++)
                        {
                            thermalField[y1][j]++;
                        }
                    }
                }
            }
        }
        public void DrawField()
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    Console.Write(thermalField[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}