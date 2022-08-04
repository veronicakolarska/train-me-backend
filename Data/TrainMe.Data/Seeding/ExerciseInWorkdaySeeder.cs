namespace TrainMe.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TrainMe.Data.Models;

    public class ExerciseInWorkdaySeeder : ISeeder
    {
        public async Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ExercisesInWorkoutDays.Any())
            {
                return;
            }

            var exercises = await dbContext.Exercises.ToListAsync();

            var chestPress = exercises.FirstOrDefault(x => x.Name == "Chest Press");
            var squats = exercises.FirstOrDefault(x => x.Name == "Squats");
            var pushUps = exercises.FirstOrDefault(x => x.Name == "Push-ups");
            var crunches = exercises.FirstOrDefault(x => x.Name == "Crunches");
            var burpees = exercises.FirstOrDefault(x => x.Name == "Burpees");
            var sidePlanks = exercises.FirstOrDefault(x => x.Name == "Side planks");
            var deadLift = exercises.FirstOrDefault(x => x.Name == "Deadlift");
            var mountainClimbers = exercises.FirstOrDefault(x => x.Name == "Mountain Climbers");
            var lunges = exercises.FirstOrDefault(x => x.Name == "Lunges");
            var bicycleCrunches = exercises.FirstOrDefault(x => x.Name == "Bicycle crunches");
            var bridge = exercises.FirstOrDefault(x => x.Name == "Bridge");
            var running = exercises.FirstOrDefault(x => x.Name == "Running");
            var cycling = exercises.FirstOrDefault(x => x.Name == "Cycling");

            var workoutDays = await dbContext.WorkoutDay.ToListAsync();

            foreach (var day in workoutDays)
            {
                await dbContext.ExercisesInWorkoutDays.AddRangeAsync(
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = chestPress.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = crunches.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = squats.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = sidePlanks.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = pushUps.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = burpees.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = deadLift.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = mountainClimbers.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = lunges.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = bicycleCrunches.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = bridge.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = running.Id },
                    new ExerciseInWorkoutDay { WorkoutDayId = day.Id, ExerciseId = cycling.Id });
            }
        }
    }
}