////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

namespace Kelson.CSharp.Extensions
{
    /// <summary>
    /// Stores a radius angle pair.
    /// </summary>
    public struct PolarPoint
    {
        public readonly double R;

        public readonly double Θ;

        public PolarPoint(double r, double θ)
        {
            R = r;
            Θ = θ;
        }

        public static bool operator ==(PolarPoint point1, PolarPoint point2)
        {
            return point1.R.Is(point2.R) && point1.Θ.Is(point2.Θ);
        }

        public static bool operator !=(PolarPoint point1, PolarPoint point2)
        {
            return !(point1 == point2);
        }
    }
}
