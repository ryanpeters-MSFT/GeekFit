using System;
using System.Collections.Generic;

namespace GeekFit.Models
{
    /// <summary>
    /// A relation between a user and their workout
    /// </summary>
    public class UserWorkout
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Workout Workout { get; set; }
        public Guid WorkoutId { get; set; }
        public ICollection<UserWorkoutProperty> Properties { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
