using System;

namespace GeekFit.Models
{
    /// <summary>
    /// A relation between a user's workout and the associated properties
    /// </summary>
    public class UserWorkoutProperty
    {
        public Guid Id { get; set; }
        public UserWorkout UserWorkout { get; set; }
        public Property Property { get; set; }
        public Guid PropertyId { get; set; }
        public decimal? Value { get; set; }

        public string GetValue()
        {
            if (Value.HasValue)
            {
                return Value.Value.ToString("#.#");
            }

            return null;
        }
    }
}
