using System;
using System.Collections.Generic;

namespace GeekFit.Models
{
    /// <summary>
    /// A workout (e.g., leg press, bench press)
    /// </summary>
    public class Workout
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public WorkoutType Type { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
