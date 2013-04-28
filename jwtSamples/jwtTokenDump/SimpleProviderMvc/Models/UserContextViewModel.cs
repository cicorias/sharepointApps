//-----------------------------------------------------------------------
// <copyright file="UserContextViewModel.cs" company="CedarLogic">
//     Copyright (c) CedarLogic. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.IdentityModel.S2S.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleProviderMvc.Models
{
    public class UserContextViewModel
    {
        public string JsonTokenString { get; set; }
        public UserContext UserContext { get; set; }
        public JsonWebSecurityToken JsonToken { get; set; }

    }
}
