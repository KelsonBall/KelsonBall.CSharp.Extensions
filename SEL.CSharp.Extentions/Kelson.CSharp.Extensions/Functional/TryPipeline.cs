////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;

namespace Kelson.CSharp.Extensions.Functional
{
    public static class TryPipeline
    {
        /// <summary>
        /// Wraps an expression and evaluates actions based on the expressions success or failure.
        /// </summary>        
        public class TryExpression<TResult>
        {
            internal TryExpression() { }

            internal Func<TResult> Function { get; set; }

            internal Func<TResult> Default { get; set; }

            internal Action<Exception> OnFail { get; set; }

            internal Action<TResult> OnSuccess { get; set; }

            internal Action Finally { get; set; }
        }

        /// <summary>
        /// Wraps an expression and evaluates actions based on the expressions success or failure.
        /// </summary>
        public class TryExpression<T1, TResult> : TryExpression<TResult>
        {
            internal TryExpression() { }

            internal new Func<T1, TResult> Function { get; set; }

            internal new Func<T1, TResult> Default { get; set; }
        }

        /// <summary>
        /// Wraps an expression and evaluates actions based on the expressions success or failure.
        /// </summary>
        public class TryExpression<T1, T2, TResult> : TryExpression<TResult>
        {
            internal TryExpression() { }

            internal new Func<T1, T2, TResult> Function { get; set; }

            internal new Func<T1, T2, TResult> Default { get; set; }
        }

        /// <summary>
        /// Wraps an expression and evaluates actions based on the expressions success or failure.
        /// </summary>
        public class TryExpression<T1, T2, T3, TResult> : TryExpression<TResult>
        {
            internal TryExpression() { }

            internal new Func<T1, T2, T3, TResult> Function { get; set; }

            internal new Func<T1, T2, T3, TResult> Default { get; set; }
        }

        /// <summary>
        /// Wraps an expression and evaluates actions based on the expressions success or failure.
        /// </summary>
        public class TryExpression<T1, T2, T3, T4, TResult> : TryExpression<TResult>
        {
            internal TryExpression() { }

            internal new Func<T1, T2, T3, T4, TResult> Function { get; set; }

            internal new Func<T1, T2, T3, T4, TResult> Default { get; set; }
        }


        /// <summary>
        /// Returns an invocable TryExpression wrapping the specified function.
        /// </summary>
        public static TryExpression<TResult> Try<TResult>(this Func<TResult> function)
        {
            return new TryExpression<TResult>() { Function = function };
        }

        /// <summary>
        /// Returns an invocable TryExpression wrapping the specified function.
        /// </summary>
        public static TryExpression<T1, TResult> Try<T1, TResult>(this Func<T1, TResult> function)
        {
            return new TryExpression<T1, TResult>() { Function = function };
        }

        /// <summary>
        /// Returns an invocable TryExpression wrapping the specified function.
        /// </summary>
        public static TryExpression<T1, T2, TResult> Try<T1, T2, TResult>(this Func<T1, T2, TResult> function)
        {
            return new TryExpression<T1, T2, TResult>() { Function = function };
        }

        /// <summary>
        /// Returns an invocable TryExpression wrapping the specified function.
        /// </summary>
        public static TryExpression<T1, T2, T3, TResult> Try<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function)
        {
            return new TryExpression<T1, T2, T3, TResult>() { Function = function };
        }

