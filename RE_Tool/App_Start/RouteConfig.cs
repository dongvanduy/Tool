using System.Web.Mvc;
using System.Web.Routing;

namespace RE_Tool
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RE_Tool.Controllers" }  // Chỉ định namespace mặc định
            );

            routes.MapRoute(
            name: "Admin",
            url: "Admin/{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "RE_Tool.Areas.Admin.Controllers" }  // Chỉ định namespace cho khu vực admin
            );
        }
    }
}
