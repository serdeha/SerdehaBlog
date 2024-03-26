using System.Text.RegularExpressions;

namespace SerdehaBlog.WebUI.Extensions
{
	public static class RemoveHtmlExtension
	{
		public static string RemoveHtml(this string input)
		{
			return Regex.Replace(input, "<[a-zA-Z/].*?>", String.Empty);
		}
	}
}
