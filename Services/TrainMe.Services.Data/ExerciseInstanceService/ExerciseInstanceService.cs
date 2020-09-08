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
        public Task Create(ExerciseInstance exerciseInstance)
        {
            throw new NotImplementedException();
        }

        public Task CreateNewInstance(Exercise exercise, User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseInstance> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExerciseInstance GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ExerciseInstance exerciseInstance)
        {
            throw new NotImplementedException();
        }
    }
}