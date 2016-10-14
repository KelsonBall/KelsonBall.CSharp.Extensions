////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;

namespace Kelson.CSharp.Extensions
{
    public static class FloatingPointExtentions
    {
        /// <summary>
        /// Determines if two floating point values are within a threshold.
        /// </summary>
        public static bool Is(this decimal val, decimal compare, decimal threshold = 1e-27m)
        {
            return System.Math.Abs(val - compare) < threshold;
        }

        /// <summary>
        /// Determines if two floating point values are within a threshold.
        /// </summary>
        public static bool Is(this double val, double compare, double threshold = double.Epsilon)
        {
            return System.Math.Abs(val - compare) < threshold;
        }

        /// <summary>
        /// Determines if two floating point values are within a threshold.
        /// </summary>
        public static bool Is(this float val, float compare, float threshold = float.Epsilon)
        {
            return System.Math.Abs(val - compare) < threshold;
        }

        /// <summary>
        /// Converts a double to a numerator denominator pair.
        /// </summary>
        /// <param name="value">A non zero, countable decimal to convert to a fraction.</param>
        /// <param name="error">The maximum error between the specified value and the </param>
        /// <returns></returns>
        public static Tuple<int, int> ToFraction(this double value, double error = double.Epsilon)
        {
            if (double.IsNaN(value)|| double.IsInfinity(value))
            {
                throw new ArgumentException(nameof(value), "Must be non zero and countable.");
            }
            if (!error.IsBetween<double>(0d, 1d, RangeFlags.Exclusive))
            {
                throw new ArgumentOutOfRangeException(nameof(error), "Must be between 0 and 1 (exclusive).");
            }

            int sign = System.Math.Sign(value);

            if (sign == -1)
            {
                value = System.Math.Abs(value);
            }

            if (sign != 0)
            {
                // error is the maximum relative error; convert to absolute
                error *= value;
            }

            int n = (int)System.Math.Floor(value);
            value -= n;

            if (value < error)
            {
                return new Tuple<int, int>(sign * n, 1);
            }

            if (1 - error < value)
            {
                return new Tuple<int, int>(sign * (n + 1), 1);
            }

            // The lower fraction is 0/1
            int lowerNumerator = 0;
            int lowerDenominator = 1;

            // The upper fraction is 1/1
            int upperNumerator = 1;
            int upperDenominator = 1;

            int maximumErrorCounter = 0;
            int middleNumerator = lowerNumerator + upperNumerator;
            int middleDenominator = lowerDenominator + upperDenominator;
            while (maximumErrorCounter++ < sizeof(double) * sizeof(double))
            {
                if (middleDenominator * (value + error) < middleNumerator)
                {
                    // real + error < middle : middle is our new upper
                    upperNumerator = middleNumerator;
                    upperDenominator = middleDenominator;
                }
                else if (middleNumerator < (value - error) * middleDenominator)
                {
                    // middle < real - error : middle is our new lower
                    lowerNumerator = middleNumerator;
                    lowerDenominator = middleDenominator;
                }
                else
                {
                    break;
                }
                // The middle fraction is (lower_numerator + upper_numerator) / (lower_denominator + upper_denominator)
                middleNumerator = lowerNumerator + upperNumerator;
                middleDenominator = lowerDenominator + upperDenominator;
            }
            return new Tuple<int, int>((n * middleDenominator + middleNumerator) * sign, middleDenominator);
        }
    }
}