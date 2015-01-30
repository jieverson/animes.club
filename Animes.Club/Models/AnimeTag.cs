using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Animes.Club.Models
{
    public class AnimeTag
    {

        [Key, Column(Order = 0)]
        public long animeId { get; set; }

        [Key, Column(Order = 1)]
        public long tagId { get; set; }

        [ForeignKey("animeId")]
        public virtual Anime anime { get; set; }

        [ForeignKey("tagId")]
        public virtual Tag tag { get; set; }

    }
}