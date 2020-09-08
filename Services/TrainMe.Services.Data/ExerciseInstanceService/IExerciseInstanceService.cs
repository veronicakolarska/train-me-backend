using System;
using System.Threading.Tasks;
using TrainMe.Data.Models;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public interface IExerciseInstanceService
    {
        Task CreateNewInstance(Exercise exercise, User user);

        Task Create(ExerciseInstance exerciseInstance);

        Task Update(ExerciseInstance exerciseInstance);

        ExerciseInstance GetById(int id);

        bool Exists(int id);

        Task Delete(int id);

        IEnumerable<ExerciseInstance> GetAll();
    }
}