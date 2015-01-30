using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animes.Club.Crawler
{
    public static class AnidbTableTagParser
    {

        public static void Do()
        {
            using (var context = new Entities())
            {
                var database = context.anidb.ToList();
                var animes = context.Animes.ToList();
                var tags = context.Tags.ToList();

                for (int i = 0; i < database.Count; i++)
                {
                    Console.WriteLine(i + "from " + database.Count);

                    var anidb = database[i];
                    var anime = animes.FirstOrDefault(x => x.name == anidb.title);
                    if (anime != null)
                    {
                        var categories = anidb.categories.Split('|');

                        foreach (var category in categories)
                        {
                            Tags tag = tags.FirstOrDefault(x => x.value == category);
                            if (tag != null)
                            {
                                anime.Tags.Add(tag);
                            }
                        }
                    }
                }

                context.SaveChanges();
            }
        }

    }
}
