using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Animes.Club.Models
{
    public class AnimesClubContext : DbContext
    {
        public AnimesClubContext()
            : base("DefaultConnection")
        {
        }

        public static AnimesClubContext Create()
        {
            return new AnimesClubContext();
        }

        public DbSet<Anime> Animes { get; set; }

        public DbSet<User> Users { get; set; }

    }
}