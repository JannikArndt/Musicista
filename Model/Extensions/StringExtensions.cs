﻿using System.Linq;
using System.Text;

namespace Model.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveWhitespace(this string str)
        {
            if (str == null) return "";
            var sb = new StringBuilder(str.Length);
            foreach (var c in str.Where(c => !char.IsWhiteSpace(c)))
                sb.Append(c);
            return sb.ToString();
        }
    }
}
