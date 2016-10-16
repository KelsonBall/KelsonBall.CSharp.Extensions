using Kelson.CSharp.Extensions;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void In_NumericList_TrueIfContained()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(3.In(1, 4, 3, 7));
            Assert.False(2.In(1, 4, 3, 7));
        }

        [Test]
        public void In_StringList_TrueIfContained()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.True("Hello".In("Hello", ",", "World", "!"));
            Assert.False("Apples".In("Cheese", "Steak", "Lard"));
        }

        [Test]
        public void EmptyIfNull_NullCollection_EmptyCollection()
        {
            // ----------------------- Arrange -----------------------
            IEnumerable<int> source = null;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(!source.EmptyIfNull().Any());
        }

        [Test]
        public void EmptyifNull_NonNullCollection_SourceCollection()
        {
            //----------- Arrange -----------------------------
            IEnumerable<int> source = new int[] { 3, 11 };
            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.True(source.EmptyIfNull().Count() == 2);
        }

        [Test]
        public void Range_FullLength_OriginalData()
        {
            // ----------------------- Arrange -----------------------
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7 };

            // -----------------------   Act   -----------------------
            int[] a = data.Range(0, 8);

            // -----------------------  Assert -----------------------
            Assert.True(a.SequenceEqual(data));
        }

        [Test]
        public void Range_Subset_ExpectedSubset()
        {
            // ----------------------- Arrange -----------------------
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            int[] b = data.Range(0, 3);

            //----------- Assert-------------------------------
            Assert.True(b.SequenceEqual(new[] { 0, 1, 2 }));
        }

        [Test]
        public void Range_ToIndex_ExpectedSubset()
        {
            // ----------------------- Arrange -----------------------
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            int[] c = data.Range(to: 4);

            //----------- Assert-------------------------------
            Assert.True(c.SequenceEqual(new[] { 0, 1, 2, 3 }));
        }

        [Test]
        public void Range_ToIndexFromEnd_ExpectedSubset()
        {
            //----------- Arrange -----------------------------
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            int[] d = data.Range(to: -1);

            //----------- Assert-------------------------------
            Assert.True(d.SequenceEqual(new[] { 0, 1, 2, 3, 4, 5, 6 }));
        }

        [Test]
        public void Range_EmptyRange_EmptySet()
        {
            //----------- Arrange -----------------------------
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            int[] e = data.Range(4, 4);

            //----------- Assert-------------------------------
            Assert.True(e.SequenceEqual(new int[] { }));
        }

        [Test]
        public void Range_FromFirstIndex_SkipFirstElement()
        {
            //----------- Arrange -----------------------------
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            int[] g = data.Range(1);

            //----------- Assert-------------------------------
            Assert.True(g.SequenceEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }));
        }

        [Test]
        public void Range_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            // ----------------------- Arrange -----------------------            
            int[] values = { 0, 1, 2, 3, 4 };

            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<ArgumentException>(() => values.Range(3, 7));
        }

        [Test]
        public void Range_NegativeRange_ThrowsException()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(() => new int[] { }.Range(5, 2));
        }

        [Test]
        public void RangeEnumerable_FullLength_OriginalData()
        {
            // ----------------------- Arrange -----------------------
            IEnumerable<int> data = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7 };

            // -----------------------   Act   -----------------------
            var a = data.Range(0, 8);

            // -----------------------  Assert -----------------------
            Assert.True(a.SequenceEqual(data));
        }

        [Test]
        public void RangeEnumerable_Subset_ExpectedSubset()
        {
            // ----------------------- Arrange -----------------------
            IEnumerable<int> data = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            var b = data.Range(0, 3);

            //----------- Assert-------------------------------
            Assert.True(b.SequenceEqual(new[] { 0, 1, 2 }));
        }

        [Test]
        public void RangeEnumerable_ToIndex_ExpectedSubset()
        {
            // ----------------------- Arrange -----------------------
            IEnumerable<int> data = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            var c = data.Range(to: 4);

            //----------- Assert-------------------------------
            Assert.True(c.SequenceEqual(new[] { 0, 1, 2, 3 }));
        }

        [Test]
        public void RangeEnumerable_ToIndexFromEnd_ExpectedSubset()
        {
            //----------- Arrange -----------------------------
            IEnumerable<int> data = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            var d = data.Range(to: -1);

            //----------- Assert-------------------------------
            Assert.True(d.SequenceEqual(new[] { 0, 1, 2, 3, 4, 5, 6 }));
        }

        [Test]
        public void RangeEnumerable_EmptyRange_EmptySet()
        {
            //----------- Arrange -----------------------------
            IEnumerable<int> data = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            var e = data.Range(4, 4);

            //----------- Assert-------------------------------
            Assert.True(e.SequenceEqual(new int[] { }));
        }

        [Test]
        public void RangeEnumerable_FromFirstIndex_SkipFirstElement()
        {
            //----------- Arrange -----------------------------
            IEnumerable<int> data = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            var g = data.Range(1);

            //----------- Assert-------------------------------
            Assert.True(g.SequenceEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }));
        }

        [Test]
        public void RangeEnumerable_FromEndOfCollection_ExpectedSubset()
        {
            //----------- Arrange -----------------------------
            IEnumerable<int> data = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };

            //----------- Act ---------------------------------
            var e = data.Range(-5, 5);

            //----------- Assert-------------------------------
            Assert.True(e.SequenceEqual(new int[]{ 3, 4 }));
        }

        [Test]
        public void RangeEnumerable_NegativeRange_ThrowsException()
        {
            //----------- Arrange -----------------------------
            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(() => new List<int>().AsEnumerable().Range(5, 2));
        }

        [Test]
        public void Concat_TwoArraysConcatenate_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            int[] a = { 1, 2, 3 };
            int[] b = { 4, 5 };
            // -----------------------   Act   -----------------------
            var c = a.Concat(b);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(5, c.Length);
            Assert.True(c.SequenceEqual(new[] { 1, 2, 3, 4, 5 }));
        }

        [Test]
        public void Select_OnArray_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            int[] data = { 1, 2, 3, 4 };

            // -----------------------   Act   -----------------------
            int[] doubles = data.Select(i => i * 2).ToArray();

            // -----------------------  Assert -----------------------
            Assert.True(doubles.SequenceEqual(new[] { 2, 4, 6, 8 }));
        }

        [Test]
        public void Select_EmptyArray_EmptyResult()
        {
            // ----------------------- Arrange -----------------------
            int[] data = { };

            // -----------------------   Act   -----------------------
            int[] doubles = data.Select(i => i * 2).ToArray();

            // -----------------------  Assert -----------------------
            Assert.True(doubles.SequenceEqual(new int[] { }));
        }

        [Test]
        public void ForEach_OnEnumerable_ComputesActionOnItems()
        {
            // ----------------------- Arrange -----------------------
            IEnumerable<int> data = new[] { 1, 2, 3 };
            int sum = 0;
            int negsum = 0;

            // -----------------------   Act   -----------------------
            data
                .ForEach(i => sum += i)
                .ForEach(i => negsum -= i);

            // -----------------------  Assert -----------------------
            Assert.True(sum == 6);
            Assert.True(negsum == -6);
        }

        [Test]
        public void ForEach_OnArray_ComputesActionOnItems()
        {
            // ----------------------- Arrange -----------------------
            int[] data = { 1, 2, 3 };
            int sum = 0;
            int negsum = 0;

            // -----------------------   Act   -----------------------
            data
                .ForEach(i => sum += i)
                .ForEach(i => negsum -= i);

            // -----------------------  Assert -----------------------
            Assert.True(sum == 6);
            Assert.True(negsum == -6);

        }        
    }
}