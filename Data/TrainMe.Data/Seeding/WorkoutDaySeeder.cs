namespace TrainMe.Data.Seeding
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainMe.Data.Models;

    public class WorkoutDaySeeder : ISeeder
    {
        public async Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.WorkoutDay.Any())
            {
                return;
            }

            var programs = await dbContext.Programs.ToListAsync();

            var basicProgram = programs.FirstOrDefault(x => x.Name == "Basic Training");
            var intermediateProgram = programs.FirstOrDefault(x => x.Name == "Intermediate Training");
            var intensiveProgram = programs.FirstOrDefault(x => x.Name == "Intensive Training");
            var easyProgram = programs.FirstOrDefault(x => x.Name == "Easy Training");
            var cardioProgram = programs.FirstOrDefault(x => x.Name == "Cardio Training");
            var weightProgram = programs.FirstOrDefault(x => x.Name == "Weight Training");
            var mobilityProgram = programs.FirstOrDefault(x => x.Name == "Mobility Training");
            var flexibilityProgram = programs.FirstOrDefault(x => x.Name == "Flexibility Training");
            var circuitProgram = programs.FirstOrDefault(x => x.Name == "Circuit Training");

            await dbContext.WorkoutDay.AddRangeAsync(
              new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = true,
                  ProgramId = basicProgram.Id,
              },
              new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = false,
                  ProgramId = basicProgram.Id,
              }, new WorkoutDay
              {
                  Order = 3,
                  IsRestDay = true,
                  ProgramId = basicProgram.Id,
              }, new WorkoutDay
              {
                  Order = 4,
                  IsRestDay = true,
                  ProgramId = basicProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = intermediateProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = intermediateProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = intensiveProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = intensiveProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = easyProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = easyProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = cardioProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = cardioProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = weightProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = weightProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = mobilityProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = mobilityProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = flexibilityProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = flexibilityProgram.Id,
              }, new WorkoutDay
              {
                  Order = 1,
                  IsRestDay = false,
                  ProgramId = circuitProgram.Id,
              }, new WorkoutDay
              {
                  Order = 2,
                  IsRestDay = true,
                  ProgramId = circuitProgram.Id,
              }, new WorkoutDay
              {
                  Order = 3,
                  IsRestDay = true,
                  ProgramId = circuitProgram.Id,
              }, new WorkoutDay
              {
                  Order = 4,
                  IsRestDay = false,
                  ProgramId = circuitProgram.Id,
              });
        }
    }
}