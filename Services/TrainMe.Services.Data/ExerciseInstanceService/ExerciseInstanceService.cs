using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public class ExerciseInstanceService : IExerciseInstanceService
    {
        private readonly IRepository<ExerciseInstance> exerciseInstanceRepository;
        private readonly IRepository<Exercise> exerciseRepository;
        private readonly IRepository<User> userRepository;

        public ExerciseInstanceService(IRepository<Exercise> exerciseRepository,
            IRepository<User> userRepository,
            IRepository<ExerciseInstance> exerciseInstanceRepository)
        {
            this.exerciseRepository = exerciseRepository;
            this.userRepository = userRepository;
            this.exerciseInstanceRepository = exerciseInstanceRepository;
        }

        public Task Create(ExerciseInstance exerciseInstance)
        {
            return this.exerciseInstanceRepository.AddAsync(exerciseInstance);
        }

        public async Task CreateNewInstance(Exercise exercise, User user)
        {
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise), "Exercise cannot be null.");
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            var userExists = this.userRepository.All().Any((x) => x.Id == user.Id);
            if (!userExists)
            {
                throw new ArgumentException("User does not exist in the database.");
            }

            var exerciseExists = this.exerciseRepository.All().Any((x) => x.Id == exercise.Id);
            if (!exerciseExists)
            {
                throw new ArgumentException("Exercise does not exist in the database.");
            }

            // TODO: Create ExerciseInstance
            //    var newExerciseInstances = exercise.Select((x) => new ExerciseInstance()
            // {
            //     ExerciseId = x.Id,
            //     Tempo = x.TempoDefault,
            //     Break = x.BreakDefault,
            //     Series = x.SeriesDefault,
            // }).ToList();

            // await this.exerciseInstanceRepository.AddAsync(newExerciseInstances);
            await this.exerciseInstanceRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exerciseInstance = this.GetById(id);
            this.exerciseInstanceRepository.Delete(exerciseInstance);
            await this.exerciseInstanceRepository.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.exerciseInstanceRepository.All().Any((x) => x.Id == id);
        }

        public IEnumerable<ExerciseInstance> GetAll()
        {
            var exerciseInstance = this.exerciseInstanceRepository.All();
            return exerciseInstance;
        }

        public ExerciseInstance GetById(int id)
        {
            return this.GetAll().First((x) => x.Id == id);
        }

        public async Task Update(ExerciseInstance exerciseInstance)
        {
            this.exerciseInstanceRepository.Update(exerciseInstance);
            await this.exerciseInstanceRepository.SaveChangesAsync();
        }
    }
}