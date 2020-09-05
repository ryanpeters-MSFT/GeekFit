using System;
using System.Collections.Generic;

namespace GeekFit.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserWorkout> Workouts { get; set; }
    }
}
