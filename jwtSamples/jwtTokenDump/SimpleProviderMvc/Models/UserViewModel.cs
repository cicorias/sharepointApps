using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleProviderMvc.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string SpId { get; set; }
        public string Email { get; set; }
    }
}