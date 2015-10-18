using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    // TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        protected double _edge1, _edge2, _edge3;
        public double Edge1 => _edge1 * Multiplier;
        public double Edge2 => _edge2 * Multiplier;
        public double Edge3 => _edge3 * Multiplier;
        public override string ShapeName => "Triangle";

        public Triangle(double edge1, double edge2, double edge3)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, edge3},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }


        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            if (!ValidTriangle((double) parameters[ParamKeys.Edge1],
                (double) parameters[ParamKeys.Edge2],
                (double) parameters[ParamKeys.Edge3]))
                throw new ArgumentException();

            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double)parameters[ParamKeys.Edge3];
        }

        private bool ValidTriangle(double edge1 , double edge2 , double edge3 )
        {
            return edge1 <= edge2 + edge3 &&
                   edge2 <= edge1 + edge3 &&
                   edge3 <= edge1 + edge2;
        }

        public override double GetPerimeter()
        {
            return Edge1 + Edge2 + Edge3;
        }

        protected override double Area()
        {
            double semiperimeter = GetPerimeter()/2d;
            return Math.Sqrt(semiperimeter * (semiperimeter - Edge1)*(semiperimeter - Edge2)*(semiperimeter - Edge3));
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }
        
    }
}