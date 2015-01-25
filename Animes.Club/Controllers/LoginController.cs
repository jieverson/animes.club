using Animes.Club.DTOs;
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

        public bool Get()
        {
            var a = FormsAuthentication.FormsCookieName;
            var b = RequestContext.Principal.Identity.Name;
            var c = RequestContext.Principal.Identity.IsAuthenticated;
            var d = User.Identity.Name;
            var e = User.Identity.IsAuthenticated;
            var f = HttpContext.Current.User.Identity.Name;

            FormsAuthentication.SetAuthCookie("oi", true);
            
            return this.User.Identity.IsAuthenticated;
        }

        public LoginSuccessDTO Post(AuthDTO data)
        {
            using (var context = new AnimesClubContext())
            {
                var passwordHash = PasswordService.GetHash(data.password);
                var user = context.Users.FirstOrDefault(x => x.email == data.email && x.password == passwordHash);
                if (user != null)
                {
                    if (data.remember)
                    {
                        HttpContext.Current.Response.Cookies.Clear();
                        DateTime expiryDate = DateTime.Now.AddDays(30);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.id.ToString(), DateTime.Now, expiryDate, true, String.Empty);
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        authenticationCookie.Expires = ticket.Expiration;
                        HttpContext.Current.Response.Cookies.Add(authenticationCookie);
                    }

                    FormsAuthentication.SetAuthCookie(user.username, data.remember);

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

    }
}
