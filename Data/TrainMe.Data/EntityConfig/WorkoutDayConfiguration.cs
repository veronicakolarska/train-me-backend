namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class WorkoutDayConfiguration : IEntityTypeConfiguration<WorkoutDay>
    {
        public void Configure(EntityTypeBuilder<WorkoutDay> builder)
        {
            builder
                    .HasMany(x => x.WorkoutDayInstances)
                    .WithOne(x => x.WorkoutDay)
                    .HasForeignKey(x => x.WorkoutDayId);
        }
    }
}
