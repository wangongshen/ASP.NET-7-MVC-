using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemoMVC01
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AdminLogins", action = "Login", id = UrlParameter.Optional }
                //constraints: new {Controller=@"Home",Action=@"Index|Test"},//表示控制器为Home，action为Index或Test，那么其他的action就匹配不到
                //namespaces:new string[] {"MvcApplication1.Controllers"} //表示到指定的命名空间下去搜索控制器
            );
        }
    }
}
