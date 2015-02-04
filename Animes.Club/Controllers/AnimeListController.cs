using Animes.Club.DTOs;
using Animes.Club.Enum;
using Animes.Club.Models;
using Animes.Club.Service;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Animes.Club.Controllers
{
    public class AnimeListController : ApiController
    {

        // GET: api/AnimeList/watching
        public IEnumerable<AnimeDTO> Get(AnimeStatus status)
        {
            using (var context = new AnimesClubContext())
            {
                var user = context.Users.Find(long.Parse(User.Identity.Name));
                
                var list = user.animeList.Where(x => x.status == status);
                
                CloudBlobContainer container = BlobService.GetCoversContainer(false);
                DateTime expiryTime = DateTime.UtcNow.AddSeconds(30);
                
                return list.Select(x => new AnimeDTO
                {
                    id = x.animeId,
                    name = x.anime.name,
                    picture = BlobService.GetBlobSasUri(container, x.anime.picture, expiryTime),
                    episodes = x.anime.episodes,
                    rating = x.rating.HasValue ? x.rating.Value : x.anime.rating.GetValueOrDefault()
                }).ToList();
            }
        }

        // POST: api/AnimeList
        public void Post(AnimeDTO data)
        {
            using (var context = new AnimesClubContext())
            {
                var user = context.Users.Find(long.Parse(User.Identity.Name));
                var anime = context.Animes.Find(data.id);

                user.animeList.Remove(user.animeList.FirstOrDefault(x => x.animeId == anime.id));
                user.animeList.Add(new AnimeList { anime = anime, status = data.status, rating = data.rating });
                
                context.SaveChanges();
            }
        }

    }
}
