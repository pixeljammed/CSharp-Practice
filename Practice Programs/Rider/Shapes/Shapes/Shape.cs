using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        protected int numberOfSides;

        public int Sides
        {
            get { return numberOfSides; }
        }

        public Shape(int sides)
        {
            numberOfSides = sides;
        }

        public abstract double CalculateArea();

        public abstract void Draw();
    }
}