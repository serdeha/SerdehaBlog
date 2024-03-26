using Microsoft.AspNetCore.Mvc.Rendering;

namespace SerdehaBlog.WebUI.Extensions
{
	public static class HeaderIsActiveExtension
	{
		public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
		{
			var routeData = htmlHelper.ViewContext.RouteData;

			var routeAction = routeData.Values["action"]!.ToString();
			var routeController = routeData.Values["controller"]!.ToString();

			var returnActive = (controller == routeController && (action == routeAction || routeAction == "Index"));

			return returnActive ? "active" : "";
		}
	}
}
