using System;

namespace Shapes
{
    public class Square : Shape
    {
        public double SideLength { private set; get; }

        public Square(double side) : base(4)
        {
            SideLength = side;
        }

        public override double CalculateArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public override void Draw()
        {
            Console.WriteLine("square");
        }
    }
}