using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainMe.Data.Models;

namespace TrainMe.Services.Data
{
    public interface IProgramInstanceService
    {
        Task CreateNewInstance(Program program, User user);

        Task Create(ProgramInstance programInstance);

        void Update(ProgramInstance programInstance);

        ProgramInstance GetById(int id);

        bool Exists(int id);

        void Delete(int id);

        IEnumerable<ProgramInstance> GetAll();
    }
}
