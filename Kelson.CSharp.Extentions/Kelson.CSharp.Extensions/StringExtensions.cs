namespace Kelson.CSharp.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Selects a range from a string starting with index from and ending before index to.
        /// </summary>        
        /// <param name="from">Default: 0. Wraps to end of source string if negative.</param>
        /// <param name="to">Default: End of source string. Wraps to end of source string if negative.</param>
        /// <returns> Specified substring of source.</returns>
        public static string Range(this string source, int from = 0, int? to = null)
        {
            return new string(source.ToCharArray().Range(from, to));
        }
    }
}