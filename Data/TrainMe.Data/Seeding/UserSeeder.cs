namespace TrainMe.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainMe.Data.Models;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            await dbContext.Users.AddRangeAsync(
                new User()
                {
                    ExternalId = "auth0|62e3f5577113310aff110a53",
                    FirstName = "Super",
                    LastName = "Admin",
                }, new User()
                {
                    ExternalId = "auth0|62e54e0fdd4704857261a0fb",
                    FirstName = "User",
                    LastName = "User",
                }, new User()
                {
                    ExternalId = "auth0|62e54e6bb31074ce848ae860",
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                });
        }
    }
}
