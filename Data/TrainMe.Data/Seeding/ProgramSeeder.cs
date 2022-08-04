namespace TrainMe.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TrainMe.Data.Common.Enums;
    using TrainMe.Data.Models;

    public class ProgramSeeder : ISeeder
    {
        public async Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Programs.Any())
            {
                return;
            }

            var adminUser = await dbContext.Users.FirstOrDefaultAsync(x => x.ExternalId == "auth0|62e3f5577113310aff110a53");
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.ExternalId == "auth0|62e54e0fdd4704857261a0fb");
            var user2 = await dbContext.Users.FirstOrDefaultAsync(x => x.ExternalId == "auth0|62e54e6bb31074ce848ae860");

            if (adminUser == null)
            {
                return;
            }

            await dbContext.Programs.AddRangeAsync(
                new Program
                {
                    Name = "Basic Training",
                    Description = "A basic training program for beginners",
                    CreatorId = adminUser.Id,
                    Difficulty = DifficultyLevel.Easy,
                }, new Program
                {
                    Name = "Intermediate Training",
                    Description = "An intermediate training program",
                    CreatorId = adminUser.Id,
                    Difficulty = DifficultyLevel.Intermediate,
                }, new Program
                {
                    Name = "Intensive Training",
                    Description = "An intensive training program",
                    CreatorId = adminUser.Id,
                    Difficulty = DifficultyLevel.Challenging,
                }, new Program
                {
                    Name = "Easy Training",
                    Description = "An easy training program for beginners",
                    CreatorId = user.Id,
                }, new Program
                {
                    Name = "Cardio Training",
                    Description = "An easy cardio training program",
                    CreatorId = user.Id,
                    Difficulty = DifficultyLevel.Easy,
                }, new Program
                {
                    Name = "Weight Training",
                    Description = "A weight training program",
                    CreatorId = user.Id,
                    Difficulty = DifficultyLevel.Difficult,
                }, new Program
                {
                    Name = "Mobility Training",
                    Description = "A mobility training program",
                    CreatorId = user.Id,
                    Difficulty = DifficultyLevel.Challenging,
                }, new Program
                {
                    Name = "Flexibility Training",
                    Description = "A flexibility training program",
                    CreatorId = user2.Id,
                    Difficulty = DifficultyLevel.Easy,
                }, new Program
                {
                    Name = "Circuit Training",
                    Description = "A circuit training program",
                    CreatorId = user2.Id,
                    Difficulty = DifficultyLevel.Difficult,
                });
        }
    }
}
