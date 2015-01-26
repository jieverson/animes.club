using PasswordHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.Service
{
    public static class GravatarService
    {

        public static String GetUrl(String email)
        {
            return String.Format("http://www.gravatar.com/avatar/{0}?s=40&d=retro", CreateHash(email));
        }

        public static String CreateHash(String text)
        {
            return Encrypt.MD5(text.Trim().ToLower());
        }

    }
}