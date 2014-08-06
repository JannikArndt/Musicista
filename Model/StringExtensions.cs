using System.Linq;
using System.Text;

namespace Model
{
    public static class StringExtensions
    {
        public static string RemoveWhitespace(this string str)
        {
            var sb = new StringBuilder(str.Length);
            foreach (var c in str.Where(c => !char.IsWhiteSpace(c)))
                sb.Append(c);
            return sb.ToString();
        }
    }
}
