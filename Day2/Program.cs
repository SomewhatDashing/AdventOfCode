using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = File.ReadAllText(@"C:\Users\A365282\source\repos\AdventOfCode_2022\Day2\input.txt");
            string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            List<string> choices;
            int totalScore1 = 0, totalScore2 = 0;

            int[,] pointMatrixPart1 = new int[3, 3] {
                { 4, 8, 3 },
                { 1, 5, 9 },
                { 7, 2, 6 }
            };

            int[,] pointMatrixPart2 = new int[3, 3] {
                { 3, 4, 8 },
                { 1, 5, 9 },
                { 2, 6, 7 }
            };

            foreach (string match in lines)
            {
                choices = match.Split(new char[] { ' ' }).ToList();

                totalScore1 += pointMatrixPart1[char.Parse(choices[0]) - 65, char.Parse(choices[1]) - 88];
                totalScore2 += pointMatrixPart2[char.Parse(choices[0]) - 65, char.Parse(choices[1]) - 88];
            }

            Console.WriteLine("Score part 1: " + totalScore1);
            Console.WriteLine("Score part 2: " + totalScore2);
            Console.ReadKey();
        }
    }
}