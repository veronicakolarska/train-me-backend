namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ProgramInstanceConfiguration : IEntityTypeConfiguration<ProgramInstance>
    {
        public void Configure(EntityTypeBuilder<ProgramInstance> builder)
        {
            builder.HasMany(x => x.WorkoutDayInstances)
                .WithOne(x => x.ProgramInstance)
                .HasForeignKey(x => x.ProgramInstanceId);
        }
    }
}