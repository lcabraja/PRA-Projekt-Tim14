using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Extensions
{
    public static class Class1
    {
        public static IEnumerable<string> SplitByLength(this string str, int maxLength)
        {
            for (int index = 0; index < str.Length; index += maxLength)
            {
                yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
            }
        }
    }
}