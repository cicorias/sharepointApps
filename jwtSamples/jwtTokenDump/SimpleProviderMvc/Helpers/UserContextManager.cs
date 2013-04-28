using SimpleProviderMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SimpleProviderMvc.Helpers
{
    public interface IUserContextManager
    {
        UserContext Current { get; set; }

    }

    public class UserContextManager : IUserContextManager
    {
        UserContext _userContext;


        /// <summary>
        /// Prevents a default instance of the ClientUserContextManager class from being created.
        /// </summary>
        public UserContextManager()
        {
        }

        /// <summary>
        /// Returns current user context
        /// </summary>
        /// 
        // TODO: Must make this repository driven.
        public UserContext Current
        {
            get
            {
                return GetCurrentUserContext();
            }
            set
            {
                _userContext = value;
                _userContext.StoreInSession();
            }
        }

        /// <summary>
        /// This method will retrieve the usercontext object from the session and return the same.
        /// </summary>
        /// <returns>The UserContext object as retrieved from the session.</returns>
        private static UserContext GetCurrentUserContext()
        {
            UserContext userInfo = null;
            var ctx = HttpContext.Current;


            var sessionWrap = new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session);


            userInfo = sessionWrap["userContext"] as UserContext;//.GetFromCache(cookieValue);
            return userInfo;

        }

        public static void Create(SpAppAssertion spAppAssertion, Microsoft.SharePoint.Client.ClientContext clientContext)
        {
            var jsonToken = spAppAssertion.JsonToken();
            var appCtx = jsonToken.GetAppContext();
            var jsonTokenString = jsonToken.ToString();
            UserContext newContext = new UserContext
            {
                AppAssertions = spAppAssertion,
                ClientContext = clientContext,
                BootstrapToken = jsonTokenString,
                AppContext = appCtx
            };

            var sessionWrap = new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session);
            newContext.StoreInSession();;
        }
    }
}