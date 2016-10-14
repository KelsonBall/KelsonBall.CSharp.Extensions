////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System.Collections.Generic;
using CompResultPair = System.Tuple<Kelson.CSharp.Extensions.ComparableExtensions.Comparator<int>, bool>;
using NUnit.Framework;

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class ComparableExtensionsTests
    {
        [Test]
        public void IsBetween_FromInclusive_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(2.IsBetween<int>(0, 3));
            Assert.False(3.IsBetween<int>(0, 3));
            Assert.False(4.IsBetween<int>(0, 3));
            Assert.True(0.IsBetween<int>(0, 3));
            Assert.False((-1).IsBetween<int>(0, 3));
        }

        [Test]
        public void IsBetween_Inclusive_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(2.IsBetween<int>(0, 3, RangeFlags.Inclusive));
            Assert.True(3.IsBetween<int>(0, 3, RangeFlags.Inclusive));
            Assert.False(4.IsBetween<int>(0, 3, RangeFlags.Inclusive));
            Assert.True(0.IsBetween<int>(0, 3, RangeFlags.Inclusive));
            Assert.False((-1).IsBetween<int>(0, 3, RangeFlags.Inclusive));
        }

        [Test]
        public void IsBetween_ToInclusive_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(2.IsBetween<int>(0, 3, RangeFlags.ToInclusive));
            Assert.True(3.IsBetween<int>(0, 3, RangeFlags.ToInclusive));
            Assert.False(4.IsBetween<int>(0, 3, RangeFlags.ToInclusive));
            Assert.False(0.IsBetween<int>(0, 3, RangeFlags.ToInclusive));
            Assert.False((-1).IsBetween<int>(0, 3, RangeFlags.ToInclusive));

        }

        [Test]
        public void IsBetween_Exclusive_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(2.IsBetween<int>(0, 3, RangeFlags.Exclusive));
            Assert.False(3.IsBetween<int>(0, 3, RangeFlags.Exclusive));
            Assert.False(4.IsBetween<int>(0, 3, RangeFlags.Exclusive));
            Assert.False(0.IsBetween<int>(0, 3, RangeFlags.Exclusive));
            Assert.False((-1).IsBetween<int>(0, 3, RangeFlags.Exclusive));

        }

        [Test]
        public void IsBetween_NumericTypes_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(2l.IsBetween<long>(0l, 3l));
            Assert.True(2ul.IsBetween<ulong>(0ul, 3ul));
            Assert.True(2f.IsBetween<float>(0f, 3f));
            Assert.True(2d.IsBetween<double>(0d, 3d));
            Assert.True(2m.IsBetween<decimal>(0m, 3m));
        }

        private static IEnumerable<CompResultPair> ComparisonPairsRefLessThanComp()
        {
            yield return new CompResultPair(ComparableExtensions.IsGreaterThanOrEqualTo, false);
            yield return new CompResultPair(ComparableExtensions.IsGreaterThan, false);
            yield return new CompResultPair(ComparableExtensions.IsSameAs, false);
            yield return new CompResultPair(ComparableExtensions.IsLessThanOrEqualTo, true);
            yield return new CompResultPair(ComparableExtensions.IsLessThan, true);
        }

        [Test]
        public void Comparator_RefLessThanComp_MatchesExpected([ValueSource(nameof(ComparisonPairsRefLessThanComp))] CompResultPair comparison)
        {
            //----------- Arrange -----------------------------
            int reference = 1;
            int comp = 2;

            //----------- Act ---------------------------------
            bool result = comparison.Item1(reference, comp);

            //----------- Assert-------------------------------
            Assert.True(result == comparison.Item2);

        }

        private static IEnumerable<CompResultPair> ComparisonPairsRefEqualsComp()
        {
            yield return new CompResultPair(ComparableExtensions.IsGreaterThanOrEqualTo, true);
            yield return new CompResultPair(ComparableExtensions.IsGreaterThan, false);
            yield return new CompResultPair(ComparableExtensions.IsSameAs, true);
            yield return new CompResultPair(ComparableExtensions.IsLessThanOrEqualTo, true);
            yield return new CompResultPair(ComparableExtensions.IsLessThan, false);
        }

        [Test]
        public void Comparator_RefEqualsComp_MatchesExpected([ValueSource(nameof(ComparisonPairsRefEqualsComp))] CompResultPair comparison)
        {
            //----------- Arrange -----------------------------
            int reference = 1;
            int comp = 1;

            //----------- Act ---------------------------------
            bool result = comparison.Item1(reference, comp);

            //----------- Assert-------------------------------
            Assert.True(result == comparison.Item2);

        }

        private static IEnumerable<CompResultPair> ComparisonPairsRefGreaterThanComp()
        {
            yield return new CompResultPair(ComparableExtensions.IsGreaterThanOrEqualTo, true);
            yield return new CompResultPair(ComparableExtensions.IsGreaterThan, true);
            yield return new CompResultPair(ComparableExtensions.IsSameAs, false);
            yield return new CompResultPair(ComparableExtensions.IsLessThanOrEqualTo, false);
            yield return new CompResultPair(ComparableExtensions.IsLessThan, false);
        }

        [Test]
        public void Comparator_RefGreaterThanComp_MatchesExpected([ValueSource(nameof(ComparisonPairsRefGreaterThanComp))] CompResultPair comparison)
        {
            //----------- Arrange -----------------------------
            int reference = 2;
            int comp = 1;

            //----------- Act ---------------------------------
            bool result = comparison.Item1(reference, comp);

            //----------- Assert-------------------------------
            Assert.True(result == comparison.Item2);

        }

    }
}