namespace TrainMe.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder
                    .HasMany(x => x.ExerciseResources)
                    .WithOne(x => x.Resource)
                    .HasForeignKey(x => x.ResourceId);
        }
    }
}