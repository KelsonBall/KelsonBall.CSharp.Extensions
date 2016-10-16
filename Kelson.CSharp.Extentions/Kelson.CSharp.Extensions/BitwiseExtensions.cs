using System;
using System.Collections.Generic;

namespace Kelson.CSharp.Extensions
{
    public static class BitwiseExtensions
    {
        /// <summary>
        /// Determines if the specified bit is 1.
        /// </summary>
        /// <param name="place"> 0 indexed from lowest-order bit </param>
        public static bool IsTrue(this int source, int place)
        {
            if (!place.IsBetween<int>(0, 32))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 31] but was {place}.");
            }
            return (source & (1 << place)) != 0;
        }

        /// <summary>
        /// Determines if the specified bit is 1.
        /// </summary>
        /// <param name="place"> 0 indexed from lowest-order bit </param>
        public static bool IsTrue(this ulong source, int place)
        {
            if (!place.IsBetween<int>(0, 64))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 63] but was {place}.");
            }
            return (source & (1ul << place)) != 0;
        }

        /// <summary>
        /// Sets the specified bit to 1.
        /// </summary>
        /// <param name="place"> 0 indexed from lowest-order bit </param>
        public static int Set(this int source, int place)
        {
            if (!place.IsBetween<int>(0, 32))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 31] but was {place}.");
            }
            return source | (1 << place);
        }

        /// <summary>
        /// Sets the specified bit to 1.
        /// </summary>
        /// <param name="place"> 0 indexed from lowest-order bit </param>
        public static ulong Set(this ulong source, int place)
        {
            if (!place.IsBetween<int>(0, 64))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 64] but was {place}.");
            }
            return source | (1ul << place);
        }

        /// <summary>
        /// Sets the specified bits to 1.
        /// </summary>
        /// <param name="place"> List of 0 indexed from lowest-order bit indices </param>
        public static int Set(this int source, params int[] places)
        {
            foreach (int place in places)
            {
                if (!place.IsBetween<int>(0, 32))
                {
                    throw new IndexOutOfRangeException($"Place must be in the range [0, 31] but was {place}.");
                }
                source = source.Set(place);
            }
            return source;
        }

        /// <summary>
        /// Sets the specified bits to 1.
        /// </summary>
        /// <param name="place"> List of 0 indexed from lowest-order bit indices </param>
        public static ulong Set(this ulong source, params int[] places)
        {
            foreach (int place in places)
            {
                if (!place.IsBetween<int>(0, 64))
                {
                    throw new IndexOutOfRangeException($"Place must be in the range [0, 63] but was {place}.");
                }
                source = source.Set(place);
            }
            return source;
        }

        /// <summary>
        /// Sets the specified bit to 0.
        /// </summary>
        /// <param name="place"> List of 0 indexed from lowest-order bit </param>
        public static int Clear(this int source, int place)
        {
            if (!place.IsBetween<int>(0, 32))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 31] but was {place}.");
            }
            return source & ~(1 << place);
        }

        /// <summary>
        /// Sets the specified bit to 0.
        /// </summary>
        /// <param name="place"> List of 0 indexed from lowest-order bit </param>
        public static ulong Clear(this ulong source, int place)
        {
            if (!place.IsBetween<int>(0, 64))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 63] but was {place}.");
            }
            return source & ~(1ul << place);
        }

        /// <summary>
        /// Toggles the specified bit.
        /// </summary>
        /// <param name="place"> List of 0 indexed from lowest-order bit </param>
        public static int Toggle(this int source, int place)
        {
            if (!place.IsBetween<int>(0, 32))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 31] but was {place}.");
            }
            return source ^ (1 << place);
        }

        /// <summary>
        /// Toggles the specified bit.
        /// </summary>
        /// <param name="place"> List of 0 indexed from lowest-order bit </param>
        public static ulong Toggle(this ulong source, int place)
        {
            if (!place.IsBetween<int>(0, 64))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 63] but was {place}.");
            }
            return source ^ (1ul << place);
        }

        /// <summary>
        /// Converts an Int32 to an array of booleans, lowest-order bit first.
        /// </summary>
        public static IEnumerable<bool> ToBools(this int source, int places = 32)
        {
            if (!places.IsBetween<int>(0, 32, RangeFlags.Inclusive))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 32] but was {places}.");
            }
            for (int i = 0; i < places; i++)
            {
                yield return source.IsTrue(i);
            }
        }

        /// <summary>
        /// Converts an UInt64 to an array of booleans, lowest-order bit first.
        /// </summary>
        public static IEnumerable<bool> ToBools(this ulong source, int places = 64)
        {
            if (!places.IsBetween<int>(0, 64, RangeFlags.Inclusive))
            {
                throw new IndexOutOfRangeException($"Place must be in the range [0, 64] but was {places}.");
            }
            for (int i = 0; i < places; i++)
            {
                yield return source.IsTrue(i);
            }
        }

        /// <summary>
        /// Converts an array of booleans to an Int32, lowest-order bit first.
        /// </summary>
        /// <param name="bools">An array of size less than 32</param>
        public static int ToFlags(this bool[] bools)
        {
            if (bools.Length > 32)
            {
                throw new ArgumentException("Use 'ulong[] ToFlagsLarge(this bool[] bools)' for collections of size > 32");
            }

            int result = 0;
            int maskPlace = 0;
            foreach (bool value in bools)
            {
                if (value)
                {
                    result = result.Set(maskPlace);
                }
                maskPlace++;
            }
            return result;
        }

        /// <summary>
        /// Converts any array of booleans to an UInt64 array, lowest-order bit first.
        /// </summary>
        public static ulong[] ToFlagsLarge(this bool[] bools)
        {
            ulong[] result = new ulong[ (bools.Length >> 6) + 1 ];
            int topIndex = 0;
            int bottomIndex = 0;
            foreach (bool value in bools)
            {
                if (value)
                {
                    result[topIndex] = result[topIndex].Set(bottomIndex);
                }
                bottomIndex++;
                if (bottomIndex > 63)
                {
                    bottomIndex = 0;
                    topIndex++;
                }
            }
            return result;
        }
    }
}