        /// <summary>
        /// Returns an invocable TryExpression wrapping the specified function.
        /// </summary>
        public static TryExpression<T1, T2, T3, T4, TResult> Try<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> function)
        {
            return new TryExpression<T1, T2, T3, T4, TResult>() { Function = function };
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression fails on invoke.
        /// </summary>
        public static TryExpression<TResult> OnFail<TResult>(this TryExpression<TResult> expression, Action<Exception> function)
        {
            expression.OnFail += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression fails on invoke.
        /// </summary>
        public static TryExpression<T1, TResult> OnFail<T1, TResult>(this TryExpression<T1, TResult> expression, Action<Exception> function)
        {
            expression.OnFail += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression fails on invoke.
        /// </summary>
        public static TryExpression<T1, T2, TResult> OnFail<T1, T2, TResult>(this TryExpression<T1, T2, TResult> expression, Action<Exception> function)
        {
            expression.OnFail += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression fails on invoke.
        /// </summary>
        public static TryExpression<T1, T2, T3, TResult> OnFail<T1, T2, T3, TResult>(this TryExpression<T1, T2, T3, TResult> expression, Action<Exception> function)
        {
            expression.OnFail += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression fails on invoke.
        /// </summary>
        public static TryExpression<T1, T2, T3, T4, TResult> OnFail<T1, T2, T3, T4, TResult>(this TryExpression<T1, T2, T3, T4, TResult> expression, Action<Exception> function)
        {
            expression.OnFail += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression succeeds on invoke.
        /// </summary>
        public static TryExpression<TResult> OnSuccess<TResult>(this TryExpression<TResult> expression, Action<TResult> function)
        {
            expression.OnSuccess += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression succeeds on invoke.
        /// </summary>
        public static TryExpression<T1, TResult> OnSuccess<T1, TResult>(this TryExpression<T1, TResult> expression, Action<TResult> function)
        {
            expression.OnSuccess += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression succeeds on invoke.
        /// </summary>
        public static TryExpression<T1, T2, TResult> OnSuccess<T1, T2, TResult>(this TryExpression<T1, T2, TResult> expression, Action<TResult> function)
        {
            expression.OnSuccess += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression succeeds on invoke.
        /// </summary>
        public static TryExpression<T1, T2, T3, TResult> OnSuccess<T1, T2, T3, TResult>(this TryExpression<T1, T2, T3, TResult> expression, Action<TResult> function)
        {
            expression.OnSuccess += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute if the specified TryExpression succeeds on invoke.
        /// </summary>
        public static TryExpression<T1, T2, T3, T4, TResult> OnSuccess<T1, T2, T3, T4, TResult>(this TryExpression<T1, T2, T3, T4, TResult> expression, Action<TResult> function)
        {
            expression.OnSuccess += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute after the invocation of the TryExpression.
        /// </summary>
        public static TryExpression<TResult> Finally<TResult>(this TryExpression<TResult> expression, Action function)
        {
            expression.Finally += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute after the invocation of the TryExpression.
        /// </summary>
        public static TryExpression<T1, TResult> Finally<T1, TResult>(this TryExpression<T1, TResult> expression, Action function)
        {
            expression.Finally += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute after the invocation of the TryExpression.
        /// </summary>
        public static TryExpression<T1, T2, TResult> Finally<T1, T2, TResult>(this TryExpression<T1, T2, TResult> expression, Action function)
        {
            expression.Finally += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute after the invocation of the TryExpression.
        /// </summary>
        public static TryExpression<T1, T2, T3, TResult> Finally<T1, T2, T3, TResult>(this TryExpression<T1, T2, T3, TResult> expression, Action function)
        {
            expression.Finally += function;
            return expression;
        }

        /// <summary>
        /// Adds an action to execute after the invocation of the TryExpression.
        /// </summary>
        public static TryExpression<T1, T2, T3, T4, TResult> Finally<T1, T2, T3, T4, TResult>(this TryExpression<T1, T2, T3, T4, TResult> expression, Action function)
        {
            expression.Finally += function;
            return expression;
        }

        /// <summary>
        /// Sets a creation expression for the TryExpression's default value.
        /// </summary>
        public static TryExpression<TResult> WithDefault<TResult>(this TryExpression<TResult> expression, Func<TResult> function)
        {
            expression.Default = function;
            return expression;
        }

        /// <summary>
        /// Sets a creation expression for the TryExpression's default value.
        /// </summary>
        public static TryExpression<T1, TResult> WithDefault<T1, TResult>(this TryExpression<T1, TResult> expression, Func<T1, TResult> function)
        {
            expression.Default = function;
            return expression;
        }

        /// <summary>
        /// Sets a creation expression for the TryExpression's default value.
        /// </summary>
        public static TryExpression<T1, T2, TResult> WithDefault<T1, T2, TResult>(this TryExpression<T1, T2, TResult> expression, Func<T1, T2, TResult> function)
        {
            expression.Default = function;
            return expression;
        }

        /// <summary>
        /// Sets a creation expression for the TryExpression's default value.
        /// </summary>
        public static TryExpression<T1, T2, T3, TResult> WithDefault<T1, T2, T3, TResult>(this TryExpression<T1, T2, T3, TResult> expression, Func<T1, T2, T3, TResult> function)
        {
            expression.Default = function;
            return expression;
        }

        /// <summary>
        /// Sets a creation expression for the TryExpression's default value.
        /// </summary>
        public static TryExpression<T1, T2, T3, T4, TResult> WithDefault<T1, T2, T3, T4, TResult>(this TryExpression<T1, T2, T3, T4, TResult> expression, Func<T1, T2, T3, T4, TResult> function)
        {
            expression.Default = function;
            return expression;
        }

        /// <summary>
        /// Invokes the wrapped expression.
        /// </summary>        
        public static TResult Invoke<TResult>(this TryExpression<TResult> expression)
        {
            Exception error;
            try
            {
                TResult result = expression.Function.Invoke();
                expression.OnSuccess?.Invoke(result);
                return result;
            }
            catch (Exception e)
            {
                error = e;
                expression.OnFail?.Invoke(e);
            }
            finally
            {
                expression.Finally?.Invoke();
            }
            if (expression.Default != null)
            {
                return expression.Default.Invoke();
            }
            
            throw error;
        }

        /// <summary>
        /// Invokes the wrapped expression.
        /// </summary>
        public static TResult Invoke<T1, TResult>(this TryExpression<T1, TResult> expression, T1 param)
        {
            Exception error;
            try
            {
                TResult result = expression.Function.Invoke(param);
                expression.OnSuccess?.Invoke(result);
                return result;
            }
            catch (Exception e)
            {
                error = e;
                expression.OnFail?.Invoke(e);
            }
            finally
            {
                expression.Finally?.Invoke();
            }
            if (expression.Default != null)
            {
                return expression.Default.Invoke(param);
            }
            
            throw error;
        }

        /// <summary>
        /// Invokes the wrapped expression.
        /// </summary>
        public static TResult Invoke<T1, T2, TResult>(this TryExpression<T1, T2, TResult> expression, T1 param, T2 param2)
        {
            Exception error;
            try
            {
                TResult result = expression.Function.Invoke(param, param2);
                expression.OnSuccess?.Invoke(result);
                return result;
            }
            catch (Exception e)
            {
                error = e;
                expression.OnFail?.Invoke(e);
            }
            finally
            {
                expression.Finally?.Invoke();
            }
            if (expression.Default != null)
            {
                return expression.Default.Invoke(param, param2);
            }
            
            throw error;
        }

        /// <summary>
        /// Invokes the wrapped expression.
        /// </summary>
        public static TResult Invoke<T1, T2, T3, TResult>(this TryExpression<T1, T2, T3, TResult> expression, T1 param, T2 param2, T3 param3)
        {
            Exception error;
            try
            {
                TResult result = expression.Function.Invoke(param, param2, param3);
                expression.OnSuccess?.Invoke(result);
                return result;
            }
            catch (Exception e)
            {
                error = e;
                expression.OnFail?.Invoke(e);
            }
            finally
            {
                expression.Finally?.Invoke();
            }
            if (expression.Default != null)
            {
                return expression.Default.Invoke(param, param2, param3);
            }
            
            throw error;
        }

        /// <summary>
        /// Invokes the wrapped expression.
        /// </summary>
        public static TResult Invoke<T1, T2, T3, T4, TResult>(this TryExpression<T1, T2, T3, T4, TResult> expression, T1 param, T2 param2, T3 param3, T4 param4)
        {
            Exception error;
            try
            {
                TResult result = expression.Function.Invoke(param, param2, param3, param4);
                expression.OnSuccess?.Invoke(result);
                return result;
            }
            catch (Exception e)
            {
                error = e;
                expression.OnFail?.Invoke(e);
            }
            finally
            {
                expression.Finally?.Invoke();
            }
            if (expression.Default != null)
            {
                return expression.Default.Invoke(param, param2, param3, param4);
            }            
            throw error;
        }
    }
}