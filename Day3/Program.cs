using System;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllText(@"..\..\input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);

            string values = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int prioSum = 0;

            foreach (string line in lines)
            {
                string firstHalf = line.Substring(0, line.Length / 2);
                string secondHalf = line.Substring(line.Length / 2);

                foreach (char letterFirst in firstHalf)
                {
                    if (secondHalf.Contains(letterFirst))
                    {
                        prioSum += values.IndexOf(letterFirst) + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(prioSum);

            prioSum = 0;

            // Part 2 - Groups of 3
            for (int i = 0; i < lines.Length; i += 3)
            {
                foreach (char letter in lines[i])
                {
                    if (lines[i + 1].Contains(letter) && lines[i + 2].Contains(letter))
                    {
                        prioSum += values.IndexOf(letter) + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(prioSum);
            Console.ReadKey();
        }
    }
}
