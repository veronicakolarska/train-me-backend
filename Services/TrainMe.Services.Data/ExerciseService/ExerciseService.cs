using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public class ExerciseService : IExerciseService
    {
        private readonly IRepository<Exercise> exerciseRepository;

        public ExerciseService(
            IRepository<Exercise> exerciseRepository
        )
        {
            this.exerciseRepository = exerciseRepository;
        }

        public async Task Create(Exercise exercise)
        {
            await this.exerciseRepository.AddAsync(exercise);
            await this.exerciseRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exercise = this.GetById(id);
            this.exerciseRepository.Delete(exercise);
            await this.exerciseRepository.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.exerciseRepository.All().Any((x) => x.Id == id);
        }

        public IEnumerable<Exercise> GetAll()
        {
            var exercise = this.exerciseRepository.All();
            return exercise;
        }

        public Exercise GetById(int id)
        {
            return this.GetAll().First((x) => x.Id == id);
        }

        public async Task Update(Exercise exercise)
        {
            this.exerciseRepository.Update(exercise);
            await this.exerciseRepository.SaveChangesAsync();
        }
    }
}