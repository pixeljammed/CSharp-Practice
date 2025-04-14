using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius { private set; get; }

        public Circle(double radius) : base(4)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override void Draw()
        {
            Console.WriteLine("circle");
        }
    }
}