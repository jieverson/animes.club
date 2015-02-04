using Animes.Club.DTOs;
using Animes.Club.Models;
using Animes.Club.Service;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Animes.Club.Controllers
{
    public class TrendingController : ApiController
    {

        // GET: api/Trending (6 hours cache)
        [OutputCache(Duration = 6 * 60 * 60)]
        public IEnumerable<AnimeDTO> Get()
        {
            using (var context = new AnimesClubContext())
            {
                var trending = context.Animes.OrderByDescending(a => context.Users.Count(u => u.animeList.Any(l => l.animeId == a.id))).Take(30).ToList();

                CloudBlobContainer container = BlobService.GetCoversContainer(false);
                DateTime expiryTime = DateTime.UtcNow.AddSeconds(30);

                return trending.Select(x => new AnimeDTO
                {
                    id = x.id,
                    name = x.name,
                    picture = BlobService.GetBlobSasUri(container, x.picture, expiryTime),
                    episodes = x.episodes,
                    rating = x.rating.GetValueOrDefault()
                }).ToList();
            }
        }

    }
}
