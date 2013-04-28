namespace SimpleProviderMvc.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Net.Http;
    using System.Web.Http;

    public class ModelValidationFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        //public override void OnActionExecuting(ActionExecutingContext actionContext)
        //{
        //    if (actionContext.ModelState.IsValid == true)
        //    {
        //        var errors = new Dictionary<string, IEnumerable<string>>();
        //        foreach (KeyValuePair<string, System.Web.Http.ModelBinding.ModelState> keyValue in actionContext.ModelState)
        //        {
        //            errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
        //        }

        //        actionContext.Response =
        //            actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
        //    }
        //}


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState.IsValid;

            if (! modelState)
            {
                var errors = new Dictionary<string, IEnumerable<string>>();
                foreach (KeyValuePair<string, ModelState> keyValue in filterContext.Controller.ViewData.ModelState)
                {
                    errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
                }

                throw new ApplicationException("bad stuff is happening!!!");

            }


            base.OnActionExecuting(filterContext);
        }
    }
}
