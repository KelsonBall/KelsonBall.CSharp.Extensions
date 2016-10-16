using System;
using System.Collections.Generic;
using System.Linq;

namespace Kelson.CSharp.Extensions.Functional
{
    #region ParamFunc Delegates
    /// <summary>
    /// A delegate type that accepts param arguments.
    /// </summary>
    /// <typeparam name="TData">Param array type</typeparam>
    /// <typeparam name="TResult">Return type of the delegate</typeparam>
    /// <param name="args">Param array of type TData</param>
    /// <returns>Instance of type TResult</returns>
    public delegate TResult ParamFunc<in TData, out TResult>(params TData[] args);

    /// <summary>
    /// A delegate type that accepts param arguments.
    /// </summary>
    /// <typeparam name="TData">Param array type</typeparam>
    /// <typeparam name="TResult">Return type of the delegate</typeparam>
    /// <param name="args">Param array of type TData</param>
    /// <returns>Instance of type TResult</returns>
    public delegate TResult ParamFunc<in T1, in TData, out TResult>(T1 v1, params TData[] args);

    /// <summary>
    /// A delegate type that accepts param arguments.
    /// </summary>
    /// <typeparam name="TData">Param array type</typeparam>
    /// <typeparam name="TResult">Return type of the delegate</typeparam>
    /// <param name="args">Param array of type TData</param>
    /// <returns>Instance of type TResult</returns>
    public delegate TResult ParamFunc<in T1, in T2, in TData, out TResult>(T1 v1, T2 v2, params TData[] args);

    /// <summary>
    /// A delegate type that accepts param arguments.
    /// </summary>
    /// <typeparam name="TData">Param array type</typeparam>
    /// <typeparam name="TResult">Return type of the delegate</typeparam>
    /// <param name="args">Param array of type TData</param>
    /// <returns>Instance of type TResult</returns>
    public delegate TResult ParamFunc<in T1, in T2, in T3, in TData, out TResult>(T1 v1, T2 v2, T3 v3, params TData[] args);

    /// <summary>
    /// A delegate type that accepts param arguments.
    /// </summary>
    /// <typeparam name="TData">Param array type</typeparam>
    /// <typeparam name="TResult">Return type of the delegate</typeparam>
    /// <param name="args">Param array of type TData</param>
    /// <returns>Instance of type TResult</returns>
    public delegate TResult ParamFunc<in T1, in T2, in T3, in T4, in TData, out TResult>(T1 v1, T2 v2, T3 v3, T4 v4, params TData[] args);

    #endregion

