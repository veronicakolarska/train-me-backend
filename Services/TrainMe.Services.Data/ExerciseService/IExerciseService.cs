using System;
using System.Threading.Tasks;
using TrainMe.Data.Models;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public interface IExerciseService
    {
        Task Create(Exercise exercise);

        Task Update(Exercise exercise);

        Exercise GetById(int id);

        bool Exists(int id);

        Task Delete(int id);

        IEnumerable<Exercise> GetAll();
    }
}