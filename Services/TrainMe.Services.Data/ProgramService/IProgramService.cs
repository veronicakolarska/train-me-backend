using System;
using System.Threading.Tasks;
using TrainMe.Data.Models;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{

    public interface IProgramService
    {
        Task Create(Program program);

        void Update(Program program);

        Program GetById(int id);

        bool Exists(int id);

        void Delete(int id);

        IEnumerable<Program> GetAll();
    }
}