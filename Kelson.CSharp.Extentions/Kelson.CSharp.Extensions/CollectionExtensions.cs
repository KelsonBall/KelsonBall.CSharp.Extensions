using System;
using System.Collections.Generic;
using System.Linq;

namespace Kelson.CSharp.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Determines if the parameters contain the source argument.
        /// </summary>
        public static bool In<T>(this T source, params T[] list)
        {            
            return list.Contains(source);
        }

        /// <summary>
        /// Determines if the parameters contain the source argument.
        /// </summary>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Concatenates two arrays.
        /// </summary>        
        public static T[] Concat<T>(this T[] source, params T[] args)
        {
            T[] composite = new T[source.Length + args.Length];
            Array.Copy(source, composite, source.Length);
            Array.Copy(args, 0, composite, source.Length, args.Length);
            return composite;
        }

        /// <summary>
        /// Selects a range from a collection starting with index from and ending before index to.
        /// </summary>        
        /// <param name="from">Default: 0. Wraps to end of source collection if negative.</param>
        /// <param name="to">Default: End of source collection. Wraps to end of source collection if negative.</param>
        /// <returns> Specified subset of source.</returns>
        public static T[] Range<T>(this T[] list, int from = 0, int? to = null)
        {                        
            int localfrom = from;
            if (from < 0)
            {
                localfrom = list.Length + from;
            }

            int realto = to ?? list.Length;
            int localto = realto;
            if (realto < 0)
            {
                localto = list.Length + realto;
            }

            int resultLength = localto - localfrom;

            if (resultLength < 0)
            {
                throw new ArgumentException("Range must have a positive length.");
            }
            
            T[] result = new T[resultLength];

            Array.Copy(list, localfrom, result, 0, resultLength);

            return result;
        }

        /// <summary>
        /// Selects a range from a collection starting with index from and ending before index to.
        /// </summary>        
        /// <param name="from">Default: 0. Wraps to end of source collection if negative.</param>
        /// <param name="to">Default: End of source collection. Wraps to end of source collection if negative.</param>
        /// <returns> Specified subset of source.</returns>
        public static IEnumerable<T> Range<T>(this IEnumerable<T> list, int from = 0, int? to = null)
        {
            // Only use list.Count() if necessary, and only call it once. 
            // int? length will store the length of the input enumerable if it is necessary to compute ranges based on length.            
            int? length = null;

            int localfrom = from;
            if (from < 0)
            {
                length = list.Count();
                localfrom = (int)length + from;
            }

            int realto = to ?? length ?? list.Count();
            int localto = realto;
            if (realto < 0)
            {
                length = length ?? list.Count(); // Do not recompute length if it was computed to determine localfrom.
                localto = (int)length + realto;
            }

            int resultLength = localto - localfrom;

            if (resultLength < 0)
            {
                throw new ArgumentException("Range must have a positive length.");
            }

            return list.Skip(localfrom).Take(resultLength);
        }

        /// <summary>
        /// Equivalent to the Linq Select method for arrays.
        /// </summary>
        public static TResult[] Select<T, TResult>(this T[] items, Func<T, TResult> function)
        {
            TResult[] results = new TResult[items.Length];
            long count = 0;
            foreach (T item in items)
            {
                results[count] = function(item);
                count++;
            }
            return results;
        }

        /// <summary>
        /// Equivalent to the Linq ForEach method on IList, for IEnumerable.
        /// Performs an action on each item of a list of items and passes on the list.
        /// </summary>        
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }

            return items;
        }

        /// <summary>
        /// Equivalent to the Linq ForEach method on IList, for Arrays.
        /// Performs an action on each item of an array and passes on the array.
        /// </summary>
        public static T[] ForEach<T>(this T[] items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }

            return items;
        }
    }
}