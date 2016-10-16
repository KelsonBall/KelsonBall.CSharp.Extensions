using System;
using System.Collections.Generic;

namespace Kelson.CSharp.Extensions
{   
    public static class SetOperations
    {
        /// <summary>
        /// Generates a list of of tuples containing every combination of items from set1 and set2.
        /// </summary>
        public static IEnumerable<Tuple<T1, T2>> CartesianProduct<T1, T2>(this IList<T1> set1, IList<T2> set2)
        {
            if (set1 == null || set2 == null)
            {
                throw new ArgumentException("Source data of cartesian product cannot be null.");
            }
            foreach (T1 item1 in set1)
            {
                foreach (T2 item2 in set2)
                {
                    yield return new Tuple<T1, T2>(item1, item2);
                }
            }
        }        
    }    
}