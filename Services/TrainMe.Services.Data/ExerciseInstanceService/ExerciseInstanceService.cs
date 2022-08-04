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

        public ExerciseInstanceService(IRepository<Exercise> exerciseRepository,
            IRepository<ExerciseInstance> exerciseInstanceRepository)
        {
            this.exerciseRepository = exerciseRepository;
            this.exerciseInstanceRepository = exerciseInstanceRepository;
        }

        public async Task Create(ExerciseInstance exerciseInstance)
        {
            await this.exerciseInstanceRepository.AddAsync(exerciseInstance);
            await this.exerciseInstanceRepository.SaveChangesAsync();
        }

        public async Task CreateNewInstance(Program program)
        {
            // TODO: Create new ExerciseInstance from ProgramInstance
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
            return this.GetAll().FirstOrDefault((x) => x.Id == id);
        }

        public async Task Update(ExerciseInstance exerciseInstance)
        {
            this.exerciseInstanceRepository.Update(exerciseInstance);
            await this.exerciseInstanceRepository.SaveChangesAsync();
        }
    }
}