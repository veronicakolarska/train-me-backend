namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ExerciseInProgramConfiguration : IEntityTypeConfiguration<ExerciseInProgram>
    {
        public void Configure(EntityTypeBuilder<ExerciseInProgram> builder)
        {
            builder.HasKey((x) => new { x.ExerciseId, x.ProgramId });

            builder
                 .HasOne(x => x.Exercise)
                 .WithMany(x => x.ExercisesInProgram)
                 .HasForeignKey(x => x.ExerciseId);

            builder
                        .HasOne(x => x.Program)
                        .WithMany(x => x.ExercisesInProgram)
                        .HasForeignKey(x => x.ProgramId);
        }
    }
}