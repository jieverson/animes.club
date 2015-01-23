using Animes.Club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Animes.Club.Controllers
{
    public class AnimeController : ApiController
    {
        // GET: api/Anime
        public IEnumerable<Anime> Get()
        {
            using (var context = new Animes.Club.Models.AnimesClubContext())
            {
                return context.Animes.ToList();
            }
        }

        // GET: api/Anime?filter=abc
        public IEnumerable<Anime> Get(String q)
        {
            if (q.Length > 1)
            {
                using (var context = new Animes.Club.Models.AnimesClubContext())
                {
                    return context.Animes.Where(x => x.name.ToLower().Contains(q.ToLower())).ToList();
                }
            }
            return null;
        }

        //// GET: api/Anime/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Anime
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Anime/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Anime/5
        //public void Delete(int id)
        //{
        //}
    }
}
