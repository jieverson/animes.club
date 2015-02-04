using Animes.Club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.Service
{
    public static class CompatibilityService
    {

        public static float Calc(long myId, long friendId)
        {
            using (var context = new AnimesClubContext())
            {
                var animes = from anime in context.Animes
                             let me = context.Users.FirstOrDefault(u => u.id == myId)
                             let friend = context.Users.FirstOrDefault(u => u.id == friendId)
                             where me.animeList.Any(a => a.animeId == anime.id && a.rating.HasValue) &&
                                   friend.animeList.Any(a => a.animeId == anime.id && a.rating.HasValue)
                             select new
                             {
                                 anime = anime,
                                 myRating = me.animeList.FirstOrDefault(a => a.animeId == anime.id).rating.Value,
                                 friendRating = friend.animeList.FirstOrDefault(a => a.animeId == anime.id).rating.Value,
                             };

                var count = animes.Count();

                if (count == 0) return 0;

                var sum = (int)((10 - (animes.Sum(x => Math.Abs(x.myRating - x.friendRating)) / count)) * 10);

                return sum;
            }
        }

    }
}