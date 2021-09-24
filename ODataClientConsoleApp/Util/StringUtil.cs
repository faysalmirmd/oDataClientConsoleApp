using System.Text.RegularExpressions;

namespace ODataClientConsoleApp.Util
{
    public static class StringUtil
    {
        private static readonly Regex RegexWhitespace = new(@"\s+");

        public static string ReplaceWhitespace(string input, string replacement)
        {
            return RegexWhitespace.Replace(input, replacement);
        }
    }
}