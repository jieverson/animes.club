using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Animes.Club.Models
{
    public class Tag
    {

        public long id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public String value { get; set; }

        public String color { get; set; }

    }
}