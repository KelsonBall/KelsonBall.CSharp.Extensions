////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using NUnit.Framework;
using System;
using System.Reflection;
using Kelson.CSharp.Extensions.Tests;

[assembly: AttributeExtensionsTests.IsTested(true)]

namespace Kelson.CSharp.Extensions.Tests
{
    [TestFixture]
    public class AttributeExtensionsTests
    {
        internal class IsTestedAttribute : Attribute
        {
            public readonly bool State;

            public IsTestedAttribute(bool state)
            {
                State = state;
            }
        }

        [IsTested(true)]
        internal class AttributedType
        {
            [IsTested(true)]
            public int Field;

            [IsTested(true)]
            public int Property { get; set; }

            [IsTested(true)]
            public void Method()
            {

            }
        }

        public int NonAttributedField;

        public int NonAttributedProperty { get; set; }

        public void NonAttributedMethod()
        {

        }

        [Test]
        public void FieldHasAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            FieldInfo attributedField = typeof(AttributedType).GetField(nameof(AttributedType.Field));
            FieldInfo nonAttributedField = typeof(AttributeExtensionsTests).GetField(nameof(NonAttributedField));
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(attributedField.HasAttribute<IsTestedAttribute>());
            Assert.False(nonAttributedField.HasAttribute<IsTestedAttribute>());
        }

        [Test]
        public void PropertyHasAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            PropertyInfo attributedProperty = typeof(AttributedType).GetProperty(nameof(AttributedType.Property));
            PropertyInfo nonAttributedProperty = typeof(AttributeExtensionsTests).GetProperty(nameof(NonAttributedProperty));
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(attributedProperty.HasAttribute<IsTestedAttribute>());
            Assert.False(nonAttributedProperty.HasAttribute<IsTestedAttribute>());
        }

        [Test]
        public void MethodHasAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            MethodInfo attributedMethod = typeof(AttributedType).GetMethod(nameof(AttributedType.Method));
            MethodInfo nonAttributedMethod = typeof(AttributeExtensionsTests).GetMethod(nameof(NonAttributedMethod));
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(attributedMethod.HasAttribute<IsTestedAttribute>());
            Assert.False(nonAttributedMethod.HasAttribute<IsTestedAttribute>());
        }

        [Test]
        public void TypeHasAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(typeof(AttributedType).HasAttribute<IsTestedAttribute>());
            Assert.False(GetType().HasAttribute<IsTestedAttribute>());
        }

        [Test]
        public void ObjectHasAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            var instance = new AttributedType();
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(instance.HasAttribute<IsTestedAttribute>());
            Assert.False(this.HasAttribute<IsTestedAttribute>());
        }

        [Test]
        public void AssemblyHasAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.True(typeof(AttributedType).Assembly.HasAttribute<IsTestedAttribute>());
            Assert.False(typeof(int).Assembly.HasAttribute<IsTestedAttribute>());
        }

        [Test]
        public void FieldGetAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            FieldInfo attributedField = typeof(AttributedType).GetField(nameof(AttributedType.Field));
            FieldInfo nonAttributedField = typeof(AttributeExtensionsTests).GetField(nameof(NonAttributedField));
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.NotNull(attributedField.GetAttribute<IsTestedAttribute>());
            Assert.Null(nonAttributedField.GetAttribute<IsTestedAttribute>());
        }

        [Test]
        public void PropertyGetAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            PropertyInfo attributedProperty = typeof(AttributedType).GetProperty(nameof(AttributedType.Property));
            PropertyInfo nonAttributedProperty = typeof(AttributeExtensionsTests).GetProperty(nameof(NonAttributedProperty));
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.NotNull(attributedProperty.GetAttribute<IsTestedAttribute>());
            Assert.Null(nonAttributedProperty.GetAttribute<IsTestedAttribute>());
        }

        [Test]
        public void MethodGetAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            MethodInfo attributedMethod = typeof(AttributedType).GetMethod(nameof(AttributedType.Method));
            MethodInfo nonAttributedMethod = typeof(AttributeExtensionsTests).GetMethod(nameof(NonAttributedMethod));
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.NotNull(attributedMethod.GetAttribute<IsTestedAttribute>());
            Assert.Null(nonAttributedMethod.GetAttribute<IsTestedAttribute>());
        }

        [Test]
        public void TypeGetAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.NotNull(typeof(AttributedType).GetAttribute<IsTestedAttribute>());
            Assert.Null(GetType().GetAttribute<IsTestedAttribute>());
        }

        [Test]
        public void ObjectGetAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            var instance = new AttributedType();
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.NotNull(instance.GetAttribute<IsTestedAttribute>());
            Assert.Null(this.GetAttribute<IsTestedAttribute>());
        }

        [Test]
        public void AssemblyGetAttribute_ReflectedInfo_AsExpected()
        {
            // ----------------------- Arrange -----------------------
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.NotNull(typeof(AttributedType).Assembly.GetAttribute<IsTestedAttribute>());
            Assert.Null(typeof(int).Assembly.GetAttribute<IsTestedAttribute>());
        }
    }
}