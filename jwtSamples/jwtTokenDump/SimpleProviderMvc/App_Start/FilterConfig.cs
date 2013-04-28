using SimpleProviderMvc.Filters;
using System.Web;
using System.Web.Mvc;

namespace SimpleProviderMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //TODO: remove or replace
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ModelValidationFilterAttribute());
            //System.Web.Http.GlobalConfiguration.Configuration.Filters.Add(new ModelValidationFilterAttribute());
        }

    }
}
