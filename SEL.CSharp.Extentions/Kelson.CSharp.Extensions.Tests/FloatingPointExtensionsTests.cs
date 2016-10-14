////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;
using NUnit.Framework;

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class FloatingPointExtensionsTests
    {
        [Test]
        public void AngularDistance_WithAngle_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            double angle1 = 0.1;
            double angle2 = (2 * System.Math.PI) - 0.1;

            // -----------------------   Act   -----------------------
            double distance = angle1.AngularDistance(angle2);

            // -----------------------  Assert -----------------------
            Assert.True(distance.Is(0.2d, 1e-10));
        }

        [Test]
        public void FloatIs_ExpectedParameter_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(3f.Is(3f));
            Assert.True(3f.Is(3.09f, 0.1f));
            Assert.False(3f.Is(4f));
        }

        [Test]
        public void DoubleIs_ExpectedParameter_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(3d.Is(3d));
            Assert.True(3d.Is(3.09d, 0.1d));
            Assert.False(3d.Is(4d));
        }

        [Test]
        public void DecimalIs_ExpectedParameter_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(3m.Is(3m));
            Assert.True(3m.Is(3.09m, 0.1m));
            Assert.False(3m.Is(4m));
        }

        [Test]
        public void ToFraction_ExpectedParameter_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            double angle = 2 * System.Math.PI / 3d;

            // -----------------------   Act   -----------------------
            var fraction = (angle / System.Math.PI).ToFraction();

            // -----------------------  Assert -----------------------
            Assert.True(fraction.Item1 == 2 && fraction.Item2 == 3);
        }

        [Test]
        public void ToFraction_Improper_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            double angle = 5 * System.Math.PI / 3d;

            // -----------------------   Act   -----------------------
            var fraction = (angle / System.Math.PI).ToFraction();

            // -----------------------  Assert -----------------------
            Assert.True(fraction.Item1 == 5 && fraction.Item2 == 3);
        }

        [Test]
        public void ToFraction_Negative_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            double angle = -2 * System.Math.PI / 3d;

            // -----------------------   Act   -----------------------
            var fraction = (angle / System.Math.PI).ToFraction();

            // -----------------------  Assert -----------------------
            Assert.True(fraction.Item1 == -2 && fraction.Item2 == 3);
        }

        [Test]
        public void ToFraction_Nan_ThrowsArgumentException()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<ArgumentException>(() => double.NaN.ToFraction());
        }

        [Test]
        public void ToFraction_Infinity_ThrowsArgumentException()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<ArgumentException>(() => double.PositiveInfinity.ToFraction());
        }

        [Test]
        public void ToFraction_Zero_ZeroOverOne()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            var fraction = 0d.ToFraction();
            // -----------------------  Assert -----------------------
            Assert.True(fraction.Item1 == 0 && fraction.Item2 == 1);
        }

        [Test]
        public void ToFraction_LargeError_ReturnsFraction()
        {
            // ----------------------- Arrange -----------------------
            double angle = 0.75;

            // -----------------------   Act   -----------------------
            var fraction = angle.ToFraction(0.95d);

            // -----------------------  Assert -----------------------
            Assert.True(fraction.Item1 == 1 && fraction.Item2 == 1);
        }

        [Test]
        public void ToFraction_SmallNegativeLargeError_ReturnsFraction()
        {
            //----------- Arrange -----------------------------
            double angle = -0.04;
            double error = 0.95d;

            //----------- Act ---------------------------------
            var fraction = angle.ToFraction(error);

            //----------- Assert-------------------------------
            Assert.True(fraction.Item1 == -1 && fraction.Item2 == 13);
        }

        [Test]
        public void ToFraction_InvalidError_ThrowsException()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.Throws<ArgumentOutOfRangeException>(() => 1d.ToFraction(2));
        }
    }
}