using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Core
{
    public static class StringExtensions
    {
        public static string ToStringCommaSeparated(
            this IEnumerable<object> items, 
            string prefix = null, 
            string suffix = null)
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                if (sb.Length > 0) sb.Append(", ");
                if (prefix != null) sb.Append(prefix);
                sb.Append(item.ToString());
                if (suffix != null) sb.Append(suffix);
            }
            return sb.ToString();
        }
    }
}
