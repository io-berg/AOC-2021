using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2015
{
    public class Day3
    {
        string data;
        int[] xy = new int[2];
        List<int[]> visited = new();

        public Day3()
        {
            this.data = File.ReadAllText("2015/data/Day3.txt");
        }

        public void Part2()
        {
            int[] santaMove = { 0, 0 };
            int[] roboSantaMove = { 0, 0 };

            visited.Add(santaMove);
            visited.Add(roboSantaMove);

            for (int i = 0; i < data.Length; i++)
            {
                int[] move1 = { santaMove[0], santaMove[1] };
                int[] move2 = { roboSantaMove[0], roboSantaMove[1] };

                if (data[i] == '<')
                {
                    if (i % 2 == 0)
                    {
                        move1[0]--;
                    }
                    else
                    {
                        move2[0]--;
                    }
                }
                else if (data[i] == '>')
                {
                    if (i % 2 == 0)
                    {
                        move1[0]++;
                    }
                    else
                    {
                        move2[0]++;
                    }
                }
                else if (data[i] == '^')
                {
                    if (i % 2 == 0)
                    {
                        move1[1]++;
                    }
                    else
                    {
                        move2[1]++;
                    }
                }
                else if (data[i] == 'v')
                {
                    if (i % 2 == 0)
                    {
                        move1[1]--;
                    }
                    else
                    {
                        move2[1]--;
                    }
                }
                if (i % 2 == 0)
                {
                    visited.Add(move1);
                }
                else
                {
                    visited.Add(move2);
                }
                santaMove = move1;
                roboSantaMove = move2;
            }
            RemoveDuplicates(visited);
            System.Console.WriteLine(visited.Count());
        }

        public void Part1()
        {
            xy[0] = 0;
            xy[1] = 0;

            visited.Add(xy);

            for (int i = 0; i < data.Length; i++)
            {
                int[] move = { xy[0], xy[1] };

                if (data[i] == '<')
                {
                    move[0]--;
                }
                else if (data[i] == '>')
                {
                    move[0]++;
                }
                else if (data[i] == '^')
                {
                    move[1]++;
                }
                else if (data[i] == 'v')
                {
                    move[1]--;
                }
                xy = move;
                visited.Add(xy);
            }
            RemoveDuplicates(visited);
            System.Console.WriteLine(visited.Count());
        }

        private void RemoveDuplicates(List<int[]> visited)
        {
            for (int i = 0; i < visited.Count; i++)
            {
                for (int j = i + 1; j < visited.Count; j++)
                {
                    if (visited[i][0] == visited[j][0] && visited[i][1] == visited[j][1])
                    {
                        visited.RemoveAt(j);
                        j--;
                    }
                }
            }
        }
    }
}