namespace TrainMe.Data
{
    using Microsoft.EntityFrameworkCore;
    using TrainMe.Data.Models;

    public class TrainMeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<ExerciseInstance> ExerciseInstances { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<ProgramInstance> ProgramInstances { get; set; }

        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=TrainMe;User Id=sa;Password=123456!!XX;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }
}
