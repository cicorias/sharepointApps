//-----------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="ABC">
//     Copyright (c) ABC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

//-----------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="ABC">
//     Copyright (c) ABC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.IdentityModel.S2S.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleProviderWeb.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The following code gets the client context and Title property by using TokenHelper.
            // To access other properties, you may need to request permissions on the host web.

            var contextToken = TokenHelper.GetContextTokenFromRequest(Page.Request);
            var hostWeb = Page.Request["SPHostUrl"];

            txtToken.Text = contextToken;

            GetParts(contextToken);

            var jsonToken = GetJsonToken(contextToken);

            using (var clientContext = TokenHelper.GetClientContextWithContextToken(hostWeb, contextToken, Request.Url.Authority))
            {
                clientContext.Load(clientContext.Web, web => web.Title);
                clientContext.ExecuteQuery();
                Response.Write(clientContext.Web.Title);
            }
        }

        private static void GetParts(string contextToken)
        {
            string[] parts = contextToken.Split('.');

            List<TokenParts> partsList = new List<TokenParts>();
            foreach (var part in parts)
            {
                var decoded = part.FromBase64String();
                partsList.Add(new TokenParts { Name = "one", Encoded = part, Decoded = decoded });
            }
        }


        JsonWebSecurityToken GetJsonToken(string contextToken)
        {
            JsonWebSecurityTokenHandler tokenHandler = TokenHelper.CreateJsonWebSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.ReadToken(contextToken);
            JsonWebSecurityToken jsonToken = securityToken as JsonWebSecurityToken;
            return jsonToken;
        }
    }

    public static class StringHelpers
    {
        public static string FromBase64String(this string value)
        {
            try
            {
                return Convert.FromBase64String(value).BytesToString();
            }
            catch
            {
                return value;
            }
        }

        public static string BytesToString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }

    public class TokenParts
    {
        public string Name { get; set; }
        public string Encoded { get; set; }
        public string Decoded { get; set; }
    }
}
