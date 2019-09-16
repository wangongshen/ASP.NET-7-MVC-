using System.Web;
using System.Web.Mvc;

namespace ASP.NET就业实例视频教程_7_MVC框架
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
