using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainMe.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<ProgramInstance> programInstanceRepository;

        public UserService(
            IRepository<User> userRepository,
             IRepository<ProgramInstance> programInstanceRepository
        )
        {
            this.userRepository = userRepository;
            this.programInstanceRepository = programInstanceRepository;
        }

        public async Task Create(User user)
        {
            await this.userRepository.AddAsync(user);
            await this.userRepository.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.userRepository.All().Any((x) => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            var user = this.userRepository.All();
            return user;
        }

        public IEnumerable<ProgramInstance> GetAllProgramInstancesByUserId(string userId)
        {
            //var programs = this.programInstanceRepository.All().Include(x => x.User);
            var programs = this.programInstanceRepository.All().Include(x => x.Program);
            return programs.Where(x => x.User.ExternalId == userId);
        }

        public User GetById(int id)
        {
            return this.GetAll().FirstOrDefault((x) => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var user = this.GetById(id);
            this.userRepository.Delete(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }
    }
}