using System;
using System.Threading.Tasks;
using TrainMe.Data.Models;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{

    public interface IUserService
    {

        Task Create(User user);

        void Update(User user);

        User GetById(int id);

        bool Exists(int id);

        void Delete(int id);

        IEnumerable<User> GetAll();
    }
}