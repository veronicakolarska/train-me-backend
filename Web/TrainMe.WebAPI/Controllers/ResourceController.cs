using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainMe.Data.Models;
using TrainMe.Services.Data;
using TrainMe.WebAPI.Models;

namespace TrainMe.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> _logger;

        private readonly IResourceService resourceService;

        public ResourceController(
            ILogger<ResourceController> logger,
            IResourceService resourceService
        )
        {
            this._logger = logger;
            this.resourceService = resourceService;
        }

        [HttpGet]
        public IEnumerable<ResourceViewModel> GetAll()
        {
            return this.resourceService.GetAll().Select((x) => new ResourceViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Link = x.Link,
                Description = x.Description,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
            });
        }



        [HttpGet("{id}")]
        public ActionResult<ResourceViewModel> GetById(int id)
        {
            var exists = this.resourceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            var result = resourceService.GetById(id);

            var resourceViewModel = new ResourceViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Type = result.Type,
                Link = result.Link,
                Description = result.Description,
                CreatedOn = result.CreatedOn,
                ModifiedOn = result.ModifiedOn
            };
            return this.Ok(resourceViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Post(ResourceInputModel model)
        {
            var resource = new Resource
            {
                Name = model.Name,
                Type = model.Type,
                Link = model.Link,
                Description = model.Description,
            };
            await this.resourceService.Create(resource);
            return Ok();
        }

       [HttpPut]
        public ActionResult Put()
        {
            this._logger.LogInformation("Test string for put - upgrade");
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = resourceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            await this.resourceService.Delete(id);
            return this.Ok();
        }
    }
}