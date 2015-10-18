using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        public override string ShapeName => "RightTriangle";
        public double Hypotenuse => Math.Sqrt(Edge1*Edge1 + Edge2*Edge2);

        public RightTriangle(double edge1, double edge2) : base(edge1, edge2, Math.Sqrt(edge1*edge1 + edge2*edge2))
        {
        }

        public RightTriangle(IDictionary<ParamKeys, object> parameters)
            : base((double) parameters[ParamKeys.Edge1],
                (double) parameters[ParamKeys.Edge2],
                Math.Sqrt(Math.Pow((double) parameters[ParamKeys.Edge1], 2) +
                          Math.Pow((double) parameters[ParamKeys.Edge2], 2)))
        {
        }

        protected override double Area()
        {
            return Edge1*Edge2/2d;
        }
    }
}