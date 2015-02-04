using Animes.Club.DTOs;
using Animes.Club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Animes.Club.Controllers
{
    public class PeopleController : ApiController
    {

        // GET: api/People (1 hour cache)
        [OutputCache(Duration = 60 * 60)]
        public IEnumerable<PeopleDTO> Get()
        {
            using (var context = new AnimesClubContext())
            {
                var people = context.Users.OrderByDescending(x => x.animeList.Count).Take(30).ToList();

                return people.Select(x => new PeopleDTO
                {
                    username = x.username,
                    picture = x.picture,
                    animes = x.animeList.Count
                }).ToList();
            }
        }

    }
}
