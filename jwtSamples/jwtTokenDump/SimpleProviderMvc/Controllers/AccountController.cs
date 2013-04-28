namespace SimpleProviderMvc.Controllers
{
    using SimpleProviderMvc.Filters;
    using SimpleProviderMvc.Helpers;
    using SimpleProviderMvc.Models;
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        [ModelValidationFilterAttribute]
        public ActionResult Login(SpAppAssertion spAppAssertion)
        {
            var contextToken = spAppAssertion.SPAppToken;
            var hostWeb = spAppAssertion.SPHostUrl;
            //var jsonToken = spAppAssertion.JsonToken().ToString();

            using (var clientContext = TokenHelper.GetClientContextWithContextToken(hostWeb, contextToken, Request.Url.Authority))
            {
                UserContextManager.Create(spAppAssertion, clientContext);
                //clientContext.Load(clientContext.Web, web => web.Title);
                //clientContext.ExecuteQuery();
                //Response.Write(clientContext.Web.Title);
            }

            //TODO: error handling and redirect.

            return Redirect("/");
            //return RedirectToAction("Index", "Home");
        }

    }
}
