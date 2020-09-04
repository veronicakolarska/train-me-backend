using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<Program> programRepository;

        public ProgramService(
            IRepository<Program> programRepository
        )
        {
            this.programRepository = programRepository;
        }

        public Task Create(Program program)
        {
            return this.programRepository.AddAsync(program);
        }

        public void Delete(int id)
        {
            var program = this.GetById(id);
            this.programRepository.Delete(program);
        }

        public bool Exists(int id)
        {
            return this.programRepository.All().Any((x) => x.Id == id);
        }

        public IEnumerable<Program> GetAll()
        {
            var program = this.programRepository.All();
            return program;
        }

        public Program GetById(int id)
        {
            return this.GetAll().First((x) => x.Id == id);
        }

        public void Update(Program program)
        {
            this.programRepository.Update(program);
        }
    }
}