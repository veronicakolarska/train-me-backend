using System;
using System.Threading.Tasks;
using TrainMe.Data.Models;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public interface IExerciseResourceService
    {
        Task Create(ExerciseResource exerciseResource);

        Task Update(ExerciseResource exerciseResource);

        ExerciseResource GetById(int id);

        bool Exists(int id);

        Task Delete(int id);

        IEnumerable<ExerciseResource> GetAll();
    }
}