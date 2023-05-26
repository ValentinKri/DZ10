using System;
using System.Collections.Generic;
using static System.Math;

namespace HomeWork10
{
    class Class3
    {
        public class Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public static double Dist(Point point1, Point point2) =>
                Sqrt(Pow(point1.X - point2.X, 2) + Pow(point1.Y - point2.Y, 2));
            public override string ToString() => $"({X}, {Y})";
        }

        public class Rectangle
        {
            public Point Point1 { get; private set; }
            public Point Point2 { get; private set; }
            public Point Point3 { get; private set; }
            public Point Point4 { get; private set; }
            public Point Center { get; private set; }

            public Point[] Points;

            public Rectangle(Point point1, Point point2, Point point3, Point point4)
            {
                if (Point.Dist(point1, point2) != Point.Dist(point3, point4) || Point.Dist(point1, point4) != Point.Dist(point2, point3))
                    throw new ArgumentException("Задан не прямоугольник");
                Point1 = point1;
                Point2 = point2;
                Point3 = point3;
                Point4 = point4;
                double dx = (point3.X - point1.X) / 2;
                double dy = (point3.Y - point1.Y) / 2;
                Center = new Point(point1.X + dx, point1.Y + dy);
                Points = new Point[4] { Point1, Point2, Point3, Point4 };
            }

            public void Rotate(double angle)
            {
                double angleRadian = angle * PI / 180;
                for (int i = 0; i < 4; i++)
                {
                    double x = Round((Points[i].X - Center.X) * Cos(angleRadian) - (Points[i].Y - Center.Y) * Sin(angleRadian) + Center.X, 3);
                    double y = Round((Points[i].X - Center.X) * Sin(angleRadian) + (Points[i].Y - Center.Y) * Cos(angleRadian) + Center.Y, 3);
                    Points[i] = new Point(x, y);
                }
                Point1 = Points[0];
                Point2 = Points[1];
                Point3 = Points[2];
                Point4 = Points[3];
            }
            public void Move(double x, double y)
            {
                for (int i = 0; i < 4; i++)
                {
                    double mx = Points[i].X + x;
                    double my = Points[i].Y + y;
                    Points[i] = new Point(mx, my);
                }
                Point1 = Points[0];
                Point2 = Points[1];
                Point3 = Points[2];
                Point4 = Points[3];
            }
            public double Perimeter() =>
                Point.Dist(Point1, Point2) + Point.Dist(Point2, Point3) + Point.Dist(Point3, Point4) + Point.Dist(Point4, Point1);
            public double Area() =>
                Point.Dist(Point1, Point2) * Point.Dist(Point1, Point4);
            public override string ToString() =>
                $"({Point1}, {Point2}, {Point3}, {Point4})";
        }

        public class Simulator
        {
            public Point Center { get; } = new Point(0, 0);
            public List<Rectangle> Rectangles;

            public Simulator(List<Rectangle> rectangles)
            {
                Rectangles = rectangles;
            }

            public Rectangle[] GetRectangles() => Rectangles.ToArray();
            public Rectangle? FarthestRectangle()
            {
                double maxDist = double.MaxValue;
                Rectangle? res = null;
                foreach (var rectangle in Rectangles)
                {
                    double nearest = double.MaxValue;
                    foreach (var point in rectangle.Points)
                    {
                        if (nearest < Point.Dist(Center, point))
                        {
                            nearest = Point.Dist(Center, point);
                        }
                    }
                    if (nearest > maxDist)
                    {
                        maxDist = nearest;
                        res = rectangle;
                    }
                }
                return res;
            }
            public void Print() => string.Join("\n", Rectangles);
        }
        public void Init()
        {
            Console.WriteLine("Вас приветствует симулятор геметрии");
            Console.Write("Сколько прямоугольников вы хотите иметь на плоскости? => ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Теперь задайте координаты каждого");
            var rectangles = new List<Rectangle>();
            for (int i = 0; i < c; i++)
            {
                Console.Write(i + ": ");
                Console.Write("point1: ");
                Console.Write("x => ");
                var x1 = double.Parse(Console.ReadLine());
                Console.Write("y => ");
                var y1 = double.Parse(Console.ReadLine());
                Point point1 = new Point(x1, y1);
                Console.Write("point2: ");
                Console.Write("x => ");
                var x2 = double.Parse(Console.ReadLine());
                Console.Write("y => ");
                var y2 = double.Parse(Console.ReadLine());
                Point point2 = new Point(x2, y2);
                Console.Write("point3: ");
                Console.Write("x => ");
                var x3 = double.Parse(Console.ReadLine());
                Console.Write("y => ");
                var y3 = double.Parse(Console.ReadLine());
                Point point3 = new Point(x3, y3);
                Console.Write("point4: ");
                Console.Write("x => ");
                var x4 = double.Parse(Console.ReadLine());
                Console.Write("y => ");
                var y4 = double.Parse(Console.ReadLine());
                Point point4 = new Point(x4, y4);
                rectangles.Add(new Rectangle(point1, point2, point3, point4));
            }
            var sim = new Simulator(rectangles);
            while (true)
            {
                Console.Write("Что вы хотите сделать с фигурами? Ввыедите название команды => ");
                var com = Console.ReadLine();
                if (com == "Exit")
                    break;
                if (com == "GetAll")
                {
                    Console.WriteLine(string.Join("\n", sim.Rectangles));
                    continue;
                }
                if (com == "FarthestRectangle")
                {
                    Console.WriteLine(sim.FarthestRectangle());
                    continue;
                }
                Console.Write("Какую фигуру по номеру? => ");
                var num = int.Parse(Console.ReadLine()) + 1;
                switch (com)
                {
                    case "Rotate":
                        Console.Write("На сколько градусов повернуть? => ");
                        var angle = double.Parse(Console.ReadLine());
                        sim.Rectangles[num].Rotate(angle);
                        break;
                    case "Move":
                        Console.Write("На сколько подвинуть фигруру => ");
                        Console.Write("x => ");
                        var x = double.Parse(Console.ReadLine());
                        Console.Write("y => ");
                        var y = double.Parse(Console.ReadLine());
                        sim.Rectangles[num].Move(x, y);
                        break;
                    case "Perimeter":
                        Console.Write($"Периметр: {sim.Rectangles[num].Perimeter()}");
                        break;
                    case "Area":
                        Console.Write($"Площадь: {sim.Rectangles[num].Area()}");
                        break;
                    case "Get":
                        Console.Write($"Площадь: {sim.Rectangles[num]}");
                        break;
                }
            }
        }
    }
}
