using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleProviderMvc.Helpers;

namespace SimpleProviderMvc.Models
{
    public class UserContext
    {
        public SpAppAssertion AppAssertions { get; set; }
        public Microsoft.SharePoint.Client.ClientContext ClientContext { get; set; }
        public string BootstrapToken { get; set; }
        public SpAppContext AppContext { get; set; }
        public string CacheKey
        {
            get
            {
                if (this.AppContext != null)
                    return this.AppContext.CacheKey;
                else
                    return null;
            }
        }
    }
}
