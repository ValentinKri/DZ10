using System;
using System.Collections.Generic;
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

        public static double Dist(Point point1, Point point2) => Sqrt(Pow(point1.X - point2.X, 2) + Pow(point1.Y - point2.Y, 2));
        public override string ToString() => $"({X}, {Y})";
    }

    public class Rectangle
    {
        public Point Point1 { get; }
        public Point Point2 { get; }
        public Point Point3 { get; }
        public Point Point4 { get; }
        public Point Center { get; }

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
        }

        public override string ToString() => $"({Point1}, {Point2}, {Point3}, {Point4})";
    }
}