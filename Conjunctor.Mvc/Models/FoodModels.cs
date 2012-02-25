using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Conjunctor.Mvc.Models
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        public ICollection<FoodAssignment> FoodAssignments { get; set; }
    }

    public class FoodAssignment
    {
        public int FoodAssignmentId { get; set; }

        [Required]
        public int MeetingId { get; set; }

        [Required]
        public int FoodItemId { get; set; }

        [MaxLength(50)]
        public string SnaggedBy { get; set; }

        public Meeting Meeting { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}