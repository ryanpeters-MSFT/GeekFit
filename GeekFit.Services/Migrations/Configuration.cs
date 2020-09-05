namespace GeekFit.Services.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GeekFitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GeekFitContext context)
        {
            var properties = new[]
            {
                new Property
                {
                    Id = new Guid("32dadc3b-4b4f-467f-9fe9-def3aef0fe53"),
                    Name = "Running",
                    Unit = "minutes",
                    Order = 4,
                    Workouts = new List<Workout>()
                },
                new Property
                {
                    Id = new Guid("ccdba176-cc35-4418-8612-0ddc8d5957c8"),
                    Name = "Walking",
                    Unit = "minutes",
                    Order = 2,
                    Workouts = new List<Workout>()
                },
                new Property
                {
                    Id = new Guid("a58a9261-9293-4313-a2bb-c3800f4f6033"),
                    Name = "Jogging",
                    Unit = "minutes",
                    Order = 3,
                    Workouts = new List<Workout>()
                },
                new Property
                {
                    Id = new Guid("7d802e07-f497-427b-aca5-95e264384c35"),
                    Order = 1,
                    Name = "Total Time",
                    Unit = "minutes",
                    Workouts = new List<Workout>()
                },
                new Property
                {
                    Id = new Guid("21577d7d-cf75-4b4f-a7e0-57248b7a85f2"),
                    Order = 10,
                    Name = "Reps",
                    Workouts = new List<Workout>()
                },
                new Property
                {
                    Id = new Guid("f45b50a2-2a59-414f-87ad-cb200c6fe0ae"),
                    Order = 20,
                    Name = "Sets",
                    Workouts = new List<Workout>()
                }
            };

            var workouts = new[]
            {
                new Workout
                {
                    Id = new Guid("df93876e-ec52-4474-aa76-e2fb6fedd424"),
                    Name = "Treadmill",
                    Properties = new[]
                    {
                        properties[0],
                        properties[1],
                        properties[2],
                        properties[3]
                    }
                },
                new Workout
                {
                    Id = new Guid("948c5dc4-1a2e-4194-afb7-aac592f55403"),
                    Name = "Chest Press",
                    Properties = new[]
                    {
                        properties[4],
                        properties[5]
                    }
                }
            };

            //properties[0].Workouts.Add(workouts[0]);
            //properties[1].Workouts.Add(workouts[0]);
            //properties[2].Workouts.Add(workouts[0]);
            //properties[3].Workouts.Add(workouts[0]);
            //properties[4].Workouts.Add(workouts[1]);
            //properties[5].Workouts.Add(workouts[1]);

            //context.Properties.AddOrUpdate(properties);
            context.Workouts.AddOrUpdate(workouts);

            context.Users.AddOrUpdate(
                new User
                {
                    Id = new Guid("6c89b8e4-9b45-4d5b-8953-816e1bb31c0b"),
                    Name = "Ryan",
                    Workouts = new[]
                    {
                        new UserWorkout
                        {
                            Id = new Guid("6a5653f3-8d1f-447c-ad45-23e5bdf57110"),
                            Workout = workouts[0],
                            Date = DateTime.Now,
                            Properties = new[]
                            {
                                new UserWorkoutProperty
                                {
                                    Id = new Guid("4c43b665-638b-4367-bcca-cc4d983f3c81"),
                                    Property = properties[0],
                                    Value = 5
                                }
                            }
                        },
                        new UserWorkout
                        {
                            Id = new Guid("56df00e0-96b0-49e2-82d6-323623a7e8b5"),
                            Workout = workouts[1],
                            Date = DateTime.Now,
                            Properties = new[]
                            {
                                new UserWorkoutProperty
                                {
                                    Id = new Guid("aecb29aa-581e-4f9c-8413-6be9f5e1a48c"),
                                    Property = properties[4],
                                    Value = 10
                                },
                                new UserWorkoutProperty
                                {
                                    Id = new Guid("47a8b73e-fcda-430a-8df8-da752819b8b4"),
                                    Property = properties[5],
                                    Value = 2
                                }
                            }
                        }
                    }
                });
        }
    }
}
