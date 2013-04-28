//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="CedarLogic">
//     Copyright (c) CedarLogic. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using SimpleProviderMvc.Helpers;
using SimpleProviderMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleProviderMvc.Controllers
{
    public class HomeController : Controller
    {
        IUserContextManager _userContextManager;
        public HomeController() : this(new UserContextManager())
        {

        }

        public HomeController(IUserContextManager userContextManager)
        {
            _userContextManager = userContextManager;
        }

        public ActionResult Index()
        {
            var model = new UserContextViewModel();

            var userContext = _userContextManager.Current;

            var firstDot = userContext.BootstrapToken.IndexOf('.');
            var realToken = userContext.BootstrapToken.Substring(firstDot + 1);

            dynamic parsedJson = JsonConvert.DeserializeObject(realToken);
            var jsonTokenString = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);



            model.UserContext = userContext;
            model.JsonTokenString = jsonTokenString;
            model.JsonToken = userContext.AppAssertions.JsonToken();

            var siteName = GetSpSiteName(userContext);

            ViewBag.Stuff = siteName;

            return View(model);
        }

        string GetSpSiteName(UserContext context)
        {

            var clientContext = context.ClientContext;
            clientContext.Load(context.ClientContext.Web, web => web.Title);
            clientContext.ExecuteQuery();
            return context.ClientContext.Web.Title;
        }

    }
}
