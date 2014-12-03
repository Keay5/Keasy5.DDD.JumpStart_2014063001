using System.Web;
using System.Web.Mvc;

namespace Keasy5.Web.AspNetMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}