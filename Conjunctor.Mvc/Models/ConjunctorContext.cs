using System.Data.Entity;

namespace Conjunctor.Mvc.Models
{
    public class ConjunctorContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodAssignment> FoodAssignments { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttachment> MeetingAttachments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingAttachment>().Property(a => a.Hash).IsFixedLength().HasMaxLength(20);
        }
    }
}
