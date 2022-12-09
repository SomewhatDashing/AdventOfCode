using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllText(@"..\..\input.txt").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<Point> snake = new List<Point>() { new Point(0, 0), new Point(0, 0) },
            snake2 = new List<Point>() { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0) };
            Dictionary<char, Point> movements = new Dictionary<char, Point>() { { 'R', new Point(1, 0) }, { 'L', new Point(-1, 0) }, { 'U', new Point(0, 1) }, { 'D', new Point(0, -1) } };

            Console.WriteLine($"Part 1: {RunSnakeRunExclamationMark(lines, movements, snake)}");
            Console.WriteLine($"Part 2: {RunSnakeRunExclamationMark(lines, movements, snake2)}");
            Console.ReadKey();
        }
        public static int RunSnakeRunExclamationMark(string[] lines, Dictionary<char, Point> movements, List<Point> snake)
        {
            List<Point> visitedPoints = new List<Point>() { new Point(0, 0) };

            foreach (string line in lines)
            {
                string[] move = line.Split(' ');

                for (int j = 0; j < int.Parse(move[1]); j++)
                {
                    snake[0].Move(movements[char.Parse(move[0])]);

                    for (int i = 0; i < snake.Count - 1; i++)
                    {
                        if (IShouldMove(snake[i + 1], snake[i]))
                            MovePart(snake[i + 1], snake[i], movements);
                    }

                    if (visitedPoints.Find(newPosition => newPosition.X == snake.Last().X && newPosition.Y == snake.Last().Y) == null)
                        visitedPoints.Add(new Point(snake.Last().X, snake.Last().Y));
                }
            }

            return visitedPoints.Count;
        }
        public static bool IShouldMove(Point me, Point front)
        {
            if (Math.Abs(me.X - front.X) > 1 || Math.Abs(me.Y - front.Y) > 1)
                return true;
            return false;
        }
        public static void MovePart(Point me, Point destination, Dictionary<char, Point> movements)
        {
            if (destination.X > me.X)
                me.Move(movements['R']);
            if (destination.X < me.X)
                me.Move(movements['L']);
            if (destination.Y < me.Y)
                me.Move(movements['D']);
            if (destination.Y > me.Y)
                me.Move(movements['U']);
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(Point point)
        {
            X += point.X;
            Y += point.Y;
        }
    }
}