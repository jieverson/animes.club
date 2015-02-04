using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Animes.Club.Crawler
{
    public static class MyAnimeListCrawler
    {

        public static void Do()
        {
            //HtmlDocument doc = new HtmlDocument();

            //var animes = new List<MyAnimeList>();

            //var count = 0;

            //for (int i = 0; i < int.MaxValue; i += 30)
            //{
            //    try
            //    {
            //        var url = "http://myanimelist.net/topanime.php?type=&limit=" + i;
            //        var webRequest = HttpWebRequest.Create(url);
            //        var stream = webRequest.GetResponse().GetResponseStream();
            //        doc.Load(stream);

            //        var tr = doc.DocumentNode.SelectNodes("//tr").First();
            //        var img = tr.SelectNodes("//img");
            //        var titles = tr.SelectNodes("//strong");
            //        var links = tr.SelectNodes("//a[@class='hoverinfo_trigger']");

            //        for (int j = 0; j < 30; j++)
            //        {
            //            count++;

            //            var href = links.ElementAt(j * 2).Attributes["href"].Value;
            //            var picture_utl = img.ElementAt(j).Attributes["src"].Value;
            //            var fileName = picture_utl.Split('/').Last();

            //            var anime = new MyAnimeList
            //            {
            //                Id = int.Parse(href.Split('/')[2]),
            //                Name = titles.ElementAt(j).InnerText,
            //                SmallPicture = picture_utl,
            //                BigPicture = picture_utl.Replace("t.jpg", ".jpg"),

            //            };

            //            if (fileName != "qm_50.gif")
            //            {
            //                anime.PictureId = int.Parse(fileName.Split('t').First());
            //            }
            //            else
            //            {
            //                anime.PictureId = 0;
            //            }

            //            animes.Add(anime);
            //        }

            //        stream.Close();

            //        Console.WriteLine("Page " + i);
            //    }
            //    catch
            //    {
            //        break;
            //    }
            //}

            //using (var context = new Entities())
            //{
            //    context.MyAnimeList.AddRange(animes);

            //    context.SaveChanges();
            //}

            //using (var context = new Entities())
            //{
            //    var animes = context.MyAnimeList.OrderBy(x => x.Id).ToList();

            //    using (WebClient client = new WebClient())
            //    {
            //        //9018
            //        for (int i = 0; i < animes.Count; i++)
            //        {
            //            var anime = animes[i];
            //            client.DownloadFile(anime.BigPicture, "./bigCovers/" + anime.PictureId + ".jpg");
            //            client.DownloadFile(anime.SmallPicture, "./smallCovers/" + anime.PictureId + ".jpg");
            //        }
            //    }
            //}

            //HtmlDocument doc = new HtmlDocument();
            //using (var context = new Entities())
            //{
            //    foreach(var anime in context.MyAnimeList){
            //        var url = "http://myanimelist.net/anime/" + anime.Id;
            //        var webRequest = HttpWebRequest.Create(url);
            //        var stream = webRequest.GetResponse().GetResponseStream();
            //        doc.Load(stream);
            //        var code = doc.DocumentNode.InnerHtml.Split(new String[] { "<h2>Synopsis</h2>" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new String[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("<br>", "");
            //        var paragrafos = code.Split('\n');
            //        String desc = String.Empty;
            //        for (int i = 0; i < paragrafos.Count() - 1; i++)
            //        {
            //            var t = paragrafos[i];
            //            if (!String.IsNullOrEmpty(t))
            //            {
            //                desc += "\n" + t;
            //            }
            //        }
            //        if (paragrafos.Count() == 1)
            //        {
            //            desc = paragrafos.First();
            //        }
            //        desc = desc.Trim();
            //        anime.Description = desc;
            //    }
            //    context.SaveChanges();
            //}

            //HtmlDocument doc = new HtmlDocument();
            //using (var context = new Entities())
            //{
            //    var myanimelist = context.MyAnimeList.ToList();
            //    var count = myanimelist.Count();

            //    var animes = new List<Animes>();
            //    var tags = new List<Tags>();

            //    for(int i = 0; i < count; i++)
            //    {
            //        if(i % 50 == 0)
            //            Console.WriteLine(i);

            //        var anime = myanimelist[i];

            //        var url = "http://myanimelist.net/anime/" + anime.Id;
            //        var webRequest = HttpWebRequest.Create(url);
            //        var stream = webRequest.GetResponse().GetResponseStream();
            //        doc.Load(stream);

            //        int episodes;
            //        bool hasEps = int.TryParse(doc.DocumentNode.SelectNodes("//div[@class='spaceit']").First().InnerText.Split(' ')[1].Trim(), out episodes);

            //        var a = new Animes
            //        {
            //            name = anime.Name,
            //            description = anime.Description,
            //            episodes = hasEps ? new Nullable<int>(episodes) : null,
            //            picture = anime.PictureId + ".jpg"
            //        };

            //        try
            //        {
            //            var animeTags = doc.DocumentNode.SelectNodes("//div[@class='spaceit'][3]//a").Select(x => x.InnerText);

            //            foreach (var tag in animeTags)
            //            {
            //                if (!tags.Any(x => x.value == tag))
            //                {
            //                    tags.Add(new Tags { value = tag });
            //                }
            //                var t = tags.First(x => x.value == tag);
            //                a.Tags.Add(t);
            //            }
            //        }
            //        catch
            //        {

            //        }

            //        animes.Add(a);
            //    }

            //    context.Tags.AddRange(tags);
            //    context.Animes.AddRange(animes);

            //    int asd = 1 + 1;

            //    context.SaveChanges();
            //}

            //using (var context = new Entities())
            //{
            //    var animes = context.Animes.ToList();
            //    foreach (var anime in animes)
            //    {
            //        anime.name = anime.name.Trim();
            //    }

            //    context.SaveChanges();
            //}
        }

    }
}
