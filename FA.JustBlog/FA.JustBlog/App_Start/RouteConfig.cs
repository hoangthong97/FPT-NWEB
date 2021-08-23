using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional },
				namespaces: new[] { "FA.JustBlog.Controllers" }
			);
			
			routes.MapRoute(
				"Post",
				"Post/{year}/{month}/{title}",
				new { controller = "Post", action = "Details" },
				new { year = @"\d{4}", month = @"\d{2}" },
				namespaces: new[] { "FA.JustBlog.Controllers" }
			 );

			routes.MapRoute(
				name: "Tag",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Tag", action = "Index", id = UrlParameter.Optional }

				
			);

		}
	}
}