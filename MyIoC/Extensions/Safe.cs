using System;
using System.Collections.Generic;
using System.Linq;

namespace MyIoC.Extensions
{
    public static class Safe
    {
        public static bool SafeAny<TSource>(this IEnumerable<TSource> source)
        {

            if(source == null)
            {
                return false;
            }

            return source.Any();

        }

        public static bool SafeAny<TSource>(this IEnumerable<TSource> pSource, Func<TSource, bool> pPredicate)
        {
            if(pSource == null)
            {
                return false;
            }

            if(pPredicate == null)
            {
                return false;
            }

            return pSource.Any(pPredicate);

        }

    }
}
