using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Advent2015
{
    public class Day4
    {
        string key = "bgvyzdsv";

        internal void Part2()
        {
            for (int i = 0; i < 100000000; i++)
            {
                string hash = CreateMD5(key + i);
                if (hash.StartsWith("000000"))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        internal void Part1()
        {
            for (int i = 0; i < 100000000; i++)
            {
                string hash = CreateMD5(key + i);
                if (hash.StartsWith("00000"))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}