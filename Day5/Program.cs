using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build storage directly instead of parsing from input file (and I'm also to lazy to implement a deep copy)
            List<List<char>> storage = new List<List<char>>
            {
                new List<char> { 'B', 'S', 'V', 'Z', 'G', 'P', 'W' }, 
                new List<char> { 'J', 'V', 'B', 'C', 'Z', 'F' }, 
                new List<char> { 'V', 'L', 'M', 'H', 'N', 'Z', 'D', 'C' }, 
                new List<char> { 'L', 'D', 'M', 'Z', 'P', 'F', 'J', 'B' }, 
                new List<char> { 'V', 'F', 'C', 'G', 'J', 'B', 'Q', 'H' }, 
                new List<char> { 'G', 'F', 'Q', 'T', 'S', 'L', 'B' }, 
                new List<char> { 'L', 'G', 'C', 'Z', 'V' }, 
                new List<char> { 'N', 'L', 'G' }, 
                new List<char> { 'J', 'F', 'H', 'C' } 
            };

            List<List<char>> storage2 = new List<List<char>> 
            { 
                new List<char> { 'B', 'S', 'V', 'Z', 'G', 'P', 'W' }, 
                new List<char> { 'J', 'V', 'B', 'C', 'Z', 'F' }, 
                new List<char> { 'V', 'L', 'M', 'H', 'N', 'Z', 'D', 'C' }, 
                new List<char> { 'L', 'D', 'M', 'Z', 'P', 'F', 'J', 'B' }, 
                new List<char> { 'V', 'F', 'C', 'G', 'J', 'B', 'Q', 'H' }, 
                new List<char> { 'G', 'F', 'Q', 'T', 'S', 'L', 'B' }, 
                new List<char> { 'L', 'G', 'C', 'Z', 'V' }, 
                new List<char> { 'N', 'L', 'G' }, 
                new List<char> { 'J', 'F', 'H', 'C' } 
            };

            string[] lines = File.ReadAllText(@"../../input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None).Skip(10).ToArray(); // Skip storage part
            int numOfBoxes, fromStack, toStack;
            string[] instructionFields;
            List<char> tempStack = new List<char>();

            foreach (string instruction in lines)
            {
                instructionFields = instruction.Split(' ');
                numOfBoxes = int.Parse(instructionFields[1]);
                fromStack = int.Parse(instructionFields[3]);
                toStack = int.Parse(instructionFields[5]);

                for (int i = 0; i < numOfBoxes; i++)
                {
                    // Part 1
                    storage[toStack - 1].Add(storage[fromStack - 1].Last());
                    storage[fromStack - 1].RemoveAt(storage[fromStack - 1].Count - 1);

                    // Part 2
                    tempStack.Add(storage2[fromStack - 1].Last());
                    storage2[fromStack - 1].RemoveAt(storage2[fromStack - 1].Count - 1);
                }

                // Part 2 - reverse list and add it on top of the toStack
                tempStack.Reverse();
                storage2[toStack - 1].AddRange(tempStack);
                tempStack.Clear();
            }

            foreach (List<char> pile in storage)
                Console.Write(pile.Last());

            Console.WriteLine();

            foreach (List<char> pile in storage2)
                Console.Write(pile.Last());

            Console.ReadKey();
        }
    }
}
