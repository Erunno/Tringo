using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    public static class ArrayExtensions
    {
        public static string ToNiceString<T>(this T[] arr)
        {
            if (arr.Length == 0)
                return "{ }";

            StringBuilder sb = new StringBuilder();

            sb.Append("{");

            for (int i = 0; i < arr.Length - 1; i++)
                sb.Append($" {arr[i].ToString()},");

            sb.Append($" {arr[arr.Length - 1].ToString()} }}");

            return sb.ToString();
        }

    }
}
