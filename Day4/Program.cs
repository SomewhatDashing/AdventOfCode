using System;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllText(@"..\..\input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] group;
            int min1, min2, max1, max2;
            int overlaps1 = 0, overlaps2 = 0;

            foreach (string line in lines)
            {
                group = line.Split(',');

                min1 = int.Parse(group[0].Split('-')[0]);
                min2 = int.Parse(group[1].Split('-')[0]);
                max1 = int.Parse(group[0].Split('-')[1]);
                max2 = int.Parse(group[1].Split('-')[1]);

                if ((min1 >= min2 && max1 <= max2) || (min2 >= min1 && max2 <= max1))
                    overlaps1++;

                if ((min1 >= min2 && min1 <= max2) || (min2 >= min1 && min2 <= max1) || (max1 >= min2 && max1 <= max2) || (max2 >= min1 && max2 <= max1))
                    overlaps2++;
            }

            Console.WriteLine(overlaps1);
            Console.WriteLine(overlaps2);
            Console.ReadKey();
        }
    }
}