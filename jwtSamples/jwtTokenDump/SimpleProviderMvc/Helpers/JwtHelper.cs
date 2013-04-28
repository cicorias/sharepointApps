namespace SimpleProviderMvc.Helpers
{
    using Microsoft.IdentityModel.S2S.Tokens;
    using Newtonsoft.Json;
    using SimpleProviderMvc.Models;
    using System.IdentityModel.Tokens;
    public static class JwtHelper
    {
        public static JsonWebSecurityToken JsonToken(this SpAppAssertion spAppAssertion)
        {
            JsonWebSecurityTokenHandler tokenHandler = TokenHelper.CreateJsonWebSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.ReadToken(spAppAssertion.SPAppToken);
            JsonWebSecurityToken jsonToken = securityToken as JsonWebSecurityToken;
            return jsonToken;
        }

        public static SpAppContext GetAppContext(this JsonWebSecurityToken jsonToken)
        {
            SpAppContext rv = null;
            string appCtxString = null;
            foreach (var item in jsonToken.Claims)
            {
                if (item.ClaimType == "appctx")
                    appCtxString = item.Value;
            }


            if ( string.IsNullOrEmpty(appCtxString) )
                return null;

            rv = JsonConvert.DeserializeObject<SpAppContext>(appCtxString);


            return rv;
            
        }
    }
}
