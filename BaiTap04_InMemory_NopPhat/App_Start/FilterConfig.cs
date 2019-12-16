using System.Web;
using System.Web.Mvc;

namespace BaiTap04_InMemory_NopPhat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
