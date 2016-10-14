using System;
using Kelson.CSharp.MathExtensions;
using Point = System.Windows.Point;

namespace Kelson.CSharp.Extensions
{
    public static class PolarMathExtensions
    {
        /// <summary>
        /// Calculates an equivalent angle in the range [0, 2π).
        /// </summary>
        public static double SmallestPositiveAngle(this double angle)
        {
            if (angle >= 0)
            {
                return angle % MathExt.TwoPi;
            }
            int factor = (int)Math.Ceiling(-angle / MathExt.TwoPi);
            double rotations = MathExt.TwoPi * factor;
            return angle + rotations;
        }

        /// <summary>
        /// Calculates the angle between two angles, in radians.
        /// </summary>
        public static double AngularDistance(this double val, double from)
        {
            val = val.SmallestPositiveAngle();
            double distance = Math.Abs(from - val);
            return distance <= Math.PI ? distance : Math.Abs(distance - MathExt.TwoPi);
        }

        public static PolarPoint ToPolar(this Point cartesian)
        {
            double r = cartesian.Magnitude();
            double θ = Math.Atan2(cartesian.Y, cartesian.X);
            return new PolarPoint(r, θ);
        }

        public static Point ToCartesian(this PolarPoint polar)
        {
            double r = polar.R;
            double x = r * Math.Cos(polar.Θ);
            double y = r * Math.Sin(polar.Θ);
            return new Point(x, y);
        }

        public static double Magnitude(this Point point)
        {
            return Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
        }

        public static Point Translate(this Point original, double x, double y)
        {
            return new Point(original.X + x, original.Y + y);
        }


    }
}
