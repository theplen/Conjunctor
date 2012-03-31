using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Conjunctor.Mvc.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        public Idea Theme { get; set; }
        public ICollection<FoodAssignment> FoodAssignments { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<MeetingAttachment> MeetingAttachments { get; set; }
    }

    public class MeetingAttachment
    {
        public int MeetingAttachmentId { get; set; }

        [Required]
        public byte[] Hash { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(255)]
        [Required]
        public string FileName { get; set; }


        [MaxLength(150)]
        [Required]
        public string ContentType { get; set; }

        [Required]
        public byte[] Contents { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}