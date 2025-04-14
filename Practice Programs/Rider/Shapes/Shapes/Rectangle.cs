using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Width { private set; get; }
        public double Length { private set; get; }

        public Rectangle(double width, double length) : base(4)
        {
            Width = width;
            Length = length;
        }

        public override double CalculateArea()
        {
            return Width * Length;
        }

        public override void Draw()
        {
            Console.WriteLine("rectangle");
        }
    }
}