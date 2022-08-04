using System;
using System.Threading.Tasks;
using TrainMe.Data.Models;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{

    public interface IProgramService
    {
        Task Create(Program program);

        Task Update(Program program);

        Program GetById(int id);

        bool Exists(int id);

        Task Delete(int id);

        IEnumerable<Program> GetAll();

        IEnumerable<Program> GetAll(int? duration, int? difficulty, string name);
    }
}