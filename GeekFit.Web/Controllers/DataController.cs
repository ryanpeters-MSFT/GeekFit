using GeekFit.Models;
using GeekFit.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace GeekFit.Web.Controllers
{
    [RoutePrefix("data")]
    public class DataController : ApiController
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
