using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxonCFS.Application.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string value)
        {
            if (value == null)
                return string.Empty;

            return string.Concat(
                value.Select(
                    (x, i) => i > 0 && char.IsUpper(x)
                        ? "_" + x
                        : x.ToString()
                        )
                ).ToLower();
        }
    }
}
