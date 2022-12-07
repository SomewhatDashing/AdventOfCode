using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = File.ReadAllText(@"C:\Users\A365282\source\repos\AdventOfCode_2022\Day1_Calories\input.txt");
            string[] groups = content.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
            List<int> groupValues = new List<int>();
            int entrySum;

            foreach (string group in groups)
            {
                string[] lines = group.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                entrySum = 0;

                foreach (string line in lines)
                    entrySum += int.Parse(line);
                
                groupValues.Add(entrySum);
            }

            groupValues.Sort();
            groupValues.Reverse();

            Console.WriteLine($"Beefiest beefcake: {groupValues[0]}");
            Console.WriteLine($"Top 3 beefcakes: {groupValues[0]}, {groupValues[1]}, {groupValues[2]}. Total of: {groupValues[0] + groupValues[1] + groupValues[2]}.");
            Console.ReadKey();
        }
    }
}