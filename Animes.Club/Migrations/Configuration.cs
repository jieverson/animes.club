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
            //context.Tags.AddOrUpdate(
            //    t => t.value, 
            //    new Tag { value = "Action", color = "#d9534f" },
            //    new Tag { value = "Comedy", color = "#f0ad4e" },
            //    new Tag { value = "Romance", color = "#e53c37" },
            //    );
        }
    }
}
