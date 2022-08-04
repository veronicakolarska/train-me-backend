using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainMe.Data.Models;

namespace TrainMe.Services.Data
{
    public interface IProgramInstanceService
    {
        Task<ProgramInstance> EnrollInProgram(int programId, string externalUserId);

        Task<bool> Exists(int programId, string externalUserId);

        Task Create(ProgramInstance programInstance);

        Task Update(ProgramInstance programInstance);

        ProgramInstance GetById(int id);

        bool Exists(int id);

        Task Delete(int id);

        IEnumerable<ProgramInstance> GetAll();
    }
}
