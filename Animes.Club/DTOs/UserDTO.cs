using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.DTOs
{
    public class UserDTO
    {

        public long id { get; set; }

        public String username { get; set; }

        public String email { get; set; }

        public String picture { get; set; }

    }
}