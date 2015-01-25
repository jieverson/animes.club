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
