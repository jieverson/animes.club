using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Animes.Club.Crawler
{
    public static class AnidbCoversCrawler
    {

        public static void Do()
        {
            using (WebClient client = new WebClient())
            {

                using (var context = new Entities())
                {
                    foreach (var anime in context.Animes)
                    {
                        if (!String.IsNullOrEmpty(anime.picture))
                        {
                            client.DownloadFile("http://img7.anidb.net/pics/anime/" + anime.picture, "./covers/" + anime.picture);
                        }
                    }
                }

            }
        }

    }
}
