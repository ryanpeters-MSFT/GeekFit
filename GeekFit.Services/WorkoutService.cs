using GeekFit.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace GeekFit.Services
{
    public class WorkoutService : IDisposable
    {
        private readonly GeekFitContext _context;

        public WorkoutService(GeekFitContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsers()
        {
            return _context.Users
                .Include("Workouts.Workout")
                .Include("Workouts.Properties.Property");
        }

        public IQueryable<Workout> GetWorkouts()
        {
            return _context.Workouts;
        }

        public Workout GetWorkout(Guid workoutId)
        {
            return _context.Workouts
                .Include(w => w.Properties)
                .FirstOrDefault(w => w.Id == workoutId);
        }

        //public IQueryable<Property> GetWorkoutProperties(Guid workoutId)
        //{
        //    return _context.Properties.Where(p => p.Workouts.Any(w => w.ID == workoutId));
        //}

        public IQueryable<UserWorkout> GetWorkouts(Guid userId)
        {
            return _context.UserWorkouts
                .Include(w => w.Workout)
                .Include("Properties.Property")
                .Where(w => w.User.Id == userId);
        }

        public UserWorkout GetUserWorkout(Guid userWorkoutId)
        {
            return _context.UserWorkouts
                .Include(w => w.Workout)
                .Include("Properties.Property")
                .FirstOrDefault(w => w.Id == userWorkoutId);
        }

        //public IQueryable<UserWorkout> GetSimilarUserWorkouts(Guid userWorkoutId)
        //{
        //    var workouts = from uw1 in _context.UserWorkouts
        //                   join uw2 in _context.UserWorkouts on new { uw1.WorkoutID, uw1.UserID } equals new { uw2.WorkoutID, uw2.UserID }
        //                   where uw1.ID == userWorkoutId
        //                   select uw2;

        //    return workouts
        //        .Include(w => w.Workout)
        //        .Include("Properties.Property");
        //}

        public UserWorkout AddWorkout(UserWorkout workout)
        {
            _context.UserWorkouts.Add(workout);
            _context.SaveChanges();

            return workout;
        }

        public UserWorkout SaveWorkout(UserWorkout workout)
        {
            _context.SaveChanges();

            return workout;
        }

        public void DeleteUserWorkout(Guid userWorkoutId)
        {
            var userWorkout = _context.UserWorkouts
                .Include(w => w.Properties)
                .FirstOrDefault(u => u.Id == userWorkoutId);

            _context.UserWorkouts.Remove(userWorkout);

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
