using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Keasy5.Web.AspNetMvc
{
    public static class UrlHelperExtension
    {
        public static string GetProductImagePath(UrlHelper helper)
        {
            return helper.Content("~/Images/Products/");
        }

        public static MvcHtmlString ProductImagePath(this UrlHelper helper)
        {
            return MvcHtmlString.Create(GetProductImagePath(helper));
        }
    }
}