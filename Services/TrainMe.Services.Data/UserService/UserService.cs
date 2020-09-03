using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(
            IRepository<User> userRepository
        )
        {
            this.userRepository = userRepository;
        }

        public Task Create(User user)
        {
            return this.userRepository.AddAsync(user);
        }

        public void Delete(int id)
        {
            var user = this.GetById(id);
            this.userRepository.Delete(user);
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

        public User GetById(int id)
        {
            return this.GetAll().First((x) => x.Id == id);
        }

        public void Update(User user)
        {
            this.userRepository.Update(user);
        }
    }
}