using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Kelson.CSharp.Extensions.Functional;

namespace Kelson.CSharp.Extensions.Tests.Functional
{
    [TestFixture]
    public class DelegateExtensionsTests
    {
        [Test]
        public void Using_WithDisposable_Disposes()
        {
            // ----------------------- Arrange -----------------------
            Func<DisposeMe, int> increment = disposeable => ++disposeable.Counter;
            Func<DisposeMe> createDisposable = () =>
                {
                    return new DisposeMe();
                };

            // -----------------------   Act   -----------------------
            bool incremented =
                    increment
                    .Using(createDisposable)
                    .Equals(1);

            // -----------------------  Assert -----------------------
            Assert.True(incremented);
            Assert.Null(DisposeMe.Instance);
        }

        [Test]
        public void UsingOnFactoryMethod_WithDisposable_Disposes()
        {
            // ----------------------- Arrange -----------------------
            Func<DisposeMe, int> increment = disposeable => ++disposeable.Counter;
            Func<DisposeMe> createDisposable = () =>
            {
                return new DisposeMe();
            };

            // -----------------------   Act   -----------------------
            bool incremented =
                    createDisposable
                    .Using(increment)
                    .Equals(1);

            // -----------------------  Assert -----------------------
            Assert.True(incremented);
            Assert.Null(DisposeMe.Instance);
        }

        [Test]
        public void Curry_NoParams_Curries()
        {
            // ----------------------- Arrange -----------------------
            Func<int, int> identity = a => a;

            // -----------------------   Act   -----------------------
            Func<int> three = identity.Curry(3);

            // -----------------------  Assert -----------------------
            Assert.True(three() == 3);
        }

        [Test]
        public void Curry_OneParam_Curries()
        {
            // ----------------------- Arrange -----------------------            
            Func<int, int, int> add = (a, b) => a + b;

            // -----------------------   Act   -----------------------           
            Func<int, int> add3 = add.Curry(3);

            // -----------------------  Assert -----------------------
            Assert.True(add3(3) == 6);
            Assert.True(add3(-3) == 0);
        }

        [Test]
        public void Curry_TwoParams_Curries()
        {
            // ----------------------- Arrange -----------------------            
            Func<int, int, int, int> add = (a, b, c) => a + b + c;

            // -----------------------   Act   -----------------------            
            Func<int, int, int> add3 = add.Curry(3);

            // -----------------------  Assert -----------------------
            Assert.True(add3(3, 0) == 6);
            Assert.True(add3(-3, -3) == -3);
        }

        [Test]
        public void Curry_ThreeParams_Curries()
        {
            // ----------------------- Arrange -----------------------
            Func<int, int, int, int, int> add = (a, b, c, d) => a + b + c + d;

            // -----------------------   Act   -----------------------
            Func<int, int, int, int> add3 = add.Curry(3);
            Func<int, int, int> add6 = add3.Curry(3);
            Func<int, int> add9 = add6.Curry(3);
            Func<int> twelve = add9.Curry(3);
            Func<int> ten = add9.Curry(1);

            Func<int> fourFactorial = add.Curry(4).Curry(3).Curry(2).Curry(1);

            // -----------------------  Assert -----------------------
            Assert.True(add3(2, 1, 0) == 6);
            Assert.True(add3(0, 0, 0) == 3);
            Assert.True(add6(0, 0) == 6);
            Assert.True(add9(0) == 9);
            Assert.True(twelve() == 12);
            Assert.True(ten() == 10);
            Assert.True(fourFactorial() == 10);
        }

        [Test]
        public void Curry_ParameterizedDelegate_Curries()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int> add = args => args.Sum();

            // -----------------------   Act   -----------------------
            ParamFunc<int, int> add3 = add.Curry(3);

            // -----------------------  Assert -----------------------
            Assert.True(add3(1) == 4);
            Assert.True(add3(1, 2, 3, 6, 9) == 24);
            Assert.True(add3() == 3);
            Assert.True(add3(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) == 3);
        }

        [Test]
        public void Curry_ParameterizedDelegateOneLeadingParam_Curries()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int> add = (x, args) => x * args.Sum();

            // -----------------------   Act   -----------------------
            ParamFunc<int, int> addDouble = add.Curry(2);
            //----------- Assert-------------------------------
            
