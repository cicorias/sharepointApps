//-----------------------------------------------------------------------
// <copyright file="SpAppAssertion.cs" company="CedarLogic">
//     Copyright (c) CedarLogic. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleProviderMvc.Models
{
    public class SpAppAssertion
    {
        //Body
        public string SPAppToken { get; set; }
        public string SPSiteUrl { get; set; }
        public string SPSiteTitle { get; set; }
        public string SPSiteLanguage { get; set; }
        public string SPSiteCulture { get; set; }
        public string SPRedirectMessage { get; set; }
        public string SPErrorCorrelationId { get; set; }
        public string SPErrorInfo { get; set; }

        //Url
        public string SPHostUrl { get; set; }
        public string SPLanguage { get; set; }
        public string SPClientTag { get; set; }
        public string SPProductNumber { get; set; }
    }
}
