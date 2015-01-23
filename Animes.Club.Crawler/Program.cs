using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Animes.Club.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {

            using (WebClient Client = new WebClient())
            {

                using (var context = new Entities())
                {
                    foreach (var anime in context.Animes)
                    {
                        if (!String.IsNullOrEmpty(anime.picture))
                        {
                            Client.DownloadFile("http://img7.anidb.net/pics/anime/" + anime.picture, "./covers/" + anime.picture);
                        }
                    }
                }

            }


        }
    }
}
