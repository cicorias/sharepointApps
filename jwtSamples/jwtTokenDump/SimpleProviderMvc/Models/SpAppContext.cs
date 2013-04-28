using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleProviderMvc.Models
{
    public class SpAppContext
    {//{"CacheKey":"tRcYdnV7Yc6AOZXI+54z09DJvPjpjAZ8q9nA8K0O+sg=","SecurityTokenServiceUri":"https://accounts.accesscontrol.windows.net/tokens/OAuth/2"}

        public string CacheKey { get; set; }
        public string SecurityTokenServiceUri { get; set; }
    }
}