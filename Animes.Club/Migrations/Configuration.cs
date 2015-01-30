namespace Animes.Club.Migrations
{
    using Animes.Club.Models;
    using Animes.Club.Service;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnimesClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AnimesClubContext context)
        {
            context.Users.AddOrUpdate(
                a => a.username,
                new User { username = "xereta", password = PasswordService.GetHash("info3000"), email = "contact@jieverson.com", picture = "http://www.gravatar.com/avatar/ee546078aeaec763c07a40d45f5465bf?s=40&d=retro" }
                );

            context.Tags.AddOrUpdate(
                t => t.value, 
                new Tag { value = "Action", color = "#d9534f" },
                new Tag { value = "Comedy", color = "#f0ad4e" },
                new Tag { value = "Romance", color = "#e53c37" },
                new Tag { value = "Sci-Fi", color = "#337ab7" },
                new Tag { value = "Fantasy", color = "#337ab7" },
                new Tag { value = "Violence", color = "#511c39" },
                new Tag { value = "Seinen", color = "#777777" },
                new Tag { value = "School Life", color = "#5cb85c" },
                new Tag { value = "Sex", color = "#000000" },
                new Tag { value = "Shounen", color = "#264c73" },
                new Tag { value = "Ecchi", color = "#eb6864" },
                new Tag { value = "Mecha", color = "#4f5151" },
                new Tag { value = "Game", color = "#d62c1a" },
                new Tag { value = "Super Power", color = "#e72510" },
                new Tag { value = "Manga", color = "#777777" },
                new Tag { value = "Future", color = "#777777" },
                new Tag { value = "Magic", color = "#5bc0de" },
                new Tag { value = "Past", color = "#777777" },
                new Tag { value = "High School", color = "#5cb85c" },
                new Tag { value = "Novel", color = "#777777" },
                new Tag { value = "Parody", color = "#f57a00" },
                new Tag { value = "Rape", color = "#777777" },
                new Tag { value = "Shoujo", color = "#9b479f" },
                new Tag { value = "Sports", color = "#022241" },
                new Tag { value = "Harem", color = "#9b479f" },
                new Tag { value = "Yuri", color = "#5bc0de" },
                new Tag { value = "Music", color = "#62c462" },
                new Tag { value = "Incest", color = "#777777" },
                new Tag { value = "Yaoi", color = "#e9322d" }
                );

            //context.Animes.AddOrUpdate(
            //    a => a.name,
            //    new Anime { name = "Fairy Tail", picture = "http://cdn.myanimelist.net/images/anime/5/18179.jpg" },
            //    new Anime { name = "Elfen Lied", picture = "http://cdn.myanimelist.net/images/anime/10/6883.jpg" },
            //    new Anime { name = "Higurashi no Naku Koro ni", picture = "http://cdn.myanimelist.net/images/anime/12/19634.jpg" },
            //    new Anime { name = "Kiss x Sis", picture = "http://cdn.myanimelist.net/images/anime/3/25518.jpg" },
            //    new Anime { name = "Death Note", picture = "http://cdn.myanimelist.net/images/anime/9/9453.jpg" },
            //    new Anime { name = "Sword Art Online", picture = "http://cdn.myanimelist.net/images/anime/11/39717.jpg" },
            //    new Anime { name = "Magi: The Kingdom of Magic", picture = "http://cdn.myanimelist.net/images/anime/13/55039.jpg" },
            //    new Anime { name = "Steins;Gate", picture = "http://cdn.myanimelist.net/images/anime/11/41011.jpg" },
            //    new Anime { name = "Fullmetal Alchemist", picture = "http://cdn.myanimelist.net/images/anime/2/17621.jpg" },
            //    new Anime { name = "Soul Eater", picture = "http://cdn.myanimelist.net/images/anime/9/7804.jpg" },
            //    new Anime { name = "Jigoku Shoujo", picture = "http://cdn.myanimelist.net/images/anime/5/67987.jpg" }
            //    );
        }
    }
}
