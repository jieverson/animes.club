using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Animes.Club.Models
{
    public class AnimeInList
    {

        [Key, Column(Order = 0)]
        public long userId { get; set; }

        [Key, Column(Order = 1)]
        public long animeId { get; set; }

        [ForeignKey("userId")]
        public virtual User user { get; set; }

        [ForeignKey("animeId")]
        public virtual Anime anime { get; set; }

    }
}