using System;

namespace Kelson.CSharp.Extensions
{
    public static class ComparableExtensions
    {
        public delegate bool Comparator<in T>(T actual, T comparable) where T : IComparable<T>;

        /// <summary>
        /// Determines if the specified value is between from (default: inclusive) and to (default: exclusive).
        /// </summary>
        public static bool IsBetween<T>(this T actual, T lower, T upper, RangeFlags range = RangeFlags.FromInclusive) where T : IComparable<T>
        {
            int lowerComp = actual.CompareTo(lower);
            int upperComp = actual.CompareTo(upper);
            bool result = false;
            switch (range)
            {
                case RangeFlags.Exclusive:
                    result = (lowerComp > 0) && (upperComp < 0);
                    break;
                case RangeFlags.FromInclusive:
                    result = (lowerComp >= 0) && (upperComp < 0);
                    break;
                case RangeFlags.ToInclusive:
                    result = (lowerComp > 0) && (upperComp <= 0);
                    break;
                case RangeFlags.Inclusive:
                    result = (lowerComp >= 0) && (upperComp <= 0);
                    break;
            }
            return result;
        }

        public static bool IsSameAs<T>(this T actual, T comparable) where T : IComparable<T>
        {
            return actual.CompareTo(comparable) == 0;
        }

        public static bool IsLessThan<T>(this T actual, T comparable) where T : IComparable<T>
        {
            return actual.CompareTo(comparable) < 0;
        }

        public static bool IsLessThanOrEqualTo<T>(this T actual, T comparable) where T : IComparable<T>
        {
            return actual.CompareTo(comparable) <= 0;
        }

        public static bool IsGreaterThan<T>(this T actual, T comparable) where T : IComparable<T>
        {
            return actual.CompareTo(comparable) > 0;
        }

        public static bool IsGreaterThanOrEqualTo<T>(this T actual, T comparable) where T : IComparable<T>
        {
            return actual.CompareTo(comparable) >= 0;
        }
    }
}