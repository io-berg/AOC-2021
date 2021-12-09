using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Advent2021
{
    public record Coordinates
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Day9
    {
        int rows;
        int columns;
        int[][] map;
        int[][] goodMap;


        public Day9(string path)
        {
            var data = File.ReadAllLines(path);
            int height = data.Length;
            int width = data[0].Length;

            map = new int[height][];

            for (int i = 0; i < height; i++)
            {
                map[i] = new int[width];
                for (int j = 0; j < width; j++)
                {
                    map[i][j] = int.Parse(data[i][j].ToString());
                }
            }
            rows = height;
            columns = width;
            goodMap = new int[height][];
            for (int i = 0; i < height; i++)
            {
                goodMap[i] = new int[width];
                for (int j = 0; j < width; j++)
                {
                    goodMap[i][j] = int.Parse(data[i][j].ToString());
                }
            }
        }

        public void Part2ButGood()  // Mostly copied from https://github.com/jasonincanada/aoc-2021/blob/main/AdventOfCode/AdventOfCode.CSharp/Day09.cs
        {
            List<List<Coordinates>> basins = new();

            foreach (Coordinates point in Part1())
            {
                basins.Add(GetBasinSize(point));
            }

            List<int> sizes = new();
            foreach (List<Coordinates> basin in basins)
            {
                sizes.Add(basin.Count);
            }

            sizes.Sort();
            int result = 1;

            for (int i = basins.Count - 1; i > basins.Count - 4; i--)
            {
                result *= sizes[i];
            }
            System.Console.WriteLine("Part 2: " + result);
        }

        private List<Coordinates> GetBasinSize(Coordinates point)
        {
            Stack<Coordinates> stack = new();
            List<Coordinates> basin = new();

            stack.Push(point);
            basin.Add(point);

            while (stack.Any())
            {
                Coordinates current = stack.Pop();
                List<Coordinates> neighbours = GetNeighbours(current);

                var higher = neighbours.Where(n => GetHeight(n) > GetHeight(current)).Where(n => GetHeight(n) < 9);

                foreach (Coordinates higherNeighbour in higher)
                {
                    if (basin.Contains(higherNeighbour))
                    {
                        continue;
                    }

                    stack.Push(higherNeighbour);
                    basin.Add(higherNeighbour);
                }
            }

            return basin;
        }

        private List<Coordinates> GetNeighbours(Coordinates next)
        {
            List<Coordinates> neighbours = new()
            {
                new Coordinates(next.X - 1, next.Y),
                new Coordinates(next.X, next.Y + 1),
                new Coordinates(next.X + 1, next.Y),
                new Coordinates(next.X, next.Y - 1)
            };

            return neighbours.Where(n => n.X >= 0 && n.X < rows && n.Y >= 0 && n.Y < columns).ToList();
        }

        private int GetHeight(Coordinates coordinates)
        {
            return map[coordinates.X][coordinates.Y];
        }

        // public void Part2()
        // {
        //     List<int[]> points = Part1();
        //     List<int[]> needsChecked = new();
        //     List<int> basinSizes = new();
        //     foreach (int[] point in points)
        //     {
        //         List<int[]> tested = new();
        //         needsChecked.Add(point);

        //         do
        //         {
        //             int[] next = needsChecked.First();

        //             GetSurroundings(needsChecked.First()[0], needsChecked.First()[1], needsChecked, tested);

        //             tested.Add(next);
        //             needsChecked.Remove(next);
        //         } while (needsChecked.Count != 0);

        //         basinSizes.Add(tested.Count);
        //     }
        //     int result = 1;
        //     basinSizes.Sort();
        //     foreach (int size in basinSizes)
        //     {
        //         System.Console.WriteLine(size);
        //     }
        //     // get 3 biggest values in basinsizes
        //     for (int i = basinSizes.Count - 1; i > basinSizes.Count - 4; i--)
        //     {
        //         result *= basinSizes[i];
        //     }

        //     System.Console.WriteLine(result);
        // }

        // private void GetSurroundings(int i, int j, List<int[]> check, List<int[]> tested)
        // {
        //     if (IsMiddle(i, j))
        //     {
        //         if (TestLeft(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j - 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j - 1 })))
        //             {
        //                 check.Add(new int[] { i, j - 1 });
        //             }
        //         }
        //         if (TestRight(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j + 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j + 1 })))
        //             {
        //                 check.Add(new[] { i, j + 1 });
        //             }
        //         }
        //         if (TestUp(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i - 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i - 1, j })))
        //             {
        //                 check.Add(new[] { i - 1, j });
        //             }
        //         }
        //         if (TestDown(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i + 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i + 1, j })))
        //             {
        //                 check.Add(new[] { i + 1, j });
        //             }
        //         }
        //     }
        //     else if (IsCorner(i, j))
        //     {
        //         TestCorner(i, j, check, tested);
        //     }
        //     else if (IsEdge(i, j))
        //     {
        //         TestEdge(i, j, check, tested);
        //     }
        // }


        // private void TestEdge(int i, int j, List<int[]> check, List<int[]> tested)
        // {
        //     if (i == 0)
        //     {
        //         if (TestLeft(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j - 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j - 1 })))
        //             {
        //                 check.Add(new int[] { i, j - 1 });
        //             }
        //         }
        //         if (TestRight(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j + 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j + 1 })))
        //             {
        //                 check.Add(new[] { i, j + 1 });
        //             }
        //         }
        //         if (TestDown(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i + 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i + 1, j })))
        //             {
        //                 check.Add(new[] { i + 1, j });
        //             }
        //         }
        //     }
        //     else if (i == map.Length - 1)
        //     {
        //         if (TestUp(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i - 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i - 1, j })))
        //             {
        //                 check.Add(new[] { i - 1, j });
        //             }
        //         }
        //         if (TestRight(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j + 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j + 1 })))
        //             {
        //                 check.Add(new[] { i, j + 1 });
        //             }
        //         }
        //         if (TestLeft(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j - 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j - 1 })))
        //             {
        //                 check.Add(new[] { i, j - 1 });
        //             }
        //         }
        //     }
        //     else if (j == 0)
        //     {
        //         if (TestUp(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i - 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i - 1, j })))
        //             {
        //                 check.Add(new[] { i - 1, j });
        //             }
        //         }
        //         if (TestRight(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j + 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j + 1 })))
        //             {
        //                 check.Add(new[] { i, j + 1 });
        //             }
        //         }
        //         if (TestDown(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i + 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i + 1, j })))
        //             {
        //                 check.Add(new[] { i + 1, j });
        //             }
        //         }
        //     }
        //     else if (j == map[0].Length - 1)
        //     {
        //         if (TestUp(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i - 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i - 1, j })))
        //             {
        //                 check.Add(new[] { i - 1, j });
        //             }
        //         }
        //         if (TestLeft(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i, j - 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j - 1 })))
        //             {
        //                 check.Add(new[] { i, j - 1 });
        //             }
        //         }
        //         if (TestDown(i, j))
        //         {
        //             if (!tested.Any(x => x.SequenceEqual(new int[] { i + 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i + 1, j })))
        //             {
        //                 check.Add(new[] { i + 1, j });
        //             }
        //         }
        //     }
        // }

        // private void TestCorner(int i, int j, List<int[]> check, List<int[]> tested)
        // {
        //     if (i == 0)
        //     {
        //         if (j == 0)
        //         {
        //             if (TestDown(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i + 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i + 1, j })))
        //                 {
        //                     check.Add(new[] { i + 1, j });
        //                 }
        //             }
        //             if (TestRight(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i, j + 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j + 1 })))
        //                 {
        //                     check.Add(new[] { i, j + 1 });
        //                 }
        //             }
        //         }
        //         else if (j == map[0].Length - 1)
        //         {
        //             if (TestDown(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i + 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i + 1, j })))
        //                 {
        //                     check.Add(new[] { i + 1, j });
        //                 }
        //             }
        //             if (TestLeft(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i, j - 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j - 1 })))
        //                 {
        //                     check.Add(new[] { i, j - 1 });
        //                 }
        //             }
        //         }
        //     }
        //     else if (i == map.Length - 1)
        //     {
        //         if (j == 0)
        //         {
        //             if (TestUp(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i - 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i - 1, j })))
        //                 {
        //                     check.Add(new[] { i - 1, j });
        //                 }
        //             }
        //             if (TestRight(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i, j + 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j + 1 })))
        //                 {
        //                     check.Add(new[] { i, j + 1 });
        //                 }
        //             }
        //         }
        //         else if (j == map[0].Length - 1)
        //         {
        //             if (TestUp(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i - 1, j })) && !check.Any(x => x.SequenceEqual(new int[] { i - 1, j })))
        //                 {
        //                     check.Add(new[] { i - 1, j });
        //                 }
        //             }
        //             if (TestLeft(i, j))
        //             {
        //                 if (!tested.Any(x => x.SequenceEqual(new int[] { i, j - 1 })) && !check.Any(x => x.SequenceEqual(new int[] { i, j - 1 })))
        //                 {
        //                     check.Add(new[] { i, j - 1 });
        //                 }
        //             }
        //         }
        //     }
        // }

        // private bool TestDown(int i, int j)
        // {
        //     if (map[i + 1][j] - 1 == map[i][j] && map[i + 1][j] != 9)
        //     {
        //         return true;
        //     }
        //     else return false;
        // }

        // private bool TestUp(int i, int j)
        // {
        //     if (map[i - 1][j] - 1 == map[i][j] && map[i - 1][j] != 9)
        //     {
        //         return true;
        //     }
        //     else return false;
        // }

        // private bool TestRight(int i, int j)
        // {
        //     if (map[i][j + 1] - 1 == map[i][j] && map[i][j + 1] != 9)
        //     {
        //         return true;
        //     }
        //     else return false;
        // }

        // private bool TestLeft(int i, int j)
        // {
        //     if (map[i][j - 1] - 1 == map[i][j] && map[i][j - 1] != 9)
        //     {
        //         return true;
        //     }
        //     else return false;
        // }

        public List<Coordinates> Part1()
        {
            List<int[]> riskZones = new();
            List<Coordinates> coordinates = new();
            int totalRiskLevel = 0;
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (IsRisk(i, j))
                    {
                        // riskZones.Add(new[] { i, j });
                        coordinates.Add(new Coordinates(i, j));
                        totalRiskLevel += map[i][j] + 1;
                    }
                    // riskZones.Add(new int[] { i, j });
                    // totalRiskLevel += map[i][j] + 1;
                    // map[i][j] = (map[i][j] * -1) - 1;
                    //  USE THIS TO CHECK MAP
                }
            }
            // use this to print the map
            foreach (var item in map)
            {
                foreach (int item2 in item)
                {
                    if (item2 < 0) System.Console.Write(item2);
                    else System.Console.Write(item2 + " ");
                }
                System.Console.WriteLine();
            }
            Console.WriteLine("part1: " + totalRiskLevel);
            return coordinates;
        }

        private bool IsRisk(int i, int j)
        {
            if (IsMiddle(i, j)) return CheckMiddle(i, j);
            else if (IsCorner(i, j)) return CheckCorner(i, j);
            return CheckEdge(i, j);
        }

        private bool CheckEdge(int i, int j)
        {
            if (i == 0)
            {
                if (map[i][j] < map[i][j + 1] && map[i][j] < map[i][j - 1] && map[i][j] < map[i + 1][j]) return true;
                else return false;
            }
            else if (j == 0)
            {
                if (map[i][j] < map[i + 1][j] && map[i][j] < map[i - 1][j] && map[i][j] < map[i][j + 1]) return true;
                else return false;
            }
            else if (j == map[i].Length - 1)
            {
                if (map[i][j] < map[i + 1][j] && map[i][j] < map[i - 1][j] && map[i][j] < map[i][j - 1]) return true;
                else return false;
            }
            else if (i == map.Length - 1)
            {
                if (map[i][j] < map[i][j + 1] && map[i][j] < map[i][j - 1] && map[i][j] < map[i - 1][j]) return true;
                else return false;
            }
            else return false;
        }

        private bool IsEdge(int i, int j)
        {
            if (i == 0 || i == map.Length - 1) return true;
            else if (j == 0 || j == map[i].Length - 1) return true;
            else return false;
        }

        private bool CheckMiddle(int i, int j)
        {
            if (map[i][j] < map[i - 1][j] && map[i][j] < map[i + 1][j] && map[i][j] < map[i][j - 1] && map[i][j] < map[i][j + 1]) return true;
            else return false;
        }

        private bool IsMiddle(int i, int j)
        {
            if (i > 0 && i < map.Length - 1 && j > 0 && j < map[i].Length - 1) return true;
            else return false;
        }

        private bool CheckCorner(int i, int j)
        {
            if (i == 0 && j == 0)
            {
                if (map[i][j] < map[i + 1][j] && map[i][j] < map[i][j + 1]) return true;
                else return false;
            }
            else if (i == 0 && j == map[i].Length - 1)
            {
                if (map[i][j] < map[i + 1][j] && map[i][j] < map[i][j - 1]) return true;
                else return false;
            }
            else if (i == map.Length - 1 && j == 0)
            {
                if (map[i][j] < map[i - 1][j] && map[i][j] < map[i][j + 1]) return true;
                else return false;
            }
            else if (i == map.Length - 1 && j == map[i].Length - 1)
            {
                if (map[i][j] < map[i - 1][j] && map[i][j] < map[i][j - 1]) return true;
                else return false;
            }
            throw new Exception("Invalid corner");
        }

        private bool IsCorner(int i, int j)
        {
            if (i == 0 && j == 0) return true;
            else if (i == 0 && j == map[i].Length - 1) return true;
            else if (i == map.Length - 1 && j == 0) return true;
            else if (i == map.Length - 1 && j == map[i].Length - 1) return true;
            else return false;
        }
    }
}