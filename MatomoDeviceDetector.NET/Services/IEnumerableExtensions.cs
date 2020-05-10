// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IEnumerableExtensions.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services
{
    using System.Collections;

    /// <summary>
    /// IEnumerableExtensions.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Any?.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <returns>Bool.</returns>
        public static bool Any(this IEnumerable source)
        {
            if (source == null)
            {
                return false;
            }

            var e = source.GetEnumerator();
            return e.MoveNext();
        }

        /// <summary>
        /// Count.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <returns>Int.</returns>
        public static int Count(this IEnumerable source)
        {
            switch (source)
            {
                case null:
                    return 0;
                case ICollection col:
                    return col.Count;
            }

            var c = 0;
            var e = source.GetEnumerator();

            while (e.MoveNext())
            {
                c++;
            }

            return c;
        }
    }
}