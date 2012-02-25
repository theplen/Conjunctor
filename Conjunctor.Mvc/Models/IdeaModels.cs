using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Conjunctor.Mvc.Models
{
    public class Idea
    {
        public int IdeaId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}