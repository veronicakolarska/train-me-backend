namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasMany(x => x.ExerciseResources)
                .WithOne(x => x.Exercise)
                .HasForeignKey(x => x.ExerciseId);

            builder
                .HasMany(x => x.ExercisesInProgram)
                .WithOne(x => x.Exercise)
                .HasForeignKey(x => x.ExerciseId);
        }
    }
}