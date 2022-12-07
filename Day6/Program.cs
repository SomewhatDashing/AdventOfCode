using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = File.ReadAllText(@"C:\Users\A365282\source\repos\AdventOfCode_2022\Day6\input.txt");

            Console.WriteLine($"Marker at: {FindMarker(4, content)}");
            Console.WriteLine($"Message at: {FindMarker(14, content)}");
            Console.ReadKey();
        }

        private static int FindMarker(int windowSize, string jibberish)
        {
            for (int i = 0; i < jibberish.Length - windowSize; i++)
                if (jibberish.Substring(i, windowSize).Distinct().Count() == windowSize)
                    return i + windowSize;
            return -1;
        }
    }
}
