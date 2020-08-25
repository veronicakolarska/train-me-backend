using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainMe.Data.Models;

namespace TrainMe.Services.Data
{
    public interface IProgramService
    {
        IEnumerable<Program> GetAll();

        Task AddAsync(Program model);
    }
}
