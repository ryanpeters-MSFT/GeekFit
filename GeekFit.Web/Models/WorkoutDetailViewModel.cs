using GeekFit.Models;
using System.Collections.Generic;

namespace GeekFit.Web.Models
{
    public class WorkoutDetailViewModel
    {
        public UserWorkout Current { get; set; }
        public IEnumerable<UserWorkout> Workouts { get; set; }
    }
}