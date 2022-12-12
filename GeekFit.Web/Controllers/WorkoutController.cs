using GeekFit.Models;
using GeekFit.Services;
using GeekFit.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekFit.Web.Controllers
{
    [RoutePrefix("{userId}")]
    public class WorkoutController : BaseController
    {
        private readonly WorkoutService workoutService;

        public WorkoutController(WorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        [Route]
        public ActionResult List(Guid userId)
        {
            var minDate = DateTime.Now.AddDays(-28);

            var workouts = workoutService.GetWorkouts(userId)
                .Where(w => w.Date >= minDate)
                .ToList();

            return View(workouts);
        }

        [Route("select")]
        public ActionResult Select(Guid userId)
        {
            var workouts = workoutService.GetWorkouts();

            return View(workouts);
        }

        [Route("view/{workoutId}")]
        public ActionResult View(Guid userId, Guid workoutId)
        {
            var workouts = workoutService.GetWorkouts(userId)
                .Where(w => w.WorkoutId == workoutId)
                .OrderByDescending(w => w.Date)
                .Take(20)
                .ToList();

            return View(workouts);
        }

        #region Add

        [Route("add/{workoutId}")]
        public ActionResult Add(Guid userId, Guid workoutId)
        {
            // pre-fill with the previous workout
            var lastWorkout = workoutService.GetWorkouts(userId)
                .Where(w => w.WorkoutId == workoutId)
                .OrderByDescending(w => w.Date)
                .FirstOrDefault();

            var workout = workoutService.GetWorkout(workoutId);

            // if no previous workouts, make empty list of properties
            // otherwise retrieve previous workout
            if (lastWorkout == null)
            {
                lastWorkout = new UserWorkout
                {
                    Workout = workout,
                    Properties = workout.Properties.Select(p => new UserWorkoutProperty
                    {
                        Property = p,
                    })
                    .ToList()
                };
            }
            else
            {
                // retrieve previous workout but apply any newly-created properties
                // (this process may be temporary)
                lastWorkout.Properties = workout.Properties
                    .Select(p =>
                    {
                        var userWorkoutProperty = lastWorkout.Properties
                            .FirstOrDefault(u => u.PropertyId == p.Id);

                        if (userWorkoutProperty != null)
                        {
                            return userWorkoutProperty;
                        }

                        return new UserWorkoutProperty
                        {
                            Property = p,
                            PropertyId = p.Id,
                            UserWorkout = lastWorkout
                        };
                    })
                    .ToList();
            }

            return View(lastWorkout);
        }

        [HttpPost]
        [Route("add/{workoutId}")]
        public ActionResult Add(Guid userId, Guid workoutId, IEnumerable<PropertyViewModel> properties, string comment)
        {
            var userWorkout = new UserWorkout()
            {
                Id = Guid.NewGuid(),
                WorkoutId = workoutId,
                UserId = userId,
                Comment = comment,
                Date = DateTime.Now,
            };

            userWorkout.Properties = properties
                .Select(w => new UserWorkoutProperty
                {
                    Id = Guid.NewGuid(),
                    UserWorkout = userWorkout,
                    PropertyId = w.ID,
                    Value = w.Value
                })
                .ToList();

            workoutService.AddWorkout(userWorkout);

            return RedirectToList();
        } 

        #endregion

        #region Edit

        [Route("edit/{userWorkoutId}")]
        public ActionResult Edit(Guid userWorkoutId)
        {
            var userWorkout = workoutService.GetUserWorkout(userWorkoutId);

            return View(userWorkout);
        }

        [Route("edit/{userWorkoutId}")]
        [HttpPost]
        public ActionResult Edit(Guid userWorkoutId, IEnumerable<PropertyViewModel> properties, string comment, DateTime date)
        {
            var userWorkout = workoutService.GetUserWorkout(userWorkoutId);

            userWorkout.Comment = comment;
            userWorkout.Date = date;

            userWorkout.Properties
                .Join(properties, w => w.Id, p => p.ID, (w, p) => new { w, p })
                .ToList()
                .ForEach(g => g.w.Value = g.p.Value);

            workoutService.SaveWorkout(userWorkout);

            return RedirectToList();
        }

        #endregion

        #region Delete

        [Route("delete/{userWorkoutId}")]
        public ActionResult Delete(Guid userWorkoutId)
        {
            workoutService.DeleteUserWorkout(userWorkoutId);

            return RedirectToList();
        } 

        #endregion
    }
}