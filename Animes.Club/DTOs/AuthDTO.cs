using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.DTOs
{
    public class AuthDTO
    {

        public string email { get; set; }

        public string password { get; set; }
        
        public bool remember { get; set; }

    }
}