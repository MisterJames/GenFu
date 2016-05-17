using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFu.Utilities
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Append a string when a predicate evaluates true.
        /// </summary>
        /// <param name="value">String to append.</param>
        /// <param name="predicate">Predicate</param>
        /// <returns></returns>
        public static StringBuilder AppendWhen(this StringBuilder sb, string value, bool predicate) => predicate ? sb.Append(value) : sb;

        /// <summary>
        /// Repeats a string builder operation for n times.
        /// </summary>
        /// <param name="times">Number of times to repeat.</param>
        /// <param name="fn">A StringBuilder function.</param>
        /// <returns>StringBuilder</returns>
        public static StringBuilder BuildFor(this StringBuilder sb, int times, Func<StringBuilder, StringBuilder> fn)
        {
            for (int i = 0; i < times; i++)
            {
                fn(sb);
            }
            return sb;
        }

        /// <summary>
        /// Repeats a string builder operation for n times.
        /// </summary>
        /// <param name="times">Number of times to repeat.</param>
        /// <param name="fn">A StringBuilder function with index.</param>
        /// <returns>StringBuilder</returns>
        public static StringBuilder BuildFor(this StringBuilder sb, int times, Func<StringBuilder, int, StringBuilder> fn)
        {
            for (int i = 0; i < times; i++)
            {
                fn(sb, i);
            }
            return sb;
        }
    }
}