using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Advent
{
    public class Day4
    {
        static int[] drawnNumbers;
        static List<int[][]> boards;

        public Day4()
        {
            boards = ParseBoards();
            drawnNumbers = ParseNumbers();
        }

        private int[] ParseNumbers()
        {
            return File.ReadAllLines("data/bingoData.txt")[0].Split(',').Select(int.Parse).ToArray();
        }

        private List<int[][]> ParseBoards()
        {
            List<int[][]> list = new();
            var data = File.ReadAllLines("data/bingoData.txt");


            for (int i = 2; i < data.Length; i += 6)
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

        public void PlayBingoPart1()
        {
            int[][] winner = new int[5][];
            int x = 0;
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
                    System.Console.WriteLine(CalcScore(winner, x));
                    return;
                }
            }
        }

        public void PlayBingoPart2()
        {
            List<int[][]> winners = boards;
            int x = 0;
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
                    System.Console.WriteLine(CalcScore(winner, x));
                    return;
                }
            }
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

        public int CalcScore(int[][] board, int winningN)
        {
            int score = 0;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] > 0)
                    {
                        score += board[i][j];
                    }
                }
            }
            return score * winningN;
        }
    }
}