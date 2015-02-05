using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Animes.Club.Models
{
    public class Anime
    {

        public long id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(150)]
        public String name { get; set; }

        public String picture { get; set; }

        public String description { get; set; }

        public int? episodes { get; set; }

        public float? rating { get; set; }

        public virtual ICollection<AnimeTag> tags { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created { get; set; }

    }
}