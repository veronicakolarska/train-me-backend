namespace TrainMe.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider);
    }
}
