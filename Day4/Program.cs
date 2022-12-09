using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] group, lines = File.ReadAllText(@"..\..\input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int contains = 0, intersects = 0;

            foreach (string line in lines)
            {
                group = line.Split(new char[] {'-', ','});
                List<int> sample1 = Enumerable.Range(int.Parse(group[0]), int.Parse(group[1]) - int.Parse(group[0]) + 1).ToList(),
                          sample2 = Enumerable.Range(int.Parse(group[2]), int.Parse(group[3]) - int.Parse(group[2]) + 1).ToList();

                if (sample1.Union(sample2).Count() == sample1.Count || sample2.Union(sample1).Count() == sample2.Count)
                    contains++;
                
                if (sample1.Intersect(sample2).Count() > 0  || sample2.Intersect(sample1).Count() > 0)
                    intersects++;
            }

            Console.WriteLine(contains);
            Console.WriteLine(intersects);
            Console.ReadKey();
        }
    }
}