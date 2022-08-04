namespace TrainMe.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainMe.Common;
    using TrainMe.Data.Models;

    public class ResourceSeeder : ISeeder
    {
        public async Task SeedAsync(TrainMeContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Resources.Any())
            {
                return;
            }

            await dbContext.Resources.AddRangeAsync(
               new Resource { Name = "Chest Press", Description = "Chest Press", Type = ResourceType.Picture, Link = "https://www.tradeinn.com/f/13796/137961910/gymstick-hex-dumbbell-8-kg-unit.jpg" },
               new Resource { Name = "Squats", Description = "Squats", Type = ResourceType.Picture, Link = "https://post.healthline.com/wp-content/uploads/2019/03/Female_Squat_Studio_732x549-thumbnail-2.jpg" },
               new Resource { Name = "Push-ups", Description = "Push-ups", Type = ResourceType.Picture, Link = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/whm010120feafitnesschallenge-011-1574792492.jpg" },
               new Resource { Name = "Crunches", Description = "Crunches", Type = ResourceType.Picture, Link = "https://i.ytimg.com/vi/Xyd_fa5zoEU/maxresdefault.jpg" },
               new Resource { Name = "Burpees", Description = "Burpees", Type = ResourceType.Picture, Link = "https://i.ytimg.com/vi/qLBImHhCXSw/maxresdefault.jpg" },
               new Resource { Name = "Side planks", Description = "Side planks", Type = ResourceType.Picture, Link = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/side-plank-1549646915.jpg" },
               new Resource { Name = "Deadlift", Description = "Deadlift", Type = ResourceType.Picture, Link = "https://cdn.mos.cms.futurecdn.net/gr4n9czpVacSitH3qv4rKE.jpg" },
               new Resource { Name = "Mountain Climbers", Description = "Mountain Climbers", Type = ResourceType.Picture, Link = "https://cdn.mos.cms.futurecdn.net/JDdefEyTSFj9kt5QvjZqtB.jpg" },
               new Resource { Name = "Lunges", Description = "Lunges", Type = ResourceType.Picture, Link = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/reverse-lunges-1544222100.jpg" },
               new Resource { Name = "Bicycle crunches", Description = "Bicycle crunches", Type = ResourceType.Picture, Link = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/bicycle-crunch-1548880579.jpg" },
               new Resource { Name = "Bridge", Description = "Bridge", Type = ResourceType.Picture, Link = "https://i0.wp.com/post.greatist.com/wp-content/uploads/sites/2/2020/06/GRT_Bridge_Pose_Yoga-1296x728-HEader.jpg" },
               new Resource { Name = "Running", Description = "Running", Type = ResourceType.Picture, Link = "https://st4.depositphotos.com/1724915/31436/v/1600/depositphotos_314364640-stock-illustration-woman-run-exercise-cartoon-shape.jpg" },
               new Resource { Name = "Cycling", Description = "Cycling", Type = ResourceType.Picture, Link = "https://www.shape.com/thmb/Am96ZE28UKTvdFFLMGlNiDipthU=/1404x1053/smart/filters:no_upscale():focal(599x293:601x295)/spinning-fb-2000-0360ca8272ca47d7baada8af8e5616bb.jpg" });
        }
    }
}
