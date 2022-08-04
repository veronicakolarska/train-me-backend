namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ExerciseInWorkoutDayConfiguration : IEntityTypeConfiguration<ExerciseInWorkoutDay>
    {
        public void Configure(EntityTypeBuilder<ExerciseInWorkoutDay> builder)
        {
            builder.HasKey((x) => new { x.ExerciseId, x.WorkoutDayId });

            builder
                 .HasOne(x => x.Exercise)
                 .WithMany(x => x.ExercisesInProgram)
                 .HasForeignKey(x => x.ExerciseId);

            builder
                        .HasOne(x => x.WorkoutDay)
                        .WithMany(x => x.ExercisesInWorkoutDay)
                        .HasForeignKey(x => x.WorkoutDayId);
        }
    }
}