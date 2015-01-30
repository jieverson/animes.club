using Animes.Club.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.DTOs
{
    public class AnimeDTO
    {

        public long id { get; set; }

        public String name { get; set; }

        public String picture { get; set; }

        public String description { get; set; }

        public List<TagDTO> tags { get; set; }

        public float? rating { get; set; }

        public AnimeStatus status { get; set; }

    }
}