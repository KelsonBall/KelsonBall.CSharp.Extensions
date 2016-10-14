using NUnit.Framework;
using System;
using System.Windows;
using Kelson.CSharp.MathExtensions;

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class PolarMathExtensionsTests
    {
        [Test]
        public void SmallestPositiveAngle_PositiveInput_CorrectAngle()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            double angle = (MathExt.TwoPi + 0.1).SmallestPositiveAngle();

            //----------- Assert-------------------------------
            Assert.True(angle.Is(0.1d, 1e-10));
        }

        [Test]
        public void SmallestPositiveAngle_NegativeInput_PositiveAngle()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            double angle = (-MathExt.TwoPi + 0.1).SmallestPositiveAngle();

            //----------- Assert-------------------------------
            Assert.True(angle.Is(0.1d, 1e-10));
        }

        [Test]
        public void AngularDistance_AnglesAcrossModularBoundry_CorrectDistance()
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
        public void AngularDistance_AnglesIn0ToπRange_CorrectDistance()
        {
            // ----------------------- Arrange -----------------------
            double angle1 = 0.1;
            double angle2 = 0.2;

            // -----------------------   Act   -----------------------
            double distance = angle1.AngularDistance(angle2);

            // -----------------------  Assert -----------------------
            Assert.True(distance.Is(0.1d, 1e-10));
        }

        [Test]
        public void ToPolar_PositiveAngle_ExpectedBehavior()
        {
            //----------- Arrange -----------------------------
            Point point = new Point(1, 1);

            //----------- Act ---------------------------------
            var polar = point.ToPolar();

            //----------- Assert-------------------------------
            Assert.True(polar.R.Is(MathExt.SquareRootOf2, 1e-10));
            Assert.True(polar.Θ.Is(Math.PI / 4d));
        }

        [Test]
        public void ToPolar_NegativeAngle_ExpectedBehavior()
        {
            //----------- Arrange -----------------------------
            Point point = new Point(1, -1);

            //----------- Act ---------------------------------
            var polar = point.ToPolar();

            //----------- Assert-------------------------------
            Assert.True(polar.R.Is(MathExt.SquareRootOf2, 1e-10));
            Assert.True(polar.Θ.Is(-Math.PI / 4d));
        }

        [Test]
        public void ToCartesian_FourCorners_UnitVectors()
        {
            //----------- Arrange -----------------------------
            var right = new PolarPoint(1, 0);
            var up = new PolarPoint(1, Math.PI / 2d);
            var left = new PolarPoint(1, Math.PI);
            var down = new PolarPoint(1, 3 * Math.PI / 2d);

            //----------- Act ---------------------------------
            var ihat = right.ToCartesian();
            var jhat = up.ToCartesian();
            var minusihat = left.ToCartesian();
            var minusjhat = down.ToCartesian();

            //----------- Assert-------------------------------
            Assert.True(ihat.X.Is(1, 1e-12) && ihat.Y.Is(0, 1e-12));
            Assert.True(jhat.X.Is(0, 1e-12) && jhat.Y.Is(1, 1e-12));
            Assert.True(minusihat.X.Is(-1, 1e-12) && minusihat.Y.Is(0, 1e-12));
            Assert.True(minusjhat.X.Is(0, 1e-12) && minusjhat.Y.Is(-1, 1e-12));
        }

        [Test]
        public void ToCartesian_LargeAngle_ExpectedBehavior()
        {
            //----------- Arrange -----------------------------
            var right = new PolarPoint(1, 1000 * MathExt.TwoPi);

            //----------- Act ---------------------------------
            var ihat = right.ToCartesian();

            //----------- Assert-------------------------------
            Assert.True(ihat.X.Is(1, 1e-12) && ihat.Y.Is(0, 1e-12));
        }

        [Test]
        public void ToPolarToCartesian_ExpectedParameter_OriginalValue()
        {
            //----------- Arrange -----------------------------
            var origin = new Point(1, 1);

            //----------- Act ---------------------------------
            var result = origin.ToPolar().ToCartesian();

            //----------- Assert-------------------------------
            Assert.True(origin.X.Is(result.X, 1e-12) && origin.Y.Is(result.Y, 1e-12));
        }

        [Test]
        public void ToCartesianToPolar_ExpectedParameter_OriginalValue()
        {
            //----------- Arrange -----------------------------
            var origin = new PolarPoint(1, 1);

            //----------- Act ---------------------------------
            var result = origin.ToCartesian().ToPolar();

            //----------- Assert-------------------------------
            Assert.True(origin.R.Is(result.R, 1e-12) && origin.Θ.Is(result.Θ, 1e-12));
        }

        [Test]
        public void PolarPointEquality_Equals_Equals()
        {
            //----------- Arrange -----------------------------
            var data = new PolarPoint(1, 0);
            var data2 = new PolarPoint(1, 0);
            //----------- Act ---------------------------------
            bool result = data == data2;
            bool inverse = data != data2;

            //----------- Assert-------------------------------
            Assert.True(result);
            Assert.False(inverse);
        }

        [Test]
        public void PolarPointEquality_RadiusNotEqual_NotEqual()
        {
            //----------- Arrange -----------------------------
            var data = new PolarPoint(1, 0);
            var data2 = new PolarPoint(0.5, 0);
            //----------- Act ---------------------------------
            bool result = data == data2;
            bool inverse = data != data2;

            //----------- Assert-------------------------------
            Assert.False(result);
            Assert.True(inverse);
        }

        [Test]
        public void PolarPointEquality_ThetaNotEqual_NotEqual()
        {
            //----------- Arrange -----------------------------
            var data = new PolarPoint(1, 0);
            var data2 = new PolarPoint(1, Math.PI);
            //----------- Act ---------------------------------
            bool result = data == data2;
            bool inverse = data != data2;

            //----------- Assert-------------------------------
            Assert.False(result);
            Assert.True(inverse);
        }

        [Test]
        public void PolarPointEquality_NotEqual_NotEqual()
        {
            //----------- Arrange -----------------------------
            var data = new PolarPoint(1, 0);
            var data2 = new PolarPoint(0.5, Math.PI);
            //----------- Act ---------------------------------
            bool result = data == data2;
            bool inverse = data != data2;

            //----------- Assert-------------------------------
            Assert.False(result);
            Assert.True(inverse);
        }

        [Test]
        public void Translatae_WithCoordinates_ExpectedBehavior()
        {
            //----------- Arrange -----------------------------
            Point p = new Point(0, 0);

            //----------- Act ---------------------------------
            Point p2 = p.Translate(1, 1);

            //----------- Assert-------------------------------
            Assert.True(p.X == 0 && p.Y == 0); // yes, should be *exactly* 0.
            Assert.True(p2.X.Is(1) && p2.Y.Is(1));

        }
    }
}