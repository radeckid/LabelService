using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelService.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            if(text == null || text.Trim().Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
