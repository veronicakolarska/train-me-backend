namespace TrainMe.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder
                    .HasMany(x => x.ProgramInstances)
                    .WithOne(x => x.Program)
                    .HasForeignKey(x => x.ProgramId);

            builder
                    .HasMany(x => x.ExercisesInProgram)
                    .WithOne(x => x.Program)
                    .HasForeignKey(x => x.ProgramId);
        }
    }
}