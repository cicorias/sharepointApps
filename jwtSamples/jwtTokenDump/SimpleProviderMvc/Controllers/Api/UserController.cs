using SimpleProviderMvc.Helpers;
using SimpleProviderMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleProviderMvc.Controllers.Api
{
    public class UserController : ApiController
    {
        IUserContextManager _userContextManager;
        public UserController()
            : this(new UserContextManager())
        {

        }

        public UserController(IUserContextManager userContextManager)
        {
            _userContextManager = userContextManager;
        }
        public IEnumerable<UserViewModel> Get()
        {
            var clientContext = _userContextManager.Current.ClientContext;
            clientContext.Load(clientContext.Web, web => web.CurrentUser);
            clientContext.ExecuteQuery();

            var authNmode = clientContext.AuthenticationMode;
            var appName = clientContext.ApplicationName;

            var userName = clientContext.Web.CurrentUser.LoginName;
            var title = clientContext.Web.CurrentUser.Title;
            var userEmail = clientContext.Web.CurrentUser.Email;
            var spId = clientContext.Web.CurrentUser.Id.ToString();


            return new UserViewModel[] { new UserViewModel { Title = title, Name = userName, SpId = spId, Email = userEmail } };
        }

    }
}
