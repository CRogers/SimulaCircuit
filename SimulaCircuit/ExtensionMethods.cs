using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulaCircuit
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Unfold<T>(this T seed, Func<T,T> func, Predicate<T> endCondition = null, int max = int.MaxValue)
        {
            if (endCondition == null)
                endCondition = x => false;

            var t = seed;
            for (int i = 0; !endCondition(t) && i < max; i++)
                yield return t = func(t);
        }
    }
}
