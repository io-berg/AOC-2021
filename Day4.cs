using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Advent
{
    public class Bingo
    {
        static int[] drawnNumbers = { 1, 76, 38, 96, 62, 41, 27, 33, 4, 2, 94, 15, 89, 25, 66, 14, 30, 0, 71, 21, 48, 44, 87, 73, 60, 50, 77, 45, 29, 18, 5, 99, 65, 16, 93, 95, 37, 3, 52, 32, 46, 80, 98, 63, 92, 24, 35, 55, 12, 81, 51, 17, 70, 78, 61, 91, 54, 8, 72, 40, 74, 68, 75, 67, 39, 64, 10, 53, 9, 31, 6, 7, 47, 42, 90, 20, 19, 36, 22, 43, 58, 28, 79, 86, 57, 49, 83, 84, 97, 11, 85, 26, 69, 23, 59, 82, 88, 34, 56, 13 };
        static List<int[][]> boards;

        public Bingo()
        {
            boards = ParseBoards();
        }

        private List<int[][]> ParseBoards()
        {
            List<int[][]> list = new();
            var data = File.ReadAllLines("data/bingoData.txt");

            for (int i = 0; i < data.Length; i += 6)
            {
                var board = new int[5][];
                for (int j = 0; j < 5; j++)
                {
                    int count = 0;
                    int[] row = new int[5];
                    foreach (string s in data[i + j].Trim().Split(" "))
                    {
                        if (s != "")
                        {
                            row[count] = int.Parse(s);
                            count++;
                        }
                    }
                    board[j] = row;
                }
                list.Add(board);
            }

            return list;
        }

        public int[][] PlayBingoPart1(ref int x)
        {
            int[][] winner = new int[5][];

            foreach (int n in drawnNumbers)
            {
                foreach (int[][] board in boards)
                {
                    foreach (int[] row in board)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (row[i] == n)
                            {
                                row[i] = -row[i];
                            }
                        }
                    }
                }
                winner = CheckForWinners();
                if (winner != null)
                {
                    x = n;
                    return winner;
                }
            }

            return null;
        }
        public int[][] PlayBingoPart2(ref int x)
        {
            List<int[][]> winners = boards;

            foreach (int n in drawnNumbers)
            {
                foreach (int[][] board in winners)
                {
                    foreach (int[] row in board)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (row[i] == n)
                            {
                                row[i] = -row[i];
                            }
                        }
                    }
                }



                int[][] winner = CheckForWinners(winners);
                if (winner != null && winners.Count != 1)
                {
                    for (int i = 0; i < winners.Count; i++)
                    {
                        if (IsWinner(winners[i]))
                        {
                            winners.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (winner != null)
                {
                    x = n;
                    return winner;
                }
            }

            return null;
        }


        private static int[][] CheckForWinners()
        {
            foreach (int[][] b in boards)
            {
                if (CheckHorizontalWin(b) || CheckVerticalWin(b) || CheckDiagonalWin(b))
                {
                    return b;
                }
            }
            return null;
        }

        private static int[][] CheckForWinners(List<int[][]> board)
        {
            foreach (int[][] b in board)
            {
                if (CheckHorizontalWin(b) || CheckVerticalWin(b) || CheckDiagonalWin(b))
                {
                    return b;
                }
            }
            return null;
        }

        private static bool IsWinner(int[][] b)
        {
            if (CheckHorizontalWin(b) || CheckVerticalWin(b) || CheckDiagonalWin(b))
            {
                return true;
            }

            return false;
        }

        private static bool CheckDiagonalWin(int[][] b)
        {
            int count = 0;
            int oCount = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i][i] < 0)
                {
                    count++;
                }
                if (b[i][4 - i] < 0)
                {
                    oCount++;
                }
                if (count == 5)
                {
                    return true;
                }
                if (oCount == 5)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckVerticalWin(int[][] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < b[i].Length; j++)
                {
                    if (b[j][i] < 0)
                    {
                        count++;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckHorizontalWin(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                int count = 0;
                foreach (int n in board[i])
                {
                    if (n < 0)
                    {
                        count++;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
            }
            return false;
        }
    }
}