using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;

namespace TrainMe.Services.Data
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<Program> programsRepository;

        public ProgramService(IRepository<Program> programsRepository)
        {
            this.programsRepository = programsRepository;
        }

        public Task AddAsync(Program model)
        {
            return this.AddAsync(model);
        }

        public IEnumerable<Program> GetAll()
        {
            return this.programsRepository.All().ToList();
        }
    }
}
