using System;
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
                if (Enumerable.Range(int.Parse(group[0]), int.Parse(group[1]) - int.Parse(group[0]) + 1).ToList().Union(Enumerable.Range(int.Parse(group[2]), int.Parse(group[3]) - int.Parse(group[2]) + 1).ToList()).Count() == int.Parse(group[1]) - int.Parse(group[0]) + 1 || Enumerable.Range(int.Parse(group[2]), int.Parse(group[3]) - int.Parse(group[2]) + 1).ToList().Union(Enumerable.Range(int.Parse(group[0]), int.Parse(group[1]) - int.Parse(group[0]) + 1).ToList()).Count() == int.Parse(group[3]) - int.Parse(group[2]) + 1)
                    contains++;
                
                if (Enumerable.Range(int.Parse(group[0]), int.Parse(group[1]) - int.Parse(group[0]) + 1).ToList().Intersect(Enumerable.Range(int.Parse(group[2]), int.Parse(group[3]) - int.Parse(group[2]) + 1).ToList()).Count() > 0 || Enumerable.Range(int.Parse(group[2]), int.Parse(group[3]) - int.Parse(group[2]) + 1).ToList().Intersect(Enumerable.Range(int.Parse(group[0]), int.Parse(group[1]) - int.Parse(group[0]) + 1).ToList()).Count() > 0)
                    intersects++;
            }

            Console.WriteLine(contains);
            Console.WriteLine(intersects);
            Console.ReadKey();
        }
    }
}