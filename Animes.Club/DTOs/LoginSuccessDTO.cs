﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.DTOs
{
    public class LoginSuccessDTO
    {

        public long sessionId { get; set; }

        public UserDTO user { get; set; }

        public String message { get; set; }

    }
}