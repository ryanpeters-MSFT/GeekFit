namespace GeekFit.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Unit = c.String(),
                        Order = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserWorkouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        WorkoutId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => t.WorkoutId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WorkoutId);
            
            CreateTable(
                "dbo.UserWorkoutProperties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Value = c.Decimal(precision: 18, scale: 2),
                        UserWorkout_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.UserWorkouts", t => t.UserWorkout_Id)
                .Index(t => t.PropertyId)
                .Index(t => t.UserWorkout_Id);
            
            CreateTable(
                "dbo.WorkoutProperties",
                c => new
                    {
                        Workout_Id = c.Guid(nullable: false),
                        Property_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workout_Id, t.Property_Id })
                .ForeignKey("dbo.Workouts", t => t.Workout_Id, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.Property_Id, cascadeDelete: true)
                .Index(t => t.Workout_Id)
                .Index(t => t.Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWorkouts", "WorkoutId", "dbo.Workouts");
            DropForeignKey("dbo.UserWorkouts", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserWorkoutProperties", "UserWorkout_Id", "dbo.UserWorkouts");
            DropForeignKey("dbo.UserWorkoutProperties", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.WorkoutProperties", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.WorkoutProperties", "Workout_Id", "dbo.Workouts");
            DropIndex("dbo.WorkoutProperties", new[] { "Property_Id" });
            DropIndex("dbo.WorkoutProperties", new[] { "Workout_Id" });
            DropIndex("dbo.UserWorkoutProperties", new[] { "UserWorkout_Id" });
            DropIndex("dbo.UserWorkoutProperties", new[] { "PropertyId" });
            DropIndex("dbo.UserWorkouts", new[] { "WorkoutId" });
            DropIndex("dbo.UserWorkouts", new[] { "UserId" });
            DropTable("dbo.WorkoutProperties");
            DropTable("dbo.UserWorkoutProperties");
            DropTable("dbo.UserWorkouts");
            DropTable("dbo.Users");
            DropTable("dbo.Workouts");
            DropTable("dbo.Properties");
        }
    }
}
