using System.Web;
using System.Web.Mvc;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;

namespace TodoDemoDotNet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
