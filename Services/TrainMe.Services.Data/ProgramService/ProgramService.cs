using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using TrainMe.Data.Common.Enums;
using Microsoft.EntityFrameworkCore;

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

        public async Task Create(Program program)
        {
            await this.programRepository.AddAsync(program);
            await this.programRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var program = this.GetById(id);
            this.programRepository.Delete(program);
            await this.programRepository.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.programRepository.All().Any((x) => x.Id == id);
        }

        public IEnumerable<Program> GetAll()
        {
            return this.programRepository
                .All()
                .Include(x => x.ProgramInstances)
                .ThenInclude(x => x.User)
                .AsQueryable();
        }

        public IEnumerable<Program> GetAll(int? duration, int? difficulty, string name)
        {
            var allprograms = this.programRepository.All()
                .Include(program => program.WorkoutDays)
                .AsQueryable();

            if (duration.HasValue)
            {
                allprograms = allprograms.Where(program => program.WorkoutDays.Count == duration);
            }

            if (difficulty != null)
            {
                allprograms = allprograms.Where(program => (int)program.Difficulty == difficulty);
            }

            if (name != null)
            {
                allprograms = allprograms.Where(program => program.Name.ToLower().Contains(name.ToLower()));
            }

            return allprograms;
        }

        public Program GetById(int id)
        {
            return this.GetAll().FirstOrDefault((x) => x.Id == id);
        }

        public async Task Update(Program program)
        {
            this.programRepository.Update(program);
            await this.programRepository.SaveChangesAsync();
        }
    }
}
