using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Rectangle : ShapeBase
    {
        protected double _edge1, _edge2;
        public double Edge1 => _edge1 * Multiplier;
        public double Edge2 => _edge2 * Multiplier;
        public override string ShapeName => "Rectangle";

        public Rectangle(double edge1, double edge2)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }


        public Rectangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
        }

        public override double GetPerimeter()
        {
            return 2*(Edge1 + Edge2);
        }

        protected override double Area()
        {
            return Edge1*Edge2;
        }
        
    }
}