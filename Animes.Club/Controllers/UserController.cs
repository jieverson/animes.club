using Animes.Club.DTOs;
using Animes.Club.Models;
using Animes.Club.Service;
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

        // GET: api/User/abc
        [Route("api/user/{username}")]
        public UserDTO Get(String username)
        {
            User user;
            using (var context = new AnimesClubContext())
            {
                user = context.Users.FirstOrDefault(x => x.username == username);
            }

            var result = new UserDTO
            {
                username = user.username,
                picture = user.picture
            };

            if (user.id != long.Parse(User.Identity.Name))
            {
                result.compatibility = CompatibilityService.Calc(long.Parse(User.Identity.Name), user.id);
            }

            return result;
        }

    }
}
