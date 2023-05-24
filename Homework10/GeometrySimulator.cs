using System;
using static System.Math;

namespace GeometrySimulator
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

        public Simulator(IEnumerable<Rectangle> rectangles)
        {
            Rectangles = rectangles.ToList();
        }

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
}