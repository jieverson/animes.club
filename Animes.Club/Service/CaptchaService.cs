using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Animes.Club.Service
{
    public static class CaptchaService
    {
        private const String SECRET_KEY = "6LfS_QATAAAAAOKUFr1btV9CP4HHw-RzJMEdjkPt";

        public static async Task<bool> Check(String response)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(String.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", SECRET_KEY, response));
                return result.StatusCode == HttpStatusCode.OK;
            }
        }
    }
}