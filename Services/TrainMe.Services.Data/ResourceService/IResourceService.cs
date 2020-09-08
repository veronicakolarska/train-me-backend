using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainMe.Data.Models;

namespace TrainMe.Services.Data
{
    public interface IResourceService
    {
        Task Create(Resource resource);

        void Update(Resource resource);

        Resource GetById(int id);

        bool Exists(int id);

        void Delete(int id);

        IEnumerable<Resource> GetAll();
    }
}
