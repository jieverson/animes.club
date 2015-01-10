using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Animes.Club.Models
{
    public class AnimesClubContext : IdentityDbContext<ApplicationUser>
    {
        public AnimesClubContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AnimesClubContext Create()
        {
            return new AnimesClubContext();
        }

        public DbSet<Anime> Animes { get; set; }

    }
}