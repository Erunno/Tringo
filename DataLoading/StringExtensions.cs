using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoading
{
    public static class StringExtensions
    {
        public static int GetStartIndexOf(this string str, string pattern)
        {
            for (int i = 0; i < str.Length - pattern.Length + 1; i++)
                if (str.IsSubstringStartingAt(pattern, i))
                    return i;

            return -1; // pattern hasnt been found
        }

        private static bool IsSubstringStartingAt(this string str, string pattern, int startingIndex)
        {
            for (int i = 0; i < pattern.Length; i++)
                if (pattern[i] != str[i + startingIndex])
                    return false;

            return true;
        }

    }
}
