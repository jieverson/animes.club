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

        public IEnumerable<AnimeDTO> Get(AnimeStatus status)
        {
            using (var context = new AnimesClubContext())
            {
                var user = context.Users.Find(long.Parse(User.Identity.Name));
                
                IEnumerable<AnimeInList> list = null;
                switch (status)
                {
                    case AnimeStatus.Watching:
                        list = user.watching;
                        break;
                    case AnimeStatus.Completed:
                        list = user.completed;
                        break;
                    case AnimeStatus.Todo:
                        list = user.todo;
                        break;
                    case AnimeStatus.Dropped:
                        list = user.dropped;
                        break;
                    default:
                        break;
                }

                CloudBlobContainer container = BlobService.GetCoversContainer();
                DateTime expiryTime = DateTime.UtcNow.AddSeconds(30);
                
                return list.Select(x => new AnimeDTO
                {
                    id = x.animeId,
                    name = x.anime.name,
                    picture = BlobService.GetBlobSasUri(container, x.anime.picture, expiryTime),
                    rating = x.anime.rating
                }).ToList();
            }
        }

        public void Post(AnimeDTO data)
        {
            using (var context = new AnimesClubContext())
            {
                var user = context.Users.Find(long.Parse(User.Identity.Name));
                var anime = context.Animes.Find(data.id);

                user.watching.Remove(user.watching.FirstOrDefault(x => x.animeId == anime.id));
                user.completed.Remove(user.completed.FirstOrDefault(x => x.animeId == anime.id));
                user.todo.Remove(user.todo.FirstOrDefault(x => x.animeId == anime.id));
                user.dropped.Remove(user.dropped.FirstOrDefault(x => x.animeId == anime.id));

                switch (data.status)
                {
                    case AnimeStatus.Watching:
                        user.watching.Add(new Watching{ anime = anime });
                        break;
                    case AnimeStatus.Completed:
                        user.completed.Add(new Completed{ anime = anime });
                        break;
                    case AnimeStatus.Todo:
                        user.todo.Add(new Todo{ anime = anime });
                        break;
                    case AnimeStatus.Dropped:
                        user.dropped.Add(new Dropped{ anime = anime });
                        break;
                    default:
                        break;
                }

                context.SaveChanges();
            }
        }

    }
}
