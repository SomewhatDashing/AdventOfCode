using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = File.ReadAllText(@"C:\Users\A365282\source\repos\AdventOfCode_2022\Day7\input.txt");
            string[] lines = content.Split(new string[] { "$ " }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            DeviceDirectory tree = new DeviceDirectory("/", null);
            DeviceDirectory currentDirectory = tree;
            const int TOTAL_SIZE = 70000000;
            const int SPACE_NEEDED = 30000000;

            List<int> answerSet = new List<int>();

            // Build tree
            foreach (string line in lines)
            {
                if (line.StartsWith("ls"))
                {
                    string[] contentLines = line.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 1; i < contentLines.Length; i++)
                    {
                        string[] listItemContent = contentLines[i].Split(' ');
                        if (contentLines[i].StartsWith("dir"))
                            currentDirectory.directories.Add(new DeviceDirectory(listItemContent[1], currentDirectory));
                        else
                            currentDirectory.files.Add(new DeviceFile(listItemContent[1], int.Parse(listItemContent[0])));
                    }
                }

                if (line.StartsWith("cd"))
                {
                    string dirName;
                    if ((dirName = line.Split()[1]) != "..")
                        currentDirectory = currentDirectory.directories.Find(x => x.name == dirName);
                    else
                        currentDirectory = currentDirectory.parent;
                }
            }

            // Calculate directories' sizes recursively
            int freeSpaceNow = TOTAL_SIZE - CalculateDirectorySize(tree, answerSet);

            answerSet.Sort();

            Console.WriteLine(answerSet.Where(x => x < 100000).Sum());
            Console.WriteLine(answerSet.Where(x => x > SPACE_NEEDED - freeSpaceNow).FirstOrDefault());
            Console.ReadKey();
        }

        static int CalculateDirectorySize(DeviceDirectory directory, List<int> answerSet)
        {
            if (directory.directories.Count > 0)
            {
                for (int i = 0; i < directory.directories.Count; i++)
                     directory.size += CalculateDirectorySize(directory.directories[i], answerSet);
            }

            directory.size += directory.files.Sum(x => x.size);

            // Only used for our answers
            answerSet.Add(directory.size);

            return directory.size;
        }
    }

    class DeviceDirectory
    {
        public string name;
        public int size;
        public DeviceDirectory parent;
        public List<DeviceDirectory> directories;
        public List<DeviceFile> files;

        public DeviceDirectory(string name, DeviceDirectory parent)
        {
            this.name = name;
            size = 0;
            this.parent = parent;
            directories = new List<DeviceDirectory>();
            files = new List<DeviceFile>();
        }
    }

    class DeviceFile
    {
        public string name;
        public int size;

        public DeviceFile(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
    }
}