namespace TrainMe.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ExerciseInstanceConfiguration : IEntityTypeConfiguration<ExerciseInstance>
    {
        public void Configure(EntityTypeBuilder<ExerciseInstance> builder)
        {
            builder
                    .HasOne(x => x.Exercise)
                    .WithMany(x => x.ExerciseInstances)
                    .HasForeignKey(x => x.ExerciseId);
        }
    }
}