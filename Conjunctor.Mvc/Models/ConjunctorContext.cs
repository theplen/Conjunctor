using System.Data.Entity;

namespace Conjunctor.Mvc.Models
{
    public class ConjunctorContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodAssignment> FoodAssignments { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}
