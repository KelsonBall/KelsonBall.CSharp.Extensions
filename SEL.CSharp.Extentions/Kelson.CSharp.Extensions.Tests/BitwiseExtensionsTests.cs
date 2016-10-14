////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;
using System.Linq;
using NUnit.Framework;

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class BitwiseExtensionsTests
    {
        [Test]
        public void IsTrue_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(v.IsTrue(0));
            Assert.True(v.IsTrue(2));
        }

        [Test]
        public void IsTrue_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.IsTrue(100));
        }

        [Test]
        public void IsTrueUlong_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(v.IsTrue(0));
            Assert.True(v.IsTrue(2));
        }

        [Test]
        public void IsTrueUlong_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.IsTrue(100));
        }

        [Test]
        public void Set_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            v = v.Set(1);
            // -----------------------  Assert -----------------------
            Assert.True(v == 7);
        }

        [Test]
        public void Set_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Set(100));
        }

        [Test]
        public void SetUlong_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            v = v.Set(1);
            // -----------------------  Assert -----------------------
            Assert.True(v == 7);
        }

        [Test]
        public void SetUlong_ExpectedInput_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Set(100));
        }

        [Test]
        public void Set_ExpectedInput_AsExpected2()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            v = v.Set(1, 3);
            // -----------------------  Assert -----------------------
            Assert.True(v == 15);
        }

        [Test]
        public void Set_IndexOutOfRange_ThrowsException2()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Set(1, 2, 3, 100));
        }

        [Test]
        public void SetUlong_ExpectedInput_AsExpected2()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            v = v.Set(1, 3);
            // -----------------------  Assert -----------------------
            Assert.True(v == 15);
        }

        [Test]
        public void SetUlong_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Set(1, 2, 3, 100));
        }

        [Test]
        public void Clear_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            v = v.Clear(2);
            // -----------------------  Assert -----------------------
            Assert.True(v == 1);
        }

        [Test]
        public void Clear_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Clear(100));
        }

        [Test]
        public void ClearUlong_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            v = v.Clear(2);
            // -----------------------  Assert -----------------------
            Assert.True(v == 1);
        }

        [Test]
        public void ClearUlong_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Clear(100));
        }

        [Test]
        public void Toggle_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            v = v.Toggle(2);
            v = v.Toggle(1);
            // -----------------------  Assert -----------------------
            Assert.True(v == 3);
        }

        [Test]
        public void Toggle_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Toggle(100));
        }

        [Test]
        public void ToggleUlong_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            v = v.Toggle(2);
            v = v.Toggle(1);
            // -----------------------  Assert -----------------------
            Assert.True(v == 3);
        }

        [Test]
        public void ToggleUlong_IndexOutOfRange_ThrowsException()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.Toggle(100));
        }

        [Test]
        public void ToBools_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            int v = 5;
            // -----------------------   Act   -----------------------
            bool[] bools = v.ToBools(4).ToArray();
            // -----------------------  Assert -----------------------
            Assert.True(bools.SequenceEqual(new [] { true, false, true, false }));
        }

        [Test]
        public void ToBools_IndexOutOfRange_ThrowsException()
        {
            //----------- Arrange -----------------------------
            int v = 5;

            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.ToBools(100).ToList());
        }

        [Test]
        public void ToBoolsUlong_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            ulong v = 5ul;
            // -----------------------   Act   -----------------------
            bool[] bools = v.ToBools(4).ToArray();
            // -----------------------  Assert -----------------------
            Assert.True(bools.SequenceEqual(new[] { true, false, true, false }));
        }


        [Test]
        public void ToBoolsUlong_IndexOutOfRange_ThrowsException()
        {
            //----------- Arrange -----------------------------
            ulong v = 5ul;
            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.Throws<IndexOutOfRangeException>(() => v.ToBools(100).ToList());
        }

        [Test]
        public void ToFlags_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            bool[] bools = { true, false, true, false };
            // -----------------------   Act   -----------------------
            int flags = bools.ToFlags();
            // -----------------------  Assert -----------------------
            Assert.True(flags == 5);
        }

        [Test]
        public void ToFlags_LargeInput_ThrowsException()
        {
            //----------- Arrange -----------------------------
            bool[] data = new bool[100];
            //----------- Act ---------------------------------
            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(() => data.ToFlags());
        }

        [Test]
        public void ToFlagsLarge_ExpectedInput_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            bool[] bools = { true, false, true, false };
            // -----------------------   Act   -----------------------
            ulong[] flags = bools.ToFlagsLarge();
            // -----------------------  Assert -----------------------
            Assert.True(flags[0] == 5);
        }

        [Test]
        public void ToFlagsLarge_LargeInput_UlongArray()
        {
            //----------- Arrange -----------------------------
            bool[] data = new bool[100];
            //----------- Act ---------------------------------
            ulong[] flags = data.ToFlagsLarge();

            //----------- Assert-------------------------------
            Assert.True(flags.SequenceEqual(new [] {0ul, 0ul}));
        }
    }
}