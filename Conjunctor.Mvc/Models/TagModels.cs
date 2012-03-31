using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Conjunctor.Mvc.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<Idea> Ideas { get; set; }
    }
}