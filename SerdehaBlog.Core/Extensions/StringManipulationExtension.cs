using System.Text.RegularExpressions;

namespace SerdehaBlog.Core.Extensions
{
    public static class StringManipulationExtension
    {
        public static string RemoveHtml(this string input)
        {
            return Regex.Replace(input, "<[a-zA-Z/].*?>", String.Empty);
        }
    }
}
