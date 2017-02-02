using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Core
{
    public static class ListExtensions
    {
        public static bool Matches<T>(this IList<T> me, IList<T> other)
            where T : IMatches<T>
        {
            if (other == null || other.Count != me.Count) return false;

            for (int i = 0; i < me.Count; i++)
            {
                var meItem = me[i];
                var otherItem = other[i];
                if (!meItem.Matches(otherItem)) return false;
            }

            return true;
        }
    }
}
