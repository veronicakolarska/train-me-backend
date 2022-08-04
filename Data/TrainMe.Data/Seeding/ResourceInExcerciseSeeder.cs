namespace TrainMe.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainMe.Data.Models;

    public class ResourceInExcerciseSeeder : ISeeder
    {
        public async Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ExerciseResources.Any())
            {
                return;
            }

            var resources = dbContext.Resources.ToList();
            var chestPressResource = resources.FirstOrDefault(r => r.Name == "Chest Press");
            var squatsResource = resources.FirstOrDefault(r => r.Name == "Squats");
            var pushUpResource = resources.FirstOrDefault(r => r.Name == "Push-ups");
            var crunchesResource = resources.FirstOrDefault(r => r.Name == "Crunches");
            var burpeeResource = resources.FirstOrDefault(r => r.Name == "Burpees");
            var sidePlanksResource = resources.FirstOrDefault(r => r.Name == "Side planks");
            var deadLiftResource = resources.FirstOrDefault(r => r.Name == "Deadlift");
            var mountainClimbersResource = resources.FirstOrDefault(r => r.Name == "Mountain Climbers");
            var lungesResource = resources.FirstOrDefault(r => r.Name == "Lunges");
            var bridgeResource = resources.FirstOrDefault(r => r.Name == "Bridge");
            var runningResource = resources.FirstOrDefault(r => r.Name == "Running");
            var cyclingResource = resources.FirstOrDefault(r => r.Name == "Cycling");

            var exercises = dbContext.Exercises.ToList();
            var chestPress = exercises.FirstOrDefault(r => r.Name == "Chest Press");
            var squats = exercises.FirstOrDefault(r => r.Name == "Squats");
            var pushUp = exercises.FirstOrDefault(r => r.Name == "Push-ups");
            var crunches = exercises.FirstOrDefault(r => r.Name == "Crunches");
            var burpee = exercises.FirstOrDefault(r => r.Name == "Burpees");
            var sidePlanks = exercises.FirstOrDefault(r => r.Name == "Side planks");
            var deadLift = exercises.FirstOrDefault(r => r.Name == "Deadlift");
            var mountainClimbers = exercises.FirstOrDefault(r => r.Name == "Mountain Climbers");
            var lunges = exercises.FirstOrDefault(r => r.Name == "Lunges");
            var bridge = exercises.FirstOrDefault(r => r.Name == "Bridge");
            var running = exercises.FirstOrDefault(r => r.Name == "Running");
            var cycling = exercises.FirstOrDefault(r => r.Name == "Cycling");

            await dbContext.ExerciseResources.AddRangeAsync(
           new ExerciseResource { ExerciseId = chestPress.Id, ResourceId = chestPressResource.Id },
           new ExerciseResource { ExerciseId = squats.Id, ResourceId = squatsResource.Id },
           new ExerciseResource { ExerciseId = pushUp.Id, ResourceId = pushUpResource.Id },
           new ExerciseResource { ExerciseId = crunches.Id, ResourceId = crunchesResource.Id },
           new ExerciseResource { ExerciseId = burpee.Id, ResourceId = burpeeResource.Id },
           new ExerciseResource { ExerciseId = sidePlanks.Id, ResourceId = sidePlanksResource.Id },
           new ExerciseResource { ExerciseId = deadLift.Id, ResourceId = deadLiftResource.Id },
           new ExerciseResource { ExerciseId = mountainClimbers.Id, ResourceId = mountainClimbersResource.Id },
           new ExerciseResource { ExerciseId = lunges.Id, ResourceId = lungesResource.Id },
           new ExerciseResource { ExerciseId = bridge.Id, ResourceId = bridgeResource.Id },
           new ExerciseResource { ExerciseId = running.Id, ResourceId = runningResource.Id },
           new ExerciseResource { ExerciseId = cycling.Id, ResourceId = cyclingResource.Id });
        }
    }
}
