namespace TrainMe.Data
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TrainMe.Data.Models;
    using System.Linq;
    using TrainMe.Data.EntityConfig;

    public class TrainMeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<ExerciseInstance> ExerciseInstances { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<ProgramInstance> ProgramInstances { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ExerciseResource> ExerciseResources { get; set; }

        public DbSet<ExerciseInProgram> ExercisesInPrograms { get; set; }

        public DbSet<ExerciseInstanceInProgramInstance> ExerciseInstancesInProgramInstances { get; set; }

        public TrainMeContext() { }

        public TrainMeContext(DbContextOptions<TrainMeContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramInstanceConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseResourceConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseInProgramConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseInstanceInProgramInstanceConfiguration());

            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            // var deletableEntityTypes = entityTypes
            //     .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            // foreach (var deletableEntityType in deletableEntityTypes)
            // {
            //     var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
            //     method.Invoke(null, new object[] { modelBuilder });
            // }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public override int SaveChanges() => this.SaveChanges(true);
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);
        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is AuditableEntity &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (AuditableEntity)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}