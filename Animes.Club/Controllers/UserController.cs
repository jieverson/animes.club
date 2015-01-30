using Animes.Club.DTOs;
using Animes.Club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Animes.Club.Controllers
{
    public class UserController : ApiController
    {

        // GET: api/User/xereta
        public UserDTO Get(String username)
        {
            using (var context = new AnimesClubContext())
            {
                var user = context.Users.FirstOrDefault(x => x.username == username);

                var result = new UserDTO
                {
                    username = user.username,
                    picture = user.picture
                };

                return result;
            }
        }

    }
}
