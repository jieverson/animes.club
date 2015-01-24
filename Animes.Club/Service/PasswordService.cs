using PasswordHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Animes.Club.Service
{
    public static class PasswordService
    {

        private const String SALT = "´@.com/\\a1!}";

        public static String GetHash(String password)
        {
            return Encrypt.MD5(AddSalt(password));
        }

        private static String AddSalt(String password)
        {
            return password + SALT;
        }

    }
}