    public static class DelegateExtensions
    {
        #region Curry Func

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static Func<TResult> Curry<T1, TResult>(this Func<T1, TResult> function, T1 value)
        {
            return () => function(value);
        }

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static Func<T2, TResult> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> function, T1 value)
        {
            return x => function(value, x);
        }

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static Func<T2, T3, TResult> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function, T1 value)
        {
            return (x, y) => function(value, x, y);
        }

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static Func<T2, T3, T4, TResult> Curry<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> function, T1 value)
        {
            return (x, y, z) => function(value, x, y, z);
        }

        #region ParamFunc
        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static ParamFunc<TData, TResult> Curry<TData, TResult>(
            this ParamFunc<TData, TResult> function,
            TData value)
        {
            return data =>
                {
                    TData[] parameters = new TData[data.Length + 1];
                    parameters[0] = value;
                    data.CopyTo(parameters, 1);
                    return function(parameters.ToArray());
                };
        }

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static ParamFunc<TData, TResult> Curry<T1, TData, TResult>(
            this ParamFunc<T1, TData, TResult> function, T1 value)
        {
            return data => function(value, data);
        }

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static ParamFunc<T2, TData, TResult> Curry<T1, T2, TData, TResult>(
            this ParamFunc<T1, T2, TData, TResult> function, T1 value)
        {
            return (x, data) => function(value, x, data);
        }

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static ParamFunc<T2, T3, TData, TResult> Curry<T1, T2, T3, TData, TResult>(
            this ParamFunc<T1, T2, T3, TData, TResult> function, T1 value)
        {
            return (x, y, data) => function(value, x, y, data);
        }

        /// <summary>
        /// Takes a function and preloads its first argument with the specified value.
        /// </summary>
        public static ParamFunc<T2, T3, T4, TData, TResult> Curry<T1, T2, T3, T4, TData, TResult>(
            this ParamFunc<T1, T2, T3, T4, TData, TResult> function, T1 value)
        {
            return (x, y, z, data) => function(value, x, y, z, data);
        }

        #endregion

        #endregion

        #region Scope Inversions
        /// <summary>
        /// Executes the source function in the using scope of an IDisposable.
        /// </summary>
        /// <typeparam name="TDisposable">Type of the disposable to use.</typeparam>
        /// <typeparam name="TResult">Type to return.</typeparam>
        /// <param name="function">Function to execute in disposable scope.</param>
        /// <param name="disposable">Function to create the TDisposable</param>
        public static TResult Using<TDisposable, TResult>(this Func<TDisposable, TResult> function, Func<TDisposable> disposable) where TDisposable : IDisposable
        {
            using (TDisposable disposableInstance = disposable())
            {
                return function(disposableInstance);
            }
        }

        /// <summary>
        /// Executes the source function in the using scope of an IDisposable.
        /// </summary>
        /// <typeparam name="TDisposable">Type of the disposable to use.</typeparam>
        /// <typeparam name="TResult">Type to return.</typeparam>
        /// <param name="disposable">Function to create the TDisposable.</param>
        /// /// <param name="function">Function to execute in disposable scope.</param>
        public static TResult Using<TDisposable, TResult>(
            this Func<TDisposable> disposable,
            Func<TDisposable, TResult> function) where TDisposable : IDisposable
        {
            using (TDisposable disposableInstance = disposable())
            {
                return function(disposableInstance);
            }
        }

        #endregion

        #region Action Pipes
        /// <summary>
        /// Performs an action on item and passes on the item.
        /// </summary>
        public static T Do<T>(this T item, Action<T> action)
        {
            action(item);
            return item;
        }

        /// <summary>
        /// Performs an action with the specified parameter and passes on the source item.
        /// </summary>
        public static T NonSequitur<T, TParam>(this T data, Action<TParam> action, TParam message)
        {
            action(message);
            return data;
        }
        #endregion

        #region Pipes and Params

        /// <summary>
        /// Takes pipe input and passes it to the params argument of a ParamFunc.
        /// </summary>
        public static TResult PipeToParams<TData, TResult>(this TData[] data, ParamFunc<TData, TResult> func)
        {
            return func(data);
        }

        /// <summary>
        /// Takes pipe input and passes it to the params argument of a ParamFunc.
        /// </summary>
        public static TResult PipeToParams<T1, TData, TResult>(this TData[] data, ParamFunc<T1, TData, TResult> function, T1 value1)
        {
            return function(value1, data);
        }

        /// <summary>
        /// Takes pipe input and passes it to the params argument of a ParamFunc.
        /// </summary>
        public static TResult PipeToParams<T1, T2, TData, TResult>(this TData[] data, ParamFunc<T1, T2, TData, TResult> function, T1 value1, T2 value2)
        {
            return function(value1, value2, data);
        }

        /// <summary>
        /// Takes pipe input and passes it to the params argument of a ParamFunc.
        /// </summary>
        public static TResult PipeToParams<T1, T2, T3, TData, TResult>(this TData[] data, ParamFunc<T1, T2, T3, TData, TResult> function, T1 value1, T2 value2, T3 value3)
        {
            return function(value1, value2, value3, data);
        }

        /// <summary>
        /// Takes pipe input and passes it to the params argument of a ParamFunc.
        /// </summary>
        public static TResult PipeToParams<T1, T2, T3, T4, TData, TResult>(this TData[] data, ParamFunc<T1, T2, T3, T4, TData, TResult> function, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return function(value1, value2, value3, value4, data);
        }

        /// <summary>
        /// Casts an array or params list to an enumerable.
        /// </summary>
        public static IEnumerable<TData> AsEnumerable<TData>(params TData[] args) => args.AsEnumerable();

        #endregion
    }
}