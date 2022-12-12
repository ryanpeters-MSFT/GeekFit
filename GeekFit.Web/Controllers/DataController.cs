using GeekFit.Models;
using GeekFit.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeekFit.Web.Controllers
{
    [RoutePrefix("data")]
    public class DataController : ControllerBase
    {
        private readonly WorkoutService workoutService;

        public DataController(WorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        [Route("workouts")]
        public IEnumerable<Workout> GetWorkouts()
        {
            return workoutService.GetWorkouts();
        }
    }
}
