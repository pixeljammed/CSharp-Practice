using System;

namespace Shapes
{
    public class Triangle : Shape
    {
        public double Based { private set; get; }
        public double Height { private set; get; }

        public Triangle(double based, double height) : base(4)
        {
            Based = based;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Based * Height;
        }

        public override void Draw()
        {
            Console.WriteLine("triangle");
        }
    }
}