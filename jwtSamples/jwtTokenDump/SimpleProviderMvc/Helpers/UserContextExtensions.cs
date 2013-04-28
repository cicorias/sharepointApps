//-----------------------------------------------------------------------
// <copyright file="UserContextExtensions.cs" company="CedarLogic">
//     Copyright (c) CedarLogic. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using SimpleProviderMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace SimpleProviderMvc.Helpers
{
    public static class UserContextExtensions
    {
        public static void StoreInSession(this UserContext userContext)
        {
            var sessionWrap = new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session);

            if (sessionWrap.IsNewSession)
            {
                sessionWrap.Add("userContext", userContext);
            }
        }

        public static void StoreInCache1(this UserContext userContext, string sessionId)
        {
            var cache = MemoryCache.Default;

            if (cache.Contains(sessionId))
                cache.Remove(sessionId);


            var item = new CacheItem(sessionId, userContext);
            cache.Add(item, new CacheItemPolicy());
        }

        public static UserContext GetFromCache1(string sessionId)
        {
            var cache = MemoryCache.Default;

            if (cache.Contains(sessionId))
                return cache[sessionId] as UserContext;


            return null;
        }


    }
}
