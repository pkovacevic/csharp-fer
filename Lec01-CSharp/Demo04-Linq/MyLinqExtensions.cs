using System;
using System.Collections.Generic;

namespace Demo04_Linq
{
    public static class MyLinqExtensions
    {
        /// <summary>
        /// Naive approach.
        /// </summary>
        public static bool AnyStartsWithL(this IEnumerable<string> collection)
        {
            IEnumerable<string> ret = new List<string>();
            foreach (var element in collection)
            {
                if (element.ToLower().StartsWith("l"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Naive approach
        /// </summary>
        public static bool AnyStartsWithM(this IEnumerable<string> collection)
        {
            IEnumerable<string> ret = new List<string>();
            foreach (var element in collection)
            {
                if (element.ToLower().StartsWith("m"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Okay, but we can do much better
        /// </summary>
        public static bool Any(this IEnumerable<string> collection, Func<string, bool> operation)
        {
            IEnumerable<string> ret = new List<string>();
            foreach (var element in collection)
            {
                if (operation(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Perfect implementation
        /// </summary>
        public static bool Any<T>(this IEnumerable<T> collection, Func<T, bool> operation)
        {
            IEnumerable<string> ret = new List<string>();
            foreach (var element in collection)
            {
                if (operation(element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}