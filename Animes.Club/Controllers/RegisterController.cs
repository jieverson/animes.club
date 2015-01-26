using Animes.Club.DTOs;
using Animes.Club.Models;
using Animes.Club.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;

namespace Animes.Club.Controllers
{
    public class RegisterController : ApiController
    {

        public async Task<LoginSuccessDTO> Post(RegisterDTO data)
        {
            if (await CaptchaService.Check(data.captchaResponse))
            {
                using (var context = new AnimesClubContext())
                {
                    var user = UserService.Create(data);
                    context.Users.Add(user);
                    context.SaveChanges();

                    FormsAuthentication.SetAuthCookie(user.id.ToString(), false);

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
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
