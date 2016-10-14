////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class SetOperationTests
    {
        [Test]
        public void CartesianProduct_ExpectedInput_ComputesAllCombinations()
        {
            // ----------------------- Arrange -----------------------
            List<bool> set1 = new List<bool>() { false, true };
            List<int>  set2 = new List<int>()  { 0, 1, 2, int.MinValue };

            // -----------------------   Act   -----------------------
            var pairs = set1.CartesianProduct(set2).ToList();

            // -----------------------  Assert -----------------------
            Assert.True(pairs.Count == set1.Count * set2.Count);
            int item2 = set2.Skip(1).First();
            var subset = pairs.Where(t => t.Item2 == item2).ToList();
            Assert.True(subset.Count == set1.Count);
            Assert.True(subset.Count(t => set1.Contains(t.Item1)) == subset.Count());
        }

        [Test]
        public void CartesianProduct_EmptyInput_EmptyResult()
        {
            // ----------------------- Arrange -----------------------
            List<bool> set1 = new List<bool>() { false, true, false };
            List<int> set2 = new List<int>();

            // -----------------------   Act   -----------------------
            var pairs = set1.CartesianProduct(set2).ToList();

            // -----------------------  Assert -----------------------
            Assert.True(pairs.Count == set1.Count * set2.Count);
        }

        [Test]
        public void CartesianProduct_NullParameter_ThrowsArgumentException()
        {
            //----------- Arrange -----------------------------
            List<bool> set1 = null;
            List<int> set2 = new List<int>();

            //----------- Act ---------------------------------
            var pairs = set1.CartesianProduct(set2);
            TestDelegate enumerate = () => pairs.Any();

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(enumerate);
        }
    }
}