            Assert.True(addDouble(1, 1, 1) == 6);
        }

        [Test]
        public void Curry_ParameterizedDelegateTwoLeadingParams_Curries()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int, int> add = (x, y, args) => x * y * args.Sum();

            // -----------------------   Act   -----------------------
            ParamFunc<int, int, int> addDouble = add.Curry(2);
            
            //----------- Assert-------------------------------
            Assert.True(addDouble(1, 1, 1, 1) == 6);
        }

        [Test]
        public void Curry_ParameterizedDelegateThreeLeadingParams_Curries()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int, int, int> add = (x, y, z, args) => x * y * z * args.Sum();

            // -----------------------   Act   -----------------------
            ParamFunc<int, int, int, int> addDouble = add.Curry(2);

            //----------- Assert-------------------------------
            Assert.True(addDouble(1, 1, 1, 1, 1) == 6);
        }

        [Test]
        public void Curry_ParameterizedDelegateFourLeadingParams_Curries()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int, int, int, int> add = (x, y, z, a, args) => x * y * z * a * args.Sum();

            // -----------------------   Act   -----------------------
            ParamFunc < int, int, int, int, int> addDouble = add.Curry(2);

            //----------- Assert-------------------------------
            Assert.True(addDouble(1, 1, 1, 1, 1, 1) == 6);
        }

        [Test]
        public void Do_WithAction_ComputesActionOnCollection()
        {
            // ----------------------- Arrange -----------------------
            IEnumerable<int> enumerable = Enumerable.Empty<int>();
            int count = 1;

            // -----------------------   Act   -----------------------
            enumerable.Do(data => count = data.Count());

            // -----------------------  Assert -----------------------
            Assert.True(count == 0);
        }        

        [Test]
        public void NonSequitur_OnEnumerable_IgnoresData()
        {
            // ----------------------- Arrange -----------------------
            IEnumerable<int> data = new[] { 1, 2, 3 };
            int sum = 0;

            // -----------------------   Act   -----------------------
            data.NonSequitur(i => sum += i, 4);

            // -----------------------  Assert -----------------------
            Assert.True(sum == 4);
        }

        [Test]
        public void PipeToParams_NoAdittionalArgs_PipesToParams()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int> sum = args => args.Sum();
                        
            // -----------------------   Act   -----------------------
            int aggregate = new [] { 1, 2, 3 }.PipeToParams(sum);

            // -----------------------  Assert -----------------------
            Assert.AreEqual(6, aggregate);
        }

        [Test]
        public void PipeToParams_OneAdittionalArg_PipesToParams()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int> sum = (x, args) => x * args.Sum();

            // -----------------------   Act   -----------------------
            int aggregate = new[] { 1, 2, 3 }.PipeToParams(sum, 2);

            // -----------------------  Assert -----------------------
            Assert.AreEqual(12, aggregate);
        }

        [Test]
        public void PipeToParams_TwoAdittionalArgs_PipesToParams()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int, int> sum = (x, y, args) => x * args.Sum() - y;

            // -----------------------   Act   -----------------------
            int aggregate = new[] { 1, 2, 3 }.PipeToParams(sum, 2, 1);

            // -----------------------  Assert -----------------------
            Assert.AreEqual(11, aggregate);
        }

        [Test]
        public void PipeToParams_ThreeAdittionalArgs_PipesToParams()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int, int, int> sum = (x, y, z, args) => (x * args.Sum() - y) << z;

            // -----------------------   Act   -----------------------
            int aggregate = new[] { 1, 2, 3 }.PipeToParams(sum, 2, 1, 3);

            // -----------------------  Assert -----------------------
            Assert.AreEqual(88, aggregate);
        }

        [Test]
        public void PipeToParams_FourAdittionalArgs_PipeToParams()
        {
            // ----------------------- Arrange -----------------------
            ParamFunc<int, int, int, int, int, int> sum = (a, x, y, z, args) => a + ((x * args.Sum() - y) << z);

            // -----------------------   Act   -----------------------
            int aggregate = new[] { 1, 2, 3 }.PipeToParams(sum, 1, 2, 1, 3);

            // -----------------------  Assert -----------------------
            Assert.AreEqual(89, aggregate);
        }

        [Test]
        public void AsEnumerable_OnArray_CastsToEnumerable()
        {
            // ----------------------- Arrange -----------------------
            int[] data = { 1, 2, 3 };

            // -----------------------   Act   -----------------------
            IEnumerable<int> dataEnumerable = DelegateExtensions.AsEnumerable(1, 2, 3);

            // -----------------------  Assert -----------------------
            Assert.True(dataEnumerable.SequenceEqual(data));
        }
    }
}