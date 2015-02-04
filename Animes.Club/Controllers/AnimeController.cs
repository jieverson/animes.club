using Animes.Club.DTOs;
using Animes.Club.Enum;
using Animes.Club.Models;
using Animes.Club.Service;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
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

        // GET: api/Anime/5
        public AnimeDTO Get(long id)
        {
            using (var context = new AnimesClubContext())
            {
                var anime = context.Animes.Find(id);

                CloudBlobContainer container = BlobService.GetCoversContainer(false);
                DateTime expiryTime = DateTime.UtcNow.AddSeconds(30);
                String coverSasUri = BlobService.GetBlobSasUri(container, anime.picture, expiryTime);
                var tags = anime.tags.Select(x => new TagDTO { value = x.tag.value, color = x.tag.color }).ToList();

                var result = new AnimeDTO
                {
                    id = anime.id,
                    name = anime.name,
                    description = anime.description,
                    picture = coverSasUri,
                    tags = tags
                };

                if (User.Identity.IsAuthenticated)
                {
                    var user = context.Users.Find(long.Parse(User.Identity.Name));

                    var review = user.animeList.FirstOrDefault(x => x.animeId == anime.id);
                    if (review != null)
                    {
                        result.status = review.status;
                        result.rating = review.rating;
                    }
                }

                return result;
            }
        }

    }
}
