using System;
using GeometrySimulator;

namespace Homework10
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Rectangle(new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0));
            Console.WriteLine(c.ToString());
            c.Rotate(45);
            Console.WriteLine(c.ToString());
        }
    }
}