using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        public override string ShapeName => "EquilateralTriangle";

        public EquilateralTriangle(double edge1) : base(edge1, edge1, edge1)
        {
        }

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters)
            : base((double) parameters[ParamKeys.Edge1],
                (double) parameters[ParamKeys.Edge1],
                (double) parameters[ParamKeys.Edge1])
        {
        }
    }
}