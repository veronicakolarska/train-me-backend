using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public class ExerciseResourceService : IExerciseResourceService
    {
        private readonly IRepository<ExerciseResource> exerciseResourceRepository;

        public ExerciseResourceService(
           IRepository<ExerciseResource> exerciseResourceRepository
       )
        {
            this.exerciseResourceRepository = exerciseResourceRepository;
        }

        public async Task Create(ExerciseResource exerciseResource)
        {
            await this.exerciseResourceRepository.AddAsync(exerciseResource);
            await this.exerciseResourceRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exerciseResource = this.GetById(id);
            this.exerciseResourceRepository.Delete(exerciseResource);
            await this.exerciseResourceRepository.SaveChangesAsync();
        }

        public bool Exists(int exerciseId)
        {
            return this.exerciseResourceRepository.All().Any((x) => x.ExerciseId == exerciseId);
        }

        public IEnumerable<ExerciseResource> GetAll()
        {
            var exerciseResource = this.exerciseResourceRepository.All();
            return exerciseResource;
        }

        public ExerciseResource GetById(int exerciseId)
        {
            return this.GetAll().First((x) => x.ExerciseId == exerciseId);
        }

        public async Task Update(ExerciseResource exerciseResource)
        {
            this.exerciseResourceRepository.Update(exerciseResource);
            await this.exerciseResourceRepository.SaveChangesAsync();
        }
    }
}