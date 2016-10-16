using System;
using System.Linq;

namespace Kelson.CSharp.MathExtensions
{
    /// <summary>
    /// Provides useful functionality not found in the default Math class.
    /// </summary>
    public static class MathExt
    {
        /// <summary>
        /// 2π
        /// </summary>
        public const double TwoPi = 6.283185307179586;

        /// <summary>
        /// Multiply by a radian value to get degrees.
        /// Divide degrees by this to get radians.
        /// </summary>
        public const double DegreesPerRadian = 57.29577951308232;

        /// <summary>
        /// The square root of 2.
        /// </summary>
        public const double SquareRootOf2 = 1.4142135623730950;

        /// <summary>
        /// The golden ratio.
        /// </summary>
        public const double GoldenRatio = 1.6180339887;

        /// <summary>
        /// Returns the largest element from a list of arguments.
        /// </summary>
        public static T Max<T>(params T[] args) where T : IComparable
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Can not take the max of an empty set.");
            }
            return args.Max();
        }

        /// <summary>
        /// Returns the largest element from a list of arguments.
        /// </summary>
        /// <param name="comparer">Method to derive a comparable value from an item.</param>
        public static T Max<T>(this Func<T, IComparable> comparer, params T[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Can not take the max of an empty set.");
            }
            return args.Aggregate((max, item) => comparer(max).CompareTo(comparer(item)) < 0 ? item : max);
        }

        /// <summary>
        /// Returns the smallest element from a list of arguments.
        /// </summary>
        public static T Min<T>(params T[] args) where T : IComparable
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Can not take the min of an empty set.");
            }
            return args.Min();
        }

        /// <summary>
        /// Returns the smallest element from a list of arguments.
        /// </summary>
        /// <param name="comparer">Method to derive a comparable value from an item.</param>
        public static T Min<T>(this Func<T, IComparable> comparer, params T[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Can not take the max of an empty set.");
            }
            return args.Aggregate((min, item) => comparer(min).CompareTo(comparer(item)) > 0 ? item : min);
        }


        /// <summary>
        /// Computes the arithmetic mean of a list of doubles.
        /// </summary>
        public static double Mean(params double[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Can not take the mean of an empty set.");
            }
            return args.Sum() / args.Length;
        }

        /// <summary>
        /// Computes the arithmetic mean of a list of integers.
        /// </summary>
        public static double Mean(params int[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Can not take the mean of an empty set.");
            }
            return args.Sum() / (double)args.Length;
        }

        /// <summary>
        /// Computes the mean of a list of items.
        /// </summary>
        /// <param name="selector">Method to map item to an arithmetic value.</param>
        public static double Mean<T>(this Func<T, double> selector, params T[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Can not take the mean of an empty set.");
            }
            return args.Select(selector).Sum() / args.Length;
        }
    }
}