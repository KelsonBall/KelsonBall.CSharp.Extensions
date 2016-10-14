////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;
using NUnit.Framework;
using Kelson.CSharp.Extensions;

namespace Kelson.CSharp.MathExtensions.Tests
{
    [TestFixture]
    public class MathExtTests
    {
        [Test]
        public void Max_ListOfNumericArguments_ReturnsMax()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            var max = MathExt.Max(1, 2, 3);
            //----------- Assert-------------------------------
            Assert.True(max == 3);
        }

        [Test]
        public void Max_ListOfComparableArguments_ReturnsMax()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            var max = MathExt.Max("Justin", "Tell", "Kelson");

            //----------- Assert-------------------------------
            Assert.True(max.Equals("Tell"));
        }

        [Test]
        public void Max_NullParameters_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            int[] data = null;

            //----------- Act ---------------------------------
            TestDelegate maxOfNullData = () => MathExt.Max(data);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(maxOfNullData);
        }

        [Test]
        public void MaxOfT_ExampleInput_ReturnsMax()
        {
            //----------- Arrange -----------------------------
            Func<double, double, Tuple<double, double>> point = (x, y) => new Tuple<double, double>(x, y);
            Func<Tuple<double, double>, IComparable> magnitude = p => System.Math.Sqrt(p.Item1 * p.Item1 + p.Item2 * p.Item2);

            //----------- Act ---------------------------------
            var max = MathExt.Max(magnitude, point(0, 0), point(1, 1), point(2, 2));

            //----------- Assert-------------------------------
            Assert.True(max.Item1.Is(2));
            Assert.True(max.Item2.Is(2));
        }

        [Test]
        public void MaxOfT_NullParameters_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            Tuple<int, string>[] data = null;

            //----------- Act ---------------------------------
            TestDelegate maxOfNullData = () => MathExt.Max(t => t.Item1, data);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(maxOfNullData);
        }

        [Test]
        public void MinOfT_ExampleInput_ReturnsMin()
        {
            //----------- Arrange -----------------------------
            Func<double, double, Tuple<double, double>> point = (x, y) => new Tuple<double, double>(x, y);
            Func<Tuple<double, double>, IComparable> magnitude = p => System.Math.Sqrt(p.Item1 * p.Item1 + p.Item2 * p.Item2);

            //----------- Act ---------------------------------
            var min = MathExt.Min(magnitude, point(0, 0), point(1, 1), point(2, 2));

            //----------- Assert-------------------------------
            Assert.True(min.Item1.Is(0));
            Assert.True(min.Item2.Is(0));
        }

        [Test]
        public void MinOfT_NullParameters_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            Tuple<int, string>[] data = null;

            //----------- Act ---------------------------------
            TestDelegate maxOfNullData = () => MathExt.Min(t => t.Item1, data);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(maxOfNullData);
        }

        [Test]
        public void Min_ListofNumericarguments_ReturnsMin()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            var min = MathExt.Min(1, 2, 3);

            //----------- Assert-------------------------------
            Assert.True(min == 1);
        }

        [Test]
        public void Min_ListOfComparableArguments_ReturnsMax()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            var min = MathExt.Min("Justin", "Kelson", "Tell");

            //----------- Assert-------------------------------
            Assert.True(min.Equals("Justin"));
        }

        [Test]
        public void Min_NullParameters_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            int[] data = null;

            //----------- Act ---------------------------------
            TestDelegate minOfNullData = () => MathExt.Min(data);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(minOfNullData);
        }

        [Test]
        public void MeanOfDoubles_ExpectedInput_ArithmeticMean()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            var mean = MathExt.Mean(1.0, 1.1, 1.2, 1.3);

            //----------- Assert-------------------------------
            Assert.True(mean.Is(1.15d));
        }

        [Test]
        public void MeanOfDoubles_EmptyInput_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            double[] data = new double[0];

            //----------- Act ---------------------------------
            TestDelegate mean = () => MathExt.Mean(data);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(mean);
        }

        [Test]
        public void MeanOfInts_ExpectedInput_ArithmeticMean()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            var mean = MathExt.Mean(1, 2, 3, 4);

            //----------- Assert-------------------------------
            Assert.True(mean.Is(2.5d));
        }

        [Test]
        public void MeanOfInts_EmptyInput_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            int[] data = new int[0];

            //----------- Act ---------------------------------
            TestDelegate mean = () => MathExt.Mean(data);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(mean);
        }

        [Test]
        public void MeanOfT_ExpectedInput_ArithmeticMean()
        {
            //----------- Arrange -----------------------------
            Func<double, double, Tuple<double, double>> point = (x, y) => new Tuple<double, double>(x, y);
            Func<Tuple<double, double>, double> magnitude = p => System.Math.Sqrt(p.Item1 * p.Item1 + p.Item2 * p.Item2);

            //----------- Act ---------------------------------
            var mean = MathExt.Mean(magnitude, point(0, 0), point(1, 1), point(2, 2));

            //----------- Assert-------------------------------
            Assert.True(mean.Is(MathExt.SquareRootOf2, 1e-15));
        }

        [Test]
        public void MeanOfT_EmptyInput_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            Tuple<double, double>[] data = null;
            Func<Tuple<double, double>, double> magnitude = p => System.Math.Sqrt(p.Item1 * p.Item1 + p.Item2 * p.Item2);

            //----------- Act ---------------------------------
            TestDelegate computeMean = () => MathExt.Mean(magnitude, data);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(computeMean);
        }
    }
}