////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;
using NUnit.Framework;

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Range_ExpectedInput_SelectsCorrectSubstring()
        {
            // ----------------------- Arrange -----------------------
            string data = "Hello, World!";

            // -----------------------   Act   -----------------------
            string hello = data.Range(to: 5);

            // -----------------------  Assert -----------------------
            Assert.True(hello.Equals("Hello"));
        }

        [Test]
        public void Range_RangeIndexedFromEnd_SelectsCorrectSubstring()
        {
            //----------- Arrange -----------------------------
            string data = "Hello, World!";

            //----------- Act ---------------------------------
            string world = data.Range(-6, -1);

            //----------- Assert-------------------------------
            Assert.True(world.Equals("World"));
        }

        [Test]
        public void Range_LargeSubstringOfEmptyString_ThrowsIndexOutOfRangeException()
        {
            //----------- Arrange -----------------------------
            string data = string.Empty;

            //----------- Act ---------------------------------
            TestDelegate selectSubstring = () => data.Range(0, 6);

            //----------- Assert-------------------------------
            Assert.Throws<ArgumentException>(selectSubstring);
        }

        [Test]
        public void Range_ZeroLengthSubstringOfEmptyString_ReturnsEmptyString()
        {
            //----------- Arrange -----------------------------
            string data = string.Empty;

            //----------- Act ---------------------------------
            string empty = data.Range(0, 0);

            //----------- Assert-------------------------------
            Assert.True(empty.Equals(string.Empty));
        }

        [Test]
        public void Range_ZeroLengthSubstringOfNonEmptyString_ReturnsEmptyString()
        {
            //----------- Arrange -----------------------------
            string data = "Hello, World!";

            //----------- Act ---------------------------------
            string empty = data.Range(0, 0);

            //----------- Assert-------------------------------
            Assert.True(empty.Equals(string.Empty));
        }
    }
}