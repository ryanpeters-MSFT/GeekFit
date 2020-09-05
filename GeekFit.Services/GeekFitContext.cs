namespace GeekFit.Services
{
    using Models;
    using System.Data.Entity;

    public class GeekFitContext : DbContext
    {
        public GeekFitContext() : base("name=GeekFitContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<UserWorkout> UserWorkouts { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<UserWorkoutProperty> UserWorkoutProperties { get; set; }
    }
}