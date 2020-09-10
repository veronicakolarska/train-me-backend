using System.Threading.Tasks;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TrainMe.Services.Data
{
    public class ResourceService : IResourceService
    {
        private readonly IRepository<Resource> resourceRepository;

        public ResourceService(IRepository<Resource> resourceRepository)
        {

            this.resourceRepository = resourceRepository;
        }

        public async Task Create(Resource resource)
        {
            await this.resourceRepository.AddAsync(resource);
            await this.resourceRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var resource = this.GetById(id);
            this.resourceRepository.Delete(resource);
            await this.resourceRepository.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.resourceRepository.All().Any((x) => x.Id == id);
        }

        public IEnumerable<Resource> GetAll()
        {
            var resources = this.resourceRepository.All();
            return resources;
        }

        public Resource GetById(int id)
        {
            return this.GetAll().First((x) => x.Id == id);
        }

        public async Task Update(Resource resource)
        {
            this.resourceRepository.Update(resource);
            await this.resourceRepository.SaveChangesAsync();
        }
    }
}