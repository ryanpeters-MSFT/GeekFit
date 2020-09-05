using System;
using System.Collections.Generic;

namespace GeekFit.Models
{
    /// <summary>
    /// A quantitative characteristic of a workout (e.g., reps, sets, distance, time)
    /// </summary>
    public class Property
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Order { get; set; }
        public ICollection<Workout> Workouts { get; set; }
        public PropertyType Type { get; set; }

        public override string ToString()
        {
            if (!String.IsNullOrWhiteSpace(Unit))
            {
                return $"{Name} ({Unit})";
            }

            return Name;
        }
    }
}
