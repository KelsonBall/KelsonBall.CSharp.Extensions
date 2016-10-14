////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;
using NUnit.Framework;
using Kelson.CSharp.Extensions.Functional;

namespace Kelson.CSharp.Extensions.Tests.Functional
{
    [TestFixture]
    public class TryPipelineTests
    {
        private static int zero = 0;

        private Func<int> divFuncNoParam = () => 1 / zero;

        private Func<int, int> divFuncOneParam = x => 1 / x;

        private Func<int, int, int> divFuncTwoParam = (x, y) => x / y;

        private Func<int, int, int, int> divFuncThreeParam = (x, y, z) => x / y / z;

        private Func<int, int, int, int, int> divFuncFourParam = (x, y, z, i) => x / y / z / i;

        [Test]
        public void Try_NoParams_ThrowsException()
        {
            // ----------------------- Arrange -----------------------                 
            var attempt = divFuncNoParam.Try();
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------            
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke());            
        }

        [Test]
        public void Try_OneParam_ThrowsExceptionOnError()
        {
            // ----------------------- Arrange -----------------------                       
            var attempt = divFuncOneParam.Try();
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(1));
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(0));
        }

        [Test]
        public void Try_TwoParam_ThrowsExceptionOnError()
        {
            // ----------------------- Arrange -----------------------            
            var attempt = divFuncTwoParam.Try();
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(2, 1));
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(1, 0));
        }

        [Test]
        public void Try_ThreeParam_ThrowsExceptionOnError()
        {
            // ----------------------- Arrange -----------------------                        
            var attempt = divFuncThreeParam.Try();
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(4, 2, 1));
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(2, 1, 0));
        }

        [Test]
        public void Try_FourParam_ThrowsExceptionOnError()
        {
            // ----------------------- Arrange -----------------------            
            var attempt = divFuncFourParam.Try();
            // -----------------------   Act   -----------------------
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(8, 4, 2, 1));
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(4, 2, 1, 0));
        }

        [Test]
        public void OnFail_NoParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncNoParam.Try().OnFail(e => failCount++);
            // -----------------------  Assert -----------------------
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke());
            Assert.AreEqual(failCount, 1);            
        }

        [Test]
        public void OnFail_OneParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncOneParam.Try().OnFail(e => failCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(1));
            Assert.AreEqual(failCount, 0);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(0));
            Assert.AreEqual(failCount, 1);
        }

        [Test]
        public void OnFail_TwoParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncTwoParam.Try().OnFail(e => failCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(1, 0));
            Assert.AreEqual(failCount, 1);
        }

        [Test]
        public void OnFail_ThreeParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncThreeParam.Try().OnFail(e => failCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(2, 1, 0));
            Assert.AreEqual(failCount, 1);
        }

        [Test]
        public void OnFail_FourParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncFourParam.Try().OnFail(e => failCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(8, 4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(4, 2, 1, 0));
            Assert.AreEqual(failCount, 1);
        }

        [Test]
        public void OnSuccess_NoParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncNoParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++);
            // -----------------------  Assert -----------------------
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke());
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 0);            
        }

        [Test]
        public void OnSuccess_NoParam_TriggersSuccess()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = ((Func<int>)(() => 1)).Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++);
            attempt.Invoke();
            // -----------------------  Assert -----------------------            
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
        }

        [Test]
        public void OnSuccess_OneParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncOneParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);            
        }

        [Test]
        public void OnSuccess_TwoParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncTwoParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);            
        }

        [Test]
        public void OnSuccess_ThreeParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncThreeParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(2, 1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
        }

        [Test]
        public void OnSuccess_FourParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncFourParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(8, 4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(4, 2, 1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);           
        }

        [Test]
        public void Finally_NoParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncNoParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke());
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 0);
            Assert.AreEqual(finallyCount, 1);            
        }

        [Test]
        public void Finally_OneParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncOneParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);            
        }

        [Test]
        public void Finally_TwoParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncTwoParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);            
        }

        [Test]
        public void Finally_ThreeParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncThreeParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(2, 1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);            
        }

        [Test]
        public void Finally_FourParam_ThrowsExceptionOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncFourParam.Try()
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(8, 4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.Throws<DivideByZeroException>(() => attempt.Invoke(4, 2, 1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);            
        }

        [Test]
        public void WithDefault_NoParam_EvaluatesToDefaultOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncNoParam.Try()
                .WithDefault(() => 0)
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(attempt.Invoke(), 0);
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 0);
            Assert.AreEqual(finallyCount, 1);            
        }

        [Test]
        public void WithDefault_OneParam_EvaluatesToDefaultOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncOneParam.Try()
                .WithDefault(p => 0)
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.AreEqual(0, attempt.Invoke(0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);            
        }

        [Test]
        public void WithDefault_TwoParam_EvaluatesToDefaultOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------            
            var attempt = divFuncTwoParam.Try()
                .WithDefault((p, q) => 0)
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.AreEqual(0, attempt.Invoke(1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);
        }

        [Test]
        public void WithDefault_ThreeParam_EvaluatesToDefaultOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncThreeParam.Try()
                .WithDefault((p, q, r) => 0)
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(2, attempt.Invoke(4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.AreEqual(0, attempt.Invoke(2, 1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);
        }

        [Test]
        public void WithDefault_FourParam_EvaluatesToDefaultOnFail()
        {
            // ----------------------- Arrange -----------------------
            int failCount = 0;
            int successCount = 0;
            int finallyCount = 0;
            // -----------------------   Act   -----------------------
            var attempt = divFuncFourParam.Try()
                .WithDefault((p, q, r, s) => 0)
                .OnFail(e => failCount++)
                .OnSuccess(result => successCount++)
                .Finally(() => finallyCount++);
            // -----------------------  Assert -----------------------
            Assert.AreEqual(1, attempt.Invoke(8, 4, 2, 1));
            Assert.AreEqual(failCount, 0);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 1);
            Assert.AreEqual(0, attempt.Invoke(4, 2, 1, 0));
            Assert.AreEqual(failCount, 1);
            Assert.AreEqual(successCount, 1);
            Assert.AreEqual(finallyCount, 2);
        }
    }
}