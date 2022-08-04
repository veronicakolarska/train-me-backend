namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ExerciseInstanceInWorkoutDayInstanceConfiguration : IEntityTypeConfiguration<ExerciseInstanceInWorkoutDayInstance>
    {
        public void Configure(EntityTypeBuilder<ExerciseInstanceInWorkoutDayInstance> builder)
        {
            builder.HasKey((x) => new { x.ExerciseInstanceId, x.WorkoutDayInstanceId });

            builder
                 .HasOne(x => x.ExerciseInstance)
                 .WithMany(x => x.ExerciseInstancesInProgramInstance)
                 .HasForeignKey(x => x.ExerciseInstanceId);

            builder
                 .HasOne(x => x.WorkoutDayInstance)
                 .WithMany(x => x.ExerciseInstancesInWorkoutDayInstances)
                 .HasForeignKey(x => x.WorkoutDayInstanceId);
        }
    }
}