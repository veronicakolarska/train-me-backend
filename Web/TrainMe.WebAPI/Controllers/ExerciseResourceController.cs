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
    [ApiController]
    [Route("[controller]")]
    public class ExerciseResourceController : ControllerBase
    {
        private readonly ILogger<ExerciseResourceController> _logger;
        private readonly IExerciseResourceService exerciseResourceService;

        public ExerciseResourceController(
            ILogger<ExerciseResourceController> logger,
            IExerciseResourceService exerciseResourceService
        )
        {
            _logger = logger;
            this.exerciseResourceService = exerciseResourceService;
        }

        [HttpGet]
        public IEnumerable<ExerciseResourceViewModel> GetAll()
        {
            return this.exerciseResourceService.GetAll().Select((x) => new ExerciseResourceViewModel
            {
                ExerciseId = x.ExerciseId,
                ResourceId = x.ResourceId,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ExerciseResourceViewModel> GetById(int id)
        {
            var exists = this.exerciseResourceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            var result = exerciseResourceService.GetById(id);


            var exerciseResourceViewModel = new ExerciseResourceViewModel
            {
                ExerciseId = result.ExerciseId,
                ResourceId = result.ResourceId,
                CreatedOn = result.CreatedOn,
                ModifiedOn = result.ModifiedOn
            };
            return this.Ok(exerciseResourceViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Post(ExerciseResourceInputModel model)
        {
            var exerciseResource = new ExerciseResource
            {
                ExerciseId = model.ExerciseId,
                ResourceId = model.ResourceId
            };
            await this.exerciseResourceService.Create(exerciseResource);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = exerciseResourceService.Exists(id);
            if (!exists)
            {
                return this.NotFound();
            }
            await this.exerciseResourceService.Delete(id);
            return this.Ok();
        }
    }
}