using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Animes.Club.Models
{
    public class User
    {

        public long id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        public String username { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public String email { get; set; }

        [Required]
        public String password { get; set; }

        public String picture { get; set; }

        public virtual ICollection<Watching> watching { get; set; }

        public virtual ICollection<Completed> completed { get; set; }

        public virtual ICollection<Todo> todo { get; set; }

        public virtual ICollection<Dropped> dropped { get; set; }

    }
}