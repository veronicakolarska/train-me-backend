namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ExerciseInstanceInProgramInstanceConfiguration : IEntityTypeConfiguration<ExerciseInstanceInProgramInstance>
    {
        public void Configure(EntityTypeBuilder<ExerciseInstanceInProgramInstance> builder)
        {
            builder.HasKey((x) => new { x.ExerciseInstanceId, x.ProgramInstanceId });

            builder
                 .HasOne(x => x.ExerciseInstance)
                 .WithMany(x => x.ExerciseInstancesInProgramInstance)
                 .HasForeignKey(x => x.ExerciseInstanceId);

            builder
                 .HasOne(x => x.ProgramInstance)
                 .WithMany(x => x.ExerciseInstancesInProgramInstance)
                 .HasForeignKey(x => x.ProgramInstanceId);
        }
    }
}