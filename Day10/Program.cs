using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder crt = new StringBuilder();
            string[] lines = File.ReadAllText(@"..\..\input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int processPointer = 1, signalValue = 1;
            List<int> signalValues = new List<int>();

            foreach (string instruction in lines)
            {
                string[] fields = instruction.Split(' ');

                if (fields[0] == "noop")
                    StepProcess(ref processPointer, signalValues, signalValue, crt);
                
                if (fields[0] == "addx")
                {
                    StepProcess(ref processPointer, signalValues, signalValue, crt);
                    StepProcess(ref processPointer, signalValues, signalValue, crt);
                    signalValue += int.Parse(fields[1]);
                }
            }

            Console.WriteLine(crt.ToString());
            Console.WriteLine(signalValues.Sum());
            Console.ReadKey();
        }
        static void StepProcess(ref int processPointer, List<int> signalValues, int signalValue, StringBuilder crt)
        {
            crt.Append(new List<int> { signalValue - 1, signalValue, signalValue + 1 }.Contains((processPointer - 1) % 40) ? "#" : ".");
            crt.Append(processPointer % 40 == 0 ? "\r\n" : ""); // Mama didn't raise an animal that skips on formatting

            if (processPointer == 20 || (processPointer + 20) % 40 == 0)
                signalValues.Add(signalValue * processPointer);

            processPointer++;
        }
    }
}
