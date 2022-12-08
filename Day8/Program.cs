using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllText(@"..\..\input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<List<int>> treeMatrix = new List<List<int>>();
            int bestSceneValue = -1, currentSceneValue = 0;

            // Build tree matrix
            foreach (string line in lines)
            {
                List<int> treeLine = new List<int>();
                
                foreach (char tree in line)
                    treeLine.Add(int.Parse(tree.ToString()));
                treeMatrix.Add(treeLine);
            }

            int visibleTrees = treeMatrix.Count * 4 - 4;

            for (int i = 1; i < treeMatrix.Count - 1; i++)
            {
                for (int j = 1; j < treeMatrix.Count - 1; j++)
                {
                    visibleTrees += TreeVisible(i, j, treeMatrix.Count, treeMatrix, ref currentSceneValue);
                    if (currentSceneValue > bestSceneValue)
                        bestSceneValue = currentSceneValue;
                }
            }

            Console.WriteLine($"Visible trees from outside: {visibleTrees}");
            Console.WriteLine($"Best scene value: {bestSceneValue}");
            Console.ReadKey();
        }

        static int TreeVisible(int x, int y, int fieldSize, List<List<int>> treeMatrix, ref int sceneValue)
        {
            int tree = treeMatrix[y][x];
            bool visLeft = true, visRight = true, visTop = true, visBottom = true;
            int sceneLeft = 0, sceneRight = 0, sceneTop = 0, sceneBottom = 0;

            // Left
            for (int i = x - 1; i >= 0; i--)
            {
                sceneLeft++;
                if (treeMatrix[y][i] >= tree)
                {
                    visLeft = false;
                    break;
                }
            }

            // Right
            for (int i = x + 1; i < fieldSize; i++)
            {
                sceneRight++;
                if (treeMatrix[y][i] >= tree)
                {
                    visRight = false;
                    break;
                }
            }

            // Top
            for (int i = y - 1; i >= 0; i--)
            {
                sceneTop++;
                if (treeMatrix[i][x] >= tree)
                {
                    visTop = false;
                    break;
                }
            }

            // Bottom
            for (int i = y + 1; i < fieldSize; i++)
            {
                sceneBottom++;
                if (treeMatrix[i][x] >= tree)
                {
                    visBottom = false;
                    break;
                }
            }

            sceneValue = sceneLeft * sceneRight * sceneBottom * sceneTop;

            if (visLeft || visRight || visTop || visBottom)
                return 1;
            return 0;
        }
    }
}