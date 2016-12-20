using System.Collections.Generic;
using System.Linq;

namespace FrontEnd.Extensions
{
    /// <summary>
    /// Helper methods for lists.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// ChunkBy
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="source">List to be 'Chunked'</param>
        /// <param name="chunkSize">Amount of items in a chunk</param>
        /// <returns></returns>
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                    .Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / chunkSize)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();
        }
    }
}
