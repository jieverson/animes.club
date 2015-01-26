using Animes.Club.DTOs;
using Animes.Club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.Service
{
    public static class UserService
    {

        public static User Create(RegisterDTO data)
        {
            var passwordHash = PasswordService.GetHash(data.password);
            var user = new User
            {
                username = data.username,
                email = data.email,
                password = passwordHash,
                picture = GravatarService.GetUrl(data.email)
            };
            return user;
        }

    }
}