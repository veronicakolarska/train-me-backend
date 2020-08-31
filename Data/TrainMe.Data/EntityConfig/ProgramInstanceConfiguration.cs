namespace TrainMe.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrainMe.Data.Models;

    public class ProgramInstanceConfiguration : IEntityTypeConfiguration<ProgramInstance>
    {
        public void Configure(EntityTypeBuilder<ProgramInstance> builder)
        {
            builder
               .HasKey(x => new { x.ProgramId, x.UserId });
        }
    }
}