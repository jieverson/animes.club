﻿using Animes.Club.DTOs;
using Animes.Club.Models;
using Animes.Club.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Animes.Club.Controllers
{
    public class LoginController : ApiController
    {

        public LoginSuccessDTO Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var context = new AnimesClubContext())
                {
                    var user = context.Users.Find(long.Parse(User.Identity.Name));

                    return new LoginSuccessDTO
                    {
                        sessionId = user.id,
                        user = new UserDTO
                        {
                            id = user.id,
                            username = user.username,
                            email = user.email,
                            picture = user.picture
                        }
                    };
                }
            }
            else
            {
                return null;
            }
        }

        public LoginSuccessDTO Post(AuthDTO data)
        {
            using (var context = new AnimesClubContext())
            {
                var passwordHash = PasswordService.GetHash(data.password);
                var user = context.Users.FirstOrDefault(x => x.email == data.email && x.password == passwordHash);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.id.ToString(), data.remember);

                    return new LoginSuccessDTO
                    {
                        sessionId = user.id,
                        user = new UserDTO
                        {
                            id = user.id,
                            username = user.username,
                            email = user.email,
                            picture = user.picture
                        }
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public void Delete()
        {
            FormsAuthentication.SignOut();
        }

    }
}
