namespace TrainMe.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainMe.Data.Models;

    public class ExerciseSeeder : ISeeder
    {
        public async Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Exercises.Any())
            {
                return;
            }

            var excercises = new List<Exercise>
            {
                new Exercise
                {
                    Name = "Chest Press",
                    SeriesDefault = 3,
                    BreakDefault = 20,
                    RepetitionsDefault = 10,
                },
                new Exercise
                {
                    Name = "Squats",
                    SeriesDefault = 5,
                    BreakDefault = 20,
                    RepetitionsDefault = 30,
                },
                new Exercise
                {
                    Name = "Push-ups",
                    SeriesDefault = 3,
                    BreakDefault = 20,
                    RepetitionsDefault = 10,
                },
                new Exercise
                {
                    Name = "Crunches",
                    SeriesDefault = 3,
                    BreakDefault = 10,
                    RepetitionsDefault = 30,
                },
                new Exercise
                {
                    Name = "Burpees",
                    SeriesDefault = 5,
                    BreakDefault = 30,
                    RepetitionsDefault = 15,
                },
                new Exercise
                {
                    Name = "Side planks",
                    SeriesDefault = 4,
                    BreakDefault = 20,
                    RepetitionsDefault = 60,
                },
                new Exercise
                {
                    Name = "Deadlift",
                    SeriesDefault = 4,
                    BreakDefault = 20,
                    RepetitionsDefault = 8,
                },
                new Exercise
                {
                    Name = "Mountain Climbers",
                    SeriesDefault = 6,
                    BreakDefault = 20,
                    RepetitionsDefault = 30,
                },
                new Exercise
                {
                    Name = "Lunges",
                    SeriesDefault = 3,
                    BreakDefault = 20,
                    RepetitionsDefault = 20,
                },
                new Exercise
                {
                    Name = "Bicycle crunches",
                    SeriesDefault = 4,
                    BreakDefault = 15,
                    RepetitionsDefault = 30,
                },
                new Exercise
                {
                    Name = "Bridge",
                    SeriesDefault = 1,
                    BreakDefault = 10,
                    RepetitionsDefault = 5,
                },
                new Exercise
                {
                    Name = "Running",
                    SeriesDefault = 3,
                    BreakDefault = 60,
                    RepetitionsDefault = 120,
                },
                new Exercise
                {
                    Name = "Cycling",
                    SeriesDefault = 3,
                    BreakDefault = 60,
                    RepetitionsDefault = 100,
                },
            };

            await dbContext.Exercises.AddRangeAsync(excercises);
        }
    }
}
