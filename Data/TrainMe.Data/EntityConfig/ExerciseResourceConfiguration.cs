namespace TrainMe.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ExerciseResourceConfiguration : IEntityTypeConfiguration<ExerciseResource>
    {
        public void Configure(EntityTypeBuilder<ExerciseResource> builder)
        {
            builder
                 .HasKey(x => new { x.ExerciseId, x.ResourceId });
        }
    